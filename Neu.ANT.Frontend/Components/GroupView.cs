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
  public partial class GroupView : UserControl
  {
    public GroupView()
    {
      InitializeComponent();
    }

    private void GroupView_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
    }

    private void GroupView_Resize(object sender, EventArgs e)
    {

      ResponsiveResizeComponents();
    }

    private void ResponsiveResizeComponents()
    {
      this.SuspendLayout();
      pn_GroupSideBar.Size = new Size()
      {
        Width = 300,
        Height = this.Height
      };

      pn_ChatViewZone.Size = new Size()
      {
        Width = this.Width - 300,
        Height = this.Height
      };
      this.ResumeLayout(true);
    }
  }
}
