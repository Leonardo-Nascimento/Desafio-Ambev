using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Models
{
    public class OrderModel
    {
        public long Id { get; set; }
        public CustomerModel Customer { get; set; }
        public StoreBranchModel StoreBranch { get; set; }
        public string SalesCode { get; set; }
        public DateTime SalesDate { get; set; }
        public StatusSales StatusSales { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
    }
}
