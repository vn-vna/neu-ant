using Neu.ANT.Frontend.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neu.ANT.Frontend.Components
{
  public partial class InvitationItem : UserControl
  {
    public string InvitationId { get; set; }

    public string GroupName { get => lb_GroupName.Text; set => lb_GroupName.Text = value; }

    public string Description { get => lb_Description.Text; set => lb_Description.Text = value; }

    public bool Responded { get; set; }

    public Color InvitationColor { get; set; } = Color.FromArgb(0, 255, 255, 255);

    public Color HoverColor { get; set; } = Color.FromArgb(255, 230, 230, 230);

    public event Action ActionRefreshInvitationList;

    public InvitationItem()
    {
      InitializeComponent();
    }

    private void InvitationItem_BackColorChanged(object sender, EventArgs e)
    {
      this.SuspendLayout();
      lb_Description.BackColor = this.BackColor;
      lb_GroupName.BackColor = this.BackColor;
      pn_Content.BackColor = this.BackColor;
      this.ResumeLayout(true);
    }

    private void ResponsiveResizeComponents()
    {
      this.SuspendLayout();

      pn_Content.Size = new Size()
      {
        Width = this.Width - pn_Checkker.Width,
        Height = this.Height
      };

      this.ResumeLayout(true);
    }

    private void InvitationItem_MouseEnter(object sender, EventArgs e)
    {
      this.BackColor = HoverColor;
    }

    private void InvitationItem_MouseLeave(object sender, EventArgs e)
    {
      this.BackColor = InvitationColor;
    }

    private void InvitationItem_Load(object sender, EventArgs e)
    {
      ApplyHoverEffect(pn_Content);
      ApplyHoverEffect(lb_Description);
      ApplyHoverEffect(lb_GroupName);

      if (!Responded)
      {
        InvitationColor = Color.FromArgb(255, 230, 230, 130);
      }
      else
      {
        InvitationColor = Color.FromArgb(255, 255, 255, 255);
      }

      this.BackColor = InvitationColor;
      if (Responded)
      {
        pn_Checkker.Visible = false;
        this.Description = "Đã trả lời";
      }

      ResponsiveResizeComponents();
    }

    private void ApplyHoverEffect(Control control)
    {
      control.MouseEnter += InvitationItem_MouseEnter;
      control.MouseLeave += InvitationItem_MouseLeave;
    }

    private void bw_AcceptInvite_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        ApplicationState
          .Instance
          .InvitationClient
          .AcceptInvite(InvitationId);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void bw_AcceptInvite_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (ActionRefreshInvitationList is not null)
      {
        ActionRefreshInvitationList();
      }
    }

    private void bw_RejectInvite_DoWork(object sender, DoWorkEventArgs e)
    {
    }

    private void bw_RejectInvite_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (ActionRefreshInvitationList is not null)
      {
        ActionRefreshInvitationList();
      }
    }

    private void btn_Reject_Click(object sender, EventArgs e)
    {
      bw_RejectInvite.RunWorkerAsync();
    }

    private void btn_Accept_Click(object sender, EventArgs e)
    {
      bw_AcceptInvite.RunWorkerAsync();
    }

    private void InvitationItem_Resize(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
    }

    private void pn_Content_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}
