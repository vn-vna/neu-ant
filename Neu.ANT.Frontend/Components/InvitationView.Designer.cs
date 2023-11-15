namespace Neu.ANT.Frontend.Components
{
  partial class InvitationView
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
      fpn_Content = new FlowLayoutPanel();
      bw_LoadIvitationList = new System.ComponentModel.BackgroundWorker();
      SuspendLayout();
      // 
      // fpn_Content
      // 
      fpn_Content.AutoScroll = true;
      fpn_Content.BackColor = Color.White;
      fpn_Content.FlowDirection = FlowDirection.TopDown;
      fpn_Content.Location = new Point(90, 0);
      fpn_Content.MaximumSize = new Size(700, 9999);
      fpn_Content.Name = "fpn_Content";
      fpn_Content.Size = new Size(635, 544);
      fpn_Content.TabIndex = 0;
      fpn_Content.WrapContents = false;
      // 
      // bw_LoadIvitationList
      // 
      bw_LoadIvitationList.DoWork += bw_LoadIvitationList_DoWork;
      bw_LoadIvitationList.RunWorkerCompleted += bw_LoadIvitationList_RunWorkerCompleted;
      // 
      // InvitationView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(fpn_Content);
      Name = "InvitationView";
      Size = new Size(814, 544);
      Load += InvitationView_Load;
      Resize += InvitationView_Resize;
      ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel fpn_Content;
    private System.ComponentModel.BackgroundWorker bw_LoadIvitationList;
  }
}
