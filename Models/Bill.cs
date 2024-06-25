using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApp.Models
{
    public class Bill
    {
        [Key]
        public int BillNumber { get; set; } // This will be the primary key
        public DateTime IssueDate { get; set; }

        public int CustomerId { get; set; } // Foreign key to Customer
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public string { get; set; } // Foreign key to Service
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }

        public bool PaymentStatus { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentMethodDescription { get; set; }
    }
}
