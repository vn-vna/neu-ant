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
  public partial class UserView : UserControl
  {
    public UserView()
    {
      InitializeComponent();
    }

    private void UserView_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponent();
    }

    private void UserView_Resize(object sender, EventArgs e)
    {
      ResponsiveResizeComponent();
    }

    private void ResponsiveResizeComponent()
    {
      pn_Summaries.Size = new Size()
      {
        Width = 300,
        Height = this.Height
      };

      pn_SummariesInner.Location = new Point()
      {
        X = (pn_Summaries.Width - pn_SummariesInner.Width) / 2,
        Y = (pn_Summaries.Height - pn_SummariesInner.Height) / 2,
      };

      pn_DetailedInfo.Size = new Size()
      {
        Width = this.Width - 300,
        Height = this.Height
      };

      pn_DetailedInfoInner.Location = new Point()
      {
        X = (pn_DetailedInfo.Width - pn_DetailedInfoInner.Width) / 2,
        Y = (pn_DetailedInfo.Height - pn_DetailedInfoInner.Height) / 2,
      };
    }
  }
}
