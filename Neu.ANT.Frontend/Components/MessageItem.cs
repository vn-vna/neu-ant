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
  public partial class MessageItem : UserControl
  {

    public string SenderDisplayName
    {
      get => gb_ConsecutiveMessage.Text;
      set => gb_ConsecutiveMessage.Text = value;
    }

    public List<string> Messages
    {
      get
      {
        List<string> messages = new List<string>();
        foreach (var item in fpn_ConsecutiveMessages.Controls)
        {
          if (item is Label)
          {
            messages.Add((item as Label).Text);
          }
        }

        return messages;
      }

      set
      {
        fpn_ConsecutiveMessages.SuspendLayout();

        fpn_ConsecutiveMessages.Controls.Clear();

        foreach (var item in value)
        {
          var label = new Label()
          {
            Text = item,
            AutoSize = true,
            TextAlign = ContentAlignment.MiddleLeft
          };

          fpn_ConsecutiveMessages.Controls.Add(label);
        }

        fpn_ConsecutiveMessages.ResumeLayout(false);
        fpn_ConsecutiveMessages.PerformLayout();
      }
    }

    public MessageItem()
    {
      InitializeComponent();
    }
  }
}
