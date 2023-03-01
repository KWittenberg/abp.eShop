using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace eShop.Entities.Categories;

public class Category : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }


    // Add for Category Manager
    private Category()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Category(Guid id, [NotNull] string name) : base(id)
    {
        SetName(name);
    }

    internal Category ChangeName([NotNull] string name)
    {
        SetName(name);
        return this;
    }

    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: CategoryConsts.MaxNameLength);
    }
}