namespace pharmSoft
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.groupboxlogin = new System.Windows.Forms.GroupBox();
            this.txtusername = new System.Windows.Forms.ComboBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupboxlogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxlogin
            // 
            this.groupboxlogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupboxlogin.BackColor = System.Drawing.Color.Transparent;
            this.groupboxlogin.Controls.Add(this.txtusername);
            this.groupboxlogin.Controls.Add(this.btnexit);
            this.groupboxlogin.Controls.Add(this.btnok);
            this.groupboxlogin.Controls.Add(this.btnreset);
            this.groupboxlogin.Controls.Add(this.label2);
            this.groupboxlogin.Controls.Add(this.lblusername);
            this.groupboxlogin.Location = new System.Drawing.Point(46, 11);
            this.groupboxlogin.Name = "groupboxlogin";
            this.groupboxlogin.Size = new System.Drawing.Size(316, 157);
            this.groupboxlogin.TabIndex = 1;
            this.groupboxlogin.TabStop = false;
            this.groupboxlogin.Text = "Login";
            this.groupboxlogin.Visible = false;
            // 
            // txtusername
            // 
            this.txtusername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtusername.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtusername.FormattingEnabled = true;
            this.txtusername.Location = new System.Drawing.Point(128, 44);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(135, 21);
            this.txtusername.Sorted = true;
            this.txtusername.TabIndex = 5;
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnexit.Location = new System.Drawing.Point(51, 125);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 3;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnok
            // 
            this.btnok.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnok.Location = new System.Drawing.Point(226, 125);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 4;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnreset.Location = new System.Drawing.Point(128, 84);
            this.btnreset.Name = "btnreset";
            this.btnreset.PasswordChar = '*';
            this.btnreset.Size = new System.Drawing.Size(135, 20);
            this.btnreset.TabIndex = 3;
            this.btnreset.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            this.btnreset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // lblusername
            // 
            this.lblusername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(34, 31);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(55, 13);
            this.lblusername.TabIndex = 0;
            this.lblusername.Text = "Username";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(97, 171);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(201, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(423, 215);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupboxlogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupboxlogin.ResumeLayout(false);
            this.groupboxlogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupboxlogin;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.TextBox btnreset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox txtusername;


    }
}