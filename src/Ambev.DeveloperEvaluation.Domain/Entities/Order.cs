using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order(long customerId, long storeBranchId, StatusSales statusSales, decimal totalValue, decimal discount)
        {
            CustomerId = customerId;
            StoreBranchId = storeBranchId;
            StatusSales = statusSales;
            TotalValue = totalValue;
            Discount = discount;
            SalesDate = DateTime.UtcNow.Date;
        }

        public Order()
        {
            
        }

        [ForeignKey("CustomerId")]
        public long CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("StoreBranchId")]
        public long StoreBranchId { get; set; }
        public StoreBranch StoreBranch { get; set; }
        public string SalesCode { get; set; }
        public DateTime SalesDate { get; set; }
        public StatusSales StatusSales { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }



        

        public static List<string> GetStatusSales()
        {
            return Enum.GetNames(typeof(StatusSales)).ToList();
        }

    }
}
