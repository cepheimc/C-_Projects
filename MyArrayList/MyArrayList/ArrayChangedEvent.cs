using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArrayList
{
    public enum ArrayChengedAction
    {
        Add, Remove, Clear, First, Last
    }

    public class ArrayChangedEvent<T> : EventArgs
    {
        private ArrayChengedAction _action;
        private T data;

        public ArrayChengedAction Action => _action;

        public T Data => data;

        public ArrayChangedEvent(ArrayChengedAction action)
        {
            try
            {
                if (action != ArrayChengedAction.Add && action != ArrayChengedAction.Remove
                  && action != ArrayChengedAction.Clear && action != ArrayChengedAction.First
                  && action != ArrayChengedAction.Last)
                {
                    throw new ArgumentException();
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
        }

        public ArrayChangedEvent(ArrayChengedAction action, T changedItem)
        {
            try
            {
                if (action != ArrayChengedAction.Add && action != ArrayChengedAction.Remove
                  && action != ArrayChengedAction.Clear && action != ArrayChengedAction.First
                  && action != ArrayChengedAction.Last)
                {
                    throw new ArgumentException();
                }

                if (action == ArrayChengedAction.Clear)
                {
                    if (changedItem != null)
                    {
                        throw new ArgumentException();
                    }

                    InitializeAdd(action, default(T));
                }
                else
                {
                    if (action == ArrayChengedAction.First || action == ArrayChengedAction.Last)
                    {
                        InitializeFirstOrLast(action, changedItem);
                    }
                    else
                    {
                        InitializeAddOrRemove(action, changedItem);
                    }
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
        }


        private void InitializeAddOrRemove(ArrayChengedAction action, T changedItems)
        {
            if (action == ArrayChengedAction.Add)
            {
                InitializeAdd(action, changedItems);
            }
            else
            {
                InitializeRemove(action, changedItems);
            }
            
        }

        private void InitializeFirstOrLast(ArrayChengedAction action, T changedItems)
        {
            if (action == ArrayChengedAction.First)
            {
                InitializeFirst(action, changedItems);
            }
            else
            {
                InitializeLast(action, changedItems);
            }            
        }

        private void InitializeAdd(ArrayChengedAction action, T newItems)
        {
            _action = action;

            data = newItems;
        }

        private void InitializeRemove(ArrayChengedAction action, T newItems)
        {
            _action = action;

            data = newItems;
        }

        private void InitializeFirst(ArrayChengedAction action, T Item)
        {
            _action = action;

            data = Item;
        }

        private void InitializeLast(ArrayChengedAction action, T Item)
        {
            _action = action;

            data = Item;
        }


    }
}
