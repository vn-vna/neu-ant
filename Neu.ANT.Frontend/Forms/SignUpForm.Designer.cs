namespace Neu.ANT.Frontend.Forms
{
  partial class SignUpForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
      panel1 = new Panel();
      button1 = new Button();
      checkBox1 = new CheckBox();
      label4 = new Label();
      tb_ConfirmPassword = new TextBox();
      label3 = new Label();
      tb_Password = new TextBox();
      label2 = new Label();
      tb_Username = new TextBox();
      label1 = new Label();
      signupWorker = new System.ComponentModel.BackgroundWorker();
      panel1.SuspendLayout();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.Controls.Add(button1);
      panel1.Controls.Add(checkBox1);
      panel1.Controls.Add(label4);
      panel1.Controls.Add(tb_ConfirmPassword);
      panel1.Controls.Add(label3);
      panel1.Controls.Add(tb_Password);
      panel1.Controls.Add(label2);
      panel1.Controls.Add(tb_Username);
      panel1.Controls.Add(label1);
      panel1.Location = new Point(2, 104);
      panel1.Name = "panel1";
      panel1.Size = new Size(313, 300);
      panel1.TabIndex = 0;
      // 
      // button1
      // 
      button1.BackColor = Color.DarkCyan;
      button1.FlatAppearance.BorderSize = 0;
      button1.FlatStyle = FlatStyle.Flat;
      button1.ForeColor = Color.White;
      button1.Location = new Point(78, 251);
      button1.Name = "button1";
      button1.Size = new Size(157, 23);
      button1.TabIndex = 12;
      button1.Text = "Đăng ký";
      button1.UseVisualStyleBackColor = false;
      button1.Click += button1_Click;
      // 
      // checkBox1
      // 
      checkBox1.Location = new Point(26, 217);
      checkBox1.Name = "checkBox1";
      checkBox1.Size = new Size(260, 28);
      checkBox1.TabIndex = 11;
      checkBox1.Text = "Tôi đồng ý với điều khoản và điệu kiện\r\n";
      checkBox1.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(26, 170);
      label4.Name = "label4";
      label4.Size = new Size(104, 15);
      label4.TabIndex = 10;
      label4.Text = "Nhập lại mật khẩu";
      // 
      // tb_ConfirmPassword
      // 
      tb_ConfirmPassword.BackColor = Color.White;
      tb_ConfirmPassword.Location = new Point(26, 188);
      tb_ConfirmPassword.Name = "tb_ConfirmPassword";
      tb_ConfirmPassword.PasswordChar = '•';
      tb_ConfirmPassword.Size = new Size(260, 23);
      tb_ConfirmPassword.TabIndex = 9;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(26, 117);
      label3.Name = "label3";
      label3.Size = new Size(57, 15);
      label3.TabIndex = 8;
      label3.Text = "Mật khẩu";
      // 
      // tb_Password
      // 
      tb_Password.BackColor = Color.White;
      tb_Password.Location = new Point(26, 135);
      tb_Password.Name = "tb_Password";
      tb_Password.PasswordChar = '•';
      tb_Password.Size = new Size(260, 23);
      tb_Password.TabIndex = 7;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(26, 66);
      label2.Name = "label2";
      label2.Size = new Size(77, 15);
      label2.TabIndex = 6;
      label2.Text = "Tên tài khoản";
      // 
      // tb_Username
      // 
      tb_Username.BackColor = Color.White;
      tb_Username.Location = new Point(26, 84);
      tb_Username.Name = "tb_Username";
      tb_Username.Size = new Size(260, 23);
      tb_Username.TabIndex = 5;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      label1.ForeColor = Color.Teal;
      label1.Location = new Point(118, 27);
      label1.Name = "label1";
      label1.Size = new Size(77, 25);
      label1.TabIndex = 0;
      label1.Text = "Đăng kí";
      // 
      // signupWorker
      // 
      signupWorker.DoWork += signupWorker_DoWork;
      // 
      // SignUpForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(316, 509);
      Controls.Add(panel1);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "SignUpForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Đăng kí tài khoản";
      Load += SignUpForm_Load;
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Label label1;
    private CheckBox checkBox1;
    private Label label4;
    private TextBox tb_ConfirmPassword;
    private Label label3;
    private TextBox tb_Password;
    private Label label2;
    private TextBox tb_Username;
    private Button button1;
    private System.ComponentModel.BackgroundWorker signupWorker;
  }
}