using Judges.Data.Dto;
using System;
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
    public class JudgeDto
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Рейтинг
        /// </summary>
        public double Raiting { get; set; }

        /// <summary>
        /// Идентификатор вида спорта.
        /// </summary>
        public int? SportId { get; set; }

        /// <summary>
        /// Вид Спорта.
        /// </summary>
        public string SportName { get; set; }

        /// <summary>
        /// Мероприятия.
        /// </summary>
        public EventDto[] Events { get; set; }
    }
}
