using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Trivia.Things
{
	class Program
	{
		static void Main(string[] args)
		{
			var folderPath = Console.ReadLine();
			
			var reg = new Regex(@"(\(1\))");

			var files = Directory
				.GetFiles(folderPath, searchPattern: "*.*", SearchOption.AllDirectories)
				.Where(f=>reg.IsMatch(f));
			
			foreach (var f in files)
			{
				RenameFile(f);
			}
		}

		static void RenameFile(string f)
		{
			File.Move(f, f.Replace(" (1)", ""), overwrite: true);
		}
	}
}
