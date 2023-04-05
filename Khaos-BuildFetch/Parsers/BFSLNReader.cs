using BugSplatDotNetStandard.Api;
using ClangSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Khaos_BuildFetch.Parsers
{
    public class BFSLNReader
    {

        public BFSLNReader(FileStream slnstream) 
        {
            if (slnstream == null || !slnstream.CanSeek)
            {
                throw new ArgumentNullException("Build Fetch Was Provided A Bad File Stream!");
            }
            else
            {
                fileStream = new StreamReader(slnstream);
            }
        }

        public string ReturnVisualStudioVersion()
        {
            while (fileStream.ReadLine() != null)
            {
                version = fileStream.ReadLine();
                if (string.IsNullOrEmpty(version))
                {
                    fileStream.Close();
                    return "00.0.00000.000";
                }
                if(version.Contains("VisualStudioVersion"))
                {
                    //Chop off "VisualStudioVersion" string, and only return the number.
                    string cleanvers = version.Replace("VisualStudioVersion = ", "");
                    fileStream.Close();
                    return version = cleanvers;
                }
            }
            //If all else fails, close file stream, and return a bad visual studio version. 
            fileStream.Close();
            return "BAD VERSION";
        }
        private StreamReader fileStream;

        private string version;
    }

}
