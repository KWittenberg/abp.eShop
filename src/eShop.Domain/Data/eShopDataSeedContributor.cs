using eShop.Categories;
using eShop.Products;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace eShop.Data;

public class eShopDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Category, Guid> _categoryRepository;
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly CategoryManager _categoryManager;

    public eShopDataSeedContributor(IRepository<Category, Guid> categoryRepository, IRepository<Product, Guid> productRepository, CategoryManager categoryManager)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _categoryManager = categoryManager;
    }
    public async Task SeedAsync(DataSeedContext context)
    {
        /***** TODO: Seed initial data here *****/



        if (await _categoryRepository.GetCountAsync() <= 0)
        {

            var books = await _categoryRepository.InsertAsync(await _categoryManager.CreateAsync("Books"));
            var movies = await _categoryRepository.InsertAsync(await _categoryManager.CreateAsync("Movies"));

            await _productRepository.InsertAsync(new Product
            {
                Category = books,
                Name = "Rudina",
                ImageUrl = "~/images/books/1997 Rudina.jpg",
                Price = 33.99f,
                ReleaseDate = new DateTime(1997, 01, 01),
                StockState = ProductStockState.InStock
            },
                autoSave: true);

            await _productRepository.InsertAsync(new Product
            {
                Category = books,
                Name = "Puvarija",
                ImageUrl = "~/images/books/1998 Puvarija.jpg",
                Price = 33.99f,
                IsFreeCargo = true,
                ReleaseDate = new DateTime(1998, 01, 01),
                StockState = ProductStockState.InStock
            },
            autoSave: true);

            await _productRepository.InsertAsync(new Product
            {
                Category = movies,
                Name = "Iron Man",
                ImageUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/78lPtwv72eTNqFW9COBYI0dWDJa.jpg",
                Price = 19.99f,
                ReleaseDate = new DateTime(2020, 11, 16),
                StockState = ProductStockState.NotAvailable
            },
                autoSave: true);
        }



        // Add Category
        //if (await _categoryRepository.CountAsync() > 0)
        //{
        //    return;
        //}

        //var books = new Category { Name = "Books" };
        //var movies = new Category { Name = "Movies" };

        //await _categoryRepository.InsertManyAsync(new[] { books, movies });

        #region OLD Dont Work When You Put Category Manager
        // Add Product
        //if (await _productRepository.GetCountAsync() <= 0)
        //{

        //    await _productRepository.InsertAsync(new Product
        //    {
        //        Category = books,
        //        Name = "Rudina",
        //        ImageUrl = "~/images/books/1997 Rudina.jpg",
        //        Price = 33.99f,
        //        ReleaseDate = new DateTime(1997, 01, 01),
        //        StockState = ProductStockState.InStock
        //    },
        //    autoSave: true);

        //    await _productRepository.InsertAsync(new Product
        //    {
        //        Category = books,
        //        Name = "Puvarija",
        //        ImageUrl = "~/images/books/1998 Puvarija.jpg",
        //        Price = 33.99f,
        //        IsFreeCargo = true,
        //        ReleaseDate = new DateTime(1998, 01, 01),
        //        StockState = ProductStockState.InStock
        //    },
        //    autoSave: true);

        //    await _productRepository.InsertAsync(new Product
        //    {
        //        Category = movies,
        //        Name = "Iron Man",
        //        ImageUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/78lPtwv72eTNqFW9COBYI0dWDJa.jpg",
        //        Price = 19.99f,
        //        ReleaseDate = new DateTime(2020, 11, 16),
        //        StockState = ProductStockState.NotAvailable
        //    },
        //        autoSave: true);
        //}
        #endregion
        #region OLD Way
        //if (await _categoryRepository.CountAsync() > 0)
        //{
        //    return;
        //}

        //var books = new Category { Name = "Books" };
        //var movies = new Category { Name = "Movies" };

        //await _categoryRepository.InsertManyAsync(new[] { books, movies });
        //var book1 = new Product
        //{
        //    Category = books,
        //    Name = "Rudina",
        //    ImageUrl = "~/images/books/1997 Rudina.jpg",
        //    Price = 33.99f,
        //    ReleaseDate = new DateTime(1997, 01, 01),
        //    StockState = ProductStockState.InStock
        //};
        //var book2 = new Product
        //{
        //    Category = books,
        //    Name = "Puvarija",
        //    ImageUrl = "~/images/books/1998 Puvarija.jpg",
        //    Price = 33.99f,
        //    IsFreeCargo = true,
        //    ReleaseDate = new DateTime(1998, 01, 01),
        //    StockState = ProductStockState.InStock
        //};
        //var movie1 = new Product
        //{
        //    Category = movies,
        //    Name = "Iron Man",
        //    ImageUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/78lPtwv72eTNqFW9COBYI0dWDJa.jpg",
        //    Price = 19.99f,
        //    ReleaseDate = new DateTime(2020, 11, 16),
        //    StockState = ProductStockState.NotAvailable
        //};

        //await _productRepository.InsertManyAsync(new[] { book1, book2, movie1 });
        #endregion
    }
}