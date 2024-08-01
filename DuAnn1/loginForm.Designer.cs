namespace DuAnn1
{
    partial class loginForm
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
            Login = new Button();
            Username = new TextBox();
            Password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // Login
            // 
            Login.Location = new Point(208, 201);
            Login.Name = "Login";
            Login.Size = new Size(127, 43);
            Login.TabIndex = 0;
            Login.Text = "Sign in";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // Username
            // 
            Username.Location = new Point(132, 73);
            Username.Name = "Username";
            Username.PlaceholderText = "Username";
            Username.Size = new Size(312, 27);
            Username.TabIndex = 1;
            // 
            // Password
            // 
            Password.Location = new Point(132, 149);
            Password.Name = "Password";
            Password.PlaceholderText = "Password";
            Password.Size = new Size(312, 27);
            Password.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 76);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 4;
            label1.Text = "TÀI KHOẢN :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 156);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 5;
            label2.Text = "MẬT KHẨU :";
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(546, 278);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(Login);
            Name = "loginForm";
            Text = "loginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Login;
        private TextBox Username;
        private TextBox Password;
        private Label label1;
        private Label label2;
    }
}