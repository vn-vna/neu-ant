using Neu.ANT.Common.Models.ApiResponse.Invitaion;
using Neu.ANT.Frontend.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neu.ANT.Frontend.Components
{

  public partial class InvitationView : UserControl
  {
    private Dictionary<string, InvitationData> _invitations;

    public InvitationView()
    {
      InitializeComponent();
    }

    private void InvitationView_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
      bw_LoadIvitationList.RunWorkerAsync();
    }

    private void InvitationView_Resize(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
    }

    private void RefreshInvitationListUI()
    {
      fpn_Content.SuspendLayout();
      fpn_Content.Controls.Clear();

      var invitations = _invitations
        .OrderByDescending(invitation => invitation.Value.CreatedDatetime)
        .OrderBy(invitation => invitation.Value.Responded)
        .ToList();

      foreach (var invitation in invitations)
      {
        var item = new InvitationItem();
        item.InvitationId = invitation.Key;
        item.GroupName = invitation.Value.Group.GroupName;

        item.ActionRefreshInvitationList += bw_LoadIvitationList.RunWorkerAsync;

        var senderName = $"{invitation.Value.Sender.FirstName} {invitation.Value.Sender.LastName}".Trim();
        if (string.IsNullOrEmpty(senderName))
        {
          senderName = $"@{invitation.Value.Sender.Username}";
        }

        item.Description = $"{FormatDuration(invitation.Value.CreatedDatetime, DateTime.UtcNow)} by {senderName}";

        item.Responded = invitation.Value.Responded;

        var itemOverflowed = invitations.Count * (item.Height + item.Margin.Top + item.Margin.Bottom) > fpn_Content.Height;
        var itemWidth = fpn_Content.Width - (itemOverflowed ? SystemInformation.VerticalScrollBarWidth : 0) - item.Margin.Left - item.Margin.Right;

        item.Size = new Size()
        {
          Width = itemWidth,
          Height = item.Height
        };
        fpn_Content.Controls.Add(item);
      }

      fpn_Content.ResumeLayout(true);
    }

    private void ResponsiveResizeComponents()
    {
      this.SuspendLayout();

      fpn_Content.Size = new Size()
      {
        Width = this.Width * 8 / 10,
        Height = this.Height
      };

      fpn_Content.Location = new Point()
      {
        X = (this.Width - fpn_Content.Width) / 2,
        Y = (this.Height - fpn_Content.Height) / 2
      };

      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void bw_LoadIvitationList_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        var data = ApplicationState
          .Instance
          .InvitationClient
          .GetInvitations();

        _invitations = data.ToDictionary(data => data.InvitationId, data => data);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void bw_LoadIvitationList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Invoke(RefreshInvitationListUI);
    }
    static string FormatDuration(DateTime start, DateTime end)
    {
      TimeSpan duration = end - start;

      if (duration.TotalMinutes < 1)
      {
        return "less than a minute ago";
      }
      else if (duration.TotalHours < 1)
      {
        int minutes = (int)duration.TotalMinutes;
        return $"{minutes} minute{(minutes > 1 ? "s" : "")} ago";
      }
      else if (duration.TotalDays < 1)
      {
        int hours = (int)duration.TotalHours;
        return $"{hours} hour{(hours > 1 ? "s" : "")} ago";
      }
      else
      {
        int days = (int)duration.TotalDays;
        return $"{days} day{(days > 1 ? "s" : "")} ago";
      }
    }

  }
}
