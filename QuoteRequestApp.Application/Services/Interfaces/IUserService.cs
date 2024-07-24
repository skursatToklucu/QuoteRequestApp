using QuoteRequestApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User user);
        Task<User> AuthenticateUserAsync(string email, string password);
        Task<string> GenerateJwtToken(User user);
    }
}
