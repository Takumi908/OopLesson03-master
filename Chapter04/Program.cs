using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04 {
    class Program {
        static void Main(string[] args) {

            //4-2-1
            //配列の宣言 
            var ymCollection = new YearMonth[] {  //YearMonthを要素として持つ配列
                new YearMonth(1980,1),
                new YearMonth(1990,4),
                new YearMonth(2000,7),
                new YearMonth(2010,9),
                new YearMonth(2020,12),
            };

            // 4.2.2(呼び出し)
            Console.WriteLine("-- 4.2.2 --");
            Exercise2_2(ymCollection);
            Console.WriteLine("-----------\n");

            // 4.2.4(呼び出し)
            Console.WriteLine("-- 4.2.4 --");
            Exercise2_4(ymCollection);
            Console.WriteLine("-----------\n");

            // 4.2.5(呼び出し)
            Console.WriteLine("-- 4.2.5 --");
            Exercise2_5(ymCollection);
            Console.WriteLine("-----------\n");




            //4-2-2
            private static void Exercise2_2(YearMonth[] ymCollection) {
                foreach (var item in ymCollection) {
                    Console.WriteLine(item);
                }
            }

            //4-2-3
            static YearMonth FindFirst21C(YearMonth[] yms) {
                foreach (var item in yms) {
                    if (item.Is21Century)
                        return item;
                }
                return null;
            }
            //4-2-4
            private static void Exercise2_4(YearMonth[] ymCollection) {
                var yearmonth = FindFirst21C(ymCollection);
#if true
                var s = yearmonth == null ? "21世紀のデータはありません" : yearmonth.ToString();
                Console.WriteLine(s);
#else
                if (yearmonth == null)
	                Console.WriteLin("21世紀のデータはありません");  
                else
                    Console.WriteLine(yearmonth);

#endif
            }
            //4-2-5
            private static void Exercise2_5(YearMonth[] ymColletion) {
                var array = ymCollection.Select(ym => ym.AddMonth()).ToArray();
                foreach (var ym in array) {
                    Console.WriteLine(ym);
                }
            }
        }
    }
}