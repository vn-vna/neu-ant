using Neu.ANT.Common.Models.ApiResponse.UserData;
using Neu.ANT.Frontend.Forms;
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
  public partial class UserView : UserControl
  {
    private CommonStateController<UserViewState> StateController;
    private UserDataView _userData;

    public UserView()
    {
      StateController = new CommonStateController<UserViewState>(this, UserViewState.Undefined);
      InitializeComponent();

      StateController.OnStateChange += HandleState;
    }

    private void HandleState(UserViewState state)
    {
      this.SuspendLayout();
      this.Controls.Clear();

      Control page = null;

      switch (state)
      {
        case UserViewState.Viewing:
          page = pn_Content;
          ResetComponentsData();
          break;

        case UserViewState.Loading:
          var loading = new LoadingComponent();
          loading.LoadingLabel = "Loading user data...";
          page = loading;
          break;
      }

      if (page is not null)
      {
        page.Dock = DockStyle.Fill;
        this.Controls.Add(page);
      }

      this.ResumeLayout(true);
    }

    private void ResetComponentsData()
    {
      _userData = ApplicationState.Instance.UserInfoClient.UserData;

      var name = $"{_userData.FirstName} {_userData.LastName}".Trim();
      if (string.IsNullOrEmpty(name))
      {
        name = "Không có tên";
      }

      lb_DisplayName.Text = name;
      lb_SummaryUsername.Text = $"@{_userData.UserName}";
      tb_FirstName.Text = _userData.FirstName;
      tb_LastName.Text = _userData.LastName;

      if (_userData.BirthDate.HasValue)
      {
        dtp_BirthDate.Value = _userData.BirthDate.Value;
      }

      rb_Male.Checked = _userData.Gender == 1;
      rb_Female.Checked = _userData.Gender == 2;
      rb_Undefined.Checked = _userData.Gender == 0;

      lb_DetailUsername.Text = $"@{_userData.UserName}";
    }

    private void UserView_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponent();
      bw_LoadUserData.RunWorkerAsync();
    }

    private void UserView_Resize(object sender, EventArgs e)
    {
      ResponsiveResizeComponent();
    }

    private void ResponsiveResizeComponent()
    {
      pn_Summaries.Size = new Size()
      {
        Width = 300,
        Height = this.Height
      };

      pn_SummariesInner.Location = new Point()
      {
        X = (pn_Summaries.Width - pn_SummariesInner.Width) / 2,
        Y = (pn_Summaries.Height - pn_SummariesInner.Height) / 2,
      };

      pn_DetailedInfo.Size = new Size()
      {
        Width = this.Width - 300,
        Height = this.Height
      };

      pn_DetailedInfoInner.Location = new Point()
      {
        X = (pn_DetailedInfo.Width - pn_DetailedInfoInner.Width) / 2,
        Y = (pn_DetailedInfo.Height - pn_DetailedInfoInner.Height) / 2,
      };
    }

    private void lb_LogOut_Click(object sender, EventArgs e)
    {
      Properties.Settings.Default.SavedToken = null;
      Properties.Settings.Default.Save();

      MainForm.Instance
        .FormStateController
        .SetState(MainForm.MainFormState.WelcomePage);

      ApplicationState
        .Instance
        .MessageGroupClient
        .ClearData();
    }

    private void bw_LoadUserData_DoWork(object sender, DoWorkEventArgs e)
    {
      StateController.SetState(UserViewState.Loading);
      ApplicationState
        .Instance
        .UserInfoClient
        .FetchUserInfo();
    }

    private void bw_LoadUserData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      StateController.SetState(UserViewState.Viewing);
    }

    private void lb_DisplayName_Resize(object sender, EventArgs e)
    {
      lb_DisplayName.Location = new Point()
      {
        X = (pn_SummariesInner.Width - lb_DisplayName.Width) / 2,
        Y = lb_DisplayName.Location.Y
      };
    }

    private void lb_Username_Resize(object sender, EventArgs e)
    {
      lb_SummaryUsername.Location = new Point()
      {
        X = (pn_SummariesInner.Width - lb_SummaryUsername.Width) / 2,
        Y = lb_SummaryUsername.Location.Y
      };
    }

    private void btn_Reset_Click(object sender, EventArgs e)
    {
      bw_LoadUserData.RunWorkerAsync();
    }

    private void btn_ChangePassword_Click(object sender, EventArgs e)
    {
      new ChangePasswordForm().ShowDialog();
    }

    private void btn_SaveChanges_Click(object sender, EventArgs e)
    {
      bw_UpdateUserData.RunWorkerAsync();
    }

    private void bw_UpdateUserData_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        var firstName = tb_FirstName.Text;
        var lastName = tb_LastName.Text;
        var birthDate = dtp_BirthDate.Value;
        int gender = 0;

        if (rb_Female.Checked)
        {
          gender = 2;
        }
        else if (rb_Male.Checked)
        {
          gender = 1;
        }

        ApplicationState
          .Instance
          .UserInfoClient
          .UpdateUserData(firstName, lastName, birthDate, gender);
      }
      catch (Exception ex)
      {
        MessageBox.Show(
          $"Cập nhật thông tin thất bại. Lý do: {ex.Message}",
          "Lỗi",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
      }
    }

    private void bw_UpdateUserData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      bw_LoadUserData.RunWorkerAsync();
    }

    public enum UserViewState
    {
      Undefined,
      Loading,
      Viewing
    }
  }
}
