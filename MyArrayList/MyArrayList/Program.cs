using System;
using System.Collections.Generic;


namespace MyArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList1<int> list = new LinkedList1<int>();

            list.ListAdded += delegate (object o, ArrayChangedEvent<int> arg)
            {
                Console.WriteLine($"A new data was added to the list: {arg.Data}");
            };

            list.Add(1);
            list.Add(2);
            list.Add(7);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(7);
            list.Add(3);
            list.Add(6);
          /*  Console.WriteLine($"First list");
            foreach (int l in list)
            {
                Console.WriteLine($"{l}");
            }
            list.Remove(4);
            Console.WriteLine($"After remove 4 in list");
            foreach (int l in list)
            {
                Console.WriteLine($"{l}");
            }
            Console.WriteLine($"Index of 5 is: {list.IndexOf(5)}");
            Console.WriteLine($"Index of 10 is: {list.IndexOf(10)}");*/
            list.AddFirst(7);
            list.AddLast(7);
            list.Add(9);
            Console.WriteLine($"After added 7 in list");
            foreach (var l in list)
            {
                Console.WriteLine($"{l}");
            }

            list.ListFirst += delegate (object o, ArrayChangedEvent<int> arg)
            {
                Console.WriteLine($"A first data in the list: {arg.Data}");
            };

            Console.WriteLine($"Display first element {list.First()}");

            list.ListLast += delegate (object o, ArrayChangedEvent<int> arg)
            {
                Console.WriteLine($"A last data in the list: {arg.Data}");
            };

            Console.WriteLine($"Display last element {list.Last()}");

            /* list.RemoveAll(7);
             Console.WriteLine($"After remove all 7 in list");
             foreach (int l in list)
             {
                 Console.WriteLine($"{l}");
             }

             LinkedList1<int> list1 = new LinkedList1<int>();
             list1.Add(1);

             Console.WriteLine($"Display first element {list1.First()}");*/
            //Console.WriteLine($"Display last element {list.Last()}");

            list.ListCleared += delegate (object o, ArrayChangedEvent<int> arg)
            {
                Console.WriteLine($"The list cleared");
            };

            // list.Clear();
            try
            {
                if (list.IsEmpty)
                {
                    throw new Exception("List is empty!");
                }
                list.Last();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
            // list.Remove(1);

            //  Console.WriteLine($"Find 7: {list.FindLast(7)}, index: {list.IndexOf(list.Find(7))}");
           //  Console.WriteLine($"index of 7: {list.IndexOf(7,8)}");
            // foreach (var l in list.FindAll(7))
            //{
            //   Console.WriteLine($"{l}");
            //}

            /* list.Reverse();
             Console.WriteLine($"After reverse");
             foreach (var l in list)
             {
                 Console.WriteLine($"{l}");
             }*/

            /* list.Remove(list.FindLast(7));
             Console.WriteLine($"After removed last 7");
             foreach (var l in list)
             {
                 Console.WriteLine($"{l}");
             }*/

            list.Insert(3, 10);
            Console.WriteLine($"After inserted 10");
            foreach (var l in list)
            {
                Console.WriteLine($"{l}");
            }
            Console.WriteLine($"Count: {list.Count}");
            list.RemoveAt(10);
            Console.WriteLine($"After removed index 5");
            foreach (var l in list)
            {
                Console.WriteLine($"{l}");
            }

            Console.ReadKey();
        }
    }
}
