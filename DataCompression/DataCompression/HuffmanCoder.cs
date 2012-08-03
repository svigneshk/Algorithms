using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression
{
    public class HuffmanCoder
    {
        Dictionary<char, long> frequencyMap = new Dictionary<char,long>();

        public void BuildCodes(string fileName)
        {
            int startIndex = 0;
            using(StreamReader reader = new StreamReader(fileName))
            {
                do 
                {
                    char[] buffer = new char[1000];
                    reader.Read(buffer, 0, buffer.Length);

                    foreach(char c in buffer)
                    {
                        if(!frequencyMap.ContainsKey(c))
                        {
                            frequencyMap.Add(c, 1);
                        }
                        else
                        {
                            frequencyMap[c]++;
                        }
                    }

                    startIndex = buffer.Length;
                } while(!reader.EndOfStream);
            }

            foreach(KeyValuePair<char, long> kvp in frequencyMap)
            {

            }
        }
    }
}
