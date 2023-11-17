namespace Neu.ANT.Frontend.Components
{
  partial class GroupItem
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
      pb_GroupImage = new PictureBox();
      lb_Name = new Label();
      lb_LastMessage = new Label();
      ((System.ComponentModel.ISupportInitialize)pb_GroupImage).BeginInit();
      SuspendLayout();
      // 
      // pb_GroupImage
      // 
      pb_GroupImage.Image = Properties.Resources.AntLogo;
      pb_GroupImage.Location = new Point(5, 5);
      pb_GroupImage.Margin = new Padding(5);
      pb_GroupImage.Name = "pb_GroupImage";
      pb_GroupImage.Size = new Size(40, 40);
      pb_GroupImage.SizeMode = PictureBoxSizeMode.Zoom;
      pb_GroupImage.TabIndex = 0;
      pb_GroupImage.TabStop = false;
      pb_GroupImage.MouseClick += GroupItem_Click;
      pb_GroupImage.MouseDown += GroupItem_MouseDown;
      pb_GroupImage.MouseEnter += GroupItem_MouseEnter;
      pb_GroupImage.MouseLeave += GroupItem_MouseLeave;
      pb_GroupImage.MouseUp += GroupItem_MouseUp;
      // 
      // lb_Name
      // 
      lb_Name.AutoSize = true;
      lb_Name.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      lb_Name.Location = new Point(53, 8);
      lb_Name.Name = "lb_Name";
      lb_Name.Size = new Size(76, 15);
      lb_Name.TabIndex = 1;
      lb_Name.Text = "Group name";
      lb_Name.MouseClick += GroupItem_Click;
      lb_Name.MouseDown += GroupItem_MouseDown;
      lb_Name.MouseEnter += GroupItem_MouseEnter;
      lb_Name.MouseLeave += GroupItem_MouseLeave;
      lb_Name.MouseUp += GroupItem_MouseUp;
      // 
      // lb_LastMessage
      // 
      lb_LastMessage.AutoSize = true;
      lb_LastMessage.Location = new Point(53, 26);
      lb_LastMessage.Name = "lb_LastMessage";
      lb_LastMessage.Size = new Size(101, 15);
      lb_LastMessage.TabIndex = 2;
      lb_LastMessage.Text = "Example message";
      lb_LastMessage.MouseClick += GroupItem_Click;
      lb_LastMessage.MouseDown += GroupItem_MouseDown;
      lb_LastMessage.MouseEnter += GroupItem_MouseEnter;
      lb_LastMessage.MouseLeave += GroupItem_MouseLeave;
      lb_LastMessage.MouseUp += GroupItem_MouseUp;
      // 
      // GroupItem
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Transparent;
      Controls.Add(lb_LastMessage);
      Controls.Add(lb_Name);
      Controls.Add(pb_GroupImage);
      Cursor = Cursors.Hand;
      Margin = new Padding(0);
      MaximumSize = new Size(600, 50);
      MinimumSize = new Size(200, 50);
      Name = "GroupItem";
      Size = new Size(300, 50);
      Load += GroupItem_Load;
      MouseClick += GroupItem_Click;
      MouseDown += GroupItem_MouseDown;
      MouseEnter += GroupItem_MouseEnter;
      MouseLeave += GroupItem_MouseLeave;
      MouseUp += GroupItem_MouseUp;
      ((System.ComponentModel.ISupportInitialize)pb_GroupImage).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private PictureBox pb_GroupImage;
    private Label lb_Name;
    private Label lb_LastMessage;
  }
}
