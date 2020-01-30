using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Clinic.Domain;

namespace Clinic.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string email, string password);
    }
}
