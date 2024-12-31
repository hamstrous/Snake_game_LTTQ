using System.Windows.Controls;

namespace Snake
{
    public class Positions
    {
        public int Row { get; }
        public int Column { get; }

        public Positions (int row , int column)
        {
            Row = row;
            Column = column;    
        }

        public Positions Translate(Directions dir)
        {
            return new Positions (Row + dir.RowOffSet, Column + dir.ColumnOffSet);
        }

        public override bool Equals(object obj)
        {
            return obj is Positions positions &&
                   Row == positions.Row &&
                   Column == positions.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Positions left, Positions right)
        {
            return EqualityComparer<Positions>.Default.Equals(left, right);
        }

        public static bool operator !=(Positions left, Positions right)
        {
            return !(left == right);
        }
    }
}
