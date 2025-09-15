using OptimizedGenericList;

using OList<int> ols = new OList<int>();

ols.Add(10);
ols.Add(12);
ols.Add(14);
ols.Add(16);
ols.Add(18);

Console.WriteLine($"Count: {ols.Count}");
Console.WriteLine($"Capacity: {ols.Capacity}");

foreach( int i in ols ) Console.WriteLine($"Final List: item value: {i}");
