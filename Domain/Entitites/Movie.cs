using Domain.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitites
{
    [Table("movies")]
    public class Movie : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("director")]
        public string Director { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }
    }
}
