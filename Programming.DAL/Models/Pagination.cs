using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL.Models
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public string FilterQuery { get; set; }
    }
}
