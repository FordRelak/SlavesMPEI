using System;
using System.ComponentModel.DataAnnotations;

namespace SlavesMPEI.Domain.Entities
{
    /// <summary>
    /// Класс представляет заказ для выполнения
    /// </summary>
    public class Order
    {
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
        [Required(ErrorMessage = "Укажите предмет")]
        [Display(Name = "Предмет")]
        public string Subject { get; set; }

        /// <summary>
        /// Язык программирования
        /// </summary>
        [Required(ErrorMessage = "Укажите ЯП")]
        [Display(Name = "Язык программирования")]
        [EnumDataType(typeof(ProgLang))]
        public ProgLang ProgLang { get; set; }

        /// <summary>
        /// Задание на выполение
        /// </summary>
        [Required(ErrorMessage = "Нужно написать задание")]
        [Display(Name = "Напишите своё задание")]
        public string Task { get; set; }

        /// <summary>
        /// Дата создания задачи
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Крайний срок выполения задачи
        /// </summary>
        [Required(ErrorMessage = "Выберите дату дедлайна")]
        [Display(Name = "Крайний срок выполения заказа")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DeadLine { get; set; }

        /// <summary>
        /// Путь к картинке задания
        /// </summary>
        public string ImagePath { get; set; }
    }
}