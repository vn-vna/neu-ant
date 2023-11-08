namespace Neu.ANT.Frontend.Components
{
  partial class GroupView
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
      pn_GroupSideBar = new Panel();
      btn_AddGroup = new Button();
      fpn_GroupList = new FlowLayoutPanel();
      pn_ChatViewZone = new Panel();
      chatView1 = new ChatView();
      bw_LoadGroupList = new System.ComponentModel.BackgroundWorker();
      pn_GroupSideBar.SuspendLayout();
      pn_ChatViewZone.SuspendLayout();
      SuspendLayout();
      // 
      // pn_GroupSideBar
      // 
      pn_GroupSideBar.BackColor = Color.Honeydew;
      pn_GroupSideBar.Controls.Add(btn_AddGroup);
      pn_GroupSideBar.Controls.Add(fpn_GroupList);
      pn_GroupSideBar.Dock = DockStyle.Left;
      pn_GroupSideBar.Location = new Point(0, 0);
      pn_GroupSideBar.Margin = new Padding(0);
      pn_GroupSideBar.Name = "pn_GroupSideBar";
      pn_GroupSideBar.Size = new Size(259, 541);
      pn_GroupSideBar.TabIndex = 0;
      // 
      // btn_AddGroup
      // 
      btn_AddGroup.Dock = DockStyle.Bottom;
      btn_AddGroup.FlatAppearance.BorderSize = 0;
      btn_AddGroup.FlatStyle = FlatStyle.Flat;
      btn_AddGroup.Location = new Point(0, 511);
      btn_AddGroup.Margin = new Padding(0);
      btn_AddGroup.Name = "btn_AddGroup";
      btn_AddGroup.Size = new Size(259, 30);
      btn_AddGroup.TabIndex = 1;
      btn_AddGroup.Text = "Tạo mới";
      btn_AddGroup.UseVisualStyleBackColor = true;
      btn_AddGroup.Click += btn_AddGroup_Click;
      // 
      // fpn_GroupList
      // 
      fpn_GroupList.AutoScroll = true;
      fpn_GroupList.Dock = DockStyle.Top;
      fpn_GroupList.FlowDirection = FlowDirection.TopDown;
      fpn_GroupList.Location = new Point(0, 0);
      fpn_GroupList.Margin = new Padding(0);
      fpn_GroupList.Name = "fpn_GroupList";
      fpn_GroupList.Size = new Size(259, 511);
      fpn_GroupList.TabIndex = 0;
      fpn_GroupList.WrapContents = false;
      fpn_GroupList.Scroll += fpn_GroupList_Scroll;
      fpn_GroupList.Resize += fpn_GroupList_Resize;
      // 
      // pn_ChatViewZone
      // 
      pn_ChatViewZone.BackColor = Color.White;
      pn_ChatViewZone.Controls.Add(chatView1);
      pn_ChatViewZone.Dock = DockStyle.Right;
      pn_ChatViewZone.Location = new Point(259, 0);
      pn_ChatViewZone.Margin = new Padding(0);
      pn_ChatViewZone.Name = "pn_ChatViewZone";
      pn_ChatViewZone.Size = new Size(621, 541);
      pn_ChatViewZone.TabIndex = 0;
      // 
      // chatView1
      // 
      chatView1.BackColor = Color.White;
      chatView1.Dock = DockStyle.Fill;
      chatView1.Location = new Point(0, 0);
      chatView1.Name = "chatView1";
      chatView1.Size = new Size(621, 541);
      chatView1.TabIndex = 0;
      // 
      // bw_LoadGroupList
      // 
      bw_LoadGroupList.DoWork += bw_LoadGroupList_DoWork;
      bw_LoadGroupList.RunWorkerCompleted += bw_LoadGroupList_RunWorkerCompleted;
      // 
      // GroupView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(pn_ChatViewZone);
      Controls.Add(pn_GroupSideBar);
      Name = "GroupView";
      Size = new Size(880, 541);
      Load += GroupView_Load;
      Resize += GroupView_Resize;
      pn_GroupSideBar.ResumeLayout(false);
      pn_ChatViewZone.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel pn_GroupSideBar;
    private Panel pn_ChatViewZone;
    private ChatView chatView1;
    private FlowLayoutPanel fpn_GroupList;
    private System.ComponentModel.BackgroundWorker bw_LoadGroupList;
    private Button button1;
    private Button btn_AddGroup;
  }
}
