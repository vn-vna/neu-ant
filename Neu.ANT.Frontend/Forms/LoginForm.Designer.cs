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
      pn_LoginPanel = new Panel();
      cb_RememberPassword = new CheckBox();
      btn_SubmitLogin = new Button();
      lb_Password = new Label();
      tb_Password = new TextBox();
      lb_Username = new Label();
      tb_Username = new TextBox();
      lb_Title = new Label();
      loadingLabel = new Label();
      basePanel.SuspendLayout();
      pn_LoginPanel.SuspendLayout();
      SuspendLayout();
      // 
      // loginBackgrounWorker
      // 
      loginBackgrounWorker.DoWork += loginBackgrounWorker_DoWork;
      loginBackgrounWorker.RunWorkerCompleted += loginBackgrounWorker_RunWorkerCompleted;
      // 
      // basePanel
      // 
      basePanel.Controls.Add(pn_LoginPanel);
      basePanel.Dock = DockStyle.Fill;
      basePanel.Location = new Point(0, 0);
      basePanel.Name = "basePanel";
      basePanel.Size = new Size(316, 509);
      basePanel.TabIndex = 0;
      // 
      // pn_LoginPanel
      // 
      pn_LoginPanel.Controls.Add(cb_RememberPassword);
      pn_LoginPanel.Controls.Add(btn_SubmitLogin);
      pn_LoginPanel.Controls.Add(lb_Password);
      pn_LoginPanel.Controls.Add(tb_Password);
      pn_LoginPanel.Controls.Add(lb_Username);
      pn_LoginPanel.Controls.Add(tb_Username);
      pn_LoginPanel.Controls.Add(lb_Title);
      pn_LoginPanel.Location = new Point(1, 126);
      pn_LoginPanel.Name = "pn_LoginPanel";
      pn_LoginPanel.Size = new Size(314, 256);
      pn_LoginPanel.TabIndex = 1;
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
      btn_SubmitLogin.Click += btn_SubmitLogin_Click;
      // 
      // lb_Password
      // 
      lb_Password.AutoSize = true;
      lb_Password.Location = new Point(27, 117);
      lb_Password.Name = "lb_Password";
      lb_Password.Size = new Size(57, 15);
      lb_Password.TabIndex = 4;
      lb_Password.Text = "Mật khẩu";
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
      // lb_Username
      // 
      lb_Username.AutoSize = true;
      lb_Username.Location = new Point(27, 66);
      lb_Username.Name = "lb_Username";
      lb_Username.Size = new Size(77, 15);
      lb_Username.TabIndex = 2;
      lb_Username.Text = "Tên tài khoản";
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
      // lb_Title
      // 
      lb_Title.AutoSize = true;
      lb_Title.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      lb_Title.ForeColor = Color.Teal;
      lb_Title.Location = new Point(62, 20);
      lb_Title.Name = "lb_Title";
      lb_Title.Size = new Size(190, 25);
      lb_Title.TabIndex = 0;
      lb_Title.Text = "Đăng nhập tài khoản";
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
      pn_LoginPanel.ResumeLayout(false);
      pn_LoginPanel.PerformLayout();
      ResumeLayout(false);
    }

    #endregion
    private System.ComponentModel.BackgroundWorker loginBackgrounWorker;
    private Panel basePanel;
    private Panel pn_LoginPanel;
    private CheckBox cb_RememberPassword;
    private Button btn_SubmitLogin;
    private Label lb_Password;
    private TextBox tb_Password;
    private Label lb_Username;
    private TextBox tb_Username;
    private Label lb_Title;
    private Label loadingLabel;
  }
}