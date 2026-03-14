namespace SistemaEletivas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnImportarExcel = new Button();
            btnProcessar = new Button();
            btnExportar = new Button();
            gridAlunos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridAlunos).BeginInit();
            SuspendLayout();
            // 
            // btnImportarExcel
            // 
            btnImportarExcel.Location = new Point(12, 71);
            btnImportarExcel.Name = "btnImportarExcel";
            btnImportarExcel.Size = new Size(117, 29);
            btnImportarExcel.TabIndex = 0;
            btnImportarExcel.Text = "Importar Excel";
            btnImportarExcel.UseVisualStyleBackColor = true;
            btnImportarExcel.Click += btnImportarExcel_Click;
            // 
            // btnProcessar
            // 
            btnProcessar.Location = new Point(585, 71);
            btnProcessar.Name = "btnProcessar";
            btnProcessar.Size = new Size(166, 29);
            btnProcessar.TabIndex = 1;
            btnProcessar.Text = "Processar Distribuição";
            btnProcessar.UseVisualStyleBackColor = true;
            btnProcessar.Click += btnProcessar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(1233, 71);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(162, 29);
            btnExportar.TabIndex = 2;
            btnExportar.Text = "Exportar Resultado";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // gridAlunos
            // 
            gridAlunos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAlunos.Location = new Point(12, 134);
            gridAlunos.Name = "gridAlunos";
            gridAlunos.RowHeadersWidth = 51;
            gridAlunos.Size = new Size(1383, 597);
            gridAlunos.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1407, 743);
            Controls.Add(gridAlunos);
            Controls.Add(btnExportar);
            Controls.Add(btnProcessar);
            Controls.Add(btnImportarExcel);
            Name = "Form1";
            Text = "Sistema de Distribuição de Eletivas";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)gridAlunos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnImportarExcel;
        private Button btnProcessar;
        private Button btnExportar;
        private DataGridView gridAlunos;
    }
}
