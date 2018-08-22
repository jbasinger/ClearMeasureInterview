using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ClearMeasureLibrary;

namespace ClearMeasureTesting {
    public class TheCountingClassTest {

        private TheCountingClass counter;

        public TheCountingClassTest() {
            counter = new TheCountingClass();
        }

        [Theory]
        [InlineData(3,"Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(0, "")]
        [InlineData(-3,"")]
        [InlineData(1,"1")]
        public void TestFizzAndBuzzDivisibility(int number, string word) {

            int x = 1;
            string numberWord = "";

            IEnumerable<string> items = counter.CountUpWithFizzAndBuzz(number);

            foreach(string i in items) {
                if(x == number) {
                    numberWord = i;
                    break;
                }                
                x++;
            }

            Assert.Equal(word, numberWord);

        }

        [Fact] // A null list of pairs will give us no items
        public void TestNumberWordPairNullList() {

            IEnumerable<string> items = counter.CountUpWithNumberWordPairs(null, 100);
            Assert.Empty(items);

        }

        [Fact] // An empty list of pairs will give us no items
        public void TestNumberWordPairEmptyList() {

            IEnumerable<string> items = counter.CountUpWithNumberWordPairs(new List<NumberWordPair>(), 100);
            Assert.Empty(items);

        }

        [Fact] // A div/0 error should be thrown if a number word pair is zero.
        public void TestNumberWordPairZeroNumber() {

            List<NumberWordPair> pairs = new List<NumberWordPair>() {
                new NumberWordPair(0,"Fizz")
            };

            IEnumerable<string> items = counter.CountUpWithNumberWordPairs(pairs, 10);

            Assert.Throws<DivideByZeroException>(() => {

                //The exception isn't actually thrown until the IEnumerable is enumerated.
                foreach(string i in items) {
                    Console.Write(i);
                }

            });

        }

        [Fact] // If a number in the count is divisible by a NumberWordPair number it will print that word
               // If a number in the count is divisible by multiple NumberWordPairs it will print all the words it is divisible by
               // If a number in the count is not divisible by one of the pairs, it will print the number
        public void TestNumberWordPairList() {

            //This is setup to allow testing of any arbitrary list of NumberWordPairs
            //You can make sure the string contains the word by going through multiplication of all the pair numbers
            //Edge cases like 0 numbers are handled in other tests below

            List<NumberWordPair> pairs = new List<NumberWordPair>() {
                new NumberWordPair(3,"Fizz"),
                new NumberWordPair(5,"Buzz"),
                new NumberWordPair(8,"Ate")
            };

            int upperBound = 1;
            foreach(NumberWordPair pair in pairs) {
                upperBound *= pair.Number;
            }

            IEnumerable<string> items = counter.CountUpWithNumberWordPairs(pairs, upperBound);

            int x = 1;

            foreach(string i in items) {
                
                bool dividedByPair = false;

                foreach(NumberWordPair pair in pairs) {
                    if(pair.Number != 0 && x % pair.Number == 0) {
                        dividedByPair = true;
                        Assert.Contains(pair.Word, i);
                    }
                }
                if(!dividedByPair) {
                    Assert.Equal(x.ToString(), i);
                }

                x++;
            }

        }

        [Fact] // Things are allowed to be divisible evenly by negative numbers
        public void TestNumberWordPairListNegativeNumber() {

            List<NumberWordPair> pairs = new List<NumberWordPair>() {
                new NumberWordPair(-3,"Fizz"),
                new NumberWordPair(-5,"Buzz")
            };

            IEnumerable<string> items = counter.CountUpWithNumberWordPairs(pairs, 15);

            int x = 1;

            foreach(string i in items) {
                if(x % -3 == 0) {
                    Assert.Contains("Fizz", i);
                }
                if(x % -5 == 0) {
                    Assert.Contains("Buzz", i);
                }
                if(x % -3 != 0 && x % -5 != 0) {
                    Assert.Equal(x.ToString(), i);
                }
                x++;
            }

        }

        [Fact] // NumberWordPairs should be sorted so that the correct word comes first when printed
        public void TestOrderOfNumberWordPairList() {

            List<NumberWordPair> pairs = new List<NumberWordPair>() {
                new NumberWordPair(5,"Buzz"),
                new NumberWordPair(3,"Fizz")
            };

            IEnumerable<string> items = counter.CountUpWithNumberWordPairs(pairs, 15);

            int x = 1;

            foreach(string i in items) {
                if(x % 3 == 0 && x % 5 == 0) {
                    Assert.StartsWith("Fizz", i);
                }
                x++;
            }
        }

        [Fact] // A zero upper bound for count will give us no items
        public void TestZeroUpperBound() {
            List<NumberWordPair> pairs = new List<NumberWordPair>() {
                new NumberWordPair(3,"Fizz"),
                new NumberWordPair(5,"Buzz")
            };

            IEnumerable<string> items = counter.CountUpWithNumberWordPairs(pairs, 0);
            Assert.Empty(items);
        }

        [Fact] // A negative upper bound for count will give us no items
        public void TestNegativeUpperBound() {

            List<NumberWordPair> pairs = new List<NumberWordPair>() {
                new NumberWordPair(3,"Fizz"),
                new NumberWordPair(5,"Buzz")
            };

            IEnumerable<string> items = counter.CountUpWithNumberWordPairs(pairs, -15);
            Assert.Empty(items);

        }

    }
}
