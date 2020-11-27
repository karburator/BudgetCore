using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BudgetCoreDAO;
using BudgetCoreDAO.Context;

namespace BudgetTestApplication.DataGeneration
{
    public class ShopGenerator
    {
        private readonly string[] _shopNames = new[]
        {
            "АО \"АПТЕКИ \"НЕ БОЛЕЙ\"",
            "АО \"Дикси ЮГ\"  Дикси-77349",
            "АО \"ТД Перекресток\"",
            "АО \"Теремок-Инвест\"",
            "ЗАО \"Т и К Продукты\"",
            "ИП Митяшина П.С.",
            "ООО \"Гуд Фуд Некрасова\"",
            "ООО \"Камелот-А\"",
            "ООО \"Кофе Сирена\"",
            "ООО \"ПАПАС КОМ\"",
            "ООО \"ПЛАНИНВЕСТ ПРОЕКТ\"",
            "ООО \"СРП\"",
            "ООО \"Фастлэнд\"",
            "ООО <Арома Маркет>",
            "ООО Коричневый бык",
            "ООО ПродМир",
            "ООО Серый Бык"
        };

        public Shop GetShop(BudgetContext context)
        {
            var rndNum = RandomUtils.PositiveNumber();
            var index = rndNum % _shopNames.Length;
            var name = _shopNames[index];

            var shop = context.Shops.FirstOrDefault(el => el.User.Equals(name));
            if (shop == null)
            {
                shop = new Shop()
                {
                    User = name,
                    UserInn = RandomUtils.NumberedString(10)
                };
                context.Shops.Add(shop);
                // context.SaveChanges();
                // shop = context.Shops.FirstOrDefault(el => el.User.Equals(name));
            }

            return shop;
        }
    }
}