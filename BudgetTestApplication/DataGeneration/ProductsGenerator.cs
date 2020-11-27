using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetTestApplication.DataGeneration
{
    public class ProductsGenerator
    {
        private readonly string[] _productNames = new string[]
        {
            "Вода святой источник",
            "Вода архыз",
            "Вода меркурий",
            "Вода нарзан",
            "Вода меркурий",
            "Хлеб белый",
            "Хлеб черный",
            "Хлеб бу",
            "Лаваш-маваш",
            "Кола",
            "Кока кола",
            "Морженко",
            "Другое мороженко",
            "Спрайт",
            "Пивасик мочаково",
            "Пивасик золотая почка",
            "Пивасик энурес",
            "Салат диарея",
            "Пирожок изжего",
            "Жевкос",
            "Печенки",
            "Та самая печенка",
            "Пилименики",
            "Вареники",
            "Простокаваша",
            "Сложнокваша"
        };

        public Product GetProduct(BudgetContext context)
        {
            var rndNum = RandomUtils.PositiveNumber();
            var index = rndNum % _productNames.Length;
            var name = _productNames[index];

            var product = context.Products.FirstOrDefault(el => el.Name.Equals(name));
            if (product == null)
            {
                context.Products.Add(new Product() {Name = name});
                // context.SaveChanges();
                // product = context.Products.FirstOrDefault(el => el.Name.Equals(name));
            }

            return product;
        }
    }
}