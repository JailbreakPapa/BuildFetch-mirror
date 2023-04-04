global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Diagnostics;
namespace BuildTools.BuildFetch
{
    public static class BFCache
    {
        public static string homedir = "D:\\Khaos";
        public static List<String> list = new List<string>();
        public static string file = "khaos_root_dir.khaos_txt";
        public static int count = 0;
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        private static string search(string sDir)
        {
            foreach (string d in Directory.GetDirectories(sDir))
            {
                try
                {
                    if (list.Count == 0)
                    {
                        //Console.WriteLine(d);
                        foreach (string f in Directory.GetFiles(d, file))
                        {
                            count++;
                            list.Add(f);
                            if (f.Contains("Khaos"))
                            {
                                return list[count];
                            }
                        }
                        if (list.Count == 0)
                        {
                            search(d);
                        }

                    }

                }
                catch (System.Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }
            }

            //defualt directory.
            return "D:\\Khaos";
        }
        public static string FindEngineRootDir()
        {
            Console.WriteLine("Checking For Cache File.");
            string[] drive = Directory.GetLogicalDrives();
            foreach (string sa in drive)
            {
                //Check If We Have Already Found The Root Dir.
                if (File.Exists(sa + "smdir.storagesm"))
                {
                    try
                    {
                      return homedir = File.ReadLines(sa + "smdir.storagesm").First();
                    }
                   catch (System.Exception e)
                    {
                        Console.WriteLine("Found Cache File, But Failed To Read Data. Make Sure To Not Open It In A Editor. ");
                        Console.WriteLine("Error Result: " + e.Message + ". Manually Searching For Root Path. It is recommended that you create a file on the drive that the repo is stored on, name it: smdir.storagesm, then open it and put the root directory inside it.");
                    }
                }
            }

            foreach (string s in Directory.GetLogicalDrives())
            {

                string result = search(s);
                if (result.Contains("Khaos"))
                {
                    try
                    {
                        File.Create(result + "smdir.storagesm");
                        FileStream st = File.OpenWrite(result + "smdir.storagesm");
                        AddText(st, result);
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("Couldnt Save Build Storage." + e.Message);
                    }
                    homedir = result;
                    return result;
                }
            }
            //defualt directory.
            return "D:\\Khaos";
        }
        public static string FindEngineThirdPartyDir()
        {
            return (homedir + "\\3rdParty");
        }
    }
}