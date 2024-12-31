
namespace Snake
{
    public class Directions
    {
        public readonly static Directions Left = new Directions(0 , -1);
        public readonly static Directions Right = new Directions(0, 1);
        public readonly static Directions Up = new Directions(-1, 0);
        public readonly static Directions Down = new Directions(1, 0);

        public int RowOffSet { get; }
        public int ColumnOffSet { get; }

        private Directions(int rowOffSet, int columnOffSet)
        {
            RowOffSet = rowOffSet; 
            ColumnOffSet = columnOffSet;
        }
        
        public Directions Opposite()
        {
            return new Directions(-RowOffSet, -ColumnOffSet);
        }

        public override bool Equals(object obj)
        {
            return obj is Directions directions &&
                   RowOffSet == directions.RowOffSet &&
                   ColumnOffSet == directions.ColumnOffSet;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RowOffSet, ColumnOffSet);
        }

        public static bool operator ==(Directions left, Directions right)
        {
            return EqualityComparer<Directions>.Default.Equals(left, right);
        }

        public static bool operator !=(Directions left, Directions right)
        {
            return !(left == right);
        }
    }
}
    