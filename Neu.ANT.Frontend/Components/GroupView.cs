using Neu.ANT.Frontend.Forms;
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
  public partial class GroupView : UserControl
  {
    private CommonStateController<GroupViewState> StateController;
    private string _currentGroupId;

    public GroupView()
    {
      StateController = new CommonStateController<GroupViewState>(this, GroupViewState.Undefined);
      StateController.OnStateChange += HandleState;
      InitializeComponent();
    }

    private void HandleState(GroupViewState state)
    {
      pn_GroupSideBar.SuspendLayout();
      pn_GroupSideBar.Controls.Clear();

      switch (state)
      {
        case GroupViewState.ShowList:
        case GroupViewState.ShowMessages:
          pn_GroupSideBar.Controls.Add(fpn_GroupList);
          pn_GroupSideBar.Controls.Add(btn_AddGroup);
          break;

        case GroupViewState.LoadingList:
          var loading = new LoadingComponent();
          loading.LoadingLabel = "Loading group list...";
          loading.Dock = DockStyle.Fill;
          pn_GroupSideBar.Controls.Add(loading);
          break;
      }
      pn_GroupSideBar.ResumeLayout(true);


      pn_ChatViewZone.SuspendLayout();
      pn_ChatViewZone.Controls.Clear();

      switch (state)
      {
        case GroupViewState.ShowMessages:
          pn_ChatViewZone.Controls.Add(pn_ChatViewZone);
          break;
      }

      pn_ChatViewZone.ResumeLayout(true);
    }

    private void GroupView_Load(object sender, EventArgs e)
    {
      ResponsiveResizeComponents();
      StateController.SetState(GroupViewState.LoadingList);
      bw_LoadGroupList.RunWorkerAsync();
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

      fpn_GroupList.Size = new Size()
      {
        Width = pn_GroupSideBar.Width,
        Height = pn_GroupSideBar.Height - btn_AddGroup.Height
      };

      pn_ChatViewZone.Size = new Size()
      {
        Width = this.Width - 300,
        Height = this.Height
      };
      this.ResumeLayout(true);
    }

    private void fpn_GroupList_Scroll(object sender, ScrollEventArgs e)
    {

    }

    private void GroupItem_OnClick(object sender, EventArgs e)
    {
      GroupItem item = sender as GroupItem;
      if (_currentGroupId == item.GroupId)
      {
        return;
      }

      _currentGroupId = item.GroupId;

      foreach (var control in fpn_GroupList.Controls)
      {
        GroupItem groupItem = control as GroupItem;
        groupItem.ChangeAllBackColor(pn_GroupSideBar.BackColor);
        groupItem.FixedBackColor = pn_GroupSideBar.BackColor;
      }

      item.FixedBackColor = Color.Khaki;

      pn_ChatViewZone.SuspendLayout();
      pn_ChatViewZone.Controls.Clear();

      var chatView = new ChatView
      {
        GroupName = item.GroupName,
        GroupId = item.GroupId,
        Dock = DockStyle.Fill
      };

      pn_ChatViewZone.Controls.Add(chatView);

      pn_ChatViewZone.ResumeLayout(false);
      pn_ChatViewZone.PerformLayout();
    }

    private void fpn_GroupList_Resize(object sender, EventArgs e)
    {
      fpn_GroupList.SuspendLayout();
      int totalHeight = 0;

      foreach (var item in fpn_GroupList.Controls)
      {
        if (item is GroupItem)
        {
          GroupItem groupItem = item as GroupItem;
          totalHeight += groupItem.Height + groupItem.Margin.Top + groupItem.Margin.Bottom;
        }
      }

      var itemOverflow = totalHeight > fpn_GroupList.Height;

      foreach (var item in fpn_GroupList.Controls)
      {
        if (item is GroupItem)
        {
          GroupItem groupItem = item as GroupItem;
          var horizontalMargin = groupItem.Margin.Left + groupItem.Margin.Right;
          groupItem.MinimumSize = new Size()
          {
            Width = fpn_GroupList.Width - (itemOverflow ? SystemInformation.VerticalScrollBarWidth + horizontalMargin : horizontalMargin),
            Height = groupItem.Height
          };
        }
      }
      fpn_GroupList.ResumeLayout(true);
    }

    private void RefreshGroupListUI()
    {
      fpn_GroupList.SuspendLayout();

      var controlMap = fpn_GroupList.Controls
        .Cast<GroupItem>()
        .ToDictionary(x => x.GroupId, x => x);

      var list = ApplicationState.Instance.MessageGroupClient.GroupInfos;

      if (list is not null)
      {
        foreach (var item in list)
        {
          var hasLatestMessage = item.LatestMessage.Content is not null;
          var latestMsgDisp = hasLatestMessage ? $"{item.LatestMessage.SenderName ?? $"@{item.LatestMessage.SenderUsername}"}: {item.LatestMessage.Content}" : "Không có tin nhắn nào";

          if (controlMap.ContainsKey(item.GroupId))
          {
            var groupItem = controlMap[item.GroupId];
            groupItem.GroupName = item.DisplayName;
            groupItem.GroupId = item.GroupId;

            groupItem.LastMessage = latestMsgDisp;
          }
          else
          {

            var groupItem = new GroupItem()
            {
              GroupName = item.DisplayName,
              GroupId = item.GroupId,
              LastMessage = latestMsgDisp,
              Dock = DockStyle.Top,
              MinimumSize = new Size()
              {
                Width = fpn_GroupList.Width,
                Height = 50
              }
            };

            groupItem.Click += GroupItem_OnClick;

            fpn_GroupList.Controls.Add(groupItem);
            controlMap.Add(item.GroupId, groupItem);
          }
        }

        for (int i = 0; i < list.Count; i++)
        {
          fpn_GroupList.Controls.SetChildIndex(controlMap[list[i].GroupId], i);
        }
      }

      ResponsiveResizeComponents();

      fpn_GroupList.ResumeLayout(true);

      StateController
        .SetState(GroupViewState.ShowList);
    }

    private void bw_LoadGroupList_DoWork(object sender, DoWorkEventArgs e)
    {
      ApplicationState
        .Instance
        .MessageGroupClient
        .GetUserGroups();
    }

    private void bw_LoadGroupList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Invoke(() =>
      {
        RefreshGroupListUI();
      });
    }

    private void btn_AddGroup_Click(object sender, EventArgs e)
    {
      new CreateChatGroupForm().ShowDialog();
      bw_LoadGroupList.RunWorkerAsync();
    }

    public enum GroupViewState
    {
      Undefined,
      LoadingList,
      ShowList,
      ShowMessages
    }
  }
}
