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
    [Table("Team")]
    public class Team 
    {
        //public Team()
        //{
        //    Matches = new HashSet<Match>();
        //    Matches1 = new HashSet<Match>();
        //    PlayerDataTeams = new HashSet<PlayerDataTeam>();
        //}

        public int TeamID { get; set; }      

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public int ClubID { get; set; }

        [ForeignKey("ClubID")]
        public virtual Club Club { get; set; }
        
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match> Matches { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Match> Matches1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PlayerData> PlayerDatas { get; set; }
    }

    public class TeamComparer : IEqualityComparer<Team>
    {
        public bool Equals(Team x, Team y)
        {
            if (x.TeamID == y.TeamID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Team p)
        {
            int hCode = p.TeamID.GetHashCode();
            return hCode;
        }
    }

    //public static class TeamMapper
    //{
    //    public static Team MapToModel(this model.Poco.Team dto)
    //    {
    //        Team model = new Team();
    //        model.TeamID = dto.TeamID;
    //        model.CategoryID = dto.CategoryID;
    //        model.ClubID = dto.ClubID;
    //        model.Name = dto.Name;

    //        return model;
    //    }

    //    public static model.Poco.Team MapToDto(this Team model)
    //    {
    //        model.Poco.Team dto = new model.Poco.Team();
    //        dto.TeamID = model.TeamID;
    //        dto.Name = model.Name;
    //        dto.CategoryID = model.CategoryID;
    //        dto.Category = model.Category.MapToDto();
    //        dto.ClubID = model.ClubID;
    //        dto.Club = model.Club.MapToDto();

    //        return dto;
    //    }
    //}
}
