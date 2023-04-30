using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ME.Core2.Entities
{
        [DataContract]
        [Serializable]
        public class Transaction
        {
            [DataMember]
            [Required]
            public string transId { get; set; }
            [DataMember]
            [Required]
            public string accountNo { get; set; }
            [DataMember]
            [Required]
            public DateTime transDate { get; set; }
            [DataMember]
            [Required]
            public double lastAmount { get; set; }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            }
        }

        [DataContract]
        [Serializable]
        public class TransactionResponse
        {
            private List<Transaction> _transactions = new List<Transaction>();

            [DataMember]
            public CustomerInfo customer { get; set; }
            [DataMember]
            public List<Transaction> Transactions
            {
                get
                {
                    if (_transactions != null)
                    {
                        return _transactions;
                    }

                    return _transactions;
                }
                set
                {
                    _transactions = value;
                }
            }
        }
}
