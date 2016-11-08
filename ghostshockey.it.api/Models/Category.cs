﻿using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.api.Models
{
    [Table("Category")]
    public class Category 
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(3)]
        public string CategoryTag { get; set; }

        [Column("Category")]
        [Required]
        [StringLength(10)]
        public string Category1 { get; set; }

        public byte Enabled { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }

    public class CategoryComparer : IEqualityComparer<Category>
    {
        public bool Equals(Category x, Category y)
        {
            if (x.CategoryID == y.CategoryID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Category p)
        {
            int hCode = p.CategoryID.GetHashCode();
            return hCode;
        }
    }
}