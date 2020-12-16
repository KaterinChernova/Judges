using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Data.Models
{
    [Table("sports")]
    public class Sport
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        [Column("id", TypeName = "serial")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Column("name", TypeName = "varchar(200)")]
        public string Name { get; set; }


        /// <summary>
        /// Описание
        /// </summary>
        [Column("description", TypeName = "varchar(2000)")]
        public string Description { get; set; }

        public virtual ICollection<Judge> Judges { get; set; }
    }
}
