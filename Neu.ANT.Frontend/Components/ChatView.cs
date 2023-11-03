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
  public partial class ChatView : UserControl
  {
    public ChatView()
    {
      InitializeComponent();
    }

    private void ChatView_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
    }

    private void pn_MsgHistory_Resize(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
    }

    private void ResponsiveResizeComponents()
    {
      this.SuspendLayout();
      pn_Header.Size = new Size()
      {
        Width = this.Width,
        Height = 40
      };

      pn_Footer.Size = new Size()
      {
        Width = this.Width,
        Height = 40
      };

      pn_TextBox.Size = new Size()
      {
        Width = this.Width - 40,
        Height = 40
      };

      this.ResumeLayout(true);
    }
  }
}
