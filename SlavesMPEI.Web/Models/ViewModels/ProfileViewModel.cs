using System.Collections.Generic;
using System.Linq;
using SlavesMPEI.Domain.Entities;

namespace SlavesMPEI.Web.Models.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel(IList<Order> orders)
        {
            Orders = orders;
            TotalTasks = orders.Count;
            DoneTasks = orders.Where(order => order.IsDone == true).Count();
            DoneTasks = TotalTasks - DoneTasks;
        }

        /// <summary>
        /// Список заказов
        /// </summary>
        public IList<Order> Orders { get; set; }

        /// <summary>
        /// Количество заказов пользователя
        /// </summary>
        public int TotalTasks { get; set; }

        /// <summary>
        /// Количество выполенных заказов
        /// </summary>
        public int DoneTasks { get; set; }

        /// <summary>
        /// Количество невыполненных заказов
        /// </summary>
        public int UnDoneTasks { get; set; }

    }
}