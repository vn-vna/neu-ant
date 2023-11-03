namespace Neu.ANT.Frontend.Components
{
  partial class WelcomePage
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
      panel4 = new Panel();
      label1 = new Label();
      pictureBox1 = new PictureBox();
      panel2 = new Panel();
      panel3 = new Panel();
      label4 = new Label();
      label3 = new Label();
      button1 = new Button();
      label2 = new Label();
      panel1.SuspendLayout();
      panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      panel2.SuspendLayout();
      panel3.SuspendLayout();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.Controls.Add(panel4);
      panel1.Dock = DockStyle.Right;
      panel1.Location = new Point(423, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(509, 558);
      panel1.TabIndex = 1;
      // 
      // panel4
      // 
      panel4.Controls.Add(label1);
      panel4.Controls.Add(pictureBox1);
      panel4.Location = new Point(25, 104);
      panel4.Name = "panel4";
      panel4.Size = new Size(459, 350);
      panel4.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Rage Italic", 30F, FontStyle.Regular, GraphicsUnit.Point);
      label1.Location = new Point(107, 49);
      label1.Name = "label1";
      label1.Size = new Size(251, 50);
      label1.TabIndex = 5;
      label1.Text = "ANT Le facteur";
      // 
      // pictureBox1
      // 
      pictureBox1.Image = Properties.Resources.Welcome_Illut;
      pictureBox1.Location = new Point(33, 99);
      pictureBox1.Margin = new Padding(0);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(392, 202);
      pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox1.TabIndex = 4;
      pictureBox1.TabStop = false;
      // 
      // panel2
      // 
      panel2.Controls.Add(panel3);
      panel2.Dock = DockStyle.Left;
      panel2.Location = new Point(0, 0);
      panel2.Name = "panel2";
      panel2.Size = new Size(423, 558);
      panel2.TabIndex = 2;
      // 
      // panel3
      // 
      panel3.Controls.Add(label4);
      panel3.Controls.Add(label3);
      panel3.Controls.Add(button1);
      panel3.Controls.Add(label2);
      panel3.Location = new Point(55, 157);
      panel3.Name = "panel3";
      panel3.Size = new Size(313, 244);
      panel3.TabIndex = 0;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.BackColor = Color.White;
      label4.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
      label4.ForeColor = Color.Teal;
      label4.Location = new Point(115, 180);
      label4.Name = "label4";
      label4.Size = new Size(82, 15);
      label4.TabIndex = 3;
      label4.Text = "Đăng ký ngay!";
      label4.Click += label4_Click;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(92, 165);
      label3.Name = "label3";
      label3.Size = new Size(129, 15);
      label3.TabIndex = 2;
      label3.Text = "Bạn chưa có tài khoản?";
      // 
      // button1
      // 
      button1.BackColor = Color.Teal;
      button1.FlatAppearance.BorderSize = 0;
      button1.FlatStyle = FlatStyle.Flat;
      button1.ForeColor = Color.White;
      button1.Location = new Point(59, 119);
      button1.Margin = new Padding(0);
      button1.Name = "button1";
      button1.Size = new Size(195, 34);
      button1.TabIndex = 1;
      button1.TabStop = false;
      button1.Text = "Đăng nhập";
      button1.UseVisualStyleBackColor = false;
      button1.Click += button1_Click;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
      label2.ForeColor = Color.Teal;
      label2.Location = new Point(49, 49);
      label2.Name = "label2";
      label2.Size = new Size(214, 37);
      label2.TabIndex = 0;
      label2.Text = "ANT chào bạn!!";
      // 
      // WelcomePage
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(panel2);
      Controls.Add(panel1);
      Name = "WelcomePage";
      Size = new Size(932, 558);
      panel1.ResumeLayout(false);
      panel4.ResumeLayout(false);
      panel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      panel2.ResumeLayout(false);
      panel3.ResumeLayout(false);
      panel3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private Label label4;
    private Label label3;
    private Button button1;
    private Label label2;
    private Panel panel4;
    private Label label1;
    private PictureBox pictureBox1;
  }
}
