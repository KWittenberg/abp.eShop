using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace eShop.Pages;

public class Index_Tests : eShopWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
