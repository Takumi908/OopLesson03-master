using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識[C#]", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            //C#チェック
            var Check = books.Count(b => b.Title.Contains("C#"));
                Console.WriteLine(Check);


            int count = 0;
            foreach (var item in books.Where(b=>b.Title.Contains("C#"))) {
                for (int i = 0; i < item.Title.Length -1; i++) {   //末尾がCだと参照中に止まってしまうので-1
                    if ((item.Title[i]=='C') && (item.Title[i+1] =='#')) {
                        count++;
                    }
                }
            }
            Console.WriteLine($"文字列[C#]の個数は{count}");
        }

        //6-2-1
        private static void Exercise2_1(List<Book> books) {
            var book = books.FirstOrDefault(b => b.Title == "ワンダフル・C#ライフ");
            if (book!= null) {
                Console.WriteLine( $"{book.Price} {book.Pages}");
            }
        }

        //6-2-2
        private static void Exercise2_2(List<Book> books) {
            var count = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(count);
        }
        //6-2-3
        private static void Exercise2_3(List<Book> books) {
            var average = books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages);
            Console.WriteLine(average);
        }
        //6-2-4
        private static void Exercise2_4(List<Book> books) {
            var book = books.FirstOrDefault(b => b.Price >= 4000);
            if (book != null) {
                Console.WriteLine(book.Title);
            }
        }
        //6-2-5
        private static void Exercise2_5(List<Book> books) {
            var pages = books.Where(b => b.Price >= 4000).Max(b => b.Price);
            Console.WriteLine(pages);
        }
        //6-2-6
        private static void Exercise2_6(List<Book> books) {
            var selected = books.Where(b => b.Price >= 4000).OrderByDescending(b => b.Price);
            foreach (var item in selected) {
                Console.WriteLine($"{0}{1}", item.Title, item.Price);
            }
        }
        //6-2-7
        private static void Exercise2_7(List<Book> books) {
            var selected = books.Where(b => b.Title.Contains("C#") && b.Pages <= 500);
            foreach (var item in books) {
                Console.WriteLine(item.Title);
            }
        }
    }
}
