
using StringDecompressionAlgorithm;

Console.WriteLine("Hello, World!");

/*string compressedString = "ab3c123d4";
string decompressedString = StringDecompressionAlgorithm.StringDecompression.DecompressString(compressedString);*/

int[] videoStreams = [10,20,30,40];
double[] revenueStreams = [100, 1000, 900, 1600];
double bandWidthCap = 90;
double totalVideoStreamingRevenue = VideoStreamsRevenueWithBandwidthCap.CalculateMaxRevenue(videoStreams, revenueStreams, bandWidthCap);
Console.WriteLine(totalVideoStreamingRevenue);