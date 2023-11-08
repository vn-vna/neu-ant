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
  public partial class GroupItem : UserControl
  {
    [Description("Group name"), Category("Data")]
    public string GroupName { get => lb_Name.Text; set => lb_Name.Text = value; }

    [Description("Last message"), Category("Data")]
    public string LastMessage { get => lb_LastMessage.Text; set => lb_LastMessage.Text = value; }

    [Description("Group image"), Category("Data")]
    public Image GroupImage { get => pb_GroupImage.Image; set => pb_GroupImage.Image = value; }

    [Description("Hover color"), Category("Data")]
    public Color HoverColor { get; set; } = Color.White;

    [Description("Click color"), Category("Data")]
    public Color ClickColor { get; set; } = Color.LightGray;

    [Description("Group id"), Category("Data")]
    public string GroupId { get; set; }

    public Color FixedBackColor;

    public GroupItem()
    {
      InitializeComponent();
    }

    private void GroupItem_Load(object sender, EventArgs e)
    {
      FixedBackColor = BackColor;
    }

    public void ChangeAllBackColor(Color color)
    {
      this.BackColor = color;
      for (int i = 0; i < this.Controls.Count; i++)
      {
        this.Controls[i].BackColor = color;
      }
    }

    private void GroupItem_MouseEnter(object sender, EventArgs e)
    {
      ChangeAllBackColor(HoverColor);
    }

    private void GroupItem_MouseLeave(object sender, EventArgs e)
    {
      ChangeAllBackColor(FixedBackColor);
    }

    private void GroupItem_MouseDown(object sender, MouseEventArgs e)
    {
      ChangeAllBackColor(ClickColor);
    }

    private void GroupItem_MouseUp(object sender, MouseEventArgs e)
    {
      ChangeAllBackColor(FixedBackColor);
    }

    public delegate void GroupItemClickHandler(object sender, MouseEventArgs e);

    public new event GroupItemClickHandler Click;

    private void GroupItem_Click(object sender, MouseEventArgs e)
    {
      Click?.Invoke(this, e);
    }
  }
}
