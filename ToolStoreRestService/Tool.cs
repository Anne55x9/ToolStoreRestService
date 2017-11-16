using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ToolStoreRestService
{
    [DataContract]
    public class Tool
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Brand { get; set; }

        [DataMember]
        public int Price { get; set; }

    }
}