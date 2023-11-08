namespace Neu.ANT.Frontend.Components
{
  partial class AppCenterPage
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
      pn_SideBar = new FlowLayoutPanel();
      btn_UserPreference = new Button();
      btn_Group = new Button();
      btn_Notification = new Button();
      pn_Content = new Panel();
      pn_SideBar.SuspendLayout();
      SuspendLayout();
      // 
      // pn_SideBar
      // 
      pn_SideBar.BackColor = Color.Teal;
      pn_SideBar.Controls.Add(btn_UserPreference);
      pn_SideBar.Controls.Add(btn_Group);
      pn_SideBar.Controls.Add(btn_Notification);
      pn_SideBar.Dock = DockStyle.Left;
      pn_SideBar.Location = new Point(0, 0);
      pn_SideBar.Margin = new Padding(0);
      pn_SideBar.Name = "pn_SideBar";
      pn_SideBar.Size = new Size(64, 563);
      pn_SideBar.TabIndex = 2;
      // 
      // btn_UserPreference
      // 
      btn_UserPreference.BackColor = Color.LightSeaGreen;
      btn_UserPreference.FlatAppearance.BorderSize = 0;
      btn_UserPreference.FlatStyle = FlatStyle.Flat;
      btn_UserPreference.Image = Properties.Resources.UserDefault32;
      btn_UserPreference.Location = new Point(0, 0);
      btn_UserPreference.Margin = new Padding(0);
      btn_UserPreference.Name = "btn_UserPreference";
      btn_UserPreference.Size = new Size(64, 64);
      btn_UserPreference.TabIndex = 0;
      btn_UserPreference.TabStop = false;
      btn_UserPreference.UseVisualStyleBackColor = false;
      btn_UserPreference.Click += btn_UserPreference_Click;
      // 
      // btn_Group
      // 
      btn_Group.FlatAppearance.BorderSize = 0;
      btn_Group.FlatStyle = FlatStyle.Flat;
      btn_Group.Image = Properties.Resources.TeamDefault32;
      btn_Group.Location = new Point(0, 64);
      btn_Group.Margin = new Padding(0);
      btn_Group.Name = "btn_Group";
      btn_Group.Size = new Size(64, 64);
      btn_Group.TabIndex = 1;
      btn_Group.TabStop = false;
      btn_Group.Click += btn_Group_Click;
      // 
      // btn_Notification
      // 
      btn_Notification.FlatAppearance.BorderSize = 0;
      btn_Notification.FlatStyle = FlatStyle.Flat;
      btn_Notification.Image = Properties.Resources.Notification32;
      btn_Notification.Location = new Point(0, 128);
      btn_Notification.Margin = new Padding(0);
      btn_Notification.Name = "btn_Notification";
      btn_Notification.Size = new Size(64, 64);
      btn_Notification.TabIndex = 2;
      btn_Notification.TabStop = false;
      btn_Notification.Click += btn_Notification_Click;
      // 
      // pn_Content
      // 
      pn_Content.Dock = DockStyle.Right;
      pn_Content.Location = new Point(64, 0);
      pn_Content.Margin = new Padding(0);
      pn_Content.Name = "pn_Content";
      pn_Content.Size = new Size(905, 563);
      pn_Content.TabIndex = 1;
      // 
      // AppCenterPage
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(pn_SideBar);
      Controls.Add(pn_Content);
      Name = "AppCenterPage";
      Size = new Size(969, 563);
      Load += AppCenterPage_Load;
      Resize += AppCenterPage_Resize;
      pn_SideBar.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion
    private FlowLayoutPanel pn_SideBar;
    private Button btn_UserPreference;
    private Button btn_Group;
    private Button btn_Notification;
    private Panel pn_Content;
  }
}
