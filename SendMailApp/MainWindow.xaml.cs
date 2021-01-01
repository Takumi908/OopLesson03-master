using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace SendMailApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        SmtpClient sc = new SmtpClient();
        public MainWindow()
        {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }
        public bool flag;
        //送信完了イベント
        private void Sc_SendCompleted(object sender,System.ComponentModel.AsyncCompletedEventArgs e) {
            if (e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました");
            } else {
                MessageBox.Show(e.Error?.Message??"送信完了");
            }
        }

        //送信する
        private void bt_Ok_Click(object sender, RoutedEventArgs e) {
            try {

                Config cf = (Config.GetInstace()).getStatus();
                MailMessage msg = new MailMessage(cf.MailAddress, tbTo.Text);

                msg.Subject = tbTitle.Text; //件名    
                msg.Body = tbBody.Text; //本文
                sc.Host = cf.Smtp; //SMTPサーバーの設定
                sc.Port = cf.Port;//ポート番号
                sc.EnableSsl = cf.Ssl;
                sc.Credentials = new NetworkCredential(cf.MailAddress, cf.PassWord);

                if (tbCc.Text != "") {
                    msg.CC.Add(tbCc.Text);
                }
                if (tbBcc.Text != "") {
                    msg.Bcc.Add(tbBcc.Text);
                }
                if (tbTitle.Text == "") {
                    MessageBoxResult result = MessageBox.Show("件名が入力されいてません",
                 "エラー", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK) {
                        sc.SendMailAsync(msg);
                    } 
                }
                if (tbFile != null) {

                    foreach (var item in tbFile.Items) {
                        Attachment data = new Attachment(item.ToString());
                        msg.Attachments.Add(data);
                    }
                }

              // sc.SendMailAsync(msg); //送信

                
                if (tbTo.Text != "" && tbBody.Text != "" && tbTitle.Text !="") {
                    sc.SendMailAsync(msg);
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        //送信キャンセル処理
        private  void bt_Cansel_Click(object sender, RoutedEventArgs e)
        {
            if (sc!=null) {
                sc.SendAsyncCancel();
            }
           
        }
        //設定画面表示
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog(); //閉じるまで操作ができないモーダル
        }
        //ロードしたときに実行
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            try {
                Config.GetInstace().DeSerialise();//逆シリアル化　XML⇒オブジェクト
            }
            catch (FileNotFoundException) {
                ConfigWindow configWindow = new ConfigWindow();
                configWindow.ShowDialog(); //閉じるまで操作ができないモーダル
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }           
        }

        //閉じたときに実行
        private void Window_Closed(object sender, EventArgs e) {
            try {
                Config.GetInstace().Serialise(); //シリアル化　オブジェクト⇒XML
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
        //添付ファイル追加
        private void btAdd_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                tbFile.Items.Add(ofd.FileName);
                
            }

           
        }
        //ファイル削除
        private void btDelete_Click(object sender, RoutedEventArgs e) {

            if(tbFile.SelectedIndex != -1) {
                tbFile.Items.RemoveAt(tbFile.SelectedIndex);
            }
        }
    }
}
