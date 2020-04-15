using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FlowTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openDialog.DefaultExt = "txt";
            openDialog.Filter = "Text Document|*.txt";
            dataTable.Location = new Point((this.Size.Width - dataTable.Width) / 2, 20);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            inputData = new List<object[]>();
            SimplexMatrixes = new List<DataGridView>();
        }

        private List<DataGridView> SimplexMatrixes;
        private List<object[]> inputData;        

        private void button1_Click(object sender, EventArgs e)
        {
            LabelState.Text = "Исходные данные";
            DrawInitial();
        }

        private double cell(int i, int j)
        {
            return Double.Parse(dataTable.Rows[i].Cells[j].Value.ToString());
        }

        private DataGridView DrawTable<T>(T[,] data)
        {
            DataGridView table = new DataGridView();

            for (int i = 0; i < data.GetUpperBound(0) + 1; i++) // z row, basis variables
            {
                table.Columns.Add("x" + (i + 1).ToString(), "x" + (i + 1).ToString());
            }

            for (int i = 0; i < data.GetUpperBound(0) + 1; i++) // z row, basis variables
            {
                object[] row = new object[data.GetUpperBound(1) + 1];
                for (int j = 0; j < data.GetUpperBound(1) + 1; j++)
                {
                    row[j] = data[i, j];
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private DataGridView DrawSimplexTable<T>(T[,] data, int freeCount, int basisCount)
        {
            DataGridView table = new DataGridView();

            table.Columns.Add("b", "Res");

            for (int i = 0; i < basisCount + freeCount; i++) // z row, basis variables
            {
                table.Columns.Add("x" + (i + 1).ToString(), "x" + (i + 1).ToString());
            }

            table.Columns.Add("Sum", "Сумма");

            for (int i = 0; i < basisCount + 2; i++) // z row, basis variables
            {
                object[] row = new object[basisCount + freeCount + 2];
                for (int j = 0; j < basisCount + freeCount + 2; j++)
                {
                    row[j] = data[i, j];
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private DataGridView DrawSimplexTable<T>(T[][] data)
        {
            DataGridView table = new DataGridView();
            
            int count = data.GetUpperBound(0) + 1;
            int len = data[0].GetUpperBound(0) + 1;

            for (int i = 0; i < len; i++) // z row, basis variables
            {
                table.Columns.Add("col_" + (i + 1).ToString(), (i + 1).ToString());
            }

            

            for (int i = 0; i < count; i++) // z row, basis variables
            {
                object[] row = new object[len];
                for (int j = 0; j < len; j++)
                {
                    row[j] = data[i][j];
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private void addRowsFromSource(DataGridView source, ref DataGridView target)
        {
            foreach (DataGridViewRow row in source.Rows)
            {
                object[] nLine = new object[row.Cells.Count];
                int i = 0;
                foreach (DataGridViewCell c in row.Cells)
                {
                    nLine[i] = c.Value;
                    i++;
                }
                target.Rows.Add(nLine);
            }
        }

        private void DrawInitial()
        {
            dgvContainer.Controls.Clear();
            var arr = MathExtend.ListTo2DArr(inputData);

            var table = this.DrawTable(arr);

            dataTable.Columns.Clear();

            for (int i = 0; i < arr.GetUpperBound(1) + 1; i++)
                dataTable.Columns.Add("column_" + i.ToString(), (i + 1).ToString());

            addRowsFromSource(table, ref dataTable);
            dataTable.Visible = true;

            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
                dataTable.Rows[i].HeaderCell.Value = i + 1;
        }

        private void DrawAnother(int index)
        {
            DataGridView source = SimplexMatrixes[index];
            dgvContainer.Controls.Clear();
            dgvContainer.Controls.Add(source);
            
            source.Dock = DockStyle.Fill;

            source.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataTable.Visible = false;
        }

        private List<object[]> retrieveGraphFromFile(string path)
        {
            StreamReader fs = new StreamReader(path);
            List<object[]> res = new List<object[]>();
            while(!fs.EndOfStream)
            {
                string row = fs.ReadLine();
                res.Add(row.Split());
            }
            
            return res;            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.Cancel)
                return;
            try
            {
                var textGraph = retrieveGraphFromFile(openDialog.FileName);

                inputData = textGraph;
                DrawInitial();
            }
            catch (Exception ex)
            {
                string msg = "Граф подан в неверном формате!";

                if(ex.Message.Length > 0)
                {
                    msg = ex.Message;
                }

                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                return;
            }
            

            
        }

        private int[][] initial2Ddata()
        {
            int count = inputData.Count;
            int[][] matrix = new int[count][];
            int len = inputData[0].GetUpperBound(0) + 1;
            for (int i = 0; i < count; i++)
            {
                matrix[i] = new int[len];
                for (int j = 0; j < len; j++)
                    matrix[i][j] = Int32.Parse(inputData[i][j].ToString());
            }
            return matrix;
        }

        private void минимальноеОстовноеДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[][] matrix = initial2Ddata();

            Graph g = new Graph(matrix);
            var table = DrawSimplexTable(g.PrimAlgorythm().Matrix);
            this.SimplexMatrixes.Clear();
            this.SimplexMatrixes.Add(table);
            DrawAnother(0);
            LabelState.Text = "Минимальное остовное дерево";
        }

        private void кратчайшиеПутиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[][] matrix = initial2Ddata();

            Graph g = new Graph(matrix);
            var table = DrawSimplexTable(g.Floyd().Matrix);
            this.SimplexMatrixes.Clear();
            this.SimplexMatrixes.Add(table);
            DrawAnother(0);
            LabelState.Text = "Кратчайшие пути";
        }

        private void максимальныйПотокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[][] matrix = initial2Ddata();

            int count = matrix.GetUpperBound(0) + 1;

            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                    if (matrix[i][j] == Int32.MaxValue)
                        matrix[i][j] = 0;

            string title = "Максимальный поток";

            Graph g = new Graph(matrix);

            Flows.FlowAlgorythms alg = new Flows.FlowAlgorythms(g);

            Form prompt = new Form()
            {
                Width = 200,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label fromLabel = new Label() { Left = 20, Top = 20, Text = "Из" };
            TextBox from = new TextBox() { Left = 60, Top = 20, Width = 100 };
            Label textLabel = new Label() { Left = 20, Top = 50, Text = "В" };
            TextBox to = new TextBox() { Left = 60, Top = 50, Width = 100 };
            Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 160, DialogResult = DialogResult.OK };
            confirmation.Click += (sendr, evt) => { prompt.Close(); };
            prompt.Controls.Add(from);
            prompt.Controls.Add(to);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(fromLabel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            if(prompt.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int source = Int32.Parse(from.Text);
                    int target = Int32.Parse(to.Text);

                    int res = alg.FordFalkerson(source, target);

                    MessageBox.Show(res.ToString(), "Результат", MessageBoxButtons.OK);

                    LabelState.Text = title;
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверно заданы узлы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }                       

        }

        private void двудольныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[][] matrix = initial2Ddata();

            int count = matrix.GetUpperBound(0) + 1;

            for (int i = 0; i < count; i++)
            {
                int s = 0;
                for (int j = 0; j < count; j++)
                {
                    if (matrix[i][j] != 0 && matrix[i][j] != Int32.MaxValue)
                        s++;
                }
                if(s != 1)
                {
                    MessageBox.Show("Граф не является двудольным", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            MessageBox.Show("Граф двудольный!", "Ответ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void критическиеПутиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[][] matrix = initial2Ddata();

            Flows.FlowAlgorythms g = new Flows.FlowAlgorythms(new Graph(matrix));

            Tuple<int[], int[]> res = g.CriticalPath();
            string path = String.Join(", ", res.Item1);
            string time = String.Join(", ", res.Item2);

            LabelState.Text = "Критический путь: " + path + Environment.NewLine + "Старт каждой работы: " + time;
        }
    }
}
