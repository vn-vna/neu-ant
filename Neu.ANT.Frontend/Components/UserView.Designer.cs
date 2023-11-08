namespace Neu.ANT.Frontend.Components
{
  partial class UserView
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      bw_LoadUserData = new System.ComponentModel.BackgroundWorker();
      pn_Content = new Panel();
      pn_DetailedInfo = new Panel();
      pn_DetailedInfoInner = new Panel();
      btn_ChangePassword = new Label();
      lb_InfoTitle = new Label();
      btn_Reset = new Button();
      btn_SaveChanges = new Button();
      panel3 = new Panel();
      rb_Undefined = new RadioButton();
      rb_Female = new RadioButton();
      rb_Male = new RadioButton();
      label6 = new Label();
      dtp_BirthDate = new DateTimePicker();
      label5 = new Label();
      tb_LastName = new TextBox();
      tb_FirstName = new TextBox();
      label4 = new Label();
      label3 = new Label();
      lb_DetailUsername = new Label();
      label1 = new Label();
      pn_Summaries = new Panel();
      pn_SummariesInner = new Panel();
      lb_LogOut = new Label();
      lb_SummaryUsername = new Label();
      lb_DisplayName = new Label();
      pictureBox1 = new PictureBox();
      bw_UpdateUserData = new System.ComponentModel.BackgroundWorker();
      pn_Content.SuspendLayout();
      pn_DetailedInfo.SuspendLayout();
      pn_DetailedInfoInner.SuspendLayout();
      panel3.SuspendLayout();
      pn_Summaries.SuspendLayout();
      pn_SummariesInner.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // bw_LoadUserData
      // 
      bw_LoadUserData.DoWork += bw_LoadUserData_DoWork;
      bw_LoadUserData.RunWorkerCompleted += bw_LoadUserData_RunWorkerCompleted;
      // 
      // pn_Content
      // 
      pn_Content.Controls.Add(pn_DetailedInfo);
      pn_Content.Controls.Add(pn_Summaries);
      pn_Content.Dock = DockStyle.Fill;
      pn_Content.Location = new Point(0, 0);
      pn_Content.Name = "pn_Content";
      pn_Content.Size = new Size(879, 555);
      pn_Content.TabIndex = 0;
      // 
      // pn_DetailedInfo
      // 
      pn_DetailedInfo.Controls.Add(pn_DetailedInfoInner);
      pn_DetailedInfo.Dock = DockStyle.Right;
      pn_DetailedInfo.Location = new Point(260, 0);
      pn_DetailedInfo.Margin = new Padding(0);
      pn_DetailedInfo.Name = "pn_DetailedInfo";
      pn_DetailedInfo.Size = new Size(619, 555);
      pn_DetailedInfo.TabIndex = 3;
      // 
      // pn_DetailedInfoInner
      // 
      pn_DetailedInfoInner.Controls.Add(btn_ChangePassword);
      pn_DetailedInfoInner.Controls.Add(lb_InfoTitle);
      pn_DetailedInfoInner.Controls.Add(btn_Reset);
      pn_DetailedInfoInner.Controls.Add(btn_SaveChanges);
      pn_DetailedInfoInner.Controls.Add(panel3);
      pn_DetailedInfoInner.Controls.Add(label6);
      pn_DetailedInfoInner.Controls.Add(dtp_BirthDate);
      pn_DetailedInfoInner.Controls.Add(label5);
      pn_DetailedInfoInner.Controls.Add(tb_LastName);
      pn_DetailedInfoInner.Controls.Add(tb_FirstName);
      pn_DetailedInfoInner.Controls.Add(label4);
      pn_DetailedInfoInner.Controls.Add(label3);
      pn_DetailedInfoInner.Controls.Add(lb_DetailUsername);
      pn_DetailedInfoInner.Controls.Add(label1);
      pn_DetailedInfoInner.Location = new Point(4, 50);
      pn_DetailedInfoInner.Name = "pn_DetailedInfoInner";
      pn_DetailedInfoInner.Size = new Size(611, 455);
      pn_DetailedInfoInner.TabIndex = 0;
      // 
      // btn_ChangePassword
      // 
      btn_ChangePassword.AutoSize = true;
      btn_ChangePassword.Cursor = Cursors.Hand;
      btn_ChangePassword.ForeColor = Color.Teal;
      btn_ChangePassword.Location = new Point(296, 420);
      btn_ChangePassword.Name = "btn_ChangePassword";
      btn_ChangePassword.Size = new Size(105, 15);
      btn_ChangePassword.TabIndex = 13;
      btn_ChangePassword.Text = "Thay đổi mật khẩu";
      btn_ChangePassword.Click += btn_ChangePassword_Click;
      // 
      // lb_InfoTitle
      // 
      lb_InfoTitle.AutoSize = true;
      lb_InfoTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      lb_InfoTitle.ForeColor = Color.Teal;
      lb_InfoTitle.Location = new Point(189, 19);
      lb_InfoTitle.Name = "lb_InfoTitle";
      lb_InfoTitle.Size = new Size(232, 25);
      lb_InfoTitle.TabIndex = 12;
      lb_InfoTitle.Text = "THÔNG TIN THÀNH VIÊN";
      // 
      // btn_Reset
      // 
      btn_Reset.BackColor = Color.IndianRed;
      btn_Reset.Cursor = Cursors.Hand;
      btn_Reset.FlatAppearance.BorderSize = 0;
      btn_Reset.FlatStyle = FlatStyle.Flat;
      btn_Reset.ForeColor = Color.White;
      btn_Reset.Location = new Point(227, 384);
      btn_Reset.Name = "btn_Reset";
      btn_Reset.Size = new Size(247, 23);
      btn_Reset.TabIndex = 11;
      btn_Reset.Text = "Đặt lại";
      btn_Reset.UseVisualStyleBackColor = false;
      btn_Reset.Click += btn_Reset_Click;
      // 
      // btn_SaveChanges
      // 
      btn_SaveChanges.BackColor = Color.Teal;
      btn_SaveChanges.Cursor = Cursors.Hand;
      btn_SaveChanges.FlatAppearance.BorderSize = 0;
      btn_SaveChanges.FlatStyle = FlatStyle.Flat;
      btn_SaveChanges.ForeColor = Color.White;
      btn_SaveChanges.Location = new Point(227, 355);
      btn_SaveChanges.Name = "btn_SaveChanges";
      btn_SaveChanges.Size = new Size(247, 23);
      btn_SaveChanges.TabIndex = 10;
      btn_SaveChanges.Text = "Lưu thay đổi";
      btn_SaveChanges.UseVisualStyleBackColor = false;
      btn_SaveChanges.Click += btn_SaveChanges_Click;
      // 
      // panel3
      // 
      panel3.Controls.Add(rb_Undefined);
      panel3.Controls.Add(rb_Female);
      panel3.Controls.Add(rb_Male);
      panel3.Location = new Point(227, 272);
      panel3.Name = "panel3";
      panel3.Size = new Size(247, 77);
      panel3.TabIndex = 9;
      // 
      // rb_Undefined
      // 
      rb_Undefined.AutoSize = true;
      rb_Undefined.Location = new Point(0, 40);
      rb_Undefined.Name = "rb_Undefined";
      rb_Undefined.Size = new Size(51, 19);
      rb_Undefined.TabIndex = 2;
      rb_Undefined.TabStop = true;
      rb_Undefined.Text = "Khác";
      rb_Undefined.UseVisualStyleBackColor = true;
      // 
      // rb_Female
      // 
      rb_Female.AutoSize = true;
      rb_Female.Location = new Point(117, 0);
      rb_Female.Name = "rb_Female";
      rb_Female.Size = new Size(41, 19);
      rb_Female.TabIndex = 1;
      rb_Female.TabStop = true;
      rb_Female.Text = "Nữ";
      rb_Female.UseVisualStyleBackColor = true;
      // 
      // rb_Male
      // 
      rb_Male.AutoSize = true;
      rb_Male.Location = new Point(0, 0);
      rb_Male.Name = "rb_Male";
      rb_Male.Size = new Size(51, 19);
      rb_Male.TabIndex = 0;
      rb_Male.TabStop = true;
      rb_Male.Text = "Nam";
      rb_Male.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Location = new Point(137, 272);
      label6.Name = "label6";
      label6.Size = new Size(52, 15);
      label6.TabIndex = 8;
      label6.Text = "Giới tính";
      // 
      // dtp_BirthDate
      // 
      dtp_BirthDate.Location = new Point(227, 215);
      dtp_BirthDate.Name = "dtp_BirthDate";
      dtp_BirthDate.Size = new Size(247, 23);
      dtp_BirthDate.TabIndex = 7;
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(137, 221);
      label5.Name = "label5";
      label5.Size = new Size(60, 15);
      label5.TabIndex = 6;
      label5.Text = "Ngày sinh";
      // 
      // tb_LastName
      // 
      tb_LastName.Location = new Point(227, 162);
      tb_LastName.Name = "tb_LastName";
      tb_LastName.Size = new Size(247, 23);
      tb_LastName.TabIndex = 5;
      // 
      // tb_FirstName
      // 
      tb_FirstName.Location = new Point(227, 108);
      tb_FirstName.Name = "tb_FirstName";
      tb_FirstName.Size = new Size(247, 23);
      tb_FirstName.TabIndex = 4;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(137, 166);
      label4.Name = "label4";
      label4.Size = new Size(25, 15);
      label4.TabIndex = 3;
      label4.Text = "Tên";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(137, 111);
      label3.Name = "label3";
      label3.Size = new Size(23, 15);
      label3.TabIndex = 2;
      label3.Text = "Họ";
      // 
      // lb_DetailUsername
      // 
      lb_DetailUsername.AutoSize = true;
      lb_DetailUsername.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
      lb_DetailUsername.ForeColor = Color.Teal;
      lb_DetailUsername.Location = new Point(227, 64);
      lb_DetailUsername.Name = "lb_DetailUsername";
      lb_DetailUsername.Size = new Size(59, 15);
      lb_DetailUsername.TabIndex = 1;
      lb_DetailUsername.Text = "username";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(137, 64);
      label1.Name = "label1";
      label1.Size = new Size(60, 15);
      label1.TabIndex = 0;
      label1.Text = "Username";
      // 
      // pn_Summaries
      // 
      pn_Summaries.BackColor = Color.Honeydew;
      pn_Summaries.Controls.Add(pn_SummariesInner);
      pn_Summaries.Dock = DockStyle.Left;
      pn_Summaries.Location = new Point(0, 0);
      pn_Summaries.Margin = new Padding(0);
      pn_Summaries.Name = "pn_Summaries";
      pn_Summaries.Size = new Size(262, 555);
      pn_Summaries.TabIndex = 2;
      // 
      // pn_SummariesInner
      // 
      pn_SummariesInner.Controls.Add(lb_LogOut);
      pn_SummariesInner.Controls.Add(lb_SummaryUsername);
      pn_SummariesInner.Controls.Add(lb_DisplayName);
      pn_SummariesInner.Controls.Add(pictureBox1);
      pn_SummariesInner.Location = new Point(3, 169);
      pn_SummariesInner.Name = "pn_SummariesInner";
      pn_SummariesInner.Size = new Size(254, 230);
      pn_SummariesInner.TabIndex = 0;
      // 
      // lb_LogOut
      // 
      lb_LogOut.AutoSize = true;
      lb_LogOut.Cursor = Cursors.Hand;
      lb_LogOut.ForeColor = Color.IndianRed;
      lb_LogOut.Location = new Point(97, 205);
      lb_LogOut.Name = "lb_LogOut";
      lb_LogOut.Size = new Size(61, 15);
      lb_LogOut.TabIndex = 4;
      lb_LogOut.Text = "Đăng xuất";
      lb_LogOut.Click += lb_LogOut_Click;
      // 
      // lb_SummaryUsername
      // 
      lb_SummaryUsername.AutoSize = true;
      lb_SummaryUsername.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
      lb_SummaryUsername.ForeColor = Color.Teal;
      lb_SummaryUsername.Location = new Point(92, 183);
      lb_SummaryUsername.Name = "lb_SummaryUsername";
      lb_SummaryUsername.Size = new Size(71, 15);
      lb_SummaryUsername.TabIndex = 3;
      lb_SummaryUsername.Text = "@username";
      lb_SummaryUsername.Resize += lb_Username_Resize;
      // 
      // lb_DisplayName
      // 
      lb_DisplayName.AutoSize = true;
      lb_DisplayName.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      lb_DisplayName.ForeColor = Color.Teal;
      lb_DisplayName.Location = new Point(44, 158);
      lb_DisplayName.Name = "lb_DisplayName";
      lb_DisplayName.Size = new Size(167, 25);
      lb_DisplayName.TabIndex = 2;
      lb_DisplayName.Text = "User DisplayName";
      lb_DisplayName.Resize += lb_DisplayName_Resize;
      // 
      // pictureBox1
      // 
      pictureBox1.Image = Properties.Resources.User_Default;
      pictureBox1.Location = new Point(50, 0);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(154, 144);
      pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox1.TabIndex = 1;
      pictureBox1.TabStop = false;
      // 
      // bw_UpdateUserData
      // 
      bw_UpdateUserData.DoWork += bw_UpdateUserData_DoWork;
      bw_UpdateUserData.RunWorkerCompleted += bw_UpdateUserData_RunWorkerCompleted;
      // 
      // UserView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(pn_Content);
      Name = "UserView";
      Size = new Size(879, 555);
      Load += UserView_Load;
      Resize += UserView_Resize;
      pn_Content.ResumeLayout(false);
      pn_DetailedInfo.ResumeLayout(false);
      pn_DetailedInfoInner.ResumeLayout(false);
      pn_DetailedInfoInner.PerformLayout();
      panel3.ResumeLayout(false);
      panel3.PerformLayout();
      pn_Summaries.ResumeLayout(false);
      pn_SummariesInner.ResumeLayout(false);
      pn_SummariesInner.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
    }

    #endregion
    private System.ComponentModel.BackgroundWorker bw_LoadUserData;
    private Panel pn_Content;
    private Panel pn_DetailedInfo;
    private Panel pn_DetailedInfoInner;
    private Label btn_ChangePassword;
    private Label lb_InfoTitle;
    private Button btn_Reset;
    private Button btn_SaveChanges;
    private Panel panel3;
    private RadioButton rb_Undefined;
    private RadioButton rb_Female;
    private RadioButton rb_Male;
    private Label label6;
    private DateTimePicker dtp_BirthDate;
    private Label label5;
    private TextBox tb_LastName;
    private TextBox tb_FirstName;
    private Label label4;
    private Label label3;
    private Label lb_DetailUsername;
    private Label label1;
    private Panel pn_Summaries;
    private Panel pn_SummariesInner;
    private Label lb_LogOut;
    private Label lb_SummaryUsername;
    private Label lb_DisplayName;
    private PictureBox pictureBox1;
    private System.ComponentModel.BackgroundWorker bw_UpdateUserData;
  }
}
