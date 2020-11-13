using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SendMailApp {
    public class Config {
        //単一のインスタンス
        private static Config Instance { get; set; }

        //インスタンスの取得
        public static Config GetInstace() {
            if (Instance == null) {
                Instance = new Config();
            }
            return Instance;
        }

        public string Smtp { get; set; }          //SMTPサーバー
        public string MailAddress { get; set; }  //自メールアドレス(送信元)
        public string PassWord { get; set; }    //パスワード
        public int Port { get; set; }   //ポート番号
        public bool Ssl { get; set; }　  //SSL設定


        //コンストラクタ(new禁止)
        private Config() {
        }

        //初期設定用
        public void DefalutSet() {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;

        }

        //初期値取得用
        public Config getDefaultStatus() {
            Config obj = new Config {
                Smtp = "smtp.gmail.com",
                MailAddress = "ojsinfosys01@gmail.com",
                PassWord = "ojsInfosys2020",
                Port = 587,
                Ssl = true,
            };
            return obj;
        }

        //設定データ更新
        //  public bool  UpdateStatus(Config cf) {
        public bool UpdateStatus(string smtp, int port, bool ssl, String
                                                      passWord, String mailAddress) {
            this.Smtp = smtp;
            this.Port = port;
            this.Ssl = ssl;
            this.PassWord = passWord;
            this.MailAddress = mailAddress;
            return true;
        }

        public Config getStatus() {
            Config obj = new Config {
                Smtp = this.Smtp,
                MailAddress = this.MailAddress,
                PassWord = this.PassWord,
                Port = this.Port,
                Ssl = this.Ssl,
            };
            return obj;
        }
        //シリアル化
        public void Serialise() {

            using (var mailText = XmlWriter.Create("obj.xml")) {
                var serializer = new XmlSerializer(Instance.GetType());
                serializer.Serialize(mailText, Instance);
            }
        }

        //逆シリアル化
        public void DeSerialise() {


            using (var reader = XmlReader.Create("obj.xml")) {
                var serializer = new XmlSerializer(typeof(Config));
                Instance = serializer.Deserialize(reader) as Config;
            }
        }
    }
}
