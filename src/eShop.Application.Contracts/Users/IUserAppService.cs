using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace eShop.Users;

public interface IUserAppService : IApplicationService
{
    Task<List<UserDto>> GetUsers();
}



