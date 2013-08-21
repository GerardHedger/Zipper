using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using C1.C1Zip;

namespace Zipper
{
    class Program
    {
        static void Main(String[] args)
        {
            String DirectoryToRead = "";
            String DirectoryToSave = "";
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: Zipper \\SourceFolder \\DestinationFile");
                return;
            }
            if (args.Length > 0)
            {
                Console.WriteLine(args[0]);
                DirectoryToRead = args[0];

            }
            if (args.Length > 1)
            {
                DirectoryToSave = args[1] + DateTime.Now.ToString("yyyyMMddHHmm") + ".zip";
                Console.WriteLine(args[1] + DateTime.Now.ToString("yyyyMMddHHmm") + ".zip");
            }

            Console.WriteLine(DirectoryToSave);


            Int32 Depth = 0;
            C1ZipFile zf = new C1ZipFile(DirectoryToSave, true);
            FolderLoop(DirectoryToRead, Depth, zf);
            zf.Close();
            //Console.WriteLine("Press any key ...");
            //Console.ReadKey();

        }

        static void FolderLoop(String DirectoryToRead, Int32 Depth, C1ZipFile zf)
        {
            DirectoryInfo di = new DirectoryInfo(DirectoryToRead);
            ++Depth;

            foreach (DirectoryInfo diSub in di.GetDirectories())
            {
                Console.WriteLine(DirectoryToRead);
                DirectoryToRead = diSub.FullName;
                FolderLoop(DirectoryToRead, Depth, zf);
            }
            foreach (FileInfo fi in di.GetFiles())
            {
                Console.WriteLine(fi.FullName);
                zf.Entries.Add(fi.FullName, Depth);
            }
        }



    }
}
