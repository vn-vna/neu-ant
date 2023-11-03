using Neu.ANT.Common.Exceptions.AuthenticationClientException;
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
      _stateController.OnStateChange += MainForm_ListenState;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      _stateController.SetState(MainFormState.WelcomePage);
    }

    private void MainForm_ListenState(MainFormState state)
    {
      this.Invoke(new Action(() =>
      {
        SuspendLayout();
        panel1.Controls.Clear();

        switch (state)
        {
          case MainFormState.WelcomePage:
            panel1.Controls.Add(WelcomePage.Instance);
            break;

          case MainFormState.MainPage:
            panel1.Controls.Add(AppCenterPage.Instance);
            break;

          case MainFormState.LoadingPage:
            panel1.Controls.Add(LoadingPage.Instance);
            break;
        }

        ResumeLayout(true);
      }));
    }

    public static MainForm Instance => _instance.Value;
    public CommonStateController<MainFormState> StateController => _stateController;

    public enum MainFormState
    {
      Undefined,
      WelcomePage,
      LoadingPage,
      MainPage
    }
  }
}
