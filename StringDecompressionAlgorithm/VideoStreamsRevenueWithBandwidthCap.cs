using System;
using System.Collections.Generic;
using System.Text;

namespace StringDecompressionAlgorithm
{
    public class VideoStreamsRevenueWithBandwidthCap
    {
        public static double CalculateMaxRevenue(int[] videoStreams, double[] revenues, double bandwidthCap)
        {
            if(videoStreams.Length != revenues.Length)
            {
                throw new ArgumentException("videoStreams and revenues arrays must have the same length.");
            }

            if (bandwidthCap == 0) return 0;

            double totalRevenue = 0.0;
            double totalBandwidthConsumed = 0.0;
            double[] revenuePerStream = new double[videoStreams.Length];

            CalculateRevenuePerStream(videoStreams, revenues, ref revenuePerStream);
            //arrange revenuePerStream and Videostreams in descending order of revenuePerStream
            ArrangeStreamsInDescendingOrder(ref revenuePerStream, ref videoStreams);

            for (int i = 0; i < videoStreams.Length; i++)
            {
                if(totalBandwidthConsumed + videoStreams[i] <= bandwidthCap)
                {
                    totalBandwidthConsumed += videoStreams[i];
                    totalRevenue = videoStreams[i] * revenuePerStream[i] + totalRevenue;
                }
                else if(totalBandwidthConsumed < bandwidthCap)
                {
                    double remainingBandwidth = bandwidthCap - totalBandwidthConsumed;
                    totalRevenue = remainingBandwidth * revenuePerStream[i] + totalRevenue;
                }
            }

            return totalRevenue;
        }

        private static void CalculateRevenuePerStream(int[] videoStreams, double[] revenues, ref double[] revenuePerStream)
        {
            for (int i = 0; i < videoStreams.Length; i++)
            {
                revenuePerStream[i] = revenues[i] / videoStreams[i];
            }
        }

        private static void ArrangeStreamsInDescendingOrder(ref double[] revenuePerStream, ref int[] videoStreams)
        {
            for (int i = 0; i < videoStreams.Length; i++)
            {
                if (i > 0)
                {
                    for (int j = i; j < videoStreams.Length; j++)
                    {
                        if (revenuePerStream[j - 1] < revenuePerStream[j])
                        {
                            //swap revenuePerStream
                            double tempRevenuePerStream = revenuePerStream[j];
                            revenuePerStream[j] = revenuePerStream[j - 1];
                            revenuePerStream[j - 1] = tempRevenuePerStream;
                            //swap videoStreams
                            int tempVideoStreams = videoStreams[j];
                            videoStreams[j] = videoStreams[j - 1];
                            videoStreams[j - 1] = tempVideoStreams;
                        }
                        else if (revenuePerStream[j - 1] > revenuePerStream[j]) break;
                    }
                }
            }
        }
    }
}
