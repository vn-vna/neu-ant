namespace Neu.ANT.Frontend.Forms
{
  partial class CreateChatGroupForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateChatGroupForm));
      label1 = new Label();
      tb_newGroupName = new TextBox();
      btn_Create = new Button();
      bw_CreateGroup = new System.ComponentModel.BackgroundWorker();
      SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      label1.ForeColor = Color.Teal;
      label1.Location = new Point(155, 29);
      label1.Name = "label1";
      label1.Size = new Size(133, 25);
      label1.TabIndex = 0;
      label1.Text = "Tên nhóm mới";
      // 
      // tb_newGroupName
      // 
      tb_newGroupName.Location = new Point(87, 69);
      tb_newGroupName.Name = "tb_newGroupName";
      tb_newGroupName.Size = new Size(268, 23);
      tb_newGroupName.TabIndex = 1;
      // 
      // btn_Create
      // 
      btn_Create.BackColor = Color.Teal;
      btn_Create.FlatAppearance.BorderSize = 0;
      btn_Create.FlatStyle = FlatStyle.Flat;
      btn_Create.ForeColor = Color.White;
      btn_Create.Location = new Point(162, 105);
      btn_Create.Name = "btn_Create";
      btn_Create.Size = new Size(118, 23);
      btn_Create.TabIndex = 2;
      btn_Create.Text = "Xác nhận";
      btn_Create.UseVisualStyleBackColor = false;
      btn_Create.Click += btn_Create_Click;
      // 
      // bw_CreateGroup
      // 
      bw_CreateGroup.DoWork += bw_CreateGroup_DoWork;
      bw_CreateGroup.RunWorkerCompleted += bw_CreateGroup_RunWorkerCompleted;
      // 
      // CreateChatGroupForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(442, 157);
      Controls.Add(btn_Create);
      Controls.Add(tb_newGroupName);
      Controls.Add(label1);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "CreateChatGroupForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Tạo nhóm mới";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox tb_newGroupName;
    private Button btn_Create;
    private System.ComponentModel.BackgroundWorker bw_CreateGroup;
  }
}