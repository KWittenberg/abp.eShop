﻿using System.Reflection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace eShop.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class eShopDbContext : AbpDbContext<eShopDbContext>, IIdentityDbContext, ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    // Add Todo
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }

    // Add Category
    public DbSet<Category> Categories { get; set; }
    // Add Product
    public DbSet<Product> Products { get; set; }
    // Add ProductImage
    public DbSet<ProductImage> ProductImages { get; set; }

    // Add Blog
    public DbSet<Blog> Blogs { get; set; }

    // Add UserAddress
    public DbSet<UserAddress> UserAddresses { get; set; }


    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        // Add for Configurations
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        // Add TodoItem
        //builder.Entity<TodoItem>(b => { b.ToTable("TodoItems"); });


        // Add Category
        //builder.Entity<Category>(b =>
        //{
        //    b.ToTable("Categories");
        //    b.Property(x => x.Name).HasMaxLength(CategoryConsts.MaxNameLength).IsRequired();
        //    b.HasIndex(x => x.Name);
        //});

        // Add Product
        //builder.Entity<Product>(b =>
        //{
        //    b.ToTable("Products");
        //    b.Property(x => x.Name).HasMaxLength(ProductConsts.MaxNameLength).IsRequired();
        //    b.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        //    b.HasIndex(x => x.Name).IsUnique();
        //});

        // Add ProductImage
        //builder.Entity<ProductImage>(b =>
        //{
        //    b.ToTable("ProductImages");
        //    b.Property(x => x.Name).HasMaxLength(ProductImageConsts.MaxNameLength).IsRequired();
        //    b.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        //    b.HasIndex(x => x.Name).IsUnique();
        //});



        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(eShopConsts.DbTablePrefix + "YourEntities", eShopConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}