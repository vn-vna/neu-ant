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
    private static Lazy<AppCenterPage> _instance = new Lazy<AppCenterPage>(() => new AppCenterPage());

    public AppCenterPage()
    {
      InitializeComponent();
    }

    private void AppCenterPage_Load(object sender, EventArgs e)
    {

    }

    public static AppCenterPage Instance => _instance.Value;
  }
}
