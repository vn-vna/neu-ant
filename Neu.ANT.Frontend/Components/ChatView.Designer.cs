namespace Neu.ANT.Frontend.Components
{
  partial class ChatView
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
      pn_Header = new Panel();
      flowLayoutPanel1 = new FlowLayoutPanel();
      btn_Options = new Button();
      btn_Invite = new Button();
      panel1 = new Panel();
      lb_GroupName = new Label();
      pn_Footer = new Panel();
      btn_SendMessage = new Button();
      pn_TextBox = new Panel();
      tb_MessageContent = new TextBox();
      bw_FetchMessage = new System.ComponentModel.BackgroundWorker();
      fpn_MessageHistory = new FlowLayoutPanel();
      bw_SendMessage = new System.ComponentModel.BackgroundWorker();
      pn_Header.SuspendLayout();
      flowLayoutPanel1.SuspendLayout();
      panel1.SuspendLayout();
      pn_Footer.SuspendLayout();
      pn_TextBox.SuspendLayout();
      SuspendLayout();
      // 
      // pn_Header
      // 
      pn_Header.BackColor = Color.GhostWhite;
      pn_Header.Controls.Add(flowLayoutPanel1);
      pn_Header.Controls.Add(panel1);
      pn_Header.Dock = DockStyle.Top;
      pn_Header.Location = new Point(0, 0);
      pn_Header.Name = "pn_Header";
      pn_Header.Size = new Size(562, 40);
      pn_Header.TabIndex = 0;
      // 
      // flowLayoutPanel1
      // 
      flowLayoutPanel1.Controls.Add(btn_Options);
      flowLayoutPanel1.Controls.Add(btn_Invite);
      flowLayoutPanel1.Dock = DockStyle.Right;
      flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
      flowLayoutPanel1.Location = new Point(454, 0);
      flowLayoutPanel1.Name = "flowLayoutPanel1";
      flowLayoutPanel1.Size = new Size(108, 40);
      flowLayoutPanel1.TabIndex = 1;
      // 
      // btn_Options
      // 
      btn_Options.FlatAppearance.BorderSize = 0;
      btn_Options.FlatStyle = FlatStyle.Flat;
      btn_Options.Image = Properties.Resources.Menu32;
      btn_Options.Location = new Point(68, 0);
      btn_Options.Margin = new Padding(0);
      btn_Options.Name = "btn_Options";
      btn_Options.Size = new Size(40, 40);
      btn_Options.TabIndex = 0;
      btn_Options.Text = " ";
      btn_Options.UseVisualStyleBackColor = true;
      // 
      // btn_Invite
      // 
      btn_Invite.FlatAppearance.BorderSize = 0;
      btn_Invite.FlatStyle = FlatStyle.Flat;
      btn_Invite.Image = Properties.Resources.AddUser32;
      btn_Invite.Location = new Point(28, 0);
      btn_Invite.Margin = new Padding(0);
      btn_Invite.Name = "btn_Invite";
      btn_Invite.Size = new Size(40, 40);
      btn_Invite.TabIndex = 1;
      btn_Invite.Text = " ";
      btn_Invite.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      panel1.Controls.Add(lb_GroupName);
      panel1.Dock = DockStyle.Left;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(299, 40);
      panel1.TabIndex = 0;
      // 
      // lb_GroupName
      // 
      lb_GroupName.Dock = DockStyle.Fill;
      lb_GroupName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      lb_GroupName.Location = new Point(0, 0);
      lb_GroupName.Name = "lb_GroupName";
      lb_GroupName.Size = new Size(299, 40);
      lb_GroupName.TabIndex = 0;
      lb_GroupName.Text = "Group name";
      lb_GroupName.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // pn_Footer
      // 
      pn_Footer.BackColor = Color.Lavender;
      pn_Footer.Controls.Add(btn_SendMessage);
      pn_Footer.Controls.Add(pn_TextBox);
      pn_Footer.Dock = DockStyle.Bottom;
      pn_Footer.Location = new Point(0, 529);
      pn_Footer.Name = "pn_Footer";
      pn_Footer.Size = new Size(562, 40);
      pn_Footer.TabIndex = 1;
      // 
      // btn_SendMessage
      // 
      btn_SendMessage.BackColor = Color.GhostWhite;
      btn_SendMessage.Dock = DockStyle.Right;
      btn_SendMessage.FlatAppearance.BorderSize = 0;
      btn_SendMessage.FlatStyle = FlatStyle.Flat;
      btn_SendMessage.Image = Properties.Resources.PaperPlanePrimary24;
      btn_SendMessage.Location = new Point(522, 0);
      btn_SendMessage.Name = "btn_SendMessage";
      btn_SendMessage.Size = new Size(40, 40);
      btn_SendMessage.TabIndex = 1;
      btn_SendMessage.UseVisualStyleBackColor = false;
      btn_SendMessage.Click += btn_SendMessage_Click;
      // 
      // pn_TextBox
      // 
      pn_TextBox.BackColor = Color.GhostWhite;
      pn_TextBox.Controls.Add(tb_MessageContent);
      pn_TextBox.Dock = DockStyle.Left;
      pn_TextBox.Location = new Point(0, 0);
      pn_TextBox.Margin = new Padding(0);
      pn_TextBox.Name = "pn_TextBox";
      pn_TextBox.Padding = new Padding(5);
      pn_TextBox.Size = new Size(519, 40);
      pn_TextBox.TabIndex = 0;
      // 
      // tb_MessageContent
      // 
      tb_MessageContent.BackColor = Color.GhostWhite;
      tb_MessageContent.BorderStyle = BorderStyle.None;
      tb_MessageContent.Dock = DockStyle.Fill;
      tb_MessageContent.Location = new Point(5, 5);
      tb_MessageContent.Margin = new Padding(5);
      tb_MessageContent.Multiline = true;
      tb_MessageContent.Name = "tb_MessageContent";
      tb_MessageContent.Size = new Size(509, 30);
      tb_MessageContent.TabIndex = 0;
      tb_MessageContent.KeyDown += tb_MessageContent_KeyDown;
      // 
      // bw_FetchMessage
      // 
      bw_FetchMessage.DoWork += bw_FetchMessage_DoWork;
      bw_FetchMessage.RunWorkerCompleted += bw_FetchMessage_RunWorkerCompleted;
      // 
      // fpn_MessageHistory
      // 
      fpn_MessageHistory.AutoScroll = true;
      fpn_MessageHistory.Dock = DockStyle.Fill;
      fpn_MessageHistory.FlowDirection = FlowDirection.BottomUp;
      fpn_MessageHistory.Location = new Point(0, 40);
      fpn_MessageHistory.Name = "fpn_MessageHistory";
      fpn_MessageHistory.Size = new Size(562, 489);
      fpn_MessageHistory.TabIndex = 2;
      // 
      // bw_SendMessage
      // 
      bw_SendMessage.DoWork += bw_SendMessage_DoWork;
      bw_SendMessage.RunWorkerCompleted += bw_SendMessage_RunWorkerCompleted;
      // 
      // ChatView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(fpn_MessageHistory);
      Controls.Add(pn_Footer);
      Controls.Add(pn_Header);
      Name = "ChatView";
      Size = new Size(562, 569);
      Load += ChatView_Load;
      Resize += ChatView_Resize;
      pn_Header.ResumeLayout(false);
      flowLayoutPanel1.ResumeLayout(false);
      panel1.ResumeLayout(false);
      pn_Footer.ResumeLayout(false);
      pn_TextBox.ResumeLayout(false);
      pn_TextBox.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Panel pn_Header;
    private Panel pn_Footer;
    private Button btn_SendMessage;
    private Panel pn_TextBox;
    private TextBox tb_MessageContent;
    private System.ComponentModel.BackgroundWorker bw_FetchMessage;
    private FlowLayoutPanel fpn_MessageHistory;
    private System.ComponentModel.BackgroundWorker bw_SendMessage;
    private Panel panel1;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button btn_Options;
    private Button btn_Invite;
    private Label lb_GroupName;
  }
}
