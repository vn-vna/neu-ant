using Neu.ANT.Frontend.Components;
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

namespace Neu.ANT.Frontend.Forms
{
  public partial class ChangePasswordForm : Form
  {
    public readonly CommonStateController<ChangePasswordFormState> StateController;
    private bool _isSuccess = false;

    public ChangePasswordForm()
    {
      StateController = new CommonStateController<ChangePasswordFormState>(this, ChangePasswordFormState.Undefined);
      StateController.OnStateChange += HandleState;

      InitializeComponent();
    }

    private void HandleState(ChangePasswordFormState state)
    {
      this.SuspendLayout();
      this.Controls.Clear();

      Control page = null;

      switch (state)
      {
        case ChangePasswordFormState.Loading:
          page = new LoadingComponent();
          break;
        case ChangePasswordFormState.Main:
          page = pn_Content;
          break;
      }

      if (page is not null)
      {
        page.Dock = DockStyle.Fill;
        this.Controls.Add(page);
      }

      this.ResumeLayout(true);
    }

    private void btn_SubmitChange_Click(object sender, EventArgs e)
    {
      bw_ChangePasswordRequest.RunWorkerAsync();
    }

    private void bw_ChangePasswordRequest_DoWork(object sender, DoWorkEventArgs e)
    {
      StateController.SetState(ChangePasswordFormState.Loading);

      var oldPassword = tb_OldPassword.Text;
      var newPassword = tb_NewPassword.Text;
      var confirmPassword = tb_ConfirmPassword.Text;

      if (oldPassword == "" || newPassword == "" || confirmPassword == "")
      {
        MessageBox.Show(
          "Vui lòng điền đầy đủ thông tin.",
          "Lỗi",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);

        return;
      }

      if (oldPassword == newPassword)
      {
        MessageBox.Show(
          "Mật khẩu mới không được trùng với mật khẩu cũ.",
          "Lỗi",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);

        return;
      }

      if (newPassword != confirmPassword)
      {
        MessageBox.Show(
          "Mật khẩu mới và xác nhận mật khẩu không khớp nhau.",
          "Lỗi",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);

        return;
      }

      try
      {

        ApplicationState
          .Instance
          .UserInfoClient
          .ChangePassword(oldPassword, newPassword);

        _isSuccess = true;

        MessageBox .Show(
          "Đổi mật khẩu thành công.",
          "Thành công",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
    }

    private void bw_ChangePasswordRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {

      if (_isSuccess)
      {
        this.Invoke(() =>
        {
          this.Close();
        });
      }
      else
      {
        StateController.SetState(ChangePasswordFormState.Main);
      }
    }

    public enum ChangePasswordFormState
    {
      Undefined,
      Loading,
      Main,
    }
  }
}
