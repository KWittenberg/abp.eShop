namespace eShop.AppServices.Users;

public class UserAppService : ApplicationService, IUserAppService
{
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    private readonly IRepository<UserAddress, Guid> _userAddressRepository;
    private readonly ICurrentUser _currentUser;


    public UserAppService(IRepository<IdentityUser, Guid> userRepository, IRepository<UserAddress, Guid> userAddressRepository, ICurrentUser currentUser)
    {
        _userRepository = userRepository;
        _userAddressRepository = userAddressRepository;
        _currentUser = currentUser;
    }

    // User /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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


    // UserAddress //////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Get User Addresses
    /// </summary>
    /// <returns></returns>
    public async Task<List<UserAddressDto>> GetUserAddresses()
    {
        var userId = _currentUser.Id;

        var userAddress = await _userAddressRepository.GetListAsync(x => x.UserId == userId);

        return ObjectMapper.Map<List<UserAddress>, List<UserAddressDto>>(userAddress);
    }

    /// <summary>
    /// Create UserAddress
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<UserAddressDto> CreateUserAddress(AddUserAddressDto model)
    {
        var userId = _currentUser.Id;

        if (userId is null) throw new EntryPointNotFoundException("User Not Found.");

        var userAddress = new UserAddress
        {
            Address = model.Address,
            UserId = (Guid)userId
        };

        var newUserAddress = await _userAddressRepository.InsertAsync(userAddress);

        return ObjectMapper.Map<UserAddress, UserAddressDto>(newUserAddress);
    }



}