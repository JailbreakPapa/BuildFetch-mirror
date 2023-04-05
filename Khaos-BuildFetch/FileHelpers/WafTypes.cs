using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Khaos_BuildFetch.FileHelpers
{
    /// <summary>
    /// Class For Extracting Information from waf (script) files.
    /// This is for converting waf build files to BuildFetch Files.
    /// </summary>
    public class WafDeclTypes
    {
        /// <summary>
        /// Returns a list of strings that contain the sub folders of a script.
        /// </summary>
        /// <returns>
        /// Lists of Sub folder Strings.
        /// </returns>
       public List<String> GetFileSubfolders(FileStream fileStream)
       {
            //First Look for the sub folder attribute.
            StreamReader sr = new StreamReader(fileStream);
            List<String> result = new List<String>();
            string sub;
            while (sr.ReadLine()
                   != null)
            {
                sub = sr.ReadLine();
                if(sub.Contains("SUBFOLDERS") && sub.Contains(" = "))
                {
                    ///Recurse Those Lines. make sure they contain ('').
                    while ((_ = sr.ReadLine()) != null
                           && (_ = sr.ReadLine()) != "]")
                    {
                        if (sub.Contains("'"))
                        {
                            string n =  sub.Replace(",", "");
                            result.Add(n);
                        }
                    }
                }
            }
            sr.Close();
            //If we default to no SUBFOLDERS, then we return null. 
            return new List<string>();
       }
       ///TODO: Create Function that grabs attributes from the build function!
    }
}
