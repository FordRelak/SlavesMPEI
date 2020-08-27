using System;

namespace SlavesMPEI.Domain.Entities
{
    /// <summary>
    /// Класс представляет заказ для выполнения
    /// </summary>
    public class Order
    {
        public Order()
        {
            IsDone = false;
            CreateDate = DateTime.Now.Date;
        }

        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит данный заказ
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Пользователь, которому принадлежит данный заказ
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Название предмета/урока/пары
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Язык программирования
        /// </summary>
        public string ProgLang { get; set; }

        /// <summary>
        /// Задание на выполение
        /// </summary>
        public string Task { get; set; }

        /// <summary>
        /// Дата создания задачи
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Крайний срок выполения задачи
        /// </summary>
        public DateTime? DeadLine { get; set; }

        /// <summary>
        /// Путь к картинке задания
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Состояние заказа. true - выполнен, иначе false.
        /// Изначально состояние false
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Путь к архиву, в котором находится решение задачи
        /// </summary>
        public string ArchivePath { get; set; }
    }
}