using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SlavesMPEI.Domain.Entities;

namespace SlavesMPEI.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        /// <summary>
        /// Пользователь, которому принадлежит данный заказ
        /// </summary>
        public string UserName { get; set; }

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
        [Display(Name = "Напишите своё задание")]
        public string Task { get; set; }

        /// <summary>
        /// Крайний срок выполения задачи
        /// </summary>
        [Required(ErrorMessage = "Выберите дату дедлайна")]
        [Display(Name = "Крайний срок выполения заказа")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DeadLine { get; set; }

        /// <summary>
        /// Путь к картинке задания
        /// </summary>
        [Display(Name ="Фото задания")]
        public IFormFile Image { get; set; }
    }
}