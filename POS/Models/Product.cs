using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public  class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code
        {
            get;set;
        }
        public string catogaryId
        {
            get;set;
        }
        public string catogaryName
        {
            get; set;
        }
    }
}
