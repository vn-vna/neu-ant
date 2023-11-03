using Neu.ANT.Frontend.Forms;
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
  public partial class WelcomePage : UserControl
  {
    public WelcomePage()
    {
      InitializeComponent();
      ResponsiveAlignElement();
    }

    private void ResponsiveAlignElement()
    { }

    private void btn_SignIn_Click(object sender, EventArgs e)
    {
      new LoginForm().ShowDialog();
    }

    private void lb_SignUp_Click(object sender, EventArgs e)
    {
      new SignUpForm().ShowDialog();
    }

    private void WelcomePage_Load(object sender, EventArgs e)
    {
      this.Dock = DockStyle.Fill;
    }
  }
}
