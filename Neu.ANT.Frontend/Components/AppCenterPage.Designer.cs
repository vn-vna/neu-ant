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
      panel1 = new Panel();
      pn_SideBar = new FlowLayoutPanel();
      btn_UserPreference = new Button();
      pn_Content = new Panel();
      panel1.SuspendLayout();
      pn_SideBar.SuspendLayout();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.Controls.Add(pn_Content);
      panel1.Dock = DockStyle.Right;
      panel1.Location = new Point(64, 0);
      panel1.Margin = new Padding(0);
      panel1.Name = "panel1";
      panel1.Size = new Size(905, 563);
      panel1.TabIndex = 1;
      // 
      // pn_SideBar
      // 
      pn_SideBar.BackColor = Color.Teal;
      pn_SideBar.Controls.Add(btn_UserPreference);
      pn_SideBar.Dock = DockStyle.Left;
      pn_SideBar.Location = new Point(0, 0);
      pn_SideBar.Margin = new Padding(0);
      pn_SideBar.Name = "pn_SideBar";
      pn_SideBar.Size = new Size(64, 563);
      pn_SideBar.TabIndex = 2;
      // 
      // btn_UserPreference
      // 
      btn_UserPreference.FlatAppearance.BorderSize = 0;
      btn_UserPreference.FlatStyle = FlatStyle.Flat;
      btn_UserPreference.Image = Properties.Resources.UserDefault32;
      btn_UserPreference.Location = new Point(5, 5);
      btn_UserPreference.Margin = new Padding(5);
      btn_UserPreference.Name = "btn_UserPreference";
      btn_UserPreference.Size = new Size(54, 54);
      btn_UserPreference.TabIndex = 0;
      btn_UserPreference.TabStop = false;
      btn_UserPreference.Click += btn_UserPreference_Click;
      // 
      // pn_Content
      // 
      pn_Content.Dock = DockStyle.Right;
      pn_Content.Location = new Point(0, 0);
      pn_Content.Margin = new Padding(0);
      pn_Content.Name = "pn_Content";
      pn_Content.Size = new Size(905, 563);
      pn_Content.TabIndex = 0;
      // 
      // AppCenterPage
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(pn_SideBar);
      Controls.Add(panel1);
      Name = "AppCenterPage";
      Size = new Size(969, 563);
      Load += AppCenterPage_Load;
      panel1.ResumeLayout(false);
      pn_SideBar.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private FlowLayoutPanel pn_SideBar;
    private Button btn_UserPreference;
    private Panel pn_Content;
  }
}
