using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public static implicit operator Pair<T, U>((T first, U second) tuple)
        {
            return new Pair<T, U>(tuple.first, tuple.second);
        }

        public static bool operator ==(Pair<T, U> pair, T value)
        {
            if (pair is null)
                return false;
            return EqualityComparer<T>.Default.Equals(pair.First, value);
        }

        public static bool operator !=(Pair<T, U> pair, T value)
        {
            return !(pair == value);
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
}
