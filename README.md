# OList
A high-performance, memory-optimized list
to reduce GC pressure. This class is intended for scenarios where performance
and memory allocation are critical.
It is not thread-safe by default yet.



The differences from the generic List<T> in .NET are as follows:

Key Differences:

1. Optimized Memory Management (Array Pooling): Instead of allocating a new array in memory each time the capacity is increased and leaving the old one for the Garbage Collector (GC), we use ArrayPool<T>. This significantly reduces the pressure on the GC, especially in scenarios where lists are frequently created, destroyed, or resized. This is the biggest difference and the main advantage of this class over the standard List<T>.

2. Use of Span<T> and Memory<T>: For AddRange operations, we use Span<T>. This structure allows us to work directly and very efficiently with a portion of memory, preventing unnecessary data copying.

3. Implementation of IAsyncEnumerable<T>: For asynchronous iteration, we implement this interface, which allows you to easily iterate over the list using await foreach. This capability is not available in the standard List<T>.

4. Support for IEnumerable<T> for foreach: For full compatibility with standard foreach loops, we provide an optimized implementation of the IEnumerable<T> and IEnumerator<T> interfaces.
