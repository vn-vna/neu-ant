namespace Neu.ANT.Frontend.Components
{
  partial class InvitationItem
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
      pn_Content = new Panel();
      lb_Description = new Label();
      lb_GroupName = new Label();
      pn_Checkker = new Panel();
      btn_Reject = new Button();
      btn_Accept = new Button();
      bw_AcceptInvite = new System.ComponentModel.BackgroundWorker();
      bw_RejectInvite = new System.ComponentModel.BackgroundWorker();
      pn_Content.SuspendLayout();
      pn_Checkker.SuspendLayout();
      SuspendLayout();
      // 
      // pn_Content
      // 
      pn_Content.Controls.Add(lb_Description);
      pn_Content.Controls.Add(lb_GroupName);
      pn_Content.Dock = DockStyle.Left;
      pn_Content.Location = new Point(0, 0);
      pn_Content.Margin = new Padding(0);
      pn_Content.Name = "pn_Content";
      pn_Content.Size = new Size(466, 86);
      pn_Content.TabIndex = 0;
      pn_Content.Paint += pn_Content_Paint;
      // 
      // lb_Description
      // 
      lb_Description.AutoSize = true;
      lb_Description.Location = new Point(39, 51);
      lb_Description.Name = "lb_Description";
      lb_Description.Size = new Size(147, 15);
      lb_Description.TabIndex = 3;
      lb_Description.Text = "2023-12-12 by @username";
      // 
      // lb_GroupName
      // 
      lb_GroupName.AutoSize = true;
      lb_GroupName.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      lb_GroupName.Location = new Point(38, 20);
      lb_GroupName.Name = "lb_GroupName";
      lb_GroupName.Size = new Size(120, 25);
      lb_GroupName.TabIndex = 2;
      lb_GroupName.Text = "Group Name";
      // 
      // pn_Checkker
      // 
      pn_Checkker.Controls.Add(btn_Reject);
      pn_Checkker.Controls.Add(btn_Accept);
      pn_Checkker.Dock = DockStyle.Right;
      pn_Checkker.Location = new Point(466, 0);
      pn_Checkker.Margin = new Padding(0);
      pn_Checkker.Name = "pn_Checkker";
      pn_Checkker.Size = new Size(68, 86);
      pn_Checkker.TabIndex = 1;
      // 
      // btn_Reject
      // 
      btn_Reject.BackColor = Color.Transparent;
      btn_Reject.Dock = DockStyle.Bottom;
      btn_Reject.FlatAppearance.BorderSize = 0;
      btn_Reject.FlatStyle = FlatStyle.Flat;
      btn_Reject.Image = Properties.Resources.CloseRed32;
      btn_Reject.Location = new Point(0, 45);
      btn_Reject.Margin = new Padding(0);
      btn_Reject.Name = "btn_Reject";
      btn_Reject.Size = new Size(68, 41);
      btn_Reject.TabIndex = 1;
      btn_Reject.UseVisualStyleBackColor = false;
      btn_Reject.Click += btn_Reject_Click;
      // 
      // btn_Accept
      // 
      btn_Accept.BackColor = Color.Transparent;
      btn_Accept.Dock = DockStyle.Top;
      btn_Accept.FlatAppearance.BorderSize = 0;
      btn_Accept.FlatStyle = FlatStyle.Flat;
      btn_Accept.Image = Properties.Resources.CheckTeal32;
      btn_Accept.Location = new Point(0, 0);
      btn_Accept.Margin = new Padding(0);
      btn_Accept.Name = "btn_Accept";
      btn_Accept.Size = new Size(68, 45);
      btn_Accept.TabIndex = 0;
      btn_Accept.UseVisualStyleBackColor = false;
      btn_Accept.Click += btn_Accept_Click;
      // 
      // bw_AcceptInvite
      // 
      bw_AcceptInvite.DoWork += bw_AcceptInvite_DoWork;
      bw_AcceptInvite.RunWorkerCompleted += bw_AcceptInvite_RunWorkerCompleted;
      // 
      // bw_RejectInvite
      // 
      bw_RejectInvite.DoWork += bw_RejectInvite_DoWork;
      bw_RejectInvite.RunWorkerCompleted += bw_RejectInvite_RunWorkerCompleted;
      // 
      // InvitationItem
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Transparent;
      Controls.Add(pn_Checkker);
      Controls.Add(pn_Content);
      Name = "InvitationItem";
      Size = new Size(534, 86);
      Load += InvitationItem_Load;
      BackColorChanged += InvitationItem_BackColorChanged;
      Resize += InvitationItem_Resize;
      pn_Content.ResumeLayout(false);
      pn_Content.PerformLayout();
      pn_Checkker.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Panel pn_Content;
    private Panel pn_Checkker;
    private Label lb_Description;
    private Label lb_GroupName;
    private Button btn_Reject;
    private Button btn_Accept;
    private System.ComponentModel.BackgroundWorker bw_AcceptInvite;
    private System.ComponentModel.BackgroundWorker bw_RejectInvite;
  }
}
