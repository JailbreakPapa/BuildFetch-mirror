using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khaos_BuildFetch.Parsers;
namespace Khaos_BuildFetch_Tests
{
    [TestClass]
    public class SLNReaderTest
    {
        [TestMethod]
        public void Test_ReadSLNVersion()
        {
            FileStream test = new FileStream("TestFiles\\Khaos-BuildFetch.sln", FileMode.Open);
            BFSLNReader bFSLNReader = new BFSLNReader(test);
            string outputversion = string.Empty;
            outputversion =  bFSLNReader.ReturnVisualStudioVersion();
            if (outputversion.Contains("VisualStudioVersion"))
            {
                Assert.Fail(outputversion);
                Console.WriteLine(outputversion);
            }
            else if (outputversion.Contains("VisualStudioVersion = "))
            {
                Assert.Fail(outputversion);
                Console.WriteLine(outputversion);
            }
            else if (outputversion.Contains("00.0.00000.000")) 
            {
                Console.WriteLine(outputversion);
                Assert.Fail(outputversion);
            }
            Console.WriteLine(outputversion);
        }
    }
}
