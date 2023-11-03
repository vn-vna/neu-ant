﻿using Neu.ANT.Common.Exceptions.AuthenticationClientException;
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
      try
      {
        AccountState.Instance.AuthClient.LoadToken(Properties.Settings.Default.SavedToken);
        _stateController.SetState(MainFormState.AppCenter);
      }
      catch (SignInFailedException)
      {
        _stateController.SetState(MainFormState.WelcomePage);
      }
    }

    private void MainForm_ListenState(MainFormState state)
    {
      this.Invoke(new Action(() =>
      {
        SuspendLayout();
        pn_Cotent.Controls.Clear();

        switch (state)
        {
          case MainFormState.WelcomePage:
            pn_Cotent.Controls.Add(new WelcomePage());
            break;

          case MainFormState.AppCenter:
            pn_Cotent.Controls.Add(new AppCenterPage());
            break;

          default:
            break;
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
