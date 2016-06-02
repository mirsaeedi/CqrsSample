using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaftar.Core
{
    [System.ComponentModel.Composition.MetadataAttributeAttribute]
    public class ModuleDiscoveryAttribute:Attribute
    {
        public ModuleDiscoveryAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
