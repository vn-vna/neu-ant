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
using Neu.ANT.Frontend.Forms;
using Neu.ANT.Frontend.Components;

namespace Neu.ANT.Frontend.Forms
{
  public partial class LoginForm : Form
  {
    private readonly CommonStateController<LoginFormState> _stateController;

    public LoginForm()
    {
      InitializeComponent();
      _stateController = new CommonStateController<LoginFormState>(this, LoginFormState.Undefined);
      _stateController.OnStateChange += this.HandleStateChange;
    }

    private void HandleStateChange(LoginFormState state)
    {
      pn_Content.SuspendLayout();
      pn_Content.Controls.Clear();

      switch (state)
      {
        case LoginFormState.Undefined:
          break;

        case LoginFormState.ShowLogin:
          pn_Content.Controls.Add(pn_LoginPanel);
          break;

        case LoginFormState.Loading:
          var loadingPage = new LoadingComponent();
          loadingPage.LoadingLabel = "Logging you in...";
          loadingPage.Dock = DockStyle.Fill;
          pn_Content.Controls.Add(loadingPage);
          break;
      }

      pn_Content.ResumeLayout(true);
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
      this.FormBorderStyle = FormBorderStyle.FixedDialog;

      if (Properties.Settings.Default.SavedUsername != null)
      {
        tb_Username.Text = Properties.Settings.Default.SavedUsername;
      }

      if (Properties.Settings.Default.SavedPassword != null)
      {
        tb_Password.Text = Properties.Settings.Default.SavedPassword;
      }
    }

    private void btn_SubmitLogin_Click(object sender, EventArgs e)
    {
      PerformLogin();
    }

    private void tb_Password_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Return)
      {
        PerformLogin();
      }
    }

    private void tb_Username_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Return)
      {
        PerformLogin();
      }
    }
    private void PerformLogin()
    {
      string username = this.tb_Username.Text;
      string password = this.tb_Password.Text;

      _stateController.SetState(LoginFormState.Loading);

      loginBackgrounWorker.RunWorkerAsync(new Dictionary<string, string>
      {
        {"username", username},
        {"password", password},
      });
    }

    private void loginBackgrounWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker backgroundWorker = sender as BackgroundWorker;

      Dictionary<string, string> kwParams = e.Argument as Dictionary<string, string>;

      if (kwParams is not null)
      {
        var username = kwParams["username"];
        var password = kwParams["password"];

        try
        {
          AccountState.Instance
            .AuthClient
            .SignIn(username, password);
        }
        catch (Exception ex)
        {
          MessageBox.Show(
            $"Reason: {ex.Message}",
            "Login Failed",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

          AccountState
            .Instance
            .AuthClient
            .ClearToken();

          return;
        }

        if (backgroundWorker.CancellationPending)
        {
          e.Cancel = true;
        }

      }
    }

    private void loginBackgrounWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (AccountState.Instance.AuthClient.IsAuthenticated)
      {
        this.Invoke(new Action(() =>
        {
          bool savePassword = cb_RememberLogin.Checked;

          if (savePassword)
          {
            Properties.Settings.Default.SavedToken = AccountState.Instance.AuthClient.UserToken;
            Properties.Settings.Default.SavedUsername = tb_Username.Text;
            Properties.Settings.Default.Save();
          }

          Close();
          MainForm.Instance.FormStateController.SetState(MainForm.MainFormState.AppCenter);
        }));
      }
      else
      {
        _stateController.SetState(LoginFormState.ShowLogin);
      }
    }

    public enum LoginFormState
    {
      Loading,
      ShowLogin,
      Undefined
    }
  }
}
