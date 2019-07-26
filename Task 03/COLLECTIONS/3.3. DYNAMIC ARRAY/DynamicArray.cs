using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.DYNAMIC_ARRAY
{
    class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        #region FIELDS
        protected T[] arr;
        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value;
                  Array.Resize(ref arr, capacity);}
        }
        #endregion

        #region CONSTRUCTORS
        public DynamicArray()
        {
            arr = new T[8];
            capacity = 8;
        }
        public DynamicArray(int n)
        {
            arr = new T[n];
            capacity = n;
        }
        public DynamicArray(IEnumerable<T> collect)
        {
            AddRange(collect);
        }
        #endregion

        #region INDEXATOR
        public T this[int index]
        {
            get
            {
                if (-length + 1 < index && index < 0 ) {
                    return arr[length + index];
                } else if(index < -length + 1 && length-1 < index) {
                    throw new ArgumentOutOfRangeException();
                }
                else { return arr[index]; }
            }
            set
            {
                if (-length + 1 < index && index < 0)
                {
                    arr[length + index] = value;
                }
                else if (index < -length + 1 && length - 1 < index)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else { arr[index] = value; }
            }
        }
        #endregion

        #region ADD
        public void Add(T elem)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    arr[i] = elem;
                    length = i + 1;
                    break;
                }
                if(i == arr.Length - 1)
                {
                    Array.Resize(ref arr, capacity*2);
                    arr[length] = elem;
                    length = length + 1;
                    capacity *= 2;
                    //проиходит увеличение capacity в два раза -- по условию задания
                }
            }
        }
        #endregion

        #region ADD_RANGE
        public void AddRange(IEnumerable<T> collect)
        {
            int lengthCollect = 0;
            foreach (T item in collect)
            {
                lengthCollect++;
            }
            if (length + lengthCollect > capacity)
            {
                Array.Resize(ref arr, capacity + lengthCollect + 5);
            }// число 5 просто для заблаговременного увеличения capacity -
            //- если вдруг понадобится потом вставить какие-либо одиночные элементы
            foreach (var elem in collect)
            {
                arr[Length] = elem;
                Length++;
            }
        }
        public bool Remove(T elem)
        {
            T [] spareArr = new T [capacity];
            int k = 0;
            for (int i = 0; i < length; i++)
            {
                if (!arr[i].Equals(elem))
                {
                    spareArr[i] = arr[i];
                }
                else { k++; }
            }
            Array.Copy(spareArr, 0, arr, 0, spareArr.Length);
            length = length - k;
            return true;
        }
        #endregion

        #region REMOVE_AT
        public void RemoveAt(int index)
        {
            T[] spareArr = new T[capacity];
            int k = 0;
            for (int i = index; i < capacity && i + 1 != capacity; i++)
            {
                arr[i] = arr[i + 1];
                if (i == capacity - 2)
                {
                    arr[i + 1] = default(T);
                }
            }
            length = length - 1;
        }
        #endregion

        #region INSERT
        public bool Insert(int index, T elem)
        {
            try
            {
                length += 1;
                if (index > capacity - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (length > capacity)
                {
                    Array.Resize(ref arr, capacity * 2);
                    capacity *= 2;
                }
                for (int i = length; i > index; i--)
                {
                    arr[i] = arr[i - 1];
                }
                return true;
            }
            catch (OutOfMemoryException ex) 
            { return false; }
            catch (ArgumentOutOfRangeException ex)
            { return false; }
            }
        #endregion

        #region GET_ENUMERATOR
        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < length; i++)
            {
                yield return arr[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region CLONE

        object ICloneable.Clone()
        {
            List<T> collect = new List<T>();
            for (int i=0; i<Length; i++)
            {
                collect.Add(arr[i]);
            }
            return new DynamicArray<T>(collect);
        }
        #endregion

        #region TO_ARRAY
        public T[] ToArray()
        {
            T[] newArr = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }
        #endregion
    }
}
