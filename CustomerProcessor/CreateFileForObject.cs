using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CustomerProcessor
{
    public static class CreateFileForObject
    {
        public static void Create(BasicAccountDetails bad, string path)
        {
            byte[] data;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream s = new MemoryStream())
            {
                bf.Serialize(s, bad);
                data = s.ToArray();
            }

            byte[] bytes = CompressStringToBytes(data);
            File.WriteAllBytes(path, bytes);
        }

        private static byte[] CompressStringToBytes(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(ms, CompressionMode.Compress, false))
                {
                    zipStream.Write(data, 0, data.Length);
                }
                return ms.ToArray();
            }
        }
    }
}
