namespace Neu.ANT.Frontend.Forms
{
  partial class NotificationForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      btn_Close = new Button();
      lb_Title = new Label();
      lb_Message = new Label();
      SuspendLayout();
      // 
      // btn_Close
      // 
      btn_Close.BackColor = Color.IndianRed;
      btn_Close.FlatAppearance.BorderSize = 0;
      btn_Close.FlatStyle = FlatStyle.Flat;
      btn_Close.Image = Properties.Resources.XSign32;
      btn_Close.Location = new Point(334, 15);
      btn_Close.Name = "btn_Close";
      btn_Close.Size = new Size(50, 50);
      btn_Close.TabIndex = 0;
      btn_Close.UseVisualStyleBackColor = false;
      btn_Close.Click += btn_Close_Click;
      // 
      // lb_Title
      // 
      lb_Title.AutoSize = true;
      lb_Title.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      lb_Title.Location = new Point(12, 15);
      lb_Title.Name = "lb_Title";
      lb_Title.Size = new Size(63, 25);
      lb_Title.TabIndex = 1;
      lb_Title.Text = "label1";
      // 
      // lb_Message
      // 
      lb_Message.AutoSize = true;
      lb_Message.Location = new Point(12, 50);
      lb_Message.Name = "lb_Message";
      lb_Message.Size = new Size(38, 15);
      lb_Message.TabIndex = 2;
      lb_Message.Text = "label2";
      // 
      // NotificationForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(396, 80);
      Controls.Add(lb_Message);
      Controls.Add(lb_Title);
      Controls.Add(btn_Close);
      FormBorderStyle = FormBorderStyle.None;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "NotificationForm";
      Text = "Notification";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button btn_Close;
    private Label lb_Title;
    private Label lb_Message;
  }
}