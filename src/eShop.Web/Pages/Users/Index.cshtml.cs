using eShop.Users;
using System.Collections.Generic;

namespace eShop.Web.Pages.Users;

public class IndexModel : eShopPageModel
{
    public List<UserDto> Users { get; set; }

    private readonly IUserAppService _userAppService;

    public IndexModel(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    public async Task OnGetAsync()
    {
        Users = await _userAppService.GetUsers();
    }
}