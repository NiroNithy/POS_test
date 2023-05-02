using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public  class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

         public string Password { get; set; }

        public string UserType { get; set; }

    }
}
