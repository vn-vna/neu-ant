namespace Neu.ANT.Frontend.Forms
{
  partial class InviteForm
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
      lb_Username = new Label();
      tb_Username = new TextBox();
      lb_Title = new Label();
      fpn_SearchResult = new FlowLayoutPanel();
      btn_ConfirmInvite = new Button();
      bw_AutoSearchUsername = new System.ComponentModel.BackgroundWorker();
      bw_InviteUser = new System.ComponentModel.BackgroundWorker();
      SuspendLayout();
      // 
      // lb_Username
      // 
      lb_Username.AutoSize = true;
      lb_Username.Location = new Point(33, 62);
      lb_Username.Name = "lb_Username";
      lb_Username.Size = new Size(60, 15);
      lb_Username.TabIndex = 0;
      lb_Username.Text = "Username";
      // 
      // tb_Username
      // 
      tb_Username.Location = new Point(33, 80);
      tb_Username.Name = "tb_Username";
      tb_Username.Size = new Size(351, 23);
      tb_Username.TabIndex = 1;
      tb_Username.TextChanged += tb_Username_TextChanged;
      // 
      // lb_Title
      // 
      lb_Title.AutoSize = true;
      lb_Title.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
      lb_Title.ForeColor = Color.Teal;
      lb_Title.Location = new Point(156, 20);
      lb_Title.Name = "lb_Title";
      lb_Title.Size = new Size(105, 25);
      lb_Title.TabIndex = 2;
      lb_Title.Text = "Gửi lời mời";
      // 
      // fpn_SearchResult
      // 
      fpn_SearchResult.AutoScroll = true;
      fpn_SearchResult.FlowDirection = FlowDirection.TopDown;
      fpn_SearchResult.Location = new Point(33, 109);
      fpn_SearchResult.Name = "fpn_SearchResult";
      fpn_SearchResult.Size = new Size(351, 166);
      fpn_SearchResult.TabIndex = 3;
      fpn_SearchResult.WrapContents = false;
      // 
      // btn_ConfirmInvite
      // 
      btn_ConfirmInvite.BackColor = Color.Teal;
      btn_ConfirmInvite.FlatAppearance.BorderSize = 0;
      btn_ConfirmInvite.FlatStyle = FlatStyle.Flat;
      btn_ConfirmInvite.ForeColor = Color.White;
      btn_ConfirmInvite.Location = new Point(124, 302);
      btn_ConfirmInvite.Name = "btn_ConfirmInvite";
      btn_ConfirmInvite.Size = new Size(168, 23);
      btn_ConfirmInvite.TabIndex = 4;
      btn_ConfirmInvite.Text = "Mời";
      btn_ConfirmInvite.UseVisualStyleBackColor = false;
      // 
      // bw_AutoSearchUsername
      // 
      bw_AutoSearchUsername.WorkerSupportsCancellation = true;
      bw_AutoSearchUsername.DoWork += bw_AutoSearchUsername_DoWork;
      // 
      // bw_InviteUser
      // 
      bw_InviteUser.DoWork += bw_InviteUser_DoWork;
      // 
      // InviteForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(416, 347);
      Controls.Add(btn_ConfirmInvite);
      Controls.Add(fpn_SearchResult);
      Controls.Add(lb_Title);
      Controls.Add(tb_Username);
      Controls.Add(lb_Username);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Name = "InviteForm";
      Text = "InviteForm";
      FormClosing += InviteForm_FormClosing;
      Load += InviteForm_Load;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label lb_Username;
    private TextBox tb_Username;
    private Label lb_Title;
    private FlowLayoutPanel fpn_SearchResult;
    private Button btn_ConfirmInvite;
    private System.ComponentModel.BackgroundWorker bw_AutoSearchUsername;
    private System.ComponentModel.BackgroundWorker bw_InviteUser;
  }
}