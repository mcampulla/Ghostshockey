using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.api.Models
{
    [Table("Year")]
    public class Year //: EntityData
    {
        public Year()
        {
        }

        //[Column("YearID")]
        public int YearID { get; set; }

        [Column("Year")]
        [Required] 
        [StringLength(100)]
        public string Year1 { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public bool? IsCurrent { get; set; }


        //public ICollection<Category> Cazzi { get; set; }
    }

    public class YearComparer : IEqualityComparer<Year>
    {
        public bool Equals(Year x, Year y)
        {
            if (x.YearID == y.YearID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Year p)
        {
            int hCode = p.YearID.GetHashCode();
            return hCode;
        }
    }

    public static class YearMapper
    {
        //public static Year MapToModel(this model.Poco.Year dto)
        //{
        //    Year model = new Year();
        //    model.YearID = dto.YearID;
        //    model.Year1 = dto.Name;
        //    model.DateStart = dto.DateStart;
        //    model.DateEnd = dto.DateEnd;
        //    model.IsCurrent = dto.IsCurrent;

        //    return model;
        //}

        //public static model.Poco.Year MapToDto(this Year model)
        //{
        //    model.Poco.Year dto = new model.Poco.Year();
        //    dto.YearID = model.YearID;
        //    dto.Name = model.Year1;
        //    dto.DateStart = model.DateStart;
        //    dto.DateEnd = model.DateEnd;
        //    dto.IsCurrent = model.IsCurrent;

        //    return dto;
        //}
    }
}
