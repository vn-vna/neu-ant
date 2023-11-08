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
      pn_Footer = new Panel();
      btn_SendMessage = new Button();
      pn_TextBox = new Panel();
      tb_MessageContent = new TextBox();
      bw_FetchMessage = new System.ComponentModel.BackgroundWorker();
      fpn_MessageHistory = new FlowLayoutPanel();
      bw_SendMessage = new System.ComponentModel.BackgroundWorker();
      pn_Footer.SuspendLayout();
      pn_TextBox.SuspendLayout();
      SuspendLayout();
      // 
      // pn_Header
      // 
      pn_Header.BackColor = Color.GhostWhite;
      pn_Header.Dock = DockStyle.Top;
      pn_Header.Location = new Point(0, 0);
      pn_Header.Name = "pn_Header";
      pn_Header.Size = new Size(562, 40);
      pn_Header.TabIndex = 0;
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
  }
}
