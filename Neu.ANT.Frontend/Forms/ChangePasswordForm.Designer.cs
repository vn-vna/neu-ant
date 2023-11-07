namespace Neu.ANT.Frontend.Forms
{
  partial class ChangePasswordForm
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
      pn_Content = new Panel();
      panel1 = new Panel();
      lb_ConfirmPassword = new Label();
      tb_ConfirmPassword = new TextBox();
      btn_SubmitChange = new Button();
      lb_NewPassword = new Label();
      tb_NewPassword = new TextBox();
      lb_OldPassword = new Label();
      tb_OldPassword = new TextBox();
      lb_Title = new Label();
      bw_ChangePasswordRequest = new System.ComponentModel.BackgroundWorker();
      pn_Content.SuspendLayout();
      panel1.SuspendLayout();
      SuspendLayout();
      // 
      // pn_Content
      // 
      pn_Content.Controls.Add(panel1);
      pn_Content.Dock = DockStyle.Fill;
      pn_Content.Location = new Point(0, 0);
      pn_Content.Name = "pn_Content";
      pn_Content.Size = new Size(316, 509);
      pn_Content.TabIndex = 0;
      // 
      // panel1
      // 
      panel1.Controls.Add(lb_ConfirmPassword);
      panel1.Controls.Add(tb_ConfirmPassword);
      panel1.Controls.Add(btn_SubmitChange);
      panel1.Controls.Add(lb_NewPassword);
      panel1.Controls.Add(tb_NewPassword);
      panel1.Controls.Add(lb_OldPassword);
      panel1.Controls.Add(tb_OldPassword);
      panel1.Controls.Add(lb_Title);
      panel1.Location = new Point(0, 117);
      panel1.Margin = new Padding(0);
      panel1.Name = "panel1";
      panel1.Size = new Size(316, 291);
      panel1.TabIndex = 0;
      // 
      // lb_ConfirmPassword
      // 
      lb_ConfirmPassword.AutoSize = true;
      lb_ConfirmPassword.Location = new Point(26, 176);
      lb_ConfirmPassword.Name = "lb_ConfirmPassword";
      lb_ConfirmPassword.Size = new Size(109, 15);
      lb_ConfirmPassword.TabIndex = 14;
      lb_ConfirmPassword.Text = "Xác nhận mật khẩu";
      // 
      // tb_ConfirmPassword
      // 
      tb_ConfirmPassword.BackColor = Color.White;
      tb_ConfirmPassword.Location = new Point(26, 194);
      tb_ConfirmPassword.Name = "tb_ConfirmPassword";
      tb_ConfirmPassword.PasswordChar = '•';
      tb_ConfirmPassword.Size = new Size(260, 23);
      tb_ConfirmPassword.TabIndex = 13;
      // 
      // btn_SubmitChange
      // 
      btn_SubmitChange.BackColor = Color.IndianRed;
      btn_SubmitChange.Cursor = Cursors.Hand;
      btn_SubmitChange.FlatAppearance.BorderSize = 0;
      btn_SubmitChange.FlatStyle = FlatStyle.Flat;
      btn_SubmitChange.ForeColor = Color.White;
      btn_SubmitChange.Location = new Point(79, 241);
      btn_SubmitChange.Name = "btn_SubmitChange";
      btn_SubmitChange.Size = new Size(157, 23);
      btn_SubmitChange.TabIndex = 12;
      btn_SubmitChange.Text = "Xác nhận";
      btn_SubmitChange.UseVisualStyleBackColor = false;
      btn_SubmitChange.Click += btn_SubmitChange_Click;
      // 
      // lb_NewPassword
      // 
      lb_NewPassword.AutoSize = true;
      lb_NewPassword.Location = new Point(26, 124);
      lb_NewPassword.Name = "lb_NewPassword";
      lb_NewPassword.Size = new Size(81, 15);
      lb_NewPassword.TabIndex = 11;
      lb_NewPassword.Text = "Mật khẩu mới";
      // 
      // tb_NewPassword
      // 
      tb_NewPassword.BackColor = Color.White;
      tb_NewPassword.Location = new Point(26, 142);
      tb_NewPassword.Name = "tb_NewPassword";
      tb_NewPassword.PasswordChar = '•';
      tb_NewPassword.Size = new Size(260, 23);
      tb_NewPassword.TabIndex = 10;
      // 
      // lb_OldPassword
      // 
      lb_OldPassword.AutoSize = true;
      lb_OldPassword.Location = new Point(26, 73);
      lb_OldPassword.Name = "lb_OldPassword";
      lb_OldPassword.Size = new Size(73, 15);
      lb_OldPassword.TabIndex = 9;
      lb_OldPassword.Text = "Mật khẩu cũ";
      // 
      // tb_OldPassword
      // 
      tb_OldPassword.BackColor = Color.White;
      tb_OldPassword.Location = new Point(26, 91);
      tb_OldPassword.Name = "tb_OldPassword";
      tb_OldPassword.PasswordChar = '•';
      tb_OldPassword.Size = new Size(260, 23);
      tb_OldPassword.TabIndex = 8;
      // 
      // lb_Title
      // 
      lb_Title.AutoSize = true;
      lb_Title.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      lb_Title.ForeColor = Color.IndianRed;
      lb_Title.Location = new Point(71, 27);
      lb_Title.Name = "lb_Title";
      lb_Title.Size = new Size(171, 25);
      lb_Title.TabIndex = 7;
      lb_Title.Text = "Thay đổi mật khẩu";
      // 
      // bw_ChangePasswordRequest
      // 
      bw_ChangePasswordRequest.DoWork += bw_ChangePasswordRequest_DoWork;
      bw_ChangePasswordRequest.RunWorkerCompleted += bw_ChangePasswordRequest_RunWorkerCompleted;
      // 
      // ChangePasswordForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(316, 509);
      Controls.Add(pn_Content);
      Name = "ChangePasswordForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Đổi mật khẩu";
      pn_Content.ResumeLayout(false);
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Panel pn_Content;
    private Panel panel1;
    private Button btn_SubmitChange;
    private Label lb_NewPassword;
    private TextBox tb_NewPassword;
    private Label lb_OldPassword;
    private TextBox tb_OldPassword;
    private Label lb_Title;
    private Label lb_ConfirmPassword;
    private TextBox tb_ConfirmPassword;
    private System.ComponentModel.BackgroundWorker bw_ChangePasswordRequest;
  }
}