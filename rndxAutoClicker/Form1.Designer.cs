namespace rndxAutoClicker
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMouseButton = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxHold = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.msInput = new System.Windows.Forms.TextBox();
            this.buttonStartMacro = new System.Windows.Forms.Button();
            this.buttonStopMacro = new System.Windows.Forms.Button();
            this.timerAutoClicker = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAssignKey = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Name = "label1";
            // 
            // comboBoxMouseButton
            // 
            this.comboBoxMouseButton.BackColor = System.Drawing.Color.White;
            this.comboBoxMouseButton.CausesValidation = false;
            this.comboBoxMouseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxMouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMouseButton.FormattingEnabled = true;
            this.comboBoxMouseButton.Items.AddRange(new object[] {
            resources.GetString("comboBoxMouseButton.Items"),
            resources.GetString("comboBoxMouseButton.Items1"),
            resources.GetString("comboBoxMouseButton.Items2")});
            resources.ApplyResources(this.comboBoxMouseButton, "comboBoxMouseButton");
            this.comboBoxMouseButton.Name = "comboBoxMouseButton";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxHold);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxMouseButton);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkBoxHold
            // 
            resources.ApplyResources(this.checkBoxHold, "checkBoxHold");
            this.checkBoxHold.ForeColor = System.Drawing.Color.White;
            this.checkBoxHold.Name = "checkBoxHold";
            this.checkBoxHold.UseVisualStyleBackColor = true;
            this.checkBoxHold.CheckedChanged += new System.EventHandler(this.checkBoxHold_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Name = "label3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.msInput);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Name = "label4";
            // 
            // msInput
            // 
            this.msInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.msInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.msInput, "msInput");
            this.msInput.ForeColor = System.Drawing.Color.White;
            this.msInput.Name = "msInput";
            // 
            // buttonStartMacro
            // 
            this.buttonStartMacro.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.buttonStartMacro, "buttonStartMacro");
            this.buttonStartMacro.Name = "buttonStartMacro";
            this.buttonStartMacro.UseVisualStyleBackColor = true;
            this.buttonStartMacro.Click += new System.EventHandler(this.buttonStartMacro_Click);
            // 
            // buttonStopMacro
            // 
            this.buttonStopMacro.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.buttonStopMacro, "buttonStopMacro");
            this.buttonStopMacro.Name = "buttonStopMacro";
            this.buttonStopMacro.UseVisualStyleBackColor = true;
            this.buttonStopMacro.Click += new System.EventHandler(this.buttonStopMacro_Click);
            // 
            // timerAutoClicker
            // 
            this.timerAutoClicker.Interval = 1000;
            this.timerAutoClicker.Tick += new System.EventHandler(this.AutoClicker_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::rndxAutoClicker.Properties.Resources.f6b8a3c5013ac8777f09b1463ead4b17;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PotatoLinkToGithub);
            // 
            // buttonAssignKey
            // 
            this.buttonAssignKey.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.buttonAssignKey, "buttonAssignKey");
            this.buttonAssignKey.Name = "buttonAssignKey";
            this.buttonAssignKey.UseVisualStyleBackColor = true;
            this.buttonAssignKey.Click += new System.EventHandler(this.buttonAssignKey_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.buttonAssignKey);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonStopMacro);
            this.Controls.Add(this.buttonStartMacro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMouseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxHold;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox msInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStartMacro;
        private System.Windows.Forms.Button buttonStopMacro;
        private System.Windows.Forms.Timer timerAutoClicker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAssignKey;
    }
}

