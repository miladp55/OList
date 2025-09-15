using OptimizedGenericList;

using OList<int> ols = new OList<int>();

ols.Add(10);
ols.Add(12);
ols.Add(14);
ols.Add(16);
ols.Add(18);


ols.AddRange(new[] { 30, 40, 50 });

Console.WriteLine($"Count: {ols.Count}");
Console.WriteLine($"Capacity: {ols.Capacity}");

foreach( int i in ols ) Console.WriteLine($"Final List: item value: {i}");



// Synchronous iteration
Console.WriteLine("Sync foreach:");
foreach (var item in ols)
{
    Console.WriteLine(item);
}

// Asynchronous iteration (a feature not in the standard List<T>)
Console.WriteLine("\nAsync foreach:");
await foreach (var item in ols)
{
    Console.WriteLine(item);
}

Console.ReadKey();