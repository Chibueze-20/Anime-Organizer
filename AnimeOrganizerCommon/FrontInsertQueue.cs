using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizerCommon
{
    public class FrontInsertQueue<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();
        private LinkedListNode<T> _insertionPoint = null;

        // Normal enqueue (initial population)
        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        // Add a child at the front, but after previously added children
        public void AddChild(T child)
        {
            // If the list is empty, just add it
            if (_list.First == null)
            {
                _list.AddFirst(child);
                return;
            }

            // Insert right after the last inserted child
            // We track the insertion point
            if (_insertionPoint == null)
            {
                // First child being added → insert at the very front
                _list.AddFirst(child);
                _insertionPoint = _list.First;
            }
            else
            {
                // Insert after the last child
                _insertionPoint = _list.AddAfter(_insertionPoint, child);
            }
        }

        

        // Pop from the front
        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Empty");

            var value = _list.First.Value;
            _list.RemoveFirst();

            // If we popped past the insertion point, reset it
            if (_insertionPoint != null && _insertionPoint.List == null)
                _insertionPoint = null;

            return value;
        }

        public int Count => _list.Count;

        public override string ToString()
            => "[" + string.Join(",", _list) + "]";
    }
}
