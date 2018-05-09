using System;


namespace MyArrayList
{
    class Node<T>
    {
        public T Data { get;  private set; }

        public Node<T> Next { get;  set; }

        public Node()
        {
            Data = default(T);
        }

        public Node(T data)
        {
            try
            {
                if (data == null)
                {
                    throw new ArgumentNullException(nameof(data));
                }

                Data = data;
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
           
        }

        public Node(T data, Node<T> next)
        {
            try
            {
                if (data == null)
                {
                    throw new ArgumentNullException(nameof(data));
                }

                Data = data;
                Next = next;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public override string ToString()
        {
            string v = "data: " + Data.ToString();
            return v;
        }

        public override bool Equals(object obj)
        {
            bool isEqual;
            isEqual = (obj.ToString() == this.ToString());
            return isEqual;
        }

        public override int GetHashCode()
        {
            int hashCode;
            hashCode = this.ToString().GetHashCode();
            return hashCode;
        }
    }

}
