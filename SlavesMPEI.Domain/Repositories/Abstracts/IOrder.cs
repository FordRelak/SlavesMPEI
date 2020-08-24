using System.Threading.Tasks;
using SlavesMPEI.Domain.Entities;

namespace SlavesMPEI.Domain.Repositories.Abstracts
{
    /// <summary>
    /// Интерфейс взаимодействия с заказом
    /// </summary>
    public interface IOrder
    {
        Task AddOrderAsync(Order order);

        Task DeleteOrderAsync(Order order);

        Task<Order> GetOrdersAsync();

        Task<Order> GetOrderByIdAsync(string id);

        Task<Order> GetUserOrdersAsync(string username);
    }
}