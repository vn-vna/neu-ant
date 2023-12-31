﻿namespace Neu.ANT.Frontend.Components
{
  partial class UserInspector
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
      bw_LoadUserInfo = new System.ComponentModel.BackgroundWorker();
      pn_Content = new Panel();
      pn_DetailedInfo = new Panel();
      pn_DetailedInfoInner = new Panel();
      lb_InfoTitle = new Label();
      panel3 = new Panel();
      radioButton3 = new RadioButton();
      radioButton2 = new RadioButton();
      radioButton1 = new RadioButton();
      label6 = new Label();
      dateTimePicker1 = new DateTimePicker();
      label5 = new Label();
      textBox2 = new TextBox();
      textBox1 = new TextBox();
      label4 = new Label();
      label3 = new Label();
      label2 = new Label();
      label1 = new Label();
      pn_Summaries = new Panel();
      pn_SummariesInner = new Panel();
      lb_AddFriend = new Label();
      lb_Username = new Label();
      lb_DisplayName = new Label();
      pictureBox1 = new PictureBox();
      pn_Content.SuspendLayout();
      pn_DetailedInfo.SuspendLayout();
      pn_DetailedInfoInner.SuspendLayout();
      panel3.SuspendLayout();
      pn_Summaries.SuspendLayout();
      pn_SummariesInner.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // bw_LoadUserInfo
      // 
      bw_LoadUserInfo.DoWork += bw_LoadUserInfo_DoWork;
      bw_LoadUserInfo.RunWorkerCompleted += bw_LoadUserInfo_RunWorkerCompleted;
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
      pn_DetailedInfoInner.Controls.Add(lb_InfoTitle);
      pn_DetailedInfoInner.Controls.Add(panel3);
      pn_DetailedInfoInner.Controls.Add(label6);
      pn_DetailedInfoInner.Controls.Add(dateTimePicker1);
      pn_DetailedInfoInner.Controls.Add(label5);
      pn_DetailedInfoInner.Controls.Add(textBox2);
      pn_DetailedInfoInner.Controls.Add(textBox1);
      pn_DetailedInfoInner.Controls.Add(label4);
      pn_DetailedInfoInner.Controls.Add(label3);
      pn_DetailedInfoInner.Controls.Add(label2);
      pn_DetailedInfoInner.Controls.Add(label1);
      pn_DetailedInfoInner.Location = new Point(4, 50);
      pn_DetailedInfoInner.Name = "pn_DetailedInfoInner";
      pn_DetailedInfoInner.Size = new Size(611, 455);
      pn_DetailedInfoInner.TabIndex = 0;
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
      // panel3
      // 
      panel3.Controls.Add(radioButton3);
      panel3.Controls.Add(radioButton2);
      panel3.Controls.Add(radioButton1);
      panel3.Location = new Point(227, 272);
      panel3.Name = "panel3";
      panel3.Size = new Size(247, 77);
      panel3.TabIndex = 9;
      // 
      // radioButton3
      // 
      radioButton3.AutoSize = true;
      radioButton3.Location = new Point(0, 40);
      radioButton3.Name = "radioButton3";
      radioButton3.Size = new Size(51, 19);
      radioButton3.TabIndex = 2;
      radioButton3.TabStop = true;
      radioButton3.Text = "Khác";
      radioButton3.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      radioButton2.AutoSize = true;
      radioButton2.Location = new Point(117, 0);
      radioButton2.Name = "radioButton2";
      radioButton2.Size = new Size(41, 19);
      radioButton2.TabIndex = 1;
      radioButton2.TabStop = true;
      radioButton2.Text = "Nữ";
      radioButton2.UseVisualStyleBackColor = true;
      // 
      // radioButton1
      // 
      radioButton1.AutoSize = true;
      radioButton1.Location = new Point(0, 0);
      radioButton1.Name = "radioButton1";
      radioButton1.Size = new Size(51, 19);
      radioButton1.TabIndex = 0;
      radioButton1.TabStop = true;
      radioButton1.Text = "Nam";
      radioButton1.UseVisualStyleBackColor = true;
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
      // dateTimePicker1
      // 
      dateTimePicker1.Enabled = false;
      dateTimePicker1.Location = new Point(227, 215);
      dateTimePicker1.Name = "dateTimePicker1";
      dateTimePicker1.Size = new Size(247, 23);
      dateTimePicker1.TabIndex = 7;
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
      // textBox2
      // 
      textBox2.Location = new Point(227, 162);
      textBox2.Name = "textBox2";
      textBox2.ReadOnly = true;
      textBox2.Size = new Size(247, 23);
      textBox2.TabIndex = 5;
      // 
      // textBox1
      // 
      textBox1.Location = new Point(227, 108);
      textBox1.Name = "textBox1";
      textBox1.ReadOnly = true;
      textBox1.Size = new Size(247, 23);
      textBox1.TabIndex = 4;
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
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
      label2.ForeColor = Color.Teal;
      label2.Location = new Point(227, 64);
      label2.Name = "label2";
      label2.Size = new Size(71, 15);
      label2.TabIndex = 1;
      label2.Text = "@username";
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
      pn_SummariesInner.Controls.Add(lb_AddFriend);
      pn_SummariesInner.Controls.Add(lb_Username);
      pn_SummariesInner.Controls.Add(lb_DisplayName);
      pn_SummariesInner.Controls.Add(pictureBox1);
      pn_SummariesInner.Location = new Point(3, 169);
      pn_SummariesInner.Name = "pn_SummariesInner";
      pn_SummariesInner.Size = new Size(254, 230);
      pn_SummariesInner.TabIndex = 0;
      // 
      // lb_AddFriend
      // 
      lb_AddFriend.AutoSize = true;
      lb_AddFriend.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
      lb_AddFriend.ForeColor = Color.SlateBlue;
      lb_AddFriend.Location = new Point(104, 205);
      lb_AddFriend.Name = "lb_AddFriend";
      lb_AddFriend.Size = new Size(47, 15);
      lb_AddFriend.TabIndex = 4;
      lb_AddFriend.Text = "Kết bạn";
      // 
      // lb_Username
      // 
      lb_Username.AutoSize = true;
      lb_Username.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
      lb_Username.ForeColor = Color.Teal;
      lb_Username.Location = new Point(90, 183);
      lb_Username.Name = "lb_Username";
      lb_Username.Size = new Size(71, 15);
      lb_Username.TabIndex = 3;
      lb_Username.Text = "@username";
      // 
      // lb_DisplayName
      // 
      lb_DisplayName.AutoSize = true;
      lb_DisplayName.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      lb_DisplayName.ForeColor = Color.Teal;
      lb_DisplayName.Location = new Point(102, 158);
      lb_DisplayName.Name = "lb_DisplayName";
      lb_DisplayName.Size = new Size(50, 25);
      lb_DisplayName.TabIndex = 2;
      lb_DisplayName.Text = "User";
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
      // UserInspector
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(pn_Content);
      Name = "UserInspector";
      Size = new Size(879, 555);
      Load += UserInspect_Load;
      Resize += UserInspect_Resize;
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
    private System.ComponentModel.BackgroundWorker bw_LoadUserInfo;
    private Panel pn_Content;
    private Panel pn_DetailedInfo;
    private Panel pn_DetailedInfoInner;
    private Label lb_InfoTitle;
    private Panel panel3;
    private RadioButton radioButton3;
    private RadioButton radioButton2;
    private RadioButton radioButton1;
    private Label label6;
    private DateTimePicker dateTimePicker1;
    private Label label5;
    private TextBox textBox2;
    private TextBox textBox1;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private Panel pn_Summaries;
    private Panel pn_SummariesInner;
    private Label lb_AddFriend;
    private Label lb_Username;
    private Label lb_DisplayName;
    private PictureBox pictureBox1;
  }
}
