using System;
using System.Collections.ObjectModel;

namespace CollectionsAndGenerics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("C# 1.0");
            GenericType1 list1 = new GenericType1();
            list1.Add(10);                                            //boxed
			list1.Add("value");
            list1.Add(2.5);                                           //boxed

			var val = list1[1];                                       //No Casting Required
			Console.WriteLine(val);

			Console.WriteLine("\nC# 2.0");
            GenericType2<double> list2 = new GenericType2<double>();

            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            // list2.Add("four");                                       //Compile Error

            int valGeneric = (int)list2[0];                             //Casting Required
			Console.WriteLine(valGeneric);


			ObservableCollection<Person> people = new ObservableCollection<Person>()
		{
			new Person(19,"Peter","Jonson"),
			new Person(45, "Luck", "McConly"),
			new Person(32, "Jan", "Janovski")
		};

            people.CollectionChanged += ObservableClass.ObservableHandler;

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

    public class GenericType2<T>
    {
        private T[] elements;
        private int count;

        public GenericType2()
        {
            elements = new T[5];
        }

		public T this[int index]
		{
			get { return elements[index]; }
			set { elements[index] = value; }
		}

        public void Add( T prm)
        {
            if (count == elements.Length)
            {
                T[] tmpArr = null;
                elements.CopyTo(tmpArr, 0);
                elements = new T[count * 2];
                elements = tmpArr;
            }

            elements[count] = prm;
            count = count + 1;
        }
	}

    public class ObservableClass
    {
        public static void ObservableHandler(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection is amended!!!");
            Console.WriteLine("Action for this event : {0}", e.Action);

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
			Console.WriteLine();

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
			{
                foreach (Person p in e.NewItems)
				{
					Console.WriteLine(p.ToString());
				}
			}
        }
    }

    internal class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(int age, string firstName, string lastName)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
