using System;
using System.Collections;
using System.Collections.Generic;

namespace Scaler.Core.DataStructures
{
    public class CyclicalList<T> : IList<T>
    {
        private List<T> list = new List<T>();
        private bool isReadOnly = false;
        public T this[int index]
        {
            get => GetByIndex(index);
            set
            {
                list[index] = value;
            }
        }

        public int Count => list.Count;

        public bool IsReadOnly => isReadOnly;

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public int IndexOf(Func<T, bool> func)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var result = func.Invoke(item);
                if (result)
                {
                    return i;
                }
            }
            return -1; // Not sure if this is what I should be returning...
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public void ForEach(int maxIterationCount, Action<T> action)
        {
            for (int i = 0; i < maxIterationCount; i++)
            {
                var item = this[i];
                action.Invoke(item);
            }
        }

        public void ForEach(int startIndex, int maxIterationCount, Action<T> action)
        {
            for (int i = startIndex; i < maxIterationCount; i++)
            {
                var item = this[i];
                action.Invoke(item);
            }
        }

        public T Find(Func<T, bool> func)
        {
            for (int i = 0; i < Count; i++)
            {
                var item = this[i];
                var result = func.Invoke(item);
                if (result) return item;
            }
            return default(T);
        }

        public void MarkReadonly()
        {
            isReadOnly = true;
        }

        private T GetByIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("index must be a positive integer.");
            }
            if (index > Count - 1)
            {
                index = CycleIndexPositive(index);
            }
            return list[index];
        }

        private int CycleIndexNegative(int index)
        {
            if (index >= 0)
            {
                return index;
            }
            var newIndex = index + Count;
            if (newIndex >= 0) return newIndex;
            return CycleIndexNegative(newIndex);
        }

        private int CycleIndexPositive(int index)
        {
            if (index < Count)
            {
                return index;
            }
            var newIndex = index - Count;
            if (newIndex < Count) return newIndex;
            return CycleIndexPositive(newIndex);
        }
    }
}
