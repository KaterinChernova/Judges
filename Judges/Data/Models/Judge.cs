using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Data.Models
{
    /// <summary>
    /// Судья.
    /// </summary>
    public class Judge
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
    }
}
