using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CollectionsGeneric.Models
{
    class MyList<T> : IEnumerable<T>
    {
        private T[] _array;
        private T[] _tempArray;
        public int Count { get { return _array.Length; } }
        public int Capacity { get; set; }

        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
        public MyList()
        {
            _array = new T[0];
        }

        public void Add(T value)
        {
            if (Capacity != Count)
            {
                _tempArray = _array;
                _array = new T[_array.Length + 1];
                for (int i = 0; i < _tempArray.Length; i++)
                {
                    _array[i] = _tempArray[i];
                }
                _array[_array.Length - 1] = value;
            }
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i].Equals(value))
                    return i;
            }
            return -1;
        }

        public void Reverse()
        {
            T temp;
            for (int i = 0; i < _array.Length / 2; i++)
            {
                temp = _array[i];
                _array[i] = _array[_array.Length - i - 1];
                _array[_array.Length - i - 1] = temp;
            }
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            RemoveAt(index);
        }

        public bool Exists(T value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array.Equals(value))
                    return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (i == index)
                {
                    _array[i] = _array[i + 1];
                    Array.Resize(ref _array, _array.Length - 1);
                }
            }
        }

        public void Insert(int index, T value)
        {
            if (Capacity != Count)
            {
                for (int i = 0; i < _array.Length - 1; i++)
                {
                    if (i == index)
                    {
                        Array.Resize(ref _array, _array.Length + 1);
                        _array[i] = _array[i + 1];
                    }
                }
                _array[index] = value;
            }
        }

        public void Clear()
        {
            Array.Resize(ref _array, 0);
        }

        private IEnumerable<T> GetValues()
        {
            foreach (var s in _array)
            {
                yield return s;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetValues().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
