global using System;
global using System.Collections.Generic;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations;
global using System.Linq;
global using System.Threading.Tasks;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.RazorPages;
global using Microsoft.AspNetCore.Mvc.Rendering;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;

global using Serilog;
global using Serilog.Events;


global using AutoMapper;
global using Volo.Abp.ObjectMapping;
global using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;






global using eShop.AppServices.Categories;
global using eShop.AppServices.Products;
global using eShop.AppServices.Products.Dtos;
global using eShop.AppServices.Todo;
global using eShop.AppServices.Todo.Dtos;
global using eShop.AppServices.Users;
global using eShop.Common.Dtos;

global using eShop.Entities.Products;
global using eShop.Entities.Todo;
global using eShop.Enums;

global using eShop.Web.Pages.Products;