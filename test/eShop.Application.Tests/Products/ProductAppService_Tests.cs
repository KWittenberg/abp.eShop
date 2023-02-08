using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Shouldly;
using Volo.Abp.Application.Dtos;
using Xunit;

namespace eShop.Products;

public class ProductAppService_Tests : eShopApplicationTestBase
{
    private readonly IProductAppService _productAppService;

    public ProductAppService_Tests()
    {
        _productAppService = GetRequiredService<IProductAppService>();
    }

    /* TODO: Test methods */

    [Fact]
    public async Task Should_Get_Product_List()
    {
        //Act
        var output = await _productAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        //Assert
        output.TotalCount.ShouldBe(3);
        output.Items.ShouldContain(x => x.Name.Contains("Rudina"));
    }
}