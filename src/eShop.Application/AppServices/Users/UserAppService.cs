namespace eShop.AppServices.Users;

public class UserAppService : ApplicationService, IUserAppService
{
    private readonly IRepository<IdentityUser, Guid> _userRepository;


    public UserAppService(IRepository<IdentityUser, Guid> userRepository)
    {
        _userRepository = userRepository;
    }


    /// <summary>
    /// Get Users
    /// </summary>
    /// <returns></returns>
    public async Task<List<UserDto>> GetUsers()
    {
        var users = await _userRepository.GetListAsync();
        return ObjectMapper.Map<List<IdentityUser>, List<UserDto>>(users);
    }

    /// <summary>
    /// Get User
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<UserDto> GetUser(Guid userId)
    {
        var user = await _userRepository.GetAsync(userId);
        return ObjectMapper.Map<IdentityUser, UserDto>(user);
    }
}