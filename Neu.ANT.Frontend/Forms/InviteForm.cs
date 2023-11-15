using Neu.ANT.Common.Models.ApiResponse.UserData;
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

namespace Neu.ANT.Frontend.Forms
{
  public partial class InviteForm : Form
  {
    public string GroupId { get; set; }

    private DateTime _lastChange;
    private bool _changed = false;
    private Dictionary<string, string> _userMapping;

    public InviteForm()
    {
      InitializeComponent();
    }

    private void tb_Username_TextChanged(object sender, EventArgs e)
    {
      _lastChange = DateTime.Now;
      _changed = true;
    }

    private void RefreshUsernameList()
    {
      fpn_SearchResult.SuspendLayout();
      fpn_SearchResult.Controls.Clear();

      if (_userMapping is not null)
      {
        foreach (var identity in _userMapping)
        {
          var item = new Button()
          {
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0 },
            Width = fpn_SearchResult.Width,
            Height = 30,
            Margin = Padding.Empty,
            Text = identity.Key,
            TextAlign = ContentAlignment.MiddleLeft
          };

          item.Click += BtnSearchResult_OnClick;

          fpn_SearchResult.Controls.Add(item);
        }
      }

      fpn_SearchResult.ResumeLayout(false);
      fpn_SearchResult.PerformLayout();
    }

    private void BtnSearchResult_OnClick(object sender, EventArgs e)
    {
      var btn = sender as Button;
      var username = btn.Text;

      bw_InviteUser.RunWorkerAsync(_userMapping[btn.Text]);
    }

    private void bw_AutoSearchUsername_DoWork(object sender, DoWorkEventArgs e)
    {
      while (true)
      {
        if (bw_AutoSearchUsername.CancellationPending)
        {
          e.Cancel = true;
          return;
        }

        if (_changed && DateTime.Now.Subtract(_lastChange).TotalMilliseconds > 1000)
        {
          try
          {

            _userMapping = ApplicationState
              .Instance
              .UserInfoClient
              .SearchUsername(tb_Username.Text)
              .ToDictionary(m => m.UserName, m => m.Id);

            Invoke(RefreshUsernameList);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

          _changed = false;
        }

        Thread.Sleep(100);
      }
    }

    private void InviteForm_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void InviteForm_Load(object sender, EventArgs e)
    {
      bw_AutoSearchUsername.RunWorkerAsync();
    }

    private void bw_InviteUser_DoWork(object sender, DoWorkEventArgs e)
    {
      string uid = e.Argument as string;

      try
      {
        ApplicationState
          .Instance
          .InvitationClient
          .CreateInvite(GroupId, uid);
      }
      catch (Exception ex)
      {
        MessageBox.Show(
          ex.Message,
          "Lỗi",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
      }
    }
  }
}
