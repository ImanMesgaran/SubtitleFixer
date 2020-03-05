using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SubtitleFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Path of the Folder, which contains Subtitle files:");
            var inputPath = Console.ReadLine();

            if (!Directory.Exists(inputPath))
                return;

            if (!Directory.Exists($@"{inputPath}\Converted"))
                Directory.CreateDirectory($@"{inputPath}\Converted");

            var listOfFiles = System.IO.Directory.GetFiles(inputPath, "*.srt", SearchOption.AllDirectories);

            ConvertDirectoryContent(inputPath, listOfFiles);
        }

        private static void ConvertDirectoryContent(string path,IEnumerable<string> listOfFiles)
        {
            foreach (var file in listOfFiles)
            {
                var newFilePath = $@"{path}\Converted\{Path.GetFileNameWithoutExtension(file)} - Edited.{Path.GetExtension(file)}";
                
                var content = File.ReadAllBytes(file);
                var Utf8Data = ConvertAnsiToUtf8(content);

                if (File.Exists(newFilePath))
                    File.Delete(newFilePath);

                File.WriteAllBytes(newFilePath, Utf8Data);
            }
        }

        private static byte[] ConvertAnsiToUtf8(byte[] fileContent)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] Win1256Data = fileContent;
            byte[] Utf8Data = Encoding.Convert(Encoding.GetEncoding(1256), Encoding.UTF8, Win1256Data);
            return Utf8Data;
        }
    }
}
