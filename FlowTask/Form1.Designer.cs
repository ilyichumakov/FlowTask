namespace FlowTask
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.theMenuStrip = new System.Windows.Forms.MenuStrip();
            this.графToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.минимальноеОстовноеДеревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кратчайшиеПутиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.максимальныйПотокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критическиеПутиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvContainer = new System.Windows.Forms.Panel();
            this.LabelState = new System.Windows.Forms.Label();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.двудольныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.theMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTable
            // 
            this.dataTable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Location = new System.Drawing.Point(12, 198);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(451, 232);
            this.dataTable.TabIndex = 0;
            // 
            // theMenuStrip
            // 
            this.theMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.графToolStripMenuItem,
            this.алгоритмыToolStripMenuItem});
            this.theMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.theMenuStrip.Name = "theMenuStrip";
            this.theMenuStrip.Size = new System.Drawing.Size(704, 24);
            this.theMenuStrip.TabIndex = 1;
            this.theMenuStrip.Text = "menuStrip1";
            // 
            // графToolStripMenuItem
            // 
            this.графToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.графToolStripMenuItem.Name = "графToolStripMenuItem";
            this.графToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.графToolStripMenuItem.Text = "Граф";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openToolStripMenuItem.Text = "Открыть...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // алгоритмыToolStripMenuItem
            // 
            this.алгоритмыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.минимальноеОстовноеДеревоToolStripMenuItem,
            this.кратчайшиеПутиToolStripMenuItem,
            this.максимальныйПотокToolStripMenuItem,
            this.критическиеПутиToolStripMenuItem,
            this.двудольныйToolStripMenuItem});
            this.алгоритмыToolStripMenuItem.Name = "алгоритмыToolStripMenuItem";
            this.алгоритмыToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.алгоритмыToolStripMenuItem.Text = "Алгоритмы";
            // 
            // минимальноеОстовноеДеревоToolStripMenuItem
            // 
            this.минимальноеОстовноеДеревоToolStripMenuItem.Name = "минимальноеОстовноеДеревоToolStripMenuItem";
            this.минимальноеОстовноеДеревоToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.минимальноеОстовноеДеревоToolStripMenuItem.Text = "Минимальное остовное дерево";
            this.минимальноеОстовноеДеревоToolStripMenuItem.Click += new System.EventHandler(this.минимальноеОстовноеДеревоToolStripMenuItem_Click);
            // 
            // кратчайшиеПутиToolStripMenuItem
            // 
            this.кратчайшиеПутиToolStripMenuItem.Name = "кратчайшиеПутиToolStripMenuItem";
            this.кратчайшиеПутиToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.кратчайшиеПутиToolStripMenuItem.Text = "Кратчайшие пути";
            this.кратчайшиеПутиToolStripMenuItem.Click += new System.EventHandler(this.кратчайшиеПутиToolStripMenuItem_Click);
            // 
            // максимальныйПотокToolStripMenuItem
            // 
            this.максимальныйПотокToolStripMenuItem.Name = "максимальныйПотокToolStripMenuItem";
            this.максимальныйПотокToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.максимальныйПотокToolStripMenuItem.Text = "Максимальный поток";
            this.максимальныйПотокToolStripMenuItem.Click += new System.EventHandler(this.максимальныйПотокToolStripMenuItem_Click);
            // 
            // критическиеПутиToolStripMenuItem
            // 
            this.критическиеПутиToolStripMenuItem.Name = "критическиеПутиToolStripMenuItem";
            this.критическиеПутиToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.критическиеПутиToolStripMenuItem.Text = "Критические пути";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Khaki;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(278, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Исходный граф";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvContainer
            // 
            this.dgvContainer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvContainer.Location = new System.Drawing.Point(118, 27);
            this.dgvContainer.Name = "dgvContainer";
            this.dgvContainer.Size = new System.Drawing.Size(496, 245);
            this.dgvContainer.TabIndex = 3;
            // 
            // LabelState
            // 
            this.LabelState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelState.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelState.Location = new System.Drawing.Point(12, 307);
            this.LabelState.Name = "LabelState";
            this.LabelState.Size = new System.Drawing.Size(680, 72);
            this.LabelState.TabIndex = 4;
            this.LabelState.Text = "Исходные данные";
            this.LabelState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // двудольныйToolStripMenuItem
            // 
            this.двудольныйToolStripMenuItem.Name = "двудольныйToolStripMenuItem";
            this.двудольныйToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.двудольныйToolStripMenuItem.Text = "Двудольный?";
            this.двудольныйToolStripMenuItem.Click += new System.EventHandler(this.двудольныйToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.LabelState);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.theMenuStrip);
            this.Controls.Add(this.dgvContainer);
            this.MainMenuStrip = this.theMenuStrip;
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Сетевое планирование";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.theMenuStrip.ResumeLayout(false);
            this.theMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.MenuStrip theMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem графToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem минимальноеОстовноеДеревоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кратчайшиеПутиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem максимальныйПотокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem критическиеПутиToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel dgvContainer;
        private System.Windows.Forms.Label LabelState;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolStripMenuItem двудольныйToolStripMenuItem;
    }
}

