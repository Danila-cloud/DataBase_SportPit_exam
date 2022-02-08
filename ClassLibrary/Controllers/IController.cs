
using System;
using System.Collections.Generic;
using ClassLibrary.Entities.Auth;

namespace ClassLibrary.Controllers
{
    interface IController <Entity>
    {
        /// <summary>
        /// Список групп, которым разрешены операции с этими данными
        /// </summary>
        public List<Group> AcceptGroup { get; set; }


        /// <summary>
        /// Создать элемент
        /// </summary>
        /// <param name="Item">Новая сущность</param>
        /// <returns>результат создания сущности (Да нет)</returns>
        public bool Create(Entity Item);

        public Entity Read(Guid Id);

        public List<Entity> ReadAll();

        public bool Update(Guid Id, Entity Item);

        public bool Delete(Guid Id);
        
    }

}
