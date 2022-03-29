using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class DtoDirectionResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
   
        public string Location { get; set; }

        public string Country { get; set; }

        public bool Default { get; set; }
    }
}
