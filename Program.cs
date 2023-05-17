using System;
  


// Name: Ziad ezzeldin & sara samer.
// section : AI

namespace StatisticsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of items: ");//The user is prompted to enter the number of items.
            int n = int.Parse(Console.ReadLine());

            int[] items = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter item " + (i + 1));
                items[i] = int.Parse(Console.ReadLine());//The user is then prompted to enter each item one by one, and the values are stored in an array.
            }

            Array.Sort(items);//this method used to arrange the number ascending

            double median = CalculateMedian(items);
            Console.WriteLine("Median" + median);

            int mode = CalculateMode(items);
            Console.WriteLine("Mode" + mode);

            int range = CalculateRange(items);
            Console.WriteLine("Range" + range);

            double firstQuartile = CalculateQuartile(items, 0.25);
            Console.WriteLine("First Quartile" + firstQuartile);

            double thirdQuartile = CalculateQuartile(items, 0.75);
            Console.WriteLine("Third Quartile" + thirdQuartile);

            int p90 = CalculatePercentile(items, 90);
            Console.WriteLine("P90 : " + p90);

            int interquartile = (int)(thirdQuartile - firstQuartile);
            Console.WriteLine("Interquartile Range: " + interquartile);

            //The user is then prompted to enter a value to check if it's an outlier, and the program determines whether the value is an outlier or not based on the lower and upper outlier boundaries calculated earlier.
            double lowerOutlierBoundary = firstQuartile - (1.5 * interquartile);
            double upperOutlierBoundary = thirdQuartile + (1.5 * interquartile);
            Console.WriteLine("Lower Outlier Boundary: " + lowerOutlierBoundary);
            Console.WriteLine("Upper Outlier Boundary: " + upperOutlierBoundary);

            Console.Write("Enter a value to check if it's an outlier: ");
            int value = int.Parse(Console.ReadLine());
            if (value < lowerOutlierBoundary || value > upperOutlierBoundary)
            {
                Console.WriteLine("" + value + "is an outlier.");
            }
            else
            {
                Console.WriteLine("" + value + "is not an outlier.");
            }
        }

        static double CalculateMedian(int[] items)
        {
            int n = items.Length;
            if (n % 2 == 0)
            {
                return (items[n / 2 + 1] + items[n / 2]) / 2.0;
            }
            else
            {
                return items[n / 2];
            }
        }

        static int CalculateMode(int[] items)
        {
            var groups = items.GroupBy(x => x);
            int maxCount = groups.Max(g => g.Count());
            return groups.First(g => g.Count() == maxCount).Key;
        }

        static int CalculateRange(int[] items)
        {
            return items.Max() - items.Min();
        }

        static double CalculateQuartile(int[] items, double percentile)
        {
            int n = items.Length;
            double index = percentile * n;
            int lowerIndex = (int)Math.Floor(index);
            int upperIndex = (int)Math.Ceiling(index);

            if (lowerIndex == upperIndex)
            {
                return items[lowerIndex];
            }
            else
            {
                double weight = index - lowerIndex;
                return items[lowerIndex] * (1 - weight) + items[upperIndex] * weight;
            }
        }

        static int CalculatePercentile(int[] items, int percentile)
        {
            int n = items.Length;
            double index = percentile / 100.0 * (n - 1);
            int lowerIndex = (int)Math.Floor(index);
            int upperIndex = (int)Math.Ceiling(index);

            if (lowerIndex == upperIndex)
            {
                return items[lowerIndex];
            }
            else
            {
                double weight = index - lowerIndex;
                return (int)(items[lowerIndex] * (1 - weight) + items[upperIndex] * weight);
            }
        }
    }
}
