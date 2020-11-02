using System;
using System.Collections.Generic;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        //送信完了イベント
        private void Sc_SendCompleted(object sender,System.ComponentModel.AsyncCompletedEventArgs e) {
            if (e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました");
            } else {
                MessageBox.Show(e.Error?.Message??"送信完了");
            }
        }

        //送信する
        private void bt_Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage("ojsinfosys01@gmail.com", tbto.Text);
                msg.CC.Add("ojsinfosys01@gmail.com");
                msg.Bcc.Add("ojsinfosys01@gmail.com");

                msg.Subject = tbTitle.Text; //件名    
                msg.Body = tbBody.Text; //本文


                sc.Host = "smtp.gmail.com"; //SMTPサーバーの設定
                sc.Port = 587;
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("ojsinfosys01@gmail.com", "ojsInfosys2020");

                sc.Send(msg); //送信
                sc.SendMailAsync(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        //送信キャンセル
        private  void bt_Cansel_Click(object sender, RoutedEventArgs e)
        {
            if (sc!=null) {
                sc.SendAsyncCancel();
            }
           
        }
       
    }
}
