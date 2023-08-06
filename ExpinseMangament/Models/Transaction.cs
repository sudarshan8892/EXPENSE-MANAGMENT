using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpinseMangament.Models
{
    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string? Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Transactions")]
        public virtual Category Category { get; set; } = null!;
    }
}
