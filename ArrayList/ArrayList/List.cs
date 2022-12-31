using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList<T>
    {
        private T?[] ArrayList1 = new T[100000000000];
        private T?[] ArrayList2;
        private int length = 0;
        public int Length
        {
            get
            {
                return length;
            }
        }
        public T? this[int index]
        {
            get
            {
                if (index > Length)
                {
                    throw new Exception(@"Index was out of range. Must be non-negative and less than the size of the collection.Parameter name: index");
                }
                else
                {
                    return ArrayList1[index];
                }
            }
            set
            {
                if (index > Length)
                {
                    throw new Exception(@"Index was out of range. Must be non-negative and less than the size of the collection.Parameter name: index");
                }
                else
                {
                    if (Length >= ArrayList1.Length)
                    {
                        ArrayList2[index] = value;
                    }
                    else
                    {
                        ArrayList1[index] = value;
                    }
                }
            }
        }

        public void Add(T? Param)
        {
            if (Length == ArrayList1.Length)
            {
                ArrayList2 = new T[200000000000];
                ArrayList1.CopyTo(ArrayList2, 0);

                length++;
                ArrayList2[Length - 1] = Param;
            }
            else if (Length > ArrayList1.Length)
            {
                length++;
                ArrayList2[Length - 1] = Param;
            }
            else
            {
                length++;
                ArrayList1[Length - 1] = Param;
            }
        }
        public void AddRange(params T?[] Params)
        {
            if (Length == ArrayList1.Length)
            {
                ArrayList2 = new T?[2000000];
                ArrayList1.CopyTo(ArrayList2, 0);
                for (int i = 0; i < Params.Length; i++)
                {
                    length++;
                    ArrayList2[Length - 1] = Params[i];
                }
            }
            else if (Length > ArrayList1.Length)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    length++;
                    ArrayList2[Length - 1] = Params[i];
                }
            }
            else
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    length++;
                    ArrayList1[Length - 1] = Params[i];
                }
            }
        }


        public void Remove(T? Param)
        {

        }
        public void RemoveRange(params T?[] Params)
        {

        }
    }


}
