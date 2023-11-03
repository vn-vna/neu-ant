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
  public partial class LoadingPage : UserControl
  {

    private static Lazy<LoadingPage> _instance = new Lazy<LoadingPage>(() => new LoadingPage());
    public LoadingPage()
    {
      InitializeComponent();
    }

    public static LoadingPage Instance => _instance.Value;

    private void LoadingPage_Resize(object sender, EventArgs e)
    {
      label1.Location = new Point { X = (this.Width - label1.Width) / 2, Y = (this.Height - label1.Height) / 2 };
    }

    private void LoadingPage_Load(object sender, EventArgs e)
    {
      label1.Location = new Point { X = (this.Width - label1.Width) / 2, Y = (this.Height - label1.Height) / 2 };
    }
  }
}
