using Neu.ANT.Frontend.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neu.ANT.Frontend.Forms
{
  public partial class NotificationForm : Form
  {
    public DateTime Time { get; set; }

    public string Title
    {
      get { return lb_Title.Text; }
      set { lb_Title.Text = value; }
    }

    public string Message
    {
      get { return lb_Message.Text; }
      set { lb_Message.Text = value; }
    }

    public NotificationForm()
    {
      InitializeComponent();
    }

    private void btn_Close_Click(object sender, EventArgs e)
    {
      NotificationManager
        .Instance
        .CloseNotification(this);
    }
  }
}
