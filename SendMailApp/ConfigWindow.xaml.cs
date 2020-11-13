using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace SendMailApp {
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window {

        public ConfigWindow() {
            InitializeComponent();
        }
        //初期値設定

        public bool flag ;

        public void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstace()).getDefaultStatus();
            //Config defaultDate =  cf.getDefaultStatus();
            tbsmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbUserName.Text = tbSender.Text =cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbssl.IsChecked = cf.Ssl;
        }
        //適用(更新)
        private void btApply_Click(object sender, RoutedEventArgs e) {
            flag = false;
                (Config.GetInstace()).UpdateStatus(
                   tbsmtp.Text,
                   int.Parse(tbPort.Text),
                   cbssl.IsChecked ?? false,
                   tbPassWord.Password,
                   tbUserName.Text);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstace()).getStatus();
            
            tbsmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbUserName.Text = tbSender.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbssl.IsChecked = cf.Ssl;
            
        }

        //OK
        private void btOK_Click(object sender, RoutedEventArgs e) {
            if (NullCheck()) {
                System.Windows.MessageBox.Show("空欄があります");            
            } else {
                btApply_Click(sender,e );
                this.Close();
            }
        }

        private bool NullCheck() {
            if (tbPassWord.Password == "" ||
                tbPort.Text == "" ||
                tbSender.Text == "" ||
                tbsmtp.Text == "" ||
                tbUserName.Text == "") {
                return true;
            } else {
                return false;
            }
        }

        //キャンセル
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            if (flag == true) {
                MessageBoxResult result = MessageBox.Show("変更が反映されていません",
                 "エラー", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK) {
                    this.Close();
                }
            } else {
             this.Close();
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e) {
            flag = true;
        }

        private void tbPassWord_PasswordChanged(object sender, RoutedEventArgs e) {
            flag = true;
        }
    }
}
