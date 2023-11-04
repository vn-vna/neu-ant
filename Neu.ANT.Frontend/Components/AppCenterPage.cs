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
  public partial class AppCenterPage : UserControl
  {
    private readonly CommonStateController<AppCenterPageState> _stateController;

    public AppCenterPage()
    {
      InitializeComponent();
      _stateController = new CommonStateController<AppCenterPageState>(this, AppCenterPageState.Undefined);
      _stateController.OnStateChange += HandleStateChange;
    }

    private void HandleStateChange(AppCenterPageState state)
    {
      pn_Content.SuspendLayout();
      pn_Content.Controls.Clear();

      btn_UserPreference.BackColor = Color.Teal;
      btn_Notification.BackColor = Color.Teal;
      btn_Group.BackColor = Color.Teal;

      Control page = null;

      switch (state)
      {
        case AppCenterPageState.UserView:
          btn_UserPreference.BackColor = Color.LightSeaGreen;
          page = new UserView();
          break;

        case AppCenterPageState.GroupView:
          btn_Group.BackColor = Color.LightSeaGreen;
          page = new GroupView();
          break;

        case AppCenterPageState.ChatView:
          pn_Content.Controls.Add(new ChatView());
          break;

        case AppCenterPageState.NotificationView:
          btn_Notification.BackColor = Color.LightSeaGreen;
          break;

        default:
          break;
      }

      if (page is not null)
      {
        page.Dock = DockStyle.Fill;
        pn_Content.Controls.Add(page);
      }

      pn_Content.ResumeLayout(true);
    }

    private void AppCenterPage_Load(object sender, EventArgs e)
    {
      _stateController.SetState(AppCenterPageState.UserView);
      ResponsiveResizeComponent();
    }
    private void AppCenterPage_Resize(object sender, EventArgs e)
    {
      ResponsiveResizeComponent();
    }

    private void ResponsiveResizeComponent()
    {
      pn_SideBar.Size = new Size()
      {
        Width = 64,
        Height = this.Height
      };

      pn_Content.Size = new Size()
      {
        Width = this.Width - 60,
        Height = this.Height,
      };

    }


    private void btn_UserPreference_Click(object sender, EventArgs e)
    {
      _stateController.SetState(AppCenterPageState.UserView);
    }

    private void btn_Group_Click(object sender, EventArgs e)
    {
      _stateController.SetState(AppCenterPageState.GroupView);
    }

    private void btn_Notification_Click(object sender, EventArgs e)
    {
      _stateController.SetState(AppCenterPageState.NotificationView);
    }

    public CommonStateController<AppCenterPageState> StateController => _stateController;

    public enum AppCenterPageState
    {
      Undefined,
      UserView,
      GroupView,
      ChatView,
      NotificationView
    }
  }
}
