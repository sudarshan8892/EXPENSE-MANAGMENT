using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpinseMangament.Models
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string? Icon { get; set; }
        [StringLength(50)]
        public string? Type { get; set; } = "Expense";

        [InverseProperty("Category")]
        public virtual ICollection<Transaction> Transactions { get; set; }


       // [NotMapped]
        //public string? IconTitle
        //{
        //    get
        //    {
        //        return this.Icon + "  "+ this.Title;

        //    }


        //}   

       

    }
}
