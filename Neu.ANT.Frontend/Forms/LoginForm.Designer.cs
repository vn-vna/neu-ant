namespace Neu.ANT.Frontend.Forms
{
  partial class LoginForm
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
      loginBackgrounWorker = new System.ComponentModel.BackgroundWorker();
      basePanel = new Panel();
      loadingLabel = new Label();
      loginPanel = new Panel();
      cb_RememberPassword = new CheckBox();
      btn_SubmitLogin = new Button();
      label3 = new Label();
      tb_Password = new TextBox();
      label2 = new Label();
      tb_Username = new TextBox();
      label1 = new Label();
      basePanel.SuspendLayout();
      loginPanel.SuspendLayout();
      SuspendLayout();
      // 
      // loginBackgrounWorker
      // 
      loginBackgrounWorker.DoWork += loginBackgrounWorker_DoWork;
      loginBackgrounWorker.RunWorkerCompleted += loginBackgrounWorker_RunWorkerCompleted;
      // 
      // basePanel
      // 
      basePanel.Controls.Add(loginPanel);
      basePanel.Dock = DockStyle.Fill;
      basePanel.Location = new Point(0, 0);
      basePanel.Name = "basePanel";
      basePanel.Size = new Size(316, 509);
      basePanel.TabIndex = 0;
      // 
      // loadingLabel
      // 
      loadingLabel.AutoSize = true;
      loadingLabel.ForeColor = Color.Teal;
      loadingLabel.Location = new Point(109, 67);
      loadingLabel.Name = "loadingLabel";
      loadingLabel.Size = new Size(99, 15);
      loadingLabel.TabIndex = 8;
      loadingLabel.Text = "Logging you in....";
      // 
      // loginPanel
      // 
      loginPanel.Controls.Add(cb_RememberPassword);
      loginPanel.Controls.Add(btn_SubmitLogin);
      loginPanel.Controls.Add(label3);
      loginPanel.Controls.Add(tb_Password);
      loginPanel.Controls.Add(label2);
      loginPanel.Controls.Add(tb_Username);
      loginPanel.Controls.Add(label1);
      loginPanel.Location = new Point(1, 126);
      loginPanel.Name = "loginPanel";
      loginPanel.Size = new Size(314, 256);
      loginPanel.TabIndex = 1;
      // 
      // cb_RememberPassword
      // 
      cb_RememberPassword.AutoSize = true;
      cb_RememberPassword.Location = new Point(27, 178);
      cb_RememberPassword.Name = "cb_RememberPassword";
      cb_RememberPassword.Size = new Size(102, 19);
      cb_RememberPassword.TabIndex = 7;
      cb_RememberPassword.Text = "Nhớ mật khẩu";
      cb_RememberPassword.UseVisualStyleBackColor = true;
      // 
      // btn_SubmitLogin
      // 
      btn_SubmitLogin.BackColor = Color.Teal;
      btn_SubmitLogin.FlatAppearance.BorderSize = 0;
      btn_SubmitLogin.FlatStyle = FlatStyle.Flat;
      btn_SubmitLogin.ForeColor = Color.White;
      btn_SubmitLogin.Location = new Point(79, 213);
      btn_SubmitLogin.Name = "btn_SubmitLogin";
      btn_SubmitLogin.Size = new Size(157, 23);
      btn_SubmitLogin.TabIndex = 6;
      btn_SubmitLogin.Text = "Đăng nhập";
      btn_SubmitLogin.UseVisualStyleBackColor = false;
      btn_SubmitLogin.Click += btn_SubmitLogin_Click_1;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(27, 117);
      label3.Name = "label3";
      label3.Size = new Size(57, 15);
      label3.TabIndex = 4;
      label3.Text = "Mật khẩu";
      // 
      // tb_Password
      // 
      tb_Password.BackColor = Color.White;
      tb_Password.Location = new Point(27, 135);
      tb_Password.Name = "tb_Password";
      tb_Password.PasswordChar = '•';
      tb_Password.Size = new Size(260, 23);
      tb_Password.TabIndex = 3;
      tb_Password.KeyPress += tb_Password_KeyPress;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(27, 66);
      label2.Name = "label2";
      label2.Size = new Size(77, 15);
      label2.TabIndex = 2;
      label2.Text = "Tên tài khoản";
      // 
      // tb_Username
      // 
      tb_Username.BackColor = Color.White;
      tb_Username.Location = new Point(27, 84);
      tb_Username.Name = "tb_Username";
      tb_Username.Size = new Size(260, 23);
      tb_Username.TabIndex = 1;
      tb_Username.KeyPress += tb_Username_KeyPress;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      label1.ForeColor = Color.Teal;
      label1.Location = new Point(62, 20);
      label1.Name = "label1";
      label1.Size = new Size(190, 25);
      label1.TabIndex = 0;
      label1.Text = "Đăng nhập tài khoản";
      // 
      // LoginForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(316, 509);
      Controls.Add(basePanel);
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "LoginForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Login";
      Load += LoginForm_Load;
      basePanel.ResumeLayout(false);
      basePanel.PerformLayout();
      loginPanel.ResumeLayout(false);
      loginPanel.PerformLayout();
      ResumeLayout(false);
    }

    #endregion
    private System.ComponentModel.BackgroundWorker loginBackgrounWorker;
    private Panel basePanel;
    private Panel loginPanel;
    private CheckBox cb_RememberPassword;
    private Button btn_SubmitLogin;
    private Label label3;
    private TextBox tb_Password;
    private Label label2;
    private TextBox tb_Username;
    private Label label1;
    private Label loadingLabel;
  }
}