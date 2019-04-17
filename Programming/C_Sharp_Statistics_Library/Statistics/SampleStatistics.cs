using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public sealed class SampleStatistics
    {
        //******************** ACTIVATION FUNCTIONS ****************************//
        //public static double ActivateUsingZScores()
        //{
        //    double zero; // mean
        //    double upper; // 6 sigma
        //    double lower; // -6 sigma
        //    Math.Log()
        //}

        //******************** CONFIDENCE INTERVAL ***********************//
        /// <summary>
        /// Returns the upper and lower bounds (interval) around the observed Proportion which the population proportion is within a degree of confidence.
        /// i.e. we are 90% confident that the population proportion lies within the interval [0.2, 0.14] given the sample proportion and n.
        /// </summary>
        /// <param name="desiredConfidence">how sure of the results as a percentage</param>
        /// <param name="proportion">The probability of something happening observed in the sample. 
        /// A number between 0-1. i.e. The probability of a six sided dice landing on three is 1/6.</param>
        /// <param name="n">sample size</param>
        /// <returns>returns double[2], with the two values being the lower and upper bounds of the interval</returns>
        public static double[] ConfidenceInterval(double desiredConfidence, double proportion, int n)
        {
            double se = StandardErrorOfProportion(desiredConfidence, proportion, n);
            return new double[] { (proportion - se), (proportion + se) };
        }
        /// <summary>
        /// Returns the upper and lower bounds (interval) around the mean which the true mean lies within a degree of confidence.
        /// i.e. we are 90% confident that the true mean lies within the interval [23.4, 25.3] given the parameters.
        /// </summary>
        /// <param name="desiredConfidence">how sure of the results as a percentage</param>
        /// <param name="stdDev">standard deviation</param>
        /// <param name="mean">average within a data set</param>
        /// <param name="n">sample size</param>
        /// <returns>returns double[2], with the two values being the lower and upper bounds of the interval</returns>
        public static double[] ConfidenceInterval(double desiredConfidence, double stdDev, double mean, int n)
        {
            double se = SamplingError(desiredConfidence, stdDev, n);
            return new double[] {(mean - se),(mean + se)};
        }
        /// <summary>
        /// Sampling error is the deviation from the mean resulting from small sample sizes. As n increases, 
        /// the Sampling Error decreases. The sampling error's deviation about the mean creates a range that we are
        /// confident the mean lies. (two-tailed)
        /// </summary>
        /// <param name="desiredConfidence">How sure of the results as a percentage. 
        /// Significant performance advantages for values of .99, .98, .95, .90, .85, .80</param>
        /// <param name="stdDev">standard deviation</param>
        /// <param name="n">sample size</param>
        /// <returns>the sampling error</returns>
        public static double SamplingError(double desiredConfidence, double stdDev, int n)
        {
            double zScore;
            ZScoreTable z = new ZScoreTable();
            switch (desiredConfidence)
            {
                case .99: zScore = 2.57; break;
                case .98: zScore = 2.32; break;
                case .95: zScore = 1.95; break;
                case .90: zScore = 1.64; break;
                case .85: zScore = 1.43; break;
                case .80: zScore = 1.28; break;
                default: zScore = z.GetZScore(desiredConfidence); break;
            }
            double samplingError = zScore * (stdDev / Math.Pow(n, 0.5));
            return samplingError;
        }
        /// <summary>
        /// Returns the standard error given the proportion. The Proportion being the probability of something happening.
        /// </summary>
        /// /// <param name="desiredConfidence">How sure of the results as a percentage. 
        /// Significant performance advantages for values of .99, .98, .95, .90, .85, .80</param>
        /// <param name="proportion">The probability of something happening observed in the sample. 
        /// A number between 0-1. i.e. The probability of a six sided dice landing on three is 1/6.</param>
        /// <param name="n">sample size</param>
        /// <returns>Returns the standard error of proportion</returns>
        public static double StandardErrorOfProportion(double desiredConfidence, double proportion, int n)
        {
            double zScore;
            ZScoreTable z = new ZScoreTable();
            switch (desiredConfidence)
            {
                case .99: zScore = 2.57; break;
                case .98: zScore = 2.32; break;
                case .95: zScore = 1.95; break;
                case .90: zScore = 1.64; break;
                case .85: zScore = 1.43; break;
                case .80: zScore = 1.28; break;
                default: zScore = z.GetZScore(desiredConfidence); break;
            }
            return zScore * Math.Pow((proportion * (1 - proportion)) / n, 0.5);
        }

        //******************** Z-TRANSLATION *****************************//
        /// <summary>
        /// returns the value of x for a desired percentile, x representing the value of the percentiles threshhold
        /// </summary>
        /// <param name="mean">sample average</param>
        /// <param name="zScore">z-score</param>
        /// <param name="stdDev">standard deviation of the population</param>
        /// <returns>returns the value of x for a desired percentile threshold</returns>
        public static double GetXForGivenPercentile(double mean, float zScore, double stdDev) =>
            mean + (zScore * stdDev);
        /// <summary>
        /// returns the value of x for a desired percentile, x representing the value of the percentiles threshhold
        /// </summary>
        /// <param name="mean">sample average</param>
        /// <param name="percentile">90th percentile as 0.90</param>
        /// <param name="stdDev">standard deviation of the population</param>
        /// <returns>returns the value of x for a desired percentile threshold</returns>
        public static double GetXForGivenPercentile(double mean, double percentile, double stdDev)
        {
            ZScoreTable z = new ZScoreTable();
            return mean + (z.GetZScore(percentile) * stdDev);
        }
        /// <summary>
        /// Gets the area under the normal distribution curve that is left of the xVal as a percentage. (ZTransformation)
        /// </summary>
        /// <param name="mean">sample average</param>
        /// <param name="xVal">value to get the probability of</param>
        /// <param name="stdDev">standard deviation of the population</param>
        /// <param name="n">sample size</param>
        /// <returns>a value between 0 and 1</returns>
        public static double GetAreaUnderCurve(double mean, double xVal, double stdDev, int n = 31)
        {
            ZScoreTable z = new ZScoreTable();
            double zScore = Math.Round(ZScore(mean, xVal, stdDev, n), 2); //get zScore
            if (zScore < -6)
                return 9.86587645037694E-10;
            if (zScore > 6)
                return 0.999999999013412;
            double probX = z.GetProbability(zScore); //cross check zScore against table
            return probX;
        }

        //******************** POISSON RARE EVENTS ***********************//
        /// <summary>
        /// Poisson gets the probability of some rare event occuring.
        /// </summary>
        /// <param name="meanX">average number occurences occuring within meanXTimeFrame</param>
        /// <param name="rareX">specifies the number of rare events to predict their probability within the rareXTimeFrame</param>
        /// <param name="meanXTimeFrame">the time frame the mean occurences are measured within</param>
        /// <param name="rareXTimeFrame">the time frame the rareX-event occurences are measured within</param>
        /// <returns>a value between 0 and 1</returns>
        public static double? PoissonRareEvent(double meanX, double rareX, double meanXTimeFrame, double rareXTimeFrame)
        {
            rareX *= (meanXTimeFrame / rareXTimeFrame);
            return (Math.Pow(Math.E, -1 * (meanX)) * Math.Pow(meanX, rareX)) / Factorial(rareX);
        }
        /// <summary>
        /// Poisson gets the probability of some rare event occuring.
        /// </summary>
        /// <param name="meanX">average number occurences occuring within meanXTimeFrame</param>
        /// <param name="rareX">specifies the number of rare events to predict their probability within the rareXTimeFrame</param>
        /// <param name="overTime">the time frame that the meanX event and rareX occurences are measured</param>
        /// <returns>a value between 0 and 1</returns>
        public static double? PoissonRareEvent(double meanX, double rareX, double overTime)
            => (Math.Pow(Math.E, -1 * (meanX)) * Math.Pow(meanX, rareX)) / Factorial(rareX);
        
        //******************** CORRELATION *******************************//
        /// <summary>
        /// The strength of the linear association between two variables.
        /// </summary>
        /// <param name="matrix">Matrix of variables, with two variables being the target for finding the correlation</param>
        /// <param name="xInd">Defaulted to the first position of each inner IEnumerable. Can be set to any variable's index</param>
        /// <param name="yInd">Defaulted to the first position of each inner IEnumerable. Can be set to any variable's index</param>
        /// <returns>A value between -1 and 1, showing a positive or negative.</returns>
        public static double? Correlation<T>(IEnumerable<IEnumerable<T>> matrix, int xInd = 0, int yInd = 1) where T : IComparable<T>
        {
            if (xInd != yInd)
            {
                int n = matrix.Count();
                List<T> listX = new List<T>();
                List<T> listY = new List<T>();
                IEnumerator<IEnumerable<T>> rowEnumer = matrix.GetEnumerator();
                while (rowEnumer.MoveNext())
                {
                    IEnumerator<T> enumerCols = rowEnumer.Current.GetEnumerator();
                    int i = -1;
                    while (enumerCols.MoveNext())
                    {
                        ++i;
                        if (i == xInd) listX.Add(enumerCols.Current);
                        if (i == yInd) listY.Add(enumerCols.Current);
                    }
                }
                double?
                    sum = 0,
                    resX,
                    resY,
                    muX = Mean(listX),
                    muY = Mean(listY), 
                    stdDevX = StandardDev(listX, (double)muX),
                    stdDevY = StandardDev(listY, (double)muY);

                for(int i = 0; i < listX.Count; ++i)
                {
                    resX = ((listX[i] as double?) - muX) / stdDevX;
                    resY = ((listY[i] as double?) - muY) / stdDevY;
                    sum += (resX * resY);
                }
                return sum / (n - 1);
            }
            else throw new Exception("Finding correlation with itself is self explanatory");
        }
        /// <summary>
        /// The strength of the linear association between two variables.
        /// </summary>
        /// <param name="matrix">Matrix of variables, with two variables being the target for finding the correlation</param>
        /// <param name="meanX">The average of x values</param>
        /// <param name="meanY">The average of y values</param>
        /// <param name="xInd">Defaulted to the first position of each inner IEnumerable. Can be set to any variable's index</param>
        /// <param name="yInd">Defaulted to the first position of each inner IEnumerable. Can be set to any variable's index</param>
        /// <returns>A value between -1 and 1, showing a positive or negative.</returns>
        public static double? Correlation<T>(IEnumerable<IEnumerable<T>> matrix, double meanX, double meanY, int xInd = 0, int yInd = 1)
            where T : IComparable<T>
        {
            if (xInd != yInd)
            {
                int n = matrix.Count();
                List<T> listX = new List<T>();
                List<T> listY = new List<T>();
                IEnumerator<IEnumerable<T>> rowEnumer = matrix.GetEnumerator();
                while (rowEnumer.MoveNext())
                {
                    IEnumerator<T> enumerCols = rowEnumer.Current.GetEnumerator();
                    int i = -1;
                    while (enumerCols.MoveNext())
                    {
                        ++i;
                        if (i == xInd) listX.Add(enumerCols.Current);
                        if (i == yInd) listY.Add(enumerCols.Current);
                    }
                }
                double?
                    sum = 0,
                    resX,
                    resY,
                    stdDevX = StandardDev(listX, meanX),
                    stdDevY = StandardDev(listY, meanY);

                for (int i = 0; i < listX.Count; ++i)
                {
                    resX = ((listX[i] as double?) - meanX) / stdDevX;
                    resY = ((listY[i] as double?) - meanY) / stdDevY;
                    sum += (resX * resY);
                }
                return sum / (n - 1);
            }
            else throw new Exception("Finding correlation with itself is self explanatory");
        }
        /// <summary>
        /// The strength of the linear association between two variables.
        /// </summary>
        /// <typeparam name="T">IComparable Type</typeparam>
        /// <param name="matrix">Matrix of variables, with two variables being the target for finding the correlation</param>
        /// <param name="meanX">Average x values</param>
        /// <param name="meanY">Average of y values</param>        
        /// <param name="stdDevX">Standard deviation of x data set</param>
        /// <param name="stdDevY">Standard deviation of y data set</param>
        /// <param name="xInd">Defaulted to the first position of each inner IEnumerable. Can be set to any variable's index</param>
        /// <param name="yInd">Defaulted to the first position of each inner IEnumerable. Can be set to any variable's index</param>
        /// <returns>A value between -1 and 1, showing a positive or negative.</returns>
        public static double? Correlation<T>(IEnumerable<IEnumerable<T>> matrix, double meanX, double meanY,double stdDevX, double stdDevY, int xInd = 0, int yInd = 1)
           where T : IComparable<T>
        {
            if (xInd != yInd)
            {
                int n = matrix.Count();
                List<T> listX = new List<T>();
                List<T> listY = new List<T>();
                IEnumerator<IEnumerable<T>> rowEnumer = matrix.GetEnumerator();
                while (rowEnumer.MoveNext())
                {
                    IEnumerator<T> enumerCols = rowEnumer.Current.GetEnumerator();
                    int i = -1;
                    while (enumerCols.MoveNext())
                    {
                        ++i;
                        if (i == xInd) listX.Add(enumerCols.Current);
                        if (i == yInd) listY.Add(enumerCols.Current);
                    }
                }
                double?
                    sum = 0,
                    resX,
                    resY;
                for (int i = 0; i < listX.Count; ++i)
                {
                    resX = ((listX[i] as double?) - meanX) / stdDevX;
                    resY = ((listY[i] as double?) - meanY) / stdDevY;
                    sum += (resX * resY);
                }
                return sum / (n - 1);
            }
            else throw new Exception("Finding correlation with itself is self explanatory");
        }
        /// <summary>
        /// the strength of the linear association between two variables.
        /// </summary>
        /// <typeparam name="T">IComparable numeric value</typeparam>
        /// <param name="listX">list of x values</param>
        /// <param name="listY">list of y values</param>
        /// <returns>a value between -1 and 1, showing a positive or negative.</returns>
        public static double? Correlation<T>(IEnumerable<T> listX, IEnumerable<T> listY) where T : IComparable<T>
        {
            int n = listX.Count();
            double?
                sum = 0,
                resX, 
                resY, 
                muX = Mean(listX),
                muY = Mean(listY),
                stdDevX = StandardDev(listX, (double)muX),
                stdDevY = StandardDev(listY, (double)muY);
            if (listX.Count() == listY.Count())
            {
                n = listX.Count();
                IEnumerator<T> enumerY = listY.GetEnumerator();
                IEnumerator<T> enumerX = listX.GetEnumerator();
                while (enumerX.MoveNext() && enumerY.MoveNext())
                {
                    resX = ((enumerX.Current as double?) - muX)/stdDevX;
                    resY = ((enumerY.Current as double?) - muY)/stdDevY;
                    sum += (resX * resY);
                }
                return sum / (n - 1);
            }
            else throw new Exception("listY and listX lengths are not equal. Could not calculate a correlation.");
        }
        /// <summary>
        /// the strength of the linear association between two variables.
        /// </summary>
        /// <typeparam name="T">IComparable numeric value</typeparam>
        /// <param name="listX">list of x values</param>
        /// <param name="meanX">average of x values</param>
        /// <param name="listY">list of y values</param>
        /// <param name="meanY">average of y values</param>
        /// <returns>a value between -1 and 1, showing a positive or negative.</returns>
        public static double? Correlation<T>(IEnumerable<T> listX, double meanX, IEnumerable<T> listY, double meanY) where T : IComparable<T>
        {
            int n = listX.Count();
            double?
                sum = 0,
                resX,
                resY,
                stdDevX = StandardDev(listX, meanX),
                stdDevY = StandardDev(listY, meanY);
            if (listX.Count() == listY.Count())
            {
                IEnumerator<T> enumerY = listY.GetEnumerator();
                IEnumerator<T> enumerX = listX.GetEnumerator();
                while (enumerX.MoveNext() && enumerY.MoveNext())
                {
                    resX = ((enumerX.Current as double?) - meanX) / stdDevX;
                    resY = ((enumerY.Current as double?) - meanY) / stdDevY;
                    sum += (resX * resY);
                }
                return sum / (n - 1);
            }
            else throw new Exception("listY and listX lengths are not equal. Could not calculate a correlation.");
        }
        /// <summary>
        /// the strength of the linear association between two variables.
        /// </summary>
        /// <typeparam name="T">IComparable numeric value</typeparam>
        /// <param name="listX">list of x values</param>
        /// <param name="meanX">average of x values</param>
        /// <param name="stdDevX">standard deviation of listX</param>
        /// <param name="listY">list of y values</param>
        /// <param name="meanY">average of y values</param>
        /// <param name="stdDevY">standard deviation of listY</param>
        /// <returns>a value between -1 and 1, showing a positive or negative.</returns>
        public static double? Correlation<T>(IEnumerable<T> listX, double meanX, double stdDevX, IEnumerable<T> listY, double meanY, double stdDevY) where T : IComparable<T>
        {
            int n = listX.Count();
            double?
                sum = 0,
                resX,
                resY;
            if (listX.Count() == listY.Count())
            {
                IEnumerator<T> enumerY = listY.GetEnumerator();
                IEnumerator<T> enumerX = listX.GetEnumerator();
                while (enumerX.MoveNext() && enumerY.MoveNext())
                {
                    resX = ((enumerX.Current as double?) - meanX) / stdDevX;
                    resY = ((enumerY.Current as double?) - meanY) / stdDevY;
                    sum += (resX * resY);
                }
                return sum / (n - 1);
            }
            else throw new Exception("listY and listX lengths are not equal. Could not calculate a correlation.");
        }

        //******************** Z-SCORE ***********************************//
        /// <summary>
        /// gets the number of standard deviations from the mean a sample data point is.
        /// </summary>
        /// <param name="mean">sample average</param>
        /// <param name="xVal">value to get the probability of</param>
        /// <param name="stdDev">standard deviation of the population</param>
        /// <param name="n">sample size</param>
        /// <returns>the z-score</returns>
        public static double ZScore(double mean, double xVal, double stdDev, int n = 31)
        {
            return (n > 30)
                ? (xVal - mean) / stdDev
                : (xVal - mean) / (stdDev / Math.Pow(n, 0.5));
        }
        /// <summary>
        /// gets the number of standard deviations from the mean a sample data point is.
        /// </summary>
        /// <typeparam name="T">IComparable numeric value</typeparam>
        /// <param name="mean">sample average</param>
        /// <param name="xVal">value to get the probability of</param>
        /// <param name="stdDev">standard Deviation</param>
        /// <param name="n">sample size</param>
        /// <returns>the z-score</returns>
        public static double? Zscore<T>(T mean, T xVal, T stdDev, int n = 31) where T : IComparable<T>
        {
            double? v = xVal as double?, m = mean as double?, sd = stdDev as double?;
            if(v != null && m != null && sd != null)
                return (n > 30)
                    ? (v - m) / sd
                    : (v - m) / (sd / Math.Pow(n, 0.5));
            return null;
        }
        /// <summary>
        /// Gets the number of standard deviations from the mean a sample data point is. Should be used when evaluating a population, else use t-score functions.
        /// </summary>
        /// <typeparam name="T">IComparable numeric value</typeparam>
        /// <param name="list">sample values from which to determine the z-score</param>
        /// <param name="xVal">value to get the probability of</param>
        /// <returns>the z-score</returns>
        public static double? Zscore<T>(IEnumerable<T> list, T xVal) where T : IComparable<T>
        {
            double? v = xVal as double?, m = Mean(list) as double?, sd = PopulationStatistics.StandardDev(list) as double?;
            int n = list.Count();
            if (v != null && m != null && sd != null)
                return (n > 30)
                    ? (v - m) / sd
                    : (v - m) / (sd / Math.Pow(n, 0.5));
            return null;
        }

        //******************** STANDARD DEVIATION ************************//
        /// <summary>
        /// Represents the dispersion of data within a normally distributed sample.
        /// </summary>
        /// <param name="list">data set</param>
        /// <returns></returns>
        public static double StandardDev(double variance)
        {
            return Math.Pow(variance, 0.5);
        }
        /// <summary>
        /// Represents the dispersion of data within a normally distributed sample.
        /// </summary>
        /// <param name="list">data set</param>
        /// <returns></returns>
        public static double StandardDev(IEnumerable<double> list)
        {
            double variance = Variance(list);
            return Math.Pow(variance, 0.5);
        }
        /// <summary>
        /// Represents the dispersion of data within a normally distributed sample.
        /// </summary>
        /// <param name="list">data set</param>
        /// <param name="mean">average within the data set</param>
        /// <returns>the standard deviation of a samle</returns>
        public static double StandardDev(IEnumerable<double> list, double mean)
        {
            double variance = Variance(list, mean);
            return Math.Pow(variance, 0.5); // else => variance is null

        }
        /// <summary>
        /// Represents the dispersion of data within a normally distributed sample.
        /// </summary>
        /// <typeparam name="T">IComparable type</typeparam>
        /// <param name="list">data set</param>
        /// <returns></returns>
        public static double? StandardDev<T>(IEnumerable<T> list) where T: IComparable<T>
        {
            double? variance = Variance(list);
            return (variance != null) ? Math.Pow((double)variance, 0.5) : variance;
        }
        /// <summary>
        /// Represents the dispersion of data within a normally distributed sample.
        /// </summary>
        /// <typeparam name="T">IComparable type</typeparam>
        /// <param name="list">data set</param>
        /// <param name="mean">average within the data set</param>
        /// <returns>the standard deviation of a samle</returns>
        public static double? StandardDev<T>(IEnumerable<T> list, double mean) where T : IComparable<T>
        {
            double? variance = Variance(list, mean);
            return (variance != null) ? Math.Pow((double)variance, 0.5) : variance; // else => variance is null

        }

        //******************** VARIANCE **********************************//
        /// <summary>
        /// gets the expectation of deviation of a value from the mean for a sample.
        /// </summary>
        /// <param name="list">data set</param>
        /// <returns>the expected variance within a sample</returns>
        public static double Variance(IEnumerable<double> list)
        {
            double mu = Mean(list);
            double sumOfSqrDifs = SumOfSquaredDifferences(list);
            int n = list.Count();
            return sumOfSqrDifs / (n - 1);
        }
        /// <summary>
        /// gets the expectation of deviation of a value from the mean for a sample.
        /// </summary>
        /// <param name="list">data set</param>
        /// <param name="mean">the average within the data set</param>
        /// <returns>the expected variance within a sample</returns>
        public static double Variance(IEnumerable<double> list, double mean)
        {
            double mu = mean;
            double sumOfSqrDifs = SumOfSquaredDifferences(list, mean);
            int n = list.Count();
            return sumOfSqrDifs / (n - 1);
        }
        /// <summary>
        /// gets the expectation of deviation of a value from the mean for a sample.
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="list">data set</param>
        /// <returns>the expected variance within a sample</returns>
        public static double? Variance<T>(IEnumerable<T> list) where T : IComparable<T>
        {
            double? mu = Mean(list);
            double? sumOfSqrDifs = SumOfSquaredDifferences(list);
            int n = list.Count();
            return (sumOfSqrDifs != null) ? (double)sumOfSqrDifs / (n - 1) : sumOfSqrDifs;
        }
        /// <summary>
        /// gets the expectation of deviation of a value from the mean for a sample.
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="list">data set</param>
        /// <param name="mean">the average within the data set</param>
        /// <returns>the expected variance within a sample</returns>
        public static double? Variance<T>(IEnumerable<T> list, double mean) where T: IComparable<T>
        {
            double? mu = mean;
            double? sumOfSqrDifs = SumOfSquaredDifferences(list, mean);
            int n = list.Count();
            return (sumOfSqrDifs != null) ? (double)sumOfSqrDifs / (n - 1) : sumOfSqrDifs;
        }

        //******************** SUM OF SQUARED DIFFERENCES ****************//
        /// <summary>
        /// describes the spread of all independent variables from the average of dependent variables.
        /// </summary>
        /// <param name="list">data set of values</param>
        /// <returns>sum of squared differences</returns>
        public static double SumOfSquaredDifferences(IEnumerable<double> list)
        {
            double sum = 0;
            double mu = Mean(list);
            IEnumerator<double> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                var dif = enumer.Current - mu;
                sum += (dif * dif);
            }
            return sum;
        }
        /// <summary>
        /// describes the spread of all independent variables from the average of dependent variables.
        /// </summary>
        /// <param name="list">data set of values</param>
        /// <param name="mean">average value of the list</param>
        /// <returns>sum of squared differences</returns>
        public static double SumOfSquaredDifferences(IEnumerable<double> list, double mean)
        {
            double sum = 0;
            IEnumerator<double> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                var dif = enumer.Current - mean;
                sum += (dif * dif);
            }
            return sum;
        }
        /// <summary>
        /// describes the spread of all independent variables from the average of dependent variables.
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="list">data set of values</param>
        /// <returns>sum of squared differences</returns>
        public static double? SumOfSquaredDifferences<T>(IEnumerable<T> list) where T: IComparable<T>
        {
            double? sum = null;
            double? mu = Mean(list);
            IEnumerator<T> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                var dif = (enumer.Current as double?) - mu;
                sum += (dif * dif);
            }
            return sum;
        }
        /// <summary>
        /// describes the spread of all independent variables from the average of dependent variables.
        /// </summary>
        /// <typeparam name="T">IComparable</typeparam>
        /// <param name="list">data set of values</param>
        /// <param name="mean">average value of the list</param>
        /// <returns>sum of squared differences</returns>
        public static double? SumOfSquaredDifferences<T>(IEnumerable<T> list, double mean) where T : IComparable<T>
        {
            double? sum = null;
            double? mu = mean;
            IEnumerator<T> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                var dif = (enumer.Current as double?) - mu;
                sum += (dif * dif);
            }
            return sum;
        }
        
        //******************** MEAN **************************************//
        /// <summary>
        /// gets the average of a list of numeric values
        /// </summary>
        /// <typeparam name="T">IComparable numeric type</typeparam>
        /// <param name="list">data set</param>
        /// <returns></returns>
        public static double? Mean<T>(IEnumerable<T> list) where T: IComparable<T>
        {
            double? sum = null;
            IEnumerator<T> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                sum += enumer.Current as double?;
            }
            if (sum != null)
                return (double)sum / list.Count();
            return null;
        }
        /// <summary>
        /// gets the average of a list of numeric values
        /// </summary>
        /// <param name="list">data set</param>
        /// <returns></returns>
        public static double Mean(IEnumerable<double> list)
        {
            double sum = 0;
            IEnumerator<double> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
                sum += enumer.Current;
            return sum / list.Count();
        }

        //******************** PROBABILITY *******************************//
        /// <summary>
        /// Gets the proportion of the sample that is within the inclusive interval [xMin, xMax].
        /// </summary>
        /// <param name="list">Data set</param>
        /// <param name="xMin">The min value of the range to find the proportion of. (inclusive)</param>
        /// <param name="xMax">The max value of the range to find the proportion of. (inclusive)</param>
        /// <returns></returns>
        public static double GetProportionExclusive(IEnumerable<double> list, double xMin, double xMax)
        {
            double rangeCount = 0;
            IEnumerator<double> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                if (enumer.Current > xMin && enumer.Current < xMax)
                    ++rangeCount;
            }
            return rangeCount / list.Count();
        }
        /// <summary>
        /// Gets the proportion of the sample that is within the inclusive interval [xMin, xMax].
        /// </summary>
        /// <param name="list">Data set</param>
        /// <param name="xMin">The min value of the range to find the proportion of. (inclusive)</param>
        /// <param name="xMax">The max value of the range to find the proportion of. (inclusive)</param>
        /// <returns></returns>
        public static double GetProportionInclusive(IEnumerable<double> list, double xMin, double xMax)
        {
            double rangeCount = 0;
            IEnumerator<double> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                if (enumer.Current >= xMin && enumer.Current <= xMax)
                    ++rangeCount;
            }
            return rangeCount / list.Count();
        }
        /// <summary>
        /// Gets the proportion of the sample that is of the discrete value x.
        /// </summary>
        /// <param name="list">Data set</param>
        /// <param name="xMin">The discrete value to find the proportion of.</param>
        /// <returns></returns>
        public static double GetProportionDiscrete(IEnumerable<double> list, double x)
        {
            double xCount = 0;
            IEnumerator<double> enumer = list.GetEnumerator();
            while (enumer.MoveNext())
            {
                if(enumer.Current == x)
                    ++xCount;
            }
            return xCount / list.Count();
        }

        //******************** UTILITY ***********************************//
        /// <summary>
        /// gets the type of an object
        /// </summary>
        /// <typeparam name="T">any type</typeparam>
        /// <param name="obj">the object to find the type of</param>
        /// <returns>the type of the obj</returns>
        public static Type FindType<T>(T obj)
            => (obj == null) ? typeof(T) : obj.GetType();
        /// <summary>
        /// Get the factorial of some value. Max Value of 
        /// </summary>
        /// <param name="number">value to perform the factorial on</param>
        /// <returns></returns>
        public static double Factorial(double number)
        {
            if (number == 0 || number == 1)
                return 1;
            if (number > 1)
                return number *= Factorial(--number);
            else
                return number;
        }
        /// <summary>
        /// Initializes a statistical set of mean, standard deviation, variance, and sample size from a data set
        /// </summary>
        /// <param name="list">Data set.</param>
        /// <param name="mean">Average of the data set.</param>
        /// <param name="stdDev">The standard deviation of the data set.</param>
        /// <param name="variance">The variance of the data set.</param>
        /// <param name="n">The count of the sample inputs.</param>
        public static void InitializeStats(IEnumerable<double> list, out double mean, out double stdDev, out double variance, out int n)
        {
            mean = Mean(list);
            variance = Variance(list, mean);
            stdDev = StandardDev(variance);
            n = list.Count();
        }

        public static void InitializeStats(IEnumerable<double> list, out StatObj statObj)
        {
            double m = Mean(list);
            double v = Variance(list, m);
            double sd = StandardDev(v);
            int n = list.Count();
            statObj = new StatObj(list, m, sd, v, n);
        }
    }

    public class StatObj
    {
        readonly string NL = Environment.NewLine;
        public StatObj(IEnumerable<double> data, double mean, double stdDev, double variance, int n)
        {
            Mean = mean;
            StdDev = stdDev;
            Variance = variance;
            N = n;
            Data = data;
        }

        double Mean { get; set; }
        double StdDev { get; set; }
        double Variance { get; set; }
        double N { get; set; }
        IEnumerable<double> Data { get; set; }

        public override string ToString()
        {
            return $"MEAN: {Mean,8}{NL}StdDev: {StdDev,8}{NL}VARIANCE: {Variance,8}{NL}n: {N,8}{NL}DATA: {Data.GetType(),8}";
        }
    }
}
