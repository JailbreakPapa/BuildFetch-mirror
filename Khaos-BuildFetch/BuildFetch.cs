// Copyright (C) 2022 - 2023 Kura Studios LLC. All Rights Reserved.
namespace BuildTools.BuildFetch
{

  public static class BuildFetch
  {
    /// looks For The Sharpmake.Application *.exe so we can launch a build instamce with it later.
    public static string FetchSharpmake() => BFCache.FindEngineRootDir() + "\\BuildTools\\Sharpmake.Application.exe";
    /// <summary>
    /// Gets All Build Files Within The Engines Directory.
    /// </summary>
    /// <param name="removehome"> True: Remove The Home Path. EX: D:\Khaos Would Be Removed in the string: D:\Khaos\main.sharpmake.cs</param>
    /// <returns>
    /// List of Build Files.
    /// </returns>
    public static List<string> GetSharpmakeFiles(bool removehome)
    {
      // First Look For The Root Directory.
      string root = BFCache.FindEngineRootDir();
      foreach (string file in Directory.GetFiles(root, "*.sharpmake.cs"))
      {
        string localfile = string.Empty;
        // Replaces Home Directory.
        if (removehome == true)
        {
          localfile = file.Replace(root + "\\", "");
        }
        BFCache.list.Add(localfile);
        Console.Write("Found Build File: " + localfile + " \n");
        foreach (string subdir in Directory.GetDirectories(root))
        {
          foreach (string subfile in Directory.GetFiles(subdir, "*.sharpmake.cs"))
          {
            string lf = string.Empty;
            // Replaces Home Directory.
            if (removehome == true)
            {
              lf = subfile.Replace(subdir + "\\", "");
            }
            Console.Write("Found Build File: " + lf + " \n");
            BFCache.list.Add(lf);
          }
        }
      }
      return BFCache.list;
    }
    public static void CallSharpmakeForBuild(List<string> input)
    {
      string source = string.Empty;
      foreach (string a in input)
      {
        string news = a.Replace("\\", @"\\\");
        source += "'" + news + "'" + " " + ",";
      }
      string args = "/sources( " + source + " ) ";
      // Start Sharpmake App.
      ProcessStartInfo startInfo = new ProcessStartInfo(
        FetchSharpmake(),
        args);
      startInfo.UseShellExecute = true;
      startInfo.WorkingDirectory = BFCache.FindEngineRootDir();
      _ = Process.Start(startInfo);
    }
    public static void Main(string[] args)
    {
      Console.WriteLine("Khaos Engine Build Fetch. Copyright (C) 2022 - 2023 Kura Studios LLC. All Rights Reserved.");
      // Check Command Line

      // Cleanup And Exit.
    }
  }


}
