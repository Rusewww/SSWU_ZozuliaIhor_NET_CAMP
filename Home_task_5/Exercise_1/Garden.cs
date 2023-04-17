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
            Tree minYTree = Trees[0];
            foreach (var tree in Trees)
            {
                if (tree.y < minYTree.y)
                    minYTree = tree;
            }
            
            List<Tree> hull = new List<Tree>();
            hull.Add(minYTree);

            Tree currentTree = minYTree;
            while (true)
            {
                Tree nextTree = null;
                foreach (var tree in Trees)
                {
                    if (tree == currentTree)
                        continue;

                    if (nextTree == null)
                    {
                        nextTree = tree;
                        continue;
                    }

                    double cross = CrossProduct(currentTree, nextTree, tree);
                    if (cross > 0)
                        nextTree = tree;
                }

                if (nextTree == minYTree)
                    break;

                hull.Add(nextTree);
                currentTree = nextTree;
            }

            double fenceLength = 0;
            for (int i = 0; i < hull.Count; i++)
            {
                int j = (i + 1) % hull.Count;
                double distance = Math.Sqrt(Math.Pow(hull[j].x - hull[i].x, 2) + Math.Pow(hull[j].y - hull[i].y, 2));
                fenceLength += distance;
            }

            return fenceLength;
        }

        private double CrossProduct(Tree A, Tree B, Tree C)
        {
            double x1 = B.x - A.x;
            double y1 = B.y - A.y;
            double x2 = C.x - A.x;
            double y2 = C.y - A.y;
            return x1 * y2 - x2 * y1;
        }
        
        public int CompareTo(Garden other)
        {
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
            if (ReferenceEquals(garden1, garden2))
            {
                return true;
            }
            return garden1.CompareTo(garden2) == 0;
        }

        public static bool operator !=(Garden garden1, Garden garden2)
        {
            return !(garden1 == garden2);
        }
    }
}