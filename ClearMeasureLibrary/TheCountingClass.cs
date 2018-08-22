using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearMeasureLibrary
{

    public class TheCountingClass
    {

        public IEnumerable<string> CountUpWithNumberWordPairs(List<NumberWordPair> pairs, int upperBound) {

            if(pairs == null || pairs.Count == 0 || upperBound <= 0) {
                yield break;
            }

            //It's important we sort them ascendingly so the words are in order.
            List<NumberWordPair> orderedPairs = pairs.OrderBy(x => x.Number).ToList();
            
            for(long i = 1; i < (long)upperBound + 1; i++) {

                string line = "";

                foreach(NumberWordPair pair in orderedPairs) {
                    if(i % (long)pair.Number == 0) {
                        line += pair.Word + " ";
                    }
                }

                line = line.Trim();

                if(line.Length == 0) {
                    line += i.ToString();
                }

                yield return line;

            }

        }

        public IEnumerable<string> CountUpWithFizzAndBuzz(int upperBound) {

            if(upperBound <= 0) {
                yield break;
            }

            long newUpperBound = (long)upperBound + 1;

            for(long i = 1; i < newUpperBound; i++) {

                string line = "";

                if(i % 3 == 0) {
                    line += "Fizz";
                }
                if(i % 5 == 0) {
                    line += "Buzz";
                }

                if(line.Length == 0) {
                    line += i.ToString();
                }

                yield return line.Trim();

            }

        }
    }
}
