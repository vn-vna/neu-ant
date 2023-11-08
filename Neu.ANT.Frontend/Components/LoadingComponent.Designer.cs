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
      pn_Content = new Panel();
      pn_Inner = new Panel();
      lb_LoadingText = new Label();
      pic_LoadingAnim = new PictureBox();
      pn_Content.SuspendLayout();
      pn_Inner.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pic_LoadingAnim).BeginInit();
      SuspendLayout();
      // 
      // pn_Content
      // 
      pn_Content.Controls.Add(pn_Inner);
      pn_Content.Dock = DockStyle.Fill;
      pn_Content.Location = new Point(0, 0);
      pn_Content.Name = "pn_Content";
      pn_Content.Size = new Size(363, 364);
      pn_Content.TabIndex = 0;
      // 
      // pn_Inner
      // 
      pn_Inner.Controls.Add(lb_LoadingText);
      pn_Inner.Controls.Add(pic_LoadingAnim);
      pn_Inner.Location = new Point(81, 132);
      pn_Inner.Name = "pn_Inner";
      pn_Inner.Size = new Size(200, 100);
      pn_Inner.TabIndex = 0;
      // 
      // lb_LoadingText
      // 
      lb_LoadingText.AutoSize = true;
      lb_LoadingText.Location = new Point(71, 75);
      lb_LoadingText.Name = "lb_LoadingText";
      lb_LoadingText.Size = new Size(59, 15);
      lb_LoadingText.TabIndex = 1;
      lb_LoadingText.Text = "Loading...";
      // 
      // pic_LoadingAnim
      // 
      pic_LoadingAnim.Image = Properties.Resources.LoadingAnim1;
      pic_LoadingAnim.Location = new Point(75, 12);
      pic_LoadingAnim.Name = "pic_LoadingAnim";
      pic_LoadingAnim.Size = new Size(50, 50);
      pic_LoadingAnim.SizeMode = PictureBoxSizeMode.Zoom;
      pic_LoadingAnim.TabIndex = 0;
      pic_LoadingAnim.TabStop = false;
      // 
      // LoadingComponent
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(pn_Content);
      Margin = new Padding(0);
      Name = "LoadingComponent";
      Size = new Size(363, 364);
      Load += LoadingComponent_Load;
      Resize += LoadingComponent_Resize;
      pn_Content.ResumeLayout(false);
      pn_Inner.ResumeLayout(false);
      pn_Inner.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pic_LoadingAnim).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel pn_Content;
    private Panel pn_Inner;
    private Label lb_LoadingText;
    private PictureBox pic_LoadingAnim;
  }
}
