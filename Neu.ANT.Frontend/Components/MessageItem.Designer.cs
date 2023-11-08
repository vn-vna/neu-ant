namespace Neu.ANT.Frontend.Components
{
  partial class MessageItem
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
      gb_ConsecutiveMessage = new GroupBox();
      fpn_ConsecutiveMessages = new FlowLayoutPanel();
      label1 = new Label();
      label2 = new Label();
      label3 = new Label();
      label4 = new Label();
      gb_ConsecutiveMessage.SuspendLayout();
      fpn_ConsecutiveMessages.SuspendLayout();
      SuspendLayout();
      // 
      // gb_ConsecutiveMessage
      // 
      gb_ConsecutiveMessage.AutoSize = true;
      gb_ConsecutiveMessage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      gb_ConsecutiveMessage.Controls.Add(fpn_ConsecutiveMessages);
      gb_ConsecutiveMessage.Dock = DockStyle.Fill;
      gb_ConsecutiveMessage.Location = new Point(0, 0);
      gb_ConsecutiveMessage.Name = "gb_ConsecutiveMessage";
      gb_ConsecutiveMessage.Size = new Size(327, 82);
      gb_ConsecutiveMessage.TabIndex = 0;
      gb_ConsecutiveMessage.TabStop = false;
      gb_ConsecutiveMessage.Text = "@username";
      // 
      // fpn_ConsecutiveMessages
      // 
      fpn_ConsecutiveMessages.AutoSize = true;
      fpn_ConsecutiveMessages.Controls.Add(label1);
      fpn_ConsecutiveMessages.Controls.Add(label2);
      fpn_ConsecutiveMessages.Controls.Add(label3);
      fpn_ConsecutiveMessages.Controls.Add(label4);
      fpn_ConsecutiveMessages.Dock = DockStyle.Top;
      fpn_ConsecutiveMessages.FlowDirection = FlowDirection.TopDown;
      fpn_ConsecutiveMessages.Location = new Point(3, 19);
      fpn_ConsecutiveMessages.Name = "fpn_ConsecutiveMessages";
      fpn_ConsecutiveMessages.Size = new Size(321, 60);
      fpn_ConsecutiveMessages.TabIndex = 0;
      fpn_ConsecutiveMessages.WrapContents = false;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(3, 0);
      label1.Name = "label1";
      label1.Size = new Size(38, 15);
      label1.TabIndex = 0;
      label1.Text = "label1";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(3, 15);
      label2.Name = "label2";
      label2.Size = new Size(38, 15);
      label2.TabIndex = 1;
      label2.Text = "label2";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(3, 30);
      label3.Name = "label3";
      label3.Size = new Size(38, 15);
      label3.TabIndex = 2;
      label3.Text = "label3";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(3, 45);
      label4.Name = "label4";
      label4.Size = new Size(38, 15);
      label4.TabIndex = 3;
      label4.Text = "label4";
      // 
      // MessageItem
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      AutoSize = true;
      Controls.Add(gb_ConsecutiveMessage);
      Margin = new Padding(0);
      MinimumSize = new Size(300, 0);
      Name = "MessageItem";
      Size = new Size(327, 82);
      gb_ConsecutiveMessage.ResumeLayout(false);
      gb_ConsecutiveMessage.PerformLayout();
      fpn_ConsecutiveMessages.ResumeLayout(false);
      fpn_ConsecutiveMessages.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private GroupBox gb_ConsecutiveMessage;
    private FlowLayoutPanel fpn_ConsecutiveMessages;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
  }
}
