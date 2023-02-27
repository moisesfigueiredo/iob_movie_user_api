using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Bases
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}