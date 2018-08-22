using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearMeasureLibrary;

namespace ClearMeasure {
    class Program {
        static void Main(string[] args) {

            TheCountingClass counting = new TheCountingClass();

            //IEnumerable<string> items = counting.CountUpWithFizzAndBuzz(int.MaxValue);
            //IEnumerable<string> items = counting.CountUpWithFizzAndBuzz(100);

            List<NumberWordPair> pairs = new List<NumberWordPair>() {
                new NumberWordPair(0,"Fizz")
                //new NumberWordPair(5,"Buzz")
            };

            IEnumerable<string> items = counting.CountUpWithNumberWordPairs(pairs, 15);

            foreach(string i in items) {
                Console.WriteLine(i);
            }

            Console.ReadLine();

        }
    }
}
