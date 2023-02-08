using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace eShop.Categories;

public class Category : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
}