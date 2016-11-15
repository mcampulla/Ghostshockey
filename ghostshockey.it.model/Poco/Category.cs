using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model.Poco
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public byte Enabled { get; set; }
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
