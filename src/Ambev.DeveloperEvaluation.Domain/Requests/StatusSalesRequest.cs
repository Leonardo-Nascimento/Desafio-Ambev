using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Requests
{
    public class StatusSalesRequest
    {
        public List<string> StatusOrder { get; set; } = new List<string>() { "Cancelled", "NotCancelled" };
    }
}
