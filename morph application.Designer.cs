namespace DataMorphApp
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
            panel1 = new Panel();
            btnCopy = new Button();
            btnGenerar = new Button();
            label3 = new Label();
            label2 = new Label();
            txtResponseData = new TextBox();
            label1 = new Label();
            txtRequestData = new TextBox();
            cboSelectAction = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCopy);
            panel1.Controls.Add(btnGenerar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtResponseData);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtRequestData);
            panel1.Controls.Add(cboSelectAction);
            panel1.Location = new Point(5, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1142, 832);
            panel1.TabIndex = 0;
            // 
            // btnCopy
            // 
            btnCopy.BackColor = Color.YellowGreen;
            btnCopy.Location = new Point(919, 390);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(160, 29);
            btnCopy.TabIndex = 7;
            btnCopy.Text = "Copiar Respuesta";
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = SystemColors.ActiveCaption;
            btnGenerar.Location = new Point(889, 718);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(191, 29);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "Generar Datos";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 42);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 5;
            label3.Text = "Acciones:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 402);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 4;
            label2.Text = "Data Response";
            // 
            // txtResponseData
            // 
            txtResponseData.Location = new Point(36, 425);
            txtResponseData.MaxLength = 99999999;
            txtResponseData.Multiline = true;
            txtResponseData.Name = "txtResponseData";
            txtResponseData.ScrollBars = ScrollBars.Vertical;
            txtResponseData.Size = new Size(1044, 265);
            txtResponseData.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 83);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 2;
            label1.Text = "Data Request";
            // 
            // txtRequestData
            // 
            txtRequestData.Location = new Point(35, 106);
            txtRequestData.MaxLength = 999999999;
            txtRequestData.Multiline = true;
            txtRequestData.Name = "txtRequestData";
            txtRequestData.ScrollBars = ScrollBars.Vertical;
            txtRequestData.Size = new Size(1044, 265);
            txtRequestData.TabIndex = 1;
            // 
            // cboSelectAction
            // 
            cboSelectAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSelectAction.FormattingEnabled = true;
            cboSelectAction.Location = new Point(154, 39);
            cboSelectAction.Name = "cboSelectAction";
            cboSelectAction.Size = new Size(413, 28);
            cboSelectAction.TabIndex = 0;
            cboSelectAction.SelectedIndexChanged += cboSelectAction_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1151, 838);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtRequestData;
        private ComboBox cboSelectAction;
        private Label label2;
        private TextBox txtResponseData;
        private Label label1;
        private Button btnGenerar;
        private Label label3;
        private Button btnCopy;
    }
}
