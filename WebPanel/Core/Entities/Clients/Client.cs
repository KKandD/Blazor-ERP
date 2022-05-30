using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Clients
{
    public class Client : BaseEntity
    {
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public DateTime AddingDate { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
