using System.Collections.Generic;
using System.Threading.Tasks;
using SlavesMPEI.Domain.Entities;

namespace SlavesMPEI.Domain.Repositories.Abstracts
{
    /// <summary>
    /// Интерфейс взаимодействия с заказом
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Добавить заказ
        /// </summary>
        /// <param name="order">Заказ</param>
        /// <returns></returns>
        Task AddOrderAsync(Order order);
        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="order">Заказ</param>
        /// <returns></returns>
        Task DeleteOrderAsync(Order order);
        /// <summary>
        /// Возвращает все заказы
        /// </summary>
        /// <returns></returns>
        Task<IList<Order>> GetOrdersAsync();
        /// <summary>
        /// Возвращает заказ по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Order> GetOrderByIdAsync(string id);
        /// <summary>
        /// Возвращает заказы пользователя
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns></returns>
        Task<IList<Order>> GetUserOrdersAsync(string username);
    }
}