global using System;
global using System.IO;
global using System.Linq;
global using System.Linq.Dynamic.Core;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Diagnostics;
global using System.Runtime.InteropServices;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;

global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.Abstractions;

global using Volo.Abp.Application.Dtos;
global using Volo.Abp.Application.Services;
global using Volo.Abp.Data;
global using Volo.Abp.DependencyInjection;
global using Volo.Abp.Domain.Entities.Auditing;
global using Volo.Abp.Domain.Values;
global using Volo.Abp.Domain.Repositories;
global using Volo.Abp.Identity;
global using Volo.Abp.MultiTenancy;
global using Volo.Abp.Users;
global using Volo.Abp.TenantManagement;

global using AutoMapper;

global using FluentValidation;


// global using Microsoft.IdentityModel.Tokens;

global using eShop.AppServices.Blogs;
global using eShop.AppServices.Blogs.Dtos;
global using eShop.AppServices.Categories;
global using eShop.AppServices.Categories.Dtos;
global using eShop.AppServices.Products;
global using eShop.AppServices.Products.Dtos;
global using eShop.AppServices.Todo;
global using eShop.AppServices.Todo.Dtos;
global using eShop.Common.Dtos;
global using eShop.Entities.Blogs;
global using eShop.Interfaces;
global using eShop.Localization;

global using eShop.Entities.Categories;
global using eShop.Entities.Products;
global using eShop.Entities.Todo;
global using eShop.Entities.User;
global using eShop.Enums;
global using eShop.ValueObjects;

