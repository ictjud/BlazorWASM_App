﻿namespace ClientLibrary.Models.Helper
{
    public static class Constant
    {
        public static class Product
        {
            public const string GetAll = "product/all";
            public const string Get = "product/single";
            public const string Add = "product/add";
            public const string Update = "product/update";
            public const string Delete = "product/delete";
        }
        public static class Category
        {
            public const string GetAll = "category/all";
            public const string Get = "category/single";
            public const string Add = "category/add";
            public const string Update = "category/update";
            public const string Delete = "category/delete";
        }
        public static class Authentication
        {
            public const string Type = "Bearer";
            public const string Login = "authentication/login";
            public const string Register = "authentication/register";
            public const string ReviveToken = "authentication/refreshToken";
        }
        public static class ApiCallType
        {
            public const string Get = "get";
            public const string Post = "post";
            public const string Put = "put";
            public const string Delete = "delete";
        }
        public static class Cookie
        {
            public const string Name = "token";
            public const string Path = "/";
            public const int Days = 1;
        }
        public static class ApiClient
        {
            public const string Name = "Blazor-Client";
        }
    }
}
