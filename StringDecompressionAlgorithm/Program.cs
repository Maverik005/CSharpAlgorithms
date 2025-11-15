
using StringDecompressionAlgorithm;

Console.WriteLine("Decompressed string:");

string compressedString = "ab3c123d4";
string decompressedString = StringDecompression.DecompressString(compressedString);
Console.WriteLine(decompressedString);

//int[] videoStreams = [10,20,30,40];
//double[] revenueStreams = [100, 1000, 900, 1600];
//double bandWidthCap = 90;
//double totalVideoStreamingRevenue = VideoStreamsRevenueWithBandwidthCap.CalculateMaxRevenue(videoStreams, revenueStreams, bandWidthCap);
//Console.WriteLine(totalVideoStreamingRevenue);