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
  public partial class LoadingComponent : UserControl
  {

    private static Lazy<LoadingComponent> _instance = new Lazy<LoadingComponent>(() => new LoadingComponent());
    public LoadingComponent()
    {
      InitializeComponent();
    }

    public static LoadingComponent Instance => _instance.Value;
  }
}
