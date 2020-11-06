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
        
        public void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstace()).getDefaultStatus();
            //Config defaultDate =  cf.getDefaultStatus();
            tbsmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbssl.IsChecked = cf.Ssl;
        }
        //適用(更新)
        private void btApply_Click(object sender, RoutedEventArgs e) {
            (Config.GetInstace()).UpdateStatus(
               tbsmtp.Text,
               int.Parse(tbPort.Text),
               cbssl.IsChecked ?? false,
               tbPassWord.Password,
               tbUserName.Text);
        }       
    }
}
