using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ME.Core2.Entities
{
    public class CustomerAccount
    {
        [DataContract]
        [Serializable]
        public class CustomerAccountInfo
        {
            [DataMember]
            [Required]
            public string customerId { get; set; }
            [DataMember]
            [Required]
            // this is the accountno by definition
            public string? accountNo { get; set; }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
        }
    }
}
