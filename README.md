# MostFrequentTriplet
MostFrequentTriplet Fuction

## Demo
```C#

static void Main()
{
    string input = "woof, woof, meow, meow";
    CancellationTokenSource cts = new CancellationTokenSource();
    CancellationToken cancelToken = cts.Token;
    Console.WriteLine(MostFrequentTriplet(input, cancelToken));
}


```
