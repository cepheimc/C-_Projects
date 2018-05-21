using System;
using MyArrayList;

namespace Demonstration
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList1<int> list1 = new LinkedList1<int>();

            try
            {
                list1.ListAdded += delegate (object o, ArrayChangedEvent<int> arg)
                {
                    Console.WriteLine($"A new data was added to the list: {arg.Data}");
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
            Console.WriteLine("Add 1, 2, 3");
            try
            {
                list1.Add(1);
                list1.Add(2);
                list1.Add(3);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }


            Console.WriteLine("Add 5 after 1");
            list1.Insert(0, 5);
            foreach (int l in list1)
            {
                Console.WriteLine($"{l}");
            }

            Console.WriteLine("Add 7 after 5, 7 after 2 and 7 in the end");
            try
            {
                list1.Insert(2, 7);
                list1.Insert(4, 7);
                list1.Add(7);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            foreach (int l in list1)
            {
                Console.WriteLine($"{l}");
            }

            Console.WriteLine("Remove first 7");
            try
            {
                list1.ListRemoved += delegate (object o, ArrayChangedEvent<int> arg)
                {
                    Console.WriteLine($"A data removed: {arg.Data}");
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
           
            try
            {
                list1.Remove(7);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            foreach (int l in list1)
            {
                Console.WriteLine($"{l}");
            }


            Console.WriteLine("Remove all data \'7\'");
            try
            {
                list1.RemoveAll(7);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            foreach (int l in list1)
            {
                Console.WriteLine($"{l}");
            }

            Console.WriteLine("Remove index 2");
            try
            {
                list1.RemoveAt(2);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            foreach (int l in list1)
            {
                Console.WriteLine($"{l}");
            }

            Console.WriteLine("Remove index 5");
            list1.RemoveAt(5);
            foreach (int l in list1)
            {
                Console.WriteLine($"{l}");
            }

            Console.WriteLine("Add 6, 1, 7, 8, 4, 2, 1, 9");
            try
            {
                list1.Add(6);
                list1.Add(1);
                list1.Add(7);
                list1.Add(8);
                list1.Add(4);
                list1.Add(2);
                list1.Add(1);
                list1.Add(9);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }


            Console.WriteLine("Print first element");
            try
            {
                list1.ListFirst += delegate (object o, ArrayChangedEvent<int> arg)
                {
                    Console.WriteLine($"First element: {arg.Data}");
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
           
            try
            {
                list1.First();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("Print last element");
            try
            {
                list1.ListLast += delegate (object o, ArrayChangedEvent<int> arg)
                {
                    Console.WriteLine($"Last element: {arg.Data}");
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            try
            {
                list1.Last();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            foreach (int l in list1)
            {
                Console.WriteLine($"{l}");
            }
            Console.WriteLine("Find index of data \'8\' and \'6\'");
            try
            {
                Console.WriteLine($"Index of '8': {list1.IndexOf(8)}");
                Console.WriteLine($"Index of '6': {list1.IndexOf(6)}");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }


            Console.WriteLine("Find all data \'1\'");
            try
            {
                foreach (int l in list1.FindAll(1))
                {
                    Console.WriteLine($"{l}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("Find index of data \'1\' after index 3");
            try
            {
                Console.WriteLine($"Index of '1': {list1.IndexOf(1, 3)}");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }


            Console.WriteLine("Clear");
            try
            {
                list1.ListCleared += delegate
                {
                    Console.WriteLine("List cleared");
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
           
            try
            {
                list1.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }


            Console.WriteLine("Remove data \'1\'");
            try
            {
                list1.ListRemoved += delegate
                {
                    Console.WriteLine("No data to remove");
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            try
            {
                list1.Remove(1);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }


            Console.ReadKey();
        }
    }
}
