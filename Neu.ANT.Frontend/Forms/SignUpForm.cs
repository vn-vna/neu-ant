using Neu.ANT.Frontend.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neu.ANT.Frontend.Forms
{
  public partial class SignUpForm : Form
  {
    public SignUpForm()
    {
      InitializeComponent();
    }

    private void SignUpForm_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      var username = tb_Username.Text;
      var password = tb_Password.Text;
      var confirmPasswod = tb_ConfirmPassword.Text;
      var tosConfirm = checkBox1.Checked;

      if (username == null || password == null)
      {
        return;
      }

      if (!IsValidUsername(username))
      {
        MessageBox.Show(
          "Tên người dùng cần có ít nhất 6 ký tự, trong đó các ký tự chỉ có thể là chữ cái tiếng anh, chữ số và dấu gạch dưới",
          "Có lỗi xảy ra",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      if (!IsValidPassword(password))
      {
        MessageBox.Show(
          "Mật khẩu phải có ít nhất 8 ký tự, trong đó có ít nhất 1 chữ thường, 1 chữ hoa, 1 chữ số và một ký tự đặc biệt",
          "Mật khẩu không hợp lệ",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      if (confirmPasswod != password)
      {
        MessageBox.Show(
          "Mật khẩu nhập lại không khớp",
          "Mật khẩu không hợp lệ",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      if (!tosConfirm)
      {
        MessageBox.Show(
          "Bạn cần phải đồng ý với điều khoản điều kiện thành viên trước khi đăng ký tài khoản",
          "Còn thiếu một bước",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      signupWorker.RunWorkerAsync(new Dictionary<string, string>
      {
        {"username", username},
        {"password", password},
      });
    }

    private void signupWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      var signupData = e.Argument as Dictionary<string, string>;

      var username = signupData["username"];
      var password = signupData["password"];

      AccountState.Instance
        .AuthClient
        .SignUp(username, password);

      MessageBox.Show(
        $"Đăng ký tài khoản thành công với username {username}. Đăng nhập ngay nào!!!",
        "Đăng ký thành công",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);

      this.Invoke(new Action(() =>
      {
        this.Close();
      }));
    }

    public static bool IsValidPassword(string password)
    {
      // Check if the password is at least 8 characters long
      if (password.Length < 8)
      {
        return false;
      }

      // Check for at least 1 lowercase letter
      if (!Regex.IsMatch(password, @"[a-z]"))
      {
        return false;
      }

      // Check for at least 1 uppercase letter
      if (!Regex.IsMatch(password, @"[A-Z]"))
      {
        return false;
      }

      // Check for at least 1 digit (number)
      if (!Regex.IsMatch(password, @"\d"))
      {
        return false;
      }

      // Check for at least 1 special character (non-alphanumeric)
      if (!Regex.IsMatch(password, @"[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]"))
      {
        return false;
      }

      // If all checks passed, the password is valid
      return true;
    }
    public static bool IsValidUsername(string username)
    {
      // Check if the username is at least 6 characters long
      if (username.Length < 6)
      {
        return false;
      }

      // Check if the username contains only English characters, numbers, and underscores
      if (!Regex.IsMatch(username, "^[a-zA-Z0-9_]+$"))
      {
        return false;
      }

      // If all checks passed, the username is valid
      return true;
    }
  }
}
