using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chapter05 {
    class Program {
        static void Main(string[] args) {
            string mozi = "Jackdaws love my big sphinx of quartz ";
            var lines = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            /*
            //5-1-1
            String mozia, mozib;
            Console.Write("文字列1:");
            mozia = Console.ReadLine();
            Console.Write("文字列2:");
            mozib = Console.ReadLine();

            if (String.Compare(mozia,mozib,true)== 0) {  //大文字小文字を無視して判定
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
             
              
            //5-1-2
            Console.Write("文字列:");
            var line = Console.ReadLine();
            int num;    //変換後の数値格納
            if(int.TryParse(line,out num)) {
                Console.WriteLine(num.ToString("#,#"));   //カンマの入力
            } else {
                Console.WriteLine("数値文字列ではありません");
            }
               */

            //5-3-1
            var count = mozi.Count(m => m == ' ');
            Console.WriteLine($"空白は{count}文字です。");

            //5-3-2
            var replaced = mozi.Replace("big", "small");
            Console.WriteLine(replaced);

            //5-3-3
            var words = mozi.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"文字列moziは{words.Length}個の単語です");

            //5-3-4
            var fors = mozi.Split(' ').Where(w => w.Length <= 4);
            foreach (var item in fors) {
                Console.WriteLine(item);
            }

            //5-3-5
            var renkt = mozi.Split(' ').ToArray();
            var sb = new StringBuilder();
            foreach (var item in renkt) {
                sb.Append(item);
            }
            var text = sb.ToString();
            Console.WriteLine(text);

            //5-4
            Console.WriteLine("---5-4---");
            foreach (var item in lines.Split(';')) {
                var word = item.Split('=');
                Console.WriteLine("{0};{1}", ToJapanse(word[0]),word[1]);
            }
        }
            static string ToJapanse(string key) {
                switch (key) {
                    case "Novelist":
                        return "作家　";
                    case "BestWork":
                        return "代表策";
                    case "Born":
                        return "誕生年";
                    default:
                        return "      ";
            }
        }
    }
}
