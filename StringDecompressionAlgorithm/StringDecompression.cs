using System;
using System.Collections.Generic;
using System.Text;

namespace StringDecompressionAlgorithm
{
    public class StringDecompression
    {
        public static string DecompressString(string compressed)
        {
            if (string.IsNullOrEmpty(compressed))
                return string.Empty;
            StringBuilder decompressed = new();
            StringBuilder substringToDecompress = new();
            StringBuilder repeatCountInString = new();

            for (int i = 0; i < compressed.Length; i++)
            {
                if (char.IsDigit(compressed[i]))
                {
                    repeatCountInString.Append(compressed[i]);
                }
                else
                {
                    if (repeatCountInString.Length > 0)
                    {
                        string substring = substringToDecompress.ToString();
                        for (int j = 0; j < int.Parse(repeatCountInString.ToString()); j++)
                        {
                            decompressed.Append(substring);
                        }
                        substringToDecompress.Clear();
                        repeatCountInString.Clear();
                    }
                    substringToDecompress.Append(compressed[i]);
                }
            }

            if (repeatCountInString.Length > 0)
            {
                string substring = substringToDecompress.ToString();
                for (int j = 0; j < int.Parse(repeatCountInString.ToString()); j++)
                {
                    decompressed.Append(substring);
                }
                substringToDecompress.Clear();
                repeatCountInString.Clear();
            }

            return decompressed.ToString();
        }
    }
}
