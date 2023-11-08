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
      _currentGroupId = item.GroupId;

      foreach (var control in fpn_GroupList.Controls)
      {
        GroupItem groupItem = control as GroupItem;
        groupItem.ChangeAllBackColor(pn_GroupSideBar.BackColor);
        groupItem.FixedBackColor = pn_GroupSideBar.BackColor;
      }

      item.FixedBackColor = Color.Khaki;
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
          groupItem.Width = fpn_GroupList.Width - (itemOverflow ? SystemInformation.VerticalScrollBarWidth + horizontalMargin : horizontalMargin);
        }
      }
      fpn_GroupList.ResumeLayout(true);
    }

    private void RefreshGroupList()
    {
      fpn_GroupList.SuspendLayout();

      if (fpn_GroupList.Controls.Count > 0)
      {
        fpn_GroupList.Controls.Clear();
      }

      var list = AccountState.Instance.MessageGroupClient.GroupInfos;

      if (list is not null)
      {
        foreach (var item in list)
        {
          var groupItem = new GroupItem();
          groupItem.Click += GroupItem_OnClick;
          groupItem.GroupName = item.DisplayName ?? "Unamed";
          groupItem.LastMessage = item.LatestMessages?.FirstOrDefault() ?? "---";
          groupItem.GroupId = item.GroupId;

          if (item.GroupId == _currentGroupId)
          {
            groupItem.BackColor = Color.Khaki;
          }

          fpn_GroupList.Controls.Add(groupItem);
        }
      }

      fpn_GroupList.ResumeLayout(true);

      StateController
        .SetState(GroupViewState.ShowList);
    }

    private void bw_LoadGroupList_DoWork(object sender, DoWorkEventArgs e)
    {
      StateController
        .SetState(GroupViewState.LoadingList);

      AccountState
        .Instance
        .MessageGroupClient
        .GetUserGroups();
    }

    private void bw_LoadGroupList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Invoke(() =>
      {
        RefreshGroupList();
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
