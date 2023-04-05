using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Khaos_BuildFetch.FileHelpers;
namespace Khaos_BuildFetch_Tests
{
    [TestClass]
    public class WAFTypesTest
    {   
        
        [TestMethod]
        /// We will use the wscript file that is found in: D:\frost\dev\Code. the test file assumes that we are grabbing from the output directory.
        /// This test should find the declaration of the sub folders in the wscript, then return a list of strings containing what was listed.
        public void Test_GetFileSubFolders()
        {
            FileStream test_stream = new FileStream("TestFiles\\wscript", FileMode.Open);
            WafDeclTypes waf_test = new();
            List<String> subfolders = new();
            subfolders = waf_test.GetFileSubfolders(test_stream);
            foreach (string test_string in subfolders)
            {
                Assert.IsNotNull(test_string);

                ///NOTE: We don't care if it contains ('), as we could just filter that out on the returned list.
                if (test_string.Contains(",")) { Assert.Fail(); }
                if (test_string.Contains("SUBFOLDERS")) { Assert.Fail(); }
                if (test_string.Contains("[")) { Assert.Fail(); }
                if (test_string.Contains("]")) { Assert.Fail(); }
                Console.Write(test_string);
            }

        }
    }
}
