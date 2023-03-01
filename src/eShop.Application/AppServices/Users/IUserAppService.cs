namespace eShop.AppServices.Users;

public interface IUserAppService : IApplicationService
{
    Task<List<UserDto>> GetUsers();
}