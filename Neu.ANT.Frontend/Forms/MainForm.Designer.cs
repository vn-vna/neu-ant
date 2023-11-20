namespace Neu.ANT.Frontend.Forms
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      pn_Cotent = new Panel();
      SuspendLayout();
      // 
      // pn_Cotent
      // 
      pn_Cotent.Dock = DockStyle.Fill;
      pn_Cotent.Location = new Point(0, 0);
      pn_Cotent.Name = "pn_Cotent";
      pn_Cotent.Size = new Size(1008, 561);
      pn_Cotent.TabIndex = 0;
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(1008, 561);
      Controls.Add(pn_Cotent);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "MainForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "ANT Messenger";
      Load += MainForm_Load;
      ResumeLayout(false);
    }

    #endregion
    private Panel pn_Cotent;
  }
}