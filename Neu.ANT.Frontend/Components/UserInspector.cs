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
  public partial class UserInspector : UserControl
  {
    CommonStateController<UserInspectorState> StateController;

    public UserInspector()
    {
      InitializeComponent();

      StateController = new CommonStateController<UserInspectorState>(this, UserInspectorState.Undefined);
      StateController.OnStateChange += HandleState;
    }

    private void HandleState(UserInspectorState state)
    {
      this.SuspendLayout();
      this.Controls.Clear();

      Control page = null;

      switch (state)
      {
        case UserInspectorState.Loading:
          break;

        case UserInspectorState.Inspect:
          break;
      }

      page.Dock = DockStyle.Fill;

      if (page is not null)
      {
        this.Controls.Add(page);
      }

      this.ResumeLayout(true);
    }

    private void UserInspect_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponent();
      StateController.SetState(UserInspectorState.Loading);
    }

    private void UserInspect_Resize(object sender, EventArgs e)
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
    }

    private void bw_LoadUserInfo_DoWork(object sender, DoWorkEventArgs e)
    {
      StateController.SetState(UserInspectorState.Loading);
      ApplicationState.Instance
        .UserInfoClient
        .FetchUserInfo();
    }

    private void bw_LoadUserInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      StateController.SetState(UserInspectorState.Inspect);
    }

    private void pn_DetailedInfo_Paint(object sender, PaintEventArgs e)
    {

    }

    public enum UserInspectorState
    {
      Undefined,
      Loading,
      Inspect
    }
  }
}
