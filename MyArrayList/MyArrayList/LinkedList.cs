using System;
using System.Collections;
using System.Collections.Generic;


namespace MyArrayList
{ 

    public class LinkedList1<T> : IEnumerable<T>
    {
        public event EventHandler<ArrayChangedEvent<T>> ListCleared;

        public event EventHandler<ArrayChangedEvent<T>> ListAdded;

        public event EventHandler<ArrayChangedEvent<T>> ListRemoved;

        public event EventHandler<ArrayChangedEvent<T>> ListFirst;

        public event EventHandler<ArrayChangedEvent<T>> ListLast;

        protected void OnListCleared()
        {
            try
            {
                if (ListCleared != null)
                {
                    ListCleared.Invoke(this, new ArrayChangedEvent<T>(ArrayChengedAction.Clear));
                }
                else
                {
                    throw new Exception($"Event Cleared is null!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
        }

        protected void OnListAdded(T value)
        {
            try
            {
                if (ListAdded != null)
                {
                    ListAdded.Invoke(this, new ArrayChangedEvent<T>(ArrayChengedAction.Add, value));
                }
                else
                {
                    throw new Exception($"Event Added is null!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        protected void OnListRemoved(T value)
        {
            try
            {
                if (ListRemoved != null)
                {
                    ListRemoved.Invoke(this, new ArrayChangedEvent<T>(ArrayChengedAction.Remove, value));
                }
                else
                {
                    throw new Exception($"Event Removed is null!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        protected void OnListFirst(T value)
        {
            try
            {
                if (ListFirst != null)
                {
                    ListFirst.Invoke(this, new ArrayChangedEvent<T>(ArrayChengedAction.First, value));
                }
                else
                {
                    throw new Exception($"Event First is null!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        protected void OnListLast(T value)
        {
            try
            {
                if (ListLast != null)
                {
                    ListLast.Invoke(this, new ArrayChangedEvent<T>(ArrayChengedAction.Last, value));
                }
                else
                {
                    throw new Exception($"Event Last is null!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private Node<T> head = null;

        private Node<T> tail = null;

        public int Count
        {
            get;
            private set;
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public T First()
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }                               
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Node<T> current = head;

            OnListFirst(current.Data);

            return current.Data;          
        }

        public T Last()
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Node<T> current = head;
            for (int i = 1; i < Count; i++)
            {
                current = current.Next;
            }

            OnListLast(current.Data);

            return current.Data;
        }

        public T Find(T value)
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }

                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(value))
                    {
                        return current.Data;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
            return default(T);
        }

        public void Reverse()
        {
            Node<T> previous = null;
            Node<T> next = new Node<T>();
            Node<T> current = head;

            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }

                while (current != null)
                {
                    next = current.Next;
                    current.Next = previous;
                    previous = current;
                    current = next;
                }
                head = previous;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }            
        }

        public T FindLast(T value)
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Node<T> current = head;
            for (int i = 1; i < Count; i++)
            {
                if(current.Data.Equals(value))
                {
                  //  current.Data = value;
                  //  current = current.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
            return current.Data;

        }

        public LinkedList1<T> FindAll(T value)
        {
            LinkedList1<T> list = new LinkedList1<T>();

            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }

                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(value))
                    {
                        list.AddLast(value);
                    }

                    current = current.Next;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
            return list;
        }        

        public void AddFirst(T value)
        {
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Node<T> node = new Node<T>(value);

                node.Next = head;

                if (IsEmpty)
                {
                    tail = head;
                }
                else
                {
                    head = node;
                }

                Count++;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }            
                       
        }

        public void AddLast(T value)
        {
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Node<T> node = new Node<T>(value);

                if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    tail.Next = node;

                    tail = node;
                }

                Count++;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }            
        }

        public void Add(T value)
        {
            AddLast(value);

            OnListAdded(value);
        }

        public void Insert(int index, T value)
        {
            try
            {              
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(value, current.Next);
                Count++;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }            
        }

        public void Clear()
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }

                head = null;
                tail = null;
                Count = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            OnListCleared();
        }


        public bool Remove(T value)
        {
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (IsEmpty)
                {
                    throw new Exception("There are no data to remove.");
                }

                Node<T> previous = null;
                Node<T> current = head;

                while (current != null)
                {
                    if (current.Data.Equals(value))
                    {
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                            {
                                tail = previous;
                            }
                        }

                        else
                        {
                            head = head.Next;

                            if (head == null)
                            {
                                tail = null;
                            }
                        }

                        Count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }

                
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            OnListRemoved(value);

            return false;
        }

        public bool Contains(T value)
        {
           
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty");
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(value))
                    {
                        return true;
                    }

                    current = current.Next;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }                      

            return false;
        }

        public void RemoveAll(T value)
        {
           while(Contains(value))
            {
                Remove(value);
            }
        }        

        public void RemoveAt(int index)
        {
            try
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> current = head;
                Node<T> result = new Node<T>();

                if (index == 0)
                {
                    head = current.Next;
                }
                else
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }
                    current.Next = current.Next.Next;
                }
                Count--;
            }
             
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
        }

        public void CopyTo(T[] array)
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Node<T> current = head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
        }

        public void CopyTo(T[] array, int index)
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }

                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }        
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Node<T> current = head;

            if(index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            while(current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
        }

        public int IndexOf(T value)
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }           

            Node<T> current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }

        public int IndexOf(T value, int index)
        {
            try
            {
                if (IsEmpty)
                {
                    throw new Exception("List is empty!");
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if(index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Node<T> current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            for (int i = index; i < Count; i++)
            {
                 if (current.Data.Equals(value))
                    {
                        return index;
                    }

                    current = current.Next;
                    index++;
            }           

            return -1;
        }
      
        
    }
}
