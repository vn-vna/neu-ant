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
  public partial class CreateChatGroupForm : Form
  {
    private bool _isSuccess = false;

    public CreateChatGroupForm()
    {
      InitializeComponent();
    }

    private void btn_Create_Click(object sender, EventArgs e)
    {
      bw_CreateGroup.RunWorkerAsync();
    }

    private void bw_CreateGroup_DoWork(object sender, DoWorkEventArgs e)
    {
      var groupName = tb_newGroupName.Text;

      if (string.IsNullOrEmpty(groupName))
      {
        MessageBox.Show("Group name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      AccountState
        .Instance
        .MessageGroupClient
        .CreateGroup(groupName);

      _isSuccess = true;
    }

    private void bw_CreateGroup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (_isSuccess)
      {
        Invoke(() =>
        {
          this.Close();
        });
      } 
    }
  }
}
