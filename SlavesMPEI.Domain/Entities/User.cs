using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SlavesMPEI.Domain.Entities
{
    public class User : IdentityUser
    {
        public User(string userName) : base(userName)
        {
        }

        /// <summary>
        /// Список всех заказов
        /// </summary>
        public IList<Order> Orders { get; set; }
    }
}