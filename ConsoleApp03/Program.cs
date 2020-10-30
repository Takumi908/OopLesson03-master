using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp03
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n----- 3.2.2 -----");     //\n 改行
            Console.WriteLine("都市名を入力:");
            var names = new List<string> {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong", };
                
                do {
                    var line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line)) { 
                        break;//値が空で終了
                    }
                    var index = names.FindIndex(s => s == line);
                    Console.WriteLine(index);
                } while (true);  //無限ループ

            //3-2-2
            Console.WriteLine("\n----- 3.2.2 -----");
            var count = names.Count(s => s.Contains('o'));
            Console.WriteLine(count);

            //3-2-3
            Console.WriteLine("\n----- 3.2.3 -----");
            var selected = names.Where(s => s.Contains('o')).ToArray();    //配列に格納
            foreach (var name in selected) {
                Console.WriteLine(name);

             //3-2-4
             Console.WriteLine("\n----- 3.2.3 -----");
                var nameCounts = names.Where(s => s.StartsWith("B")).Select(s => s.Length);
                foreach (var length in nameCounts) {
                    Console.WriteLine(length);
                 }
            }
        }
    }
}
                  