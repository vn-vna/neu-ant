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
  public partial class MainForm : Form
  {
    private static Lazy<MainForm> _instance = new Lazy<MainForm>(() => new MainForm());
    private readonly CommonStateController<MainFormState> _stateController;

    public MainForm()
    {
      InitializeComponent();
      _stateController = new CommonStateController<MainFormState>(this, MainFormState.Undefined);
      _stateController.OnStateChange += HandleState;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      NotificationManager.Instance.FormContext = this;

      try
      {
        ApplicationState.Instance.AuthClient.LoadToken(Properties.Settings.Default.SavedToken);
        _stateController.SetState(MainFormState.AppCenter);
      }
      catch (Exception)
      {
        _stateController.SetState(MainFormState.WelcomePage);
      }
    }

    private void HandleState(MainFormState state)
    {
      this.Invoke(new Action(() =>
      {
        SuspendLayout();
        pn_Cotent.Controls.Clear();

        Control page = null;

        switch (state)
        {
          case MainFormState.WelcomePage:
            page = new WelcomePage();
            break;

          case MainFormState.AppCenter:
            page = new AppCenterPage();
            break;

          default:
            break;
        }

        if (page != null)
        {
          page.Dock = DockStyle.Fill;
          page.Visible = true;
          pn_Cotent.Controls.Add(page);
        }

        ResumeLayout(true);
      }));
    }

    public static MainForm Instance => _instance.Value;
    public CommonStateController<MainFormState> FormStateController => _stateController;

    public enum MainFormState
    {
      Undefined,
      WelcomePage,
      AppCenter
    }
  }
}
