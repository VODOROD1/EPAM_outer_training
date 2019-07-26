using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.DYNAMIC_ARRAY
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base() { }
        public CycledDynamicArray(int capacity) : base(capacity) { }
        public CycledDynamicArray(IEnumerable<T> collect): base(collect) { }
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= Length; i++)
            {
                if (i == Length) { i = 0; }
                yield return arr[i];
            }
        }
    }
}
