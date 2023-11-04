namespace Neu.ANT.Frontend.Components
{
  partial class LoadingComponent
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
      panel1 = new Panel();
      panel2 = new Panel();
      pictureBox1 = new PictureBox();
      label1 = new Label();
      panel1.SuspendLayout();
      panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.Controls.Add(panel2);
      panel1.Dock = DockStyle.Fill;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(363, 364);
      panel1.TabIndex = 0;
      // 
      // panel2
      // 
      panel2.Controls.Add(label1);
      panel2.Controls.Add(pictureBox1);
      panel2.Location = new Point(81, 132);
      panel2.Name = "panel2";
      panel2.Size = new Size(200, 100);
      panel2.TabIndex = 0;
      // 
      // pictureBox1
      // 
      pictureBox1.Image = Properties.Resources.LoadingAnim1;
      pictureBox1.Location = new Point(75, 12);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(50, 50);
      pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox1.TabIndex = 0;
      pictureBox1.TabStop = false;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(71, 75);
      label1.Name = "label1";
      label1.Size = new Size(59, 15);
      label1.TabIndex = 1;
      label1.Text = "Loading...";
      // 
      // LoadingComponent
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(panel1);
      Margin = new Padding(0);
      Name = "LoadingComponent";
      Size = new Size(363, 364);
      panel1.ResumeLayout(false);
      panel2.ResumeLayout(false);
      panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Panel panel2;
    private Label label1;
    private PictureBox pictureBox1;
  }
}
