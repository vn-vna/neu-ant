namespace Neu.ANT.Frontend.Components
{
  partial class MainSideBarControl
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
      flowLayoutPanel1 = new FlowLayoutPanel();
      mainSideBarItemControl1 = new MainSideBarItemControl();
      flowLayoutPanel1.SuspendLayout();
      SuspendLayout();
      // 
      // flowLayoutPanel1
      // 
      flowLayoutPanel1.Controls.Add(mainSideBarItemControl1);
      flowLayoutPanel1.Dock = DockStyle.Fill;
      flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
      flowLayoutPanel1.Location = new Point(0, 0);
      flowLayoutPanel1.Name = "flowLayoutPanel1";
      flowLayoutPanel1.Size = new Size(64, 569);
      flowLayoutPanel1.TabIndex = 0;
      // 
      // mainSideBarItemControl1
      // 
      mainSideBarItemControl1.BackColor = Color.Teal;
      mainSideBarItemControl1.Location = new Point(0, 505);
      mainSideBarItemControl1.Margin = new Padding(0);
      mainSideBarItemControl1.Name = "mainSideBarItemControl1";
      mainSideBarItemControl1.Size = new Size(64, 64);
      mainSideBarItemControl1.TabIndex = 0;
      // 
      // MainSideBarControl
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(flowLayoutPanel1);
      Margin = new Padding(0);
      Name = "MainSideBarControl";
      Size = new Size(64, 569);
      flowLayoutPanel1.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel flowLayoutPanel1;
    private MainSideBarItemControl mainSideBarItemControl1;
  }
}
