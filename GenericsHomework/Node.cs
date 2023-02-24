namespace GenericsHomework
{
    public class Node<T>
    {
        public T Value { get; }
        private Node<T>? _Next;
        public Node<T> Next
        {
            get
            {
                return _Next ?? this;
            }
            private set
            {
                _Next = value;
            }
        }

        public Node(T value)
        {
            Value = value;
        }

        public override string? ToString()
        {
            return Value?.ToString();
        }

        public void Append(T value)
        {

            if (this.Exists(value))
            {
                throw new ArgumentException("Cannot add duplicate value");
            }
            Node<T> next = Next;
            Next = new Node<T>(value)
            {
                Next = next
            };
        }

        public void Clear(Node<T> source)
        {
            if (Next == this)
            {
                return;
            }
            Node<T> next = Next;
            Next = this;
            next.Clear(source);
            if (source != this)
            {
                Next = null!;
            }

        }

        public bool Exists(T value)
        {
            Node<T> start = this;
            Node<T> cur = start;
            do 
            {
                if (cur.Value is not null && cur.Value.Equals(value)) 
                    return true;
                cur = cur.Next;
            } while (cur != start);
            return false;
        }
    }
}