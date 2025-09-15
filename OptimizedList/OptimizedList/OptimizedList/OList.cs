using System.Buffers;
using System.Collections;

namespace OptimizedGenericList
{
    /// <summary>
    /// A high-performance, memory-optimized list to reduce GC pressure.
    /// This class is intended for scenarios where performance and memory allocation are critical.
    /// It is not thread-safe by default yet.
    /// </summary>
    /// <typeparam name="T">The type of element in the list.</typeparam>
    public sealed class OList<T> : IEnumerable<T>, IDisposable
    {
        private T[] _items;
        private int _size;
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Gets the number of elements contained in the OptimizedList.
        /// </summary>
        public int Count => _size;
        /// <summary>
        /// Gets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        public int Capacity => _items.Length;

        /// <summary>
        /// Initializes a new instance of the OptimizedList<T> class that is empty and has the default initial capacity.
        /// </summary>
        public OList()
        {
            _items = ArrayPool<T>.Shared.Rent(DefaultCapacity);
            _size = 0;
        }

        /// <summary>
        /// Initializes a new instance of the OptimizedList<T> class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public OList(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            _items = ArrayPool<T>.Shared.Rent(capacity);
            _size = 0;
        }


        /// <summary>
        /// Adds an object to the end of the OptimizedList<T>.
        /// This operation is O(1) on average, but can be O(n) if a resize is required.
        /// </summary>
        /// <param name="item">The object to be added to the end of the OptimizedList<T>.</param>
        public void Add(T item)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _items[_size++] = item;
        }


        /// <summary>
        /// Ensures that the capacity of this list is at least the given minimum value.
        /// If the current capacity is less than min, the capacity is increased to twice the
        /// current capacity, but at least min.
        /// </summary>
        private void EnsureCapacity(int min)
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            if (newCapacity < min)
            {
                newCapacity = min;
            }

            T[] newItems = ArrayPool<T>.Shared.Rent(newCapacity);
            Array.Copy(_items, newItems, _size);
            ArrayPool<T>.Shared.Return(_items, clearArray: true);

            _items = newItems;
        }

        public void Dispose()
        {
            if (_items is not null)
            {
                ArrayPool<T>.Shared.Return(_items, clearArray: true);
                _items = null;
                _size = 0;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
