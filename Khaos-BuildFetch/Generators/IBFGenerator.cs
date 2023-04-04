using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khaos_BuildFetch.Generators
{
    public enum SupportedGenerators 
    { 
        SG_CMAKE,
        SG_WAF,
        SG_LUABASED,
        SG_VISUALSTUDIO,
        SG_LINUXBASED,
        SG_UNKNOWNGENERATOR
    }
    public interface IBFGenerator
    {
        public string ReturnGeneratorString();
        public SupportedGenerators GetUsedGenerators();

        public int ReturnUsedThreads();
    }
}
