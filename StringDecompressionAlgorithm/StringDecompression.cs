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
            StringBuilder decompressed = new StringBuilder();
            char[] chars = compressed.ToCharArray();
            //convert char[] to string[]
            string[] compressedStringArray = chars.Select(c => c.ToString()).ToArray();
            StringBuilder substringToDecompress = new();

            ConcatenateConsecutiveDigits(ref compressedStringArray);
            Console.WriteLine(chars);

            for (int i = 0; i < compressedStringArray.Length; i++)
            {
                int result;
                bool isNumber = int.TryParse(compressedStringArray[i].ToString(), out result);
                if (!isNumber)
                {
                    substringToDecompress.Append(compressedStringArray[i]);
                }
                else if (isNumber)
                {
                    int repeatCount = result;
                    string substring = substringToDecompress.ToString();
                    for (int j = 0; j < repeatCount; j++)
                    {
                        decompressed.Append(substring);
                    }
                    substringToDecompress.Clear();
                }
            }
            return decompressed.ToString();
        }

        private static void ConcatenateConsecutiveDigits(ref string[] compressedStringArray)
        {
            StringBuilder substringOfDigits = new StringBuilder();
            int substringCounter = -1;

            for (int i = 0; i < compressedStringArray.Length; i++)
            {
                int firstDigit;
                int nextDigit;
                bool isDigit = int.TryParse(compressedStringArray[i].ToString(), out firstDigit);
                bool isNextDigit = (i+1) < compressedStringArray.Length ?int.TryParse(compressedStringArray[i + 1].ToString(), out nextDigit): false;

                if (isDigit)
                {
                    substringOfDigits.Append(compressedStringArray[i]);
                    substringCounter++;
                    if (!isNextDigit && substringOfDigits.Length == 1)
                    {
                        substringOfDigits.Clear();
                        substringCounter = -1;
                    }
                }
                else if (!isDigit && substringOfDigits.ToString().Length > 1)
                {
                    compressedStringArray[i - (substringCounter+1)] = substringOfDigits.ToString();
                    List<string> tempList = new List<string>(compressedStringArray);
                    tempList.RemoveRange(i - substringCounter, substringCounter);
                    compressedStringArray = tempList.ToArray();
                    i = i - substringCounter + 1;
                    substringOfDigits.Clear();
                    substringCounter = -1;
                }

                if (i == compressedStringArray.Length - 1 && substringOfDigits.ToString().Length > 1)
                {
                    compressedStringArray[i - substringCounter] = substringOfDigits.ToString();
                    List<string> tempList = new List<string>(compressedStringArray);
                    tempList.RemoveRange(i, substringCounter);
                    compressedStringArray = tempList.ToArray();
                    i = i - substringCounter + 1;
                    substringOfDigits.Clear();
                    substringCounter = -1;
                }
            }
        }
    }
}
