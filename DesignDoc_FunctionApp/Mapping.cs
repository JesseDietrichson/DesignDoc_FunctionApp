using System;
using System.Collections.Generic;
using System.Text;

namespace DesignDoc_FunctionApp
{
    public class Mapping
    {
        public string Key { get; set; }
        public List<string> Value { get; set; }
        public bool ShouldIndent { get; set; }
    }
}
