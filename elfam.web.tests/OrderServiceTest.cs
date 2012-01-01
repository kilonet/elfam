using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using elfam.web.Dao;
using elfam.web.Models;
using elfam.web.Services;
using elfam.web.Services.Results;
using Moq;
using NUnit.Framework;

namespace elfam.web.tests
{
    [TestFixture]
    class OrderServiceTest
    {
        private Income _emptyIncome;
        private List<Income> _incomesForProduct;
        private Product _product;
        private List<CartItem> _cartItems;
        private User _user;
        private OrderShippingInfo _shippingInfo;
        private Mock<IDaoTemplate> _daoTemplate;
        private OrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _product = new Product() { Id = 1 };

            _incomesForProduct = new List<Income>
                                     {
                                         new Income()
                                             {
                                                 BuyPrice = 10,
                                                 Date = new DateTime(2000, 6, 28),
                                                 Id = 1,
                                                 Product = _product,
                                                 QuantityCurrent = 10,
                                                 QuantityInital = 10
                                             },
                                         new Income()
                                             {
                                                 BuyPrice = 20,
                                                 Date = new DateTime(2000, 5, 28),
                                                 Id = 2,
                                                 Product = _product,
                                                 QuantityCurrent = 10,
                                                 QuantityInital = 10
                                             },
                                         new Income()
                                             {
                                                 BuyPrice = 30,
                                                 Date = new DateTime(2000, 4, 28),
                                                 Id = 3,
                                                 Product = _product,
                                                 QuantityCurrent = 10,
                                                 QuantityInital = 10
                                             },
                                         new Income()
                                             {
                                                 BuyPrice = 40,
                                                 Date = new DateTime(2000, 3, 28),
                                                 Id = 4,
                                                 Product = _product,
                                                 QuantityCurrent = 10,
                                                 QuantityInital = 10
                                             },
                                         new Income()
                                             {
                                                 BuyPrice = 50,
                                                 Date = new DateTime(2000, 2, 28),
                                                 Id = 5,
                                                 Product = _product,
                                                 QuantityCurrent = 10,
                                                 QuantityInital = 10
                                             },
                                     };

            _emptyIncome = new Income()
                               {
                                   BuyPrice = 50,
                                   Date = new DateTime(1980, 2, 28),
                                   Id = 6,
                                   Product = _product,
                                   QuantityCurrent = 0,
                                   QuantityInital = 0
                               };
            _incomesForProduct.Add(_emptyIncome);
            _product.Incomes = _incomesForProduct;

            _cartItems = new List<CartItem>
                             {
                                 new CartItem() {Product = _product, Quantity = 33}
                             };
            _user = new User() { };
            _shippingInfo = new OrderShippingInfo() { };


            _daoTemplate = new Mock<IDaoTemplate>();
            _daoTemplate.Setup(x => x.FindByID<Product>(1)).Returns(_product);
            _daoTemplate.Setup(x => x.FindByID<UniqueId>(0)).Returns(new UniqueId() { Uid = 123 });

            _orderService = new OrderService();
            _orderService.DaoTemplate = _daoTemplate.Object;
        }

        [Test]
        public void TestRevertOrder()
        {
            

            var incomeSumBefore = _incomesForProduct.Sum(x => x.QuantityCurrent);

            
            
            var outcome1 = new Outcome(_product.Price, 10, _incomesForProduct[0], 0);
            var outcome2 = new Outcome(_product.Price, 5, _incomesForProduct[1], 0);
            var outcomes = new List<Outcome>() {outcome1, outcome2};
            var orderLine = new OrderLine(_product, 15, outcomes);

            _incomesForProduct[0].QuantityCurrent -= 10;
            _incomesForProduct[0].QuantityCurrent -= 5;

            Order order = new Order(outcomes, new List<OrderLine>(){orderLine});

            Assert.True(order.Outcomes().Sum(x => x.Quantity) == 15);

            _orderService.RevertOrder(order);

            Assert.True(_incomesForProduct.Sum(x => x.QuantityCurrent) == incomeSumBefore);
            Assert.True(order.Outcomes().Count() == 0);
            Assert.True(order.Status.Equals(OrderStatus.Revoked));
        }

        [Test]
        public void TestAddOrder()
        {
            

//            AddOrderResult result = _orderService.AddOrder(_cartItems, _user, _shippingInfo);
//
//            Assert.True(result.Order.Outcomes().Sum(x => x.Quantity).Equals(33));
//            Assert.True(_incomesForProduct.Sum(x => x.QuantityCurrent) + 33 == _incomesForProduct.Sum(x => x.QuantityInital));
//            Assert.True(result.Order.Outcomes().SingleOrDefault(x => x.Income.Equals(_emptyIncome)) == null);
        }
    }
}
