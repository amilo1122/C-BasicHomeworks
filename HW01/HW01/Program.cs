using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

var arList = new List<int>();
var arArrayList = new ArrayList();
var arLinkedList = new LinkedList<int>();

Stopwatch stopWatch = new();
int collectionMax = 1000000;

//Execution time measurement for List collection
stopWatch.Start();
for (int i = 1; i <= collectionMax; i++)
{
    arList.Add(i);
}
stopWatch.Stop();
PrintElapsedTime(stopWatch, "Time spent adding items to the List collection");
//Reset stopWatch before next measurement
stopWatch.Reset();

//Execution time measurement for ArrayList collection
stopWatch.Start();
for (int i = 1; i <= collectionMax; i++)
{
    arArrayList.Add(i);
}
stopWatch.Stop();
PrintElapsedTime(stopWatch, "Time spent adding items to the ArrayList collection");
//Reset stopWatch before next measurement
stopWatch.Reset();

//Execution time measurement for LinkedList collection
stopWatch.Start();
for (int i = 1; i <= collectionMax; i++)
{
    arLinkedList.AddLast(i);
}
stopWatch.Stop();
PrintElapsedTime(stopWatch, "Time spent adding items to the LinkedList collection");
//Reset stopWatch before next measurement
stopWatch.Reset();

int searchElement;
//Find 496753-d List collection element
stopWatch.Start();
searchElement = arList[496753];
stopWatch.Stop();
PrintElapsedTime(stopWatch, "Time spent searching for the List collection"); 
//Reset stopWatch before next measurement
stopWatch.Reset();

//Find 496753-d ArrayList collection element
stopWatch.Start();
//Collecting has already sorted, but we sort it agian before using binary search in case other inputs
arArrayList.Sort();
//object searchElement1 = arArrayList[496753];
searchElement = arArrayList.BinarySearch(496753);
stopWatch.Stop();
PrintElapsedTime(stopWatch, "Time spent searching for the ArrayList collection");
//Reset stopWatch before next measurement
stopWatch.Reset();

//Find 496753-d LinkedList collection element
stopWatch.Start();
searchElement = arLinkedList.ElementAt(496753);
stopWatch.Stop();
PrintElapsedTime(stopWatch, "Time spent searching for the LinkedList collection");
//Reset stopWatch before next measurement
stopWatch.Reset();

Console.WriteLine("-------------------------");

//Printing all elmements of List that is evenly divisible by 777
stopWatch.Start();
int counter = 1;
for (int i = 0; i < collectionMax; i++)
{
    if (arList[i] % 777 == 0)
    {
        Console.Write("{0, 7} ", arList[i]);
        if (counter % 4 == 0)
        {
            Console.WriteLine();
        }
        counter++;
    }
}
Console.WriteLine("");
stopWatch.Stop();
PrintElapsedTime(stopWatch, "The time spent displaying all elmements of List collection that is evenly divisible by 777");
//Reset stopWatch before next measurement
stopWatch.Reset();
Console.WriteLine("-------------------------");

//Printing all elmements of ArrayList that is evenly divisible by 777
stopWatch.Start();
counter = 1;
for (int i = 0; i < collectionMax; i++)
{
    if (arList[i] % 777 == 0)
    {
        Console.Write("{0, 7} ", arArrayList[i]);
        if (counter % 4 == 0)
        {
            Console.WriteLine();
        }
        counter++;
    }
}
Console.WriteLine("");
stopWatch.Stop();
PrintElapsedTime(stopWatch, "The time spent displaying all elmements of ArrayList collection that is evenly divisible by 777");
//Reset stopWatch before next measurement
stopWatch.Reset();
Console.WriteLine("-------------------------");

//Printing all elmements of LinkedList that is evenly divisible by 777
stopWatch.Start();
counter = 1;
for (int i = 0; i < collectionMax; i++)
{
    if (arList[i] % 777 == 0)
    {
        Console.Write("{0, 7} ", arLinkedList.ElementAt(i));
        if (counter % 4 == 0)
        {
            Console.WriteLine();
        }
        counter++;
    }
}
Console.WriteLine("");
stopWatch.Stop();
PrintElapsedTime(stopWatch, "The time spent displaying all elmements of LinkedList collection that is evenly divisible by 777");
//Reset stopWatch before next measurement
stopWatch.Reset();
Console.WriteLine("-------------------------");

//function prints output using special string format
void PrintElapsedTime(Stopwatch stopWatch, string output)
{
    TimeSpan ts = stopWatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
    Console.WriteLine("{0}: {1}", output, elapsedTime);
}

