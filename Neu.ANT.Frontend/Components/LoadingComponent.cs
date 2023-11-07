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
    [Category("Loading"), Description("Set loading text")]
    public string LoadingLabel
    {
      get => lb_LoadingText.Text;
      set { lb_LoadingText.Text = value; }
    }

    public LoadingComponent()
    {
      InitializeComponent();
    }

    private void LoadingComponent_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
    }

    private void LoadingComponent_Resize(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
    }

    private void ResponsiveResizeComponents()
    {
      pn_Inner.Location = new Point()
      {
        X = (pn_Content.Width - pn_Inner.Width) / 2,
        Y = (pn_Content.Height - pn_Inner.Height) / 2
      };

      lb_LoadingText.Location = new Point()
      {
        X = (pn_Inner.Width - lb_LoadingText.Width) / 2,
        Y = lb_LoadingText.Location.Y
      };
    }

  }
}
