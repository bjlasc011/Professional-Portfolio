using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public static class PopulationStatistics
    {
        public static double Percentile(double mean, double percentile, double stdDev)
        {
            ZScoreTable z = new ZScoreTable();
            double zScore = z.GetZScore(percentile);
            double x = mean + (zScore * stdDev);
            return x;
        }
        /// <summary>
        /// Gets the area under the normal distribution curve that is left of the xVal as a percentage. (ZTransformation)
        /// </summary>
        /// <param name="mean">sample average</param>
        /// <param name="xVal">value to get the probability of</param>
        /// <param name="stdDev">standard deviation of the population</param>
        /// <param name="n">sample size</param>
        /// <returns>a value between 0 and 1</returns>
        public static double GetProbabilityOfX(double mean, double xVal, double stdDev, int n = 31)
        {
            ZScoreTable z = new ZScoreTable();
            double zScore = Math.Round(ZScore(mean, xVal, (double)stdDev, n), 2); //get zScore
            if (zScore < -6)
                return 9.86587645037694E-10;
            if (zScore > 6)
                return 0.999999999013412;
            double probX = z.GetProbability(zScore); //cross check zScore against table
            return probX;
        }

        /// <summary>
        /// gets the number of standard deviations from the mean a data point is.
        /// </summary>
        /// <param name="mean">sample average</param>
        /// <param name="xVal">value to get the probability of</param>
        /// <param name="stdDev">standard deviation of the population</param>
        /// <param name="n">sample size</param>
        /// <returns>the z-score</returns>
        public static double ZScore(double mean, double xVal, double stdDev, int n = 31)
        {
            return (n <= 30)
                ? (xVal - mean) / (stdDev / Math.Pow(n, 0.5))
                : (xVal - mean) / stdDev;
        }
        /// <summary>
        /// gets the number of standard deviations from the mean a data point is.
        /// </summary>
        /// <typeparam name="T">IComparable numeric value</typeparam>
        /// <param name="mean">sample average</param>
        /// <param name="xVal">value to get the probability of</param>
        /// <param name="stdDev">standard deviation of the population</param>
        /// <param name="n">sample size</param>
        /// <returns>the z-score</returns>
        public static double? Zscore<T>(T mean, T xVal, T stdDev, int n = 31) where T : IComparable<T>
        {
            double? x = xVal as double?, m = mean as double?, sd = stdDev as double?;
            if (x != null && m != null && sd != null)
                return (n <= 30)
                    ? (x - m) / (sd / Math.Pow(n, 0.5))
                    : (x - m) / sd;
            return null;
        }
        /// <summary>
        /// gets the number of standard deviations from the mean a data point is.
        /// </summary>
        /// <typeparam name="T">IComparable numeric value</typeparam>
        /// <param name="list">sample values from which to determine the z-score</param>
        /// <param name="xVal">value to get the probability of</param>
        /// <returns>the z-score</returns>
        public static double? Zscore<T>(IEnumerable<T> list, T xVal) where T : IComparable<T>
        {
            double? v = xVal as double?, m = Mean(list) as double?, sd = StandardDev(list) as double?;
            int n = list.Count();
            if (v != null && m != null && sd != null)
                return (n <= 30)
                    ? (v - m) / (sd / Math.Pow(n, 0.5))
                    : (v - m) / sd;
            return null;
        }

        public static double? StandardDev<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            double? variance = Variance(list);
            if (variance != null)
                return Math.Pow((double)variance, 0.5);
            return null;
        }

        public static double? Variance<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            double? mu = Mean(list);
            double? sumOfSqrDifs = SumSqrDifFromMean(list);
            int n = list.Count();
            if (sumOfSqrDifs != null)
                return (double)sumOfSqrDifs / n;
            return null;
        }

        public static double? SumSqrDifFromMean<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            double? sum = 0;
            double? mu = Mean(list);
            IEnumerator<T> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                var dif = (enumer.Current as double?) - mu;
                sum += (dif * dif);
            }
            if (sum != null)
                return (double)sum;
            return null;
        }

        private static double? Mean<T>(IEnumerable<T> sample) where T : IComparable<T>
        {
            double? sum = 0;
            int count = 0;
            IEnumerator<T> enumer = sample.GetEnumerator();
            while (enumer.MoveNext())
            {
                sum += enumer.Current as double?;
                ++count;
            }
            if (sum != null)
                return (double)sum / count;
            return null;
        }

        public static Type FindType<T>(T obj) where T : IComparable<T>
            => (obj == null) ? typeof(T) : obj.GetType();
    }
}
