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
    [Table("Club")]
    public class Club 
    {
        public Club()
        {
            //Teams = new HashSet<Team>();
        }

        public int ClubID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(5)]
        public string Cap { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(2)]
        public string Region { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? Type { get; set; }

        [StringLength(10)]
        public string Tag { get; set; }

        [StringLength(100)]
        public string Icon { get; set; }

        public ICollection<Team> Teams { get; set; }
    }

    //public static class ClubMapper
    //{
    //    public static Club MapToModel(this model.Poco.Club dto)
    //    {
    //        Club model = new Club();
    //        model.ClubID = dto.ClubID;
    //        model.Address = dto.Indirizzo;
    //        model.Cap = dto.Cap;
    //        model.City = dto.Citta;
    //        model.Club1 = dto.Name;
    //        model.Email = dto.Email;
    //        model.Icon = dto.Icon;
    //        model.Mobile = dto.Cellulare;
    //        model.Phone = dto.Telefono;
    //        model.Region = dto.Provincia;
    //        model.Tag = dto.Tag;
    //        //model.Type = dto.Type;

    //        return model;
    //    }

    //    public static model.Poco.Club MapToDto(this Club model)
    //    {
    //        model.Poco.Club dto = new model.Poco.Club();
    //        dto.ClubID = model.ClubID;
    //        dto.Name = model.Club1;
    //        dto.Cap = model.Cap;
    //        dto.Cellulare = model.Mobile;
    //        dto.Citta = model.City;
    //        dto.Email = model.Email;
    //        dto.Icon = model.Icon;
    //        dto.Indirizzo = model.Address;
    //        dto.Provincia = model.Region;
    //        dto.Tag = model.Tag;
    //        dto.Telefono = model.Phone;
    //        //dto.Type = model.Type.Value;
    //        dto.Teams = model.Teams != null ? model.Teams.Select(m => m.MapToDto()).ToList() : new List<it.model.Poco.Team>();

    //        return dto;
    //    }
    //}
}
