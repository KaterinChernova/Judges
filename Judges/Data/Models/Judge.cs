﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Data.Models
{
    /// <summary>
    /// Судья.
    /// </summary>
    [Table("judges")]
    public class Judge
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        [Column("id", TypeName = "serial")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [Column("name", TypeName = "varchar(150)")]
        public string Name { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        [Column("age", TypeName = "integer")]
        public int Age { get; set; }

        /// <summary>
        /// Рейтинг
        /// </summary>
        [Column("raiting", TypeName = "numeric")]
        public double Raiting { get; set; }

        [Column("sport_id", TypeName= "integer")]
        public int? SportId { get; set; }

        [ForeignKey("SportId")]
        public virtual Sport Sport { get; set; }
    }
}
