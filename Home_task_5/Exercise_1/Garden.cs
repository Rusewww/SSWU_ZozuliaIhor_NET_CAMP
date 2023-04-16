namespace Exercise_1
{
    public class Garden : IComparable<Garden>
    {
        public List<Tree> Trees { get; set; }

        public Garden(List<Tree> trees)
        {
            Trees = trees;
        }

        //Використовуємо алгоритм Джарвіса.
        public double CalculateFenceLength()
        {
            double fenceLength = 0;
            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double maxX = double.MinValue;
            double maxY = double.MinValue;

            foreach (var tree in Trees)
            {
                if (tree.x < minX)
                    minX = tree.x;
                if (tree.x > maxX)
                    maxX = tree.x;
                if (tree.y < minY)
                    minY = tree.y;
                if (tree.y > maxY)
                    maxY = tree.y;
            }

            fenceLength = 2 * (maxX - minX + maxY - minY);
            return fenceLength;
        }

        public int CompareTo(Garden other)
        {
            // порівнюємо довжину огорожі двох садів
            double perimeter1 = CalculateFenceLength();
            double perimeter2 = other.CalculateFenceLength();
            if (perimeter1 < perimeter2)
            {
                return -1;
            }
            else if (perimeter1 > perimeter2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        public static bool operator <(Garden garden1, Garden garden2)
        {
            return garden1.CompareTo(garden2) < 0;
        }

        public static bool operator >(Garden garden1, Garden garden2)
        {
            return garden1.CompareTo(garden2) > 0;
        }

        public static bool operator <=(Garden garden1, Garden garden2)
        {
            return garden1.CompareTo(garden2) <= 0;
        }

        public static bool operator >=(Garden garden1, Garden garden2)
        {
            return garden1.CompareTo(garden2) >= 0;
        }

        public static bool operator ==(Garden garden1, Garden garden2)
        {
            // перевіряємо на рівність два об'єкти Garden
            if (ReferenceEquals(garden1, garden2))
            {
                return true;
            }

            // перевіряємо на null-об'єктність
            if (garden1 is null || garden2 is null)
            {
                return false;
            }

            // порівнюємо довжину огорожі двох садів
            return garden1.CompareTo(garden2) == 0;
        }

        public static bool operator !=(Garden garden1, Garden garden2)
        {
            return !(garden1 == garden2);
        }
    }
}