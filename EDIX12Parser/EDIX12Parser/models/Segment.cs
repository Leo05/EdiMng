using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIX12Parser.models
{
    class Segment
    {
        public int SID { get; set; }
        public string SegID { get; set; }
        public string[] Elements { get; set; }
        public bool NewLine { get; set; }
    }
    class Lines
    {
        public int linesegid { get; set; }
        public string SegID { get; set; }
        public string[] Elements { get; set; }
        public bool NewLine { get; set; }
    }
}
