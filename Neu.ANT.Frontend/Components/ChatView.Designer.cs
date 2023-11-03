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
      textBox1 = new TextBox();
      pn_MsgHistory = new Panel();
      pn_Footer.SuspendLayout();
      pn_TextBox.SuspendLayout();
      SuspendLayout();
      // 
      // pn_Header
      // 
      pn_Header.BackColor = Color.DarkSlateBlue;
      pn_Header.Dock = DockStyle.Top;
      pn_Header.Location = new Point(0, 0);
      pn_Header.Name = "pn_Header";
      pn_Header.Size = new Size(562, 40);
      pn_Header.TabIndex = 0;
      // 
      // pn_Footer
      // 
      pn_Footer.BackColor = Color.DarkSlateBlue;
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
      btn_SendMessage.BackColor = Color.DarkSlateBlue;
      btn_SendMessage.Dock = DockStyle.Right;
      btn_SendMessage.FlatAppearance.BorderSize = 0;
      btn_SendMessage.FlatStyle = FlatStyle.Flat;
      btn_SendMessage.Image = Properties.Resources.PaperPlane24;
      btn_SendMessage.Location = new Point(522, 0);
      btn_SendMessage.Name = "btn_SendMessage";
      btn_SendMessage.Size = new Size(40, 40);
      btn_SendMessage.TabIndex = 1;
      btn_SendMessage.UseVisualStyleBackColor = false;
      // 
      // pn_TextBox
      // 
      pn_TextBox.BackColor = Color.DarkSlateBlue;
      pn_TextBox.Controls.Add(textBox1);
      pn_TextBox.Dock = DockStyle.Left;
      pn_TextBox.Location = new Point(0, 0);
      pn_TextBox.Margin = new Padding(0);
      pn_TextBox.Name = "pn_TextBox";
      pn_TextBox.Padding = new Padding(5);
      pn_TextBox.Size = new Size(519, 40);
      pn_TextBox.TabIndex = 0;
      // 
      // textBox1
      // 
      textBox1.BackColor = Color.DarkSlateBlue;
      textBox1.BorderStyle = BorderStyle.None;
      textBox1.Dock = DockStyle.Fill;
      textBox1.Location = new Point(5, 5);
      textBox1.Margin = new Padding(5);
      textBox1.Multiline = true;
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(509, 30);
      textBox1.TabIndex = 0;
      // 
      // pn_MsgHistory
      // 
      pn_MsgHistory.Dock = DockStyle.Fill;
      pn_MsgHistory.Location = new Point(0, 40);
      pn_MsgHistory.Name = "pn_MsgHistory";
      pn_MsgHistory.Size = new Size(562, 489);
      pn_MsgHistory.TabIndex = 2;
      pn_MsgHistory.Resize += pn_MsgHistory_Resize;
      // 
      // ChatView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(pn_MsgHistory);
      Controls.Add(pn_Footer);
      Controls.Add(pn_Header);
      Name = "ChatView";
      Size = new Size(562, 569);
      Load += ChatView_Load;
      pn_Footer.ResumeLayout(false);
      pn_TextBox.ResumeLayout(false);
      pn_TextBox.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Panel pn_Header;
    private Panel pn_Footer;
    private Panel pn_MsgHistory;
    private Button btn_SendMessage;
    private Panel pn_TextBox;
    private TextBox textBox1;
  }
}
