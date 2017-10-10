using System;

namespace CollectionsAndGenerics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GenericType1 gt1 = new GenericType1();
            gt1.Add(10);
            gt1.Add("value");
            gt1.Add(2.5);

            var val = gt1[1];
            Console.WriteLine(val);
        }
    }

    public class GenericType1
    {
        object[] elements;
        int count;

        public GenericType1()
        {
            elements = new object[5];
        }

        public object this[int index]
        {
            get{ return elements[index];}
            set { elements[index] = value; }
        }

        public void Add(object parametr)
        {
            if (count == elements.Length)
            {
                object[] tmpArray = null;
				elements.CopyTo(tmpArray, 0);
				elements = new object[count * 2];
				elements = tmpArray;
			}

            elements[count] = parametr;
            count = count + 1;
        }
    }
}
