
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Khaos_BuildFetch_Tests
{
    [TestClass]
    public class SharpmakeFilesTest
    {
        /// <summary>
        /// Tests If Sharpmake 
        /// </summary>
        [TestMethod]
        public void Test_GetSharpmakeFiles_NoHome()
        {
           List<string> strings =  BuildFetch.GetSharpmakeFiles(true);
           //Check If Its Not Null.
           Assert.IsNotNull(strings);
            foreach (string s in strings)
            {
                if (s.Contains("D:\\"))
                {
                    Assert.Fail();
                    return;
                }
                if (s.Contains("Khaos"))
                {
                    Assert.Fail();
                    return;
                }
                if (!s.Contains("sharpmake"))
                {
                    Assert.Fail();
                    return;
                }
            }

        }
    }
}