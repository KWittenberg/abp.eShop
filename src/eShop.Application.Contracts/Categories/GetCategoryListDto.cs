﻿using Volo.Abp.Application.Dtos;

namespace eShop.Categories;

public class GetCategoryListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}