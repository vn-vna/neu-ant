using Neu.ANT.Common.Models.ApiResponse.GroupManagement;
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

namespace Neu.ANT.Frontend.Components
{
  public partial class ChatView : UserControl
  {
    private List<ConsecutiveMessages> _msgList { get; set; }
    private Dictionary<string, MemberInfo> _members { get; set; }

    public string GroupId { get; set; }
    public string GroupName
    {
      get => lb_GroupName.Text;
      set => lb_GroupName.Text = value;
    }

    public ChatView()
    {
      _msgList = new List<ConsecutiveMessages>();
      InitializeComponent();
    }

    private void ChatView_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
      bw_FetchMessage.RunWorkerAsync();
    }

    private void ChatView_Resize(object sender, EventArgs e)
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

      foreach (var item in fpn_MessageHistory.Controls)
      {
        if (item is MessageItem)
        {
          MessageItem? messageItem = (item as MessageItem);
          messageItem.MinimumSize = new Size()
          {
            Width = this.Width - 40,
            Height = 40
          };
        }
      }

      fpn_MessageHistory.VerticalScroll.Value = fpn_MessageHistory.VerticalScroll.Maximum;
      this.ResumeLayout(true);
    }

    private void bw_FetchMessage_DoWork(object sender, DoWorkEventArgs e)
    {
      _members = ApplicationState
        .Instance
        .MessageGroupClient
        .GetMemberInfos(GroupId)
        .ToDictionary(x => x.Id);

      var messages = ApplicationState.Instance
        .MessageClient
        .GetMessage(GroupId, null, null, null);

      _msgList.Clear();
      messages.Messages.Reverse();

      foreach (var msg in messages.Messages)
      {
        if (_msgList.Count == 0 || _msgList.Last().Sender != msg.Sender)
        {
          _msgList.Add(new ConsecutiveMessages()
          {
            Sender = msg.Sender,
            Content = new List<string>() { $"{msg.SentDateTime} - {msg.Content}" }
          });
        }
        else
        {
          _msgList.Last().Content.Add($"{msg.SentDateTime} - {msg.Content}");
        }
      }
    }

    private void RefreshMessageViews()
    {
      if (_msgList.Count == 0)
      {
        return;
      }

      fpn_MessageHistory.SuspendLayout();
      fpn_MessageHistory.Controls.Clear();

      foreach (var msg in _msgList)
      {
        var msgItem = new MessageItem();
        msgItem.SenderDisplayName = _members[msg.Sender].Name;
        msgItem.Messages = msg.Content;

        fpn_MessageHistory.Controls.Add(msgItem);
      }

      fpn_MessageHistory.ResumeLayout(false);
      fpn_MessageHistory.VerticalScroll.Value = fpn_MessageHistory.VerticalScroll.Maximum;
      fpn_MessageHistory.PerformLayout();

      ResponsiveResizeComponents();
    }

    private void bw_FetchMessage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Invoke(RefreshMessageViews);
    }

    private void bw_SendMessage_DoWork(object sender, DoWorkEventArgs e)
    {
      if (string.IsNullOrEmpty(tb_MessageContent.Text))
      {
        return;
      }

      ApplicationState
        .Instance
        .MessageClient
        .SendMessage(GroupId, tb_MessageContent.Text);

      Invoke(() =>
      {
        tb_MessageContent.Text = "";
      });
    }

    private void bw_SendMessage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      bw_FetchMessage.RunWorkerAsync();
    }

    public class ConsecutiveMessages
    {
      public string Sender { get; set; }
      public List<string> Content { get; set; }
    }

    private void btn_SendMessage_Click(object sender, EventArgs e)
    {
      bw_SendMessage.RunWorkerAsync();
    }

    private void tb_MessageContent_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        bw_SendMessage.RunWorkerAsync();
      }
    }
  }
}
