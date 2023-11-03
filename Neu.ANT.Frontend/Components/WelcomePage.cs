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
    private static Lazy<WelcomePage> _instance = new Lazy<WelcomePage>(() => new WelcomePage());

    public WelcomePage()
    {
      InitializeComponent();
      ResponsiveAlignElement();
    }

    private void ResponsiveAlignElement()
    { }

    private void button1_Click(object sender, EventArgs e)
    {
      new LoginForm().ShowDialog();
    }

    private void label4_Click(object sender, EventArgs e)
    {
      new SignUpForm().ShowDialog();
    }

    public static WelcomePage Instance => _instance.Value;
  }
}
