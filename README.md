# Clear Measure Interview
Interview Assignment from Clear Measure

## Code
A small library with a class used for counting up

All functions return an IEnumerable of strings

The function `CountUpWithFizzAndBuzz` will count up to a given upper bound and if the number is divisible by 3, it will give the string "Fizz".
If the number is divisible by 5, it will give the string "Buzz". 
If it is divisible by both 3 and 5 it will give the string "FizzBuzz"
If the number isn't divisible by either, it will print that number.

The function `CountUpWithNumberWordPairs` will count up to a given upper bound, but the user can pass a list of `NumberWordPair` objects.

If the list is null or empty, an empty set will be returned.

The function will sort the `NumberWordPair` list ascending and then count up to a given bound.
If the number is divisible by any of the passed `NumberWordPair` objects, then the string returned will contain the word for any of the numbers its divisible by.

For example, if we have the following usage:
```
 TheCountingClass counting = new TheCountingClass();

  List<NumberWordPair> pairs = new List<NumberWordPair>() {
      new NumberWordPair(3,"Three")
      new NumberWordPair(4,"Four")
  };

  IEnumerable<string> items = counting.CountUpWithNumberWordPairs(pairs, 12);

  foreach(string i in items) {
      Console.WriteLine(i);
  }
```

Once the count gets to 12, it will print `Three Four`

## Building
Run the `build.bat` file to restore nuget packages, build the source and run the unit tests.