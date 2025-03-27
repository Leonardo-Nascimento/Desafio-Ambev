using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Models
{
    public class StoreBranchModel
    {
        public long Id { get; set; }
        public string NameBranch { get; set; }
        public int Number { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
