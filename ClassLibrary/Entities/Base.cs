using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    /// <summary>
    /// Базовый класс для взаимодействия с данными
    /// </summary>
    public class Base
    {
        /// <summary>
        /// Уникальный Id объекта
        /// </summary>
        public Guid Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// При создании класса уникальный Id создается автоматически
        /// </summary>
        public Base()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
