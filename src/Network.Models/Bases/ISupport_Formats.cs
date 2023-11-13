using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Network.Models.Bases
{
    public interface ISupport_Formats
    {
        public int Quality { get; set; }
        public string Format { get; set; }

        public string New_description { get; set; }
        public string Display_Desc { get; set; }
        public string SuperScript { get; set; }
        public List<string> Codec { get; set; }
    }
}
