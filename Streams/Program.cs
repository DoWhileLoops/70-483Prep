using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    class Program
    {
        public static string path = @"C:\temp\test.dat";

        static void FileStreamDemo()
        {    
            using (FileStream fileStream = File.Create(path))
            {
                string myValue = "MyValue";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }
        }
        
        static void StreamWriterDemo()
        {
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string myValue = "MyValue";
                streamWriter.Write(myValue);
            }
        }

        static void OpenAndRead()
        {
            using(FileStream fileStream = File.OpenRead(path))
            {
                byte[] data = new byte[fileStream.Length];

                for(int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(data));
            }
        }

        static void GZipStreamDemo()
        {
            string folder = @"C:\temp";
            string uncompressedFilePath = Path.Combine(folder, "uncompressed.dat");
            string compressedFilePath = Path.Combine(folder, "compressed.gz");
            byte[] dataToCompress = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();

            using (FileStream uncompressedFileStream = File.Create(uncompressedFilePath))
            {
                uncompressedFileStream.Write(dataToCompress, 0, dataToCompress.Length);
            }
            using(FileStream compressedFileStream = File.Create(compressedFilePath))
            {
                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                {
                    compressionStream.Write(dataToCompress, 0, dataToCompress.Length);
                }
            }

            FileInfo uncompressedFile = new FileInfo(uncompressedFilePath);
            FileInfo compressedFile = new FileInfo(compressedFilePath);

            Console.WriteLine("uncompressedFile: "  + uncompressedFile.Length);
            Console.WriteLine("compressedFile: " + compressedFile.Length);
        }

        static void BufferedStream()
        {
            string path2 = @"C:\temp\bufferedStream.txt";

            using(FileStream fileStream = File.Create(path))
            {
                using(BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using(StreamWriter streamWriter = new StreamWriter(bufferedStream))
                    {
                        streamWriter.WriteLine("A line of text");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            FileStreamDemo();
            StreamWriterDemo();
            OpenAndRead();
            GZipStreamDemo();
            BufferedStream();

            Console.WriteLine("*************");

            Console.ReadKey();
        }
    }
}
