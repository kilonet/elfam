
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using elfam.web.Models;
using elfam.web.Paging;
using elfam.web.Services;
using elfam.web.Utils;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using NHibernate;
using NHibernate.Context;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Transform;
using NLipsum.Core;
using NUnit.Framework;
using Configuration = NHibernate.Cfg.Configuration;
using Order = elfam.web.Models.Order;

namespace elfam.web.Tests
{
    public class DaoTests
    {
        private PostgreSQLConfiguration GetPsqlConf()
        {
            return PostgreSQLConfiguration.Standard.ConnectionString("Server=localhost;Database=elfam2;User Id=postgres;Password=111111;");
//            return PostgreSQLConfiguration.Standard.ConnectionString("Server=postgres44.1gb.ru;Database=xgb_elfam4;User Id=xgb_elfam4;Password=715a123c;");
        }

        [Test]
        public void AddCategoryToIncomes()
        {
            using(ISession session = GetConfiguration().BuildSessionFactory().OpenSession())
            {
                DetachedCriteria criteria = DetachedCriteria.For<Income>();
                foreach (Income income in criteria.GetExecutableCriteria(session).List())
                {
                    income.Category = income.Product.Category;
                    session.Save(income);
                }
                session.Flush();
            }
            
        }
        
        [Test]
        public void TestHql()
        {
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();
            const string hql = @"select p, sum(inc.QuantityCurrent), max(inc.Date)
                from Product p left join p.Incomes inc join inc.Outcomes out
                where out.OrderLine.Order.Status
                group by p.Id, p.Name, p.Description, p.ShortDescription, p.Price, p.Date, p.Category, p.Category.Name";
            IQuery query = session.CreateQuery(hql);
            var list = query.List();
            foreach (var VARIABLE in list)
            {
                
            }
        }

        [Test]
        public void ProdsWDate()
        {
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();

            Category category = new Category() {Id = 1};

            DetachedCriteria criteria = DetachedCriteria.For<Income>();
            criteria.CreateAlias("Product", "p");
            criteria.CreateAlias("p.Category", "c");
            criteria.SetProjection(
                Projections.ProjectionList()
                    .Add(Projections.GroupProperty("Product"))
                    .Add(Projections.GroupProperty("c.Name"))
                    .Add(Projections.Max("Date")));
            //criteria.Add(Restrictions.Eq("p.Category", category));
            criteria.AddOrder(NHibernate.Criterion.Order.Asc("c.Name"));
            var list = criteria.GetExecutableCriteria(session).List();
            foreach (var VARIABLE in list)
            {
                
            }
        }

        [Test]
        public void AddCategories()
        {
            Category c1 = new Category() { Name = "Компьютеры" };
            Category c12 = new Category() { Name = "Игровые приставки", Parent = c1};
            Category c13 = new Category() { Name = "Ноутбуки", Parent = c1 };
            Category c14 = new Category() { Name = "Принтеры и МФУ", Parent = c1 };
            c1.Subcategories.Add(c12);
            c1.Subcategories.Add(c13);
//            c1.Subcategories.Add(c14);

            Category c2 = new Category() { Name = "Дом и дача" };
            Category c22 = new Category() { Name = "Автомобили, самокаты", Parent = c2 };
            Category c23 = new Category() { Name = "Детская обувь", Parent = c2 };
            Category c24 = new Category() { Name = "Одежда для малышей", Parent = c2 };
//            c2.Subcategories.Add(c22);
            c2.Subcategories.Add(c23);
//            c2.Subcategories.Add(c24);

            Category c3 = new Category() { Name = "Бытовая техника" };
            Category c32 = new Category() { Name = "Стиральные машины", Parent = c3 };
            Category c33 = new Category() { Name = "Электробритвы", Parent = c3 };
            Category c34 = new Category() { Name = "Холодильники", Parent = c3 };
//            c3.Subcategories.Add(c32);
//            c3.Subcategories.Add(c33);
//            c3.Subcategories.Add(c34);

            IList<Category> categories = new List<Category>() { c1, c2, c3/*, c12, c13, c14, c22, c23, c24, c32, c33, c34 */};

            using(ISession session = GetConfiguration().BuildSessionFactory().OpenSession())
            {
                foreach (Category category in categories)
                {
                    session.Save(category);
                }
                session.Flush();
            }
        }


        public void AddQ()
        {
            
        }

        [Test]
        public void AddUids()
        {
            const int n = 100;
            List<int> list = new List<int>(n);
            for (int i = 1000; i < 1000 + n; i++)
            {
                list.Add(i);
            }
            var random = list.OrderBy(a => Guid.NewGuid());
            using (ISession session = GetConfiguration().BuildSessionFactory().OpenSession())
                {
                    foreach (int s in random)
                    {
                        UniqueId uniqueId = new UniqueId(){Uid = s};
                        session.Save(uniqueId);
                        session.Flush();
                    }
                }
        }

        [Test]
        public void GenInsertUids()
        {
            const int n = 5;
            int begin = 1000;
            List<int> list = new List<int>(n);
            int i;
            for (i = begin; i < begin + 8999; i++)
            {
                list.Add(i);
            }
            var random = list.OrderBy(a => Guid.NewGuid());
            var pairs = new List<string>();
            i = 1;
            foreach (int uid in random)
            {
                pairs.Add(string.Format("({0}, {1})", i, uid));
                i++;
            }
            var pairs_string = string.Join(",", pairs.ToArray());
            using (StreamWriter file = new StreamWriter(@"C:\insert_uids.sql"))
            {
                file.WriteLine("INSERT INTO public.unique_id(id, uid) VALUES " + pairs_string);
            }

        }

        [Test]
        public void AddUsers()
        {
            string[] cities = {"Москва", "Калуга", "Тула", "Брянск"};
            string[] streets = { "Ленина", "Кирова", "Московская", "Чичерина" };
            string[] domens = { "mail.ru", "gmail.com", "yandex.ru" };
            string[] nicks = { "vasya", "jane", "oleg" };
            string[] surnames = { "Аверин", "Дуров", "Медведев", "Тихонов", "Кузнецов" };
            string[] names = { "Андрей", "Денис", "Михаил", "Анатолий", "Кирилл" };

            using (ISession session = GetConfiguration().BuildSessionFactory().OpenSession())
            {
                Contact contact = new Contact()
                                      {
                                          City = "Калуга",
                                          Country = "РФ",
                                          House = "18",
                                          Name = "Алексей",
                                          Phone = "555-939",
                                          Region = "Калужская обл.",
                                          Room = "21",
                                          Surname = "Покревский",
                                          Street = "Чичерина",
                                          Zip = "248010"
                                      };

                DeliverPrices prices = new DeliverPrices()
                {
                    CourierMoscow = 250,
                    CourierSubMoscow = 300,
                    Post = 170,
                    Self = 0
                };
                session.Save(prices);

                User user = new User() { Contact = contact, Email = "kpdpok@gmail.com", Role = Role.Admin};
                user.PasswordHash = UserService.CalculateHash("1");
                session.Save(user);
                session.Flush();
                //return;
                Random r = new Random();
                int n =r.Next(5, 10);
                for(int i = 0; i < 11; i++)
                {
                    contact = new Contact()
                    {
                        City = cities[r.Next(cities.Length)],
                        Country = "РФ",
                        House = r.Next(1, 99) + "",
                        Name = names[r.Next(names.Length)],
                        Phone = string.Format("{0}({1}){2}-{3}-{4}", r.Next(1, 9), r.Next(100, 999), r.Next(100, 999), r.Next(10, 99), r.Next(10, 99)),
                        Region = "Калужская обл.",
                        Room = r.Next(1, 99) + "",
                        Surname = surnames[r.Next(surnames.Length)],
                        Street = streets[r.Next(streets.Length)],
                        Zip = "ABCDF"
                    };
                    User user1 = new User()
                                     {
                                         Contact = contact,
                                         Email = string.Format("{0}{2}@{1}", nicks[r.Next(nicks.Length)], domens[r.Next(domens.Length)], i),
                                         Role = Role.User,
                                         Discount = r.Next(5) * 100
                                     };
                    user1.PasswordHash = UserService.CalculateHash("1");
                    session.Save(user1);
                    session.Flush();
    
                }
            }
        }

        [Test]
        public void AddIncomes()
        {
            Random r = new Random();
            using (ISession session = GetConfiguration().BuildSessionFactory().OpenSession())
            {
                var products = session.CreateCriteria(typeof (Product)).List<Product>();
                foreach (Product product in products)
                {
                    for (int i = 0; i < r.Next(10); i++)
                    {
                        Income income = new Income()
                                            {
                                                BuyPrice = r.Next(5, 99) * 100, Product = product, QuantityCurrent = r.Next(100)
                                            };
                        session.Save(income);
                    }
                }
            }
        }

        [Test]
        public void ExportMappings()
        {
            var psqlConfig = GetPsqlConf();            

            FluentConfiguration configuration = Fluently.Configure()
                .Database(psqlConfig)
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "call")) 
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>());

            configuration.Mappings(m => m.FluentMappings.ExportTo(@"c:\1\"));

            
            

        }

        [Test]
        public void GenerateSchema()
        {
            var psqlConfig = PostgreSQLConfiguration.Standard.ConnectionString("Server=localhost;Database=elfam;User Id=postgres;Password=111111;");
            Fluently.Configure()
              .Database(psqlConfig)
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();

        }

        private void BuildSchema(Configuration cfg)
        {
            SchemaExport schemaExport = new SchemaExport(cfg);
            using (new StreamWriter("create.sql"))
            {
                schemaExport.Create(true, true);
                schemaExport.SetOutputFile("create.txt");
                schemaExport.Execute(false, true, false);
                
            }
        }

        [Test]
        public void Bootstrap()
        {
            GenerateSchema();
            AddUids();
            AddUsers();

            


            AddCategories();
            AddProducts();
//            AddOrders();
        }

        [Test]
        public void Decimal()
        {
            decimal discount = 50;
            decimal price = 301;
            decimal final = price*discount/100;
            Console.WriteLine(final);
        }

        [Test]
        public void AddOrders()
        {
            return;
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();
            IList<User> users = session.CreateCriteria(typeof(User)).List<User>();
            IList<Product> products = session.CreateCriteria(typeof(Product)).List<Product>();
            Random r = new Random();
            foreach (User user in users)
            {
                if (user.Email.Contains("11")) continue;
                if (user.Email.Contains("22")) continue;
                if (user.Email.Contains("44")) continue;
                if (user.Email.Contains("55")) continue;
                if (user.Email.Contains("66")) continue;
                if (user.Email.Contains("88")) continue;

                int n = r.Next(2, 20);
                for (int i = 0; i < n; i++)
                {
                    Order order = new Order(null, null);
                    order.User = user;
                    order.DeliverType = (DeliverType)r.Next(3);
                    order.PaymentType = (PaymentType)r.Next(2);
                    order.ShippingDetails = user.Contact;
                    
                    order.Date = new DateTime(2005 + r.Next(5), r.Next(1, 12), r.Next(1, 28), r.Next(0, 23), r.Next(0, 59), r.Next(0, 59));
                    int p = r.Next(1, 7);
                    for (int j = 0; j < p; j++)
                    {
                        order.AddOrderLine(products[r.Next(products.Count)], r.Next(1, 10), null);
                    }
                    session.Save(order);
                    order.Uid = session.Get<UniqueId>(order.Id).Uid;
                    session.Save(order);

                }
            }
            session.Flush();
        }

        [Test]
        public void AddProducts()
        {
            string[] productNames = { "HTC Desire", "Nikon D3000 Kit", "Samsung LE-32C530", "Nokia E52", "Sony Ericsson XPERIA X10", "Canon EOS 500D Kit", "Sony PRS-600 Reader Touch Edition", "HTC Legend", "Lenovo IdeaPad Y550", "Samsung GT-I9000 Galaxy S", "Samsung R530", "Nokia 5228", "Nokian Hakkapeliitta 5", "Panasonic SR-TMH18", "Nokia 5530 XpressMusic", "Apple MacBook Pro 13 Mid 2010", "Nokia X6 16Gb" };
            string[] colors = { "Красный", "Зеленй", "Желтый" };
            string[] countries = { "Россия", "Китай", "Германия", "Австрия", "Канада" };
            string[] shortDescriptions = { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis elit odio. Vestibulum ante ipsum primis in faucibus orci ", "Etiam convallis, urna ac faucibus sodales, lorem ligula malesuada metus, vitae pellentesque magna purus sit amet sapien.", "Praesent sapien magna, rhoncus nec dignissim vitae, ultrices pulvinar ligula. Pellentesque vitae sodales ipsum.", "Curabitur quis arcu in libero lobortis tristique ac sed turpis. Aenean sodales ornare leo id accumsan.", "Pellentesque sed ultricies lectus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In euismod tincidunt dolor vitae hendrerit.", "Etiam mollis libero nec eros vulputate faucibus. Morbi sagittis lacus tincidunt dui dapibus et volutpat nunc venenatis.", "Vivamus feugiat semper euismod. Duis cursus magna at dolor faucibus ut pharetra nunc rhoncus.", "In molestie mauris sit amet turpis bibendum pharetra nec eu lacus. Duis suscipit velit a diam accumsan nec scelerisque turpis fermentum.", "Donec tristique quam vel justo viverra in semper leo viverra. Etiam vel nisi in mi fringilla vehicula ullamcorper nec tellus." };
            string[] descriptions = {@"<ul>
<li>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</li>
<li>Nam vitae augue augue, id volutpat felis.</li>

<li>Pellentesque faucibus dolor ut nisi placerat imperdiet.</li>
<li>Nulla aliquam elit eu enim bibendum pharetra venenatis ligula lacinia.</li>
<li>Sed placerat massa id tellus laoreet sollicitudin.</li>
<li>Pellentesque at augue nec mi vehicula viverra.</li>
<li>Etiam posuere erat vel tellus congue in dictum metus accumsan.</li>
<li>Donec a urna augue, ullamcorper sagittis odio.</li>
</ul>
", @"<ul>
<li>Etiam ut sem diam, at faucibus purus.</li>

<li>Nulla eleifend urna sed massa viverra sit amet ornare magna varius.</li>
<li>Fusce et leo velit, nec lobortis nulla.</li>
<li>Curabitur id orci vel eros molestie imperdiet.</li>
</ul>
", @"<ul>
<li>Morbi adipiscing eros sit amet lectus tincidunt scelerisque.</li>
<li>Cras rhoncus adipiscing turpis, sit amet tempor orci rhoncus eget.</li>
<li>Morbi quis erat sit amet elit pretium rhoncus nec eu urna.</li>
<li>Etiam sodales neque eget tortor eleifend consectetur.</li>

</ul>
", @"<ul>
<li>Maecenas lacinia venenatis tortor, vel suscipit augue gravida at.</li>
<li>Phasellus et nulla ut lacus tempus cursus sed a mauris.</li>
<li>Nunc lacinia tempor felis, at elementum lectus consectetur a.</li>
</ul>
", @"<ul>
<li>Nam sed justo tellus, ut pretium neque.</li>
<li>Cras fringilla mauris sed libero interdum et consequat purus commodo.</li>

<li>Duis molestie arcu et diam scelerisque sed laoreet dolor volutpat.</li>
<li>Nam ac est vel nisl vehicula porttitor id eu nisl.</li>
<li>Sed quis purus sed tellus tincidunt dapibus.</li>
<li>Proin eget metus tellus, quis imperdiet risus.</li>
<li>Suspendisse eget enim nunc, ut viverra nisi.</li>
</ul>
"};

            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();
            IList<Category> categories = session.CreateCriteria(typeof (Category)).List<Category>();
            Random random = new Random();

            foreach (Category category in categories)
            {
                int n = random.Next(1, 5)*10;
                for(int i = 0; i < n; i++)
                {
                    
                    Product product = new Product()
                                          {
                                              Category = category,
                                              Description = descriptions[random.Next(descriptions.Length)],
                                              Name = productNames[random.Next(productNames.Length)],
                                              Price = random.Next(1, 250)*100,
                                              ShortDescription =
                                                  shortDescriptions[random.Next(shortDescriptions.Length)],
                                              SKU = Guid.NewGuid().ToString(),
                                              Size = i > random.Next(5) ? random.Next(300).ToString() : "",
                                              Weight = i > random.Next(3) ? random.Next(300).ToString() : "",
                                              Country = i > random.Next(4) ? countries[random.Next(countries.Length)] : "",
                                              Color = i > random.Next(6) ? colors[random.Next(colors.Length)] : "",
                                              IsNew = i % 5 == 0
                                          };
                    session.Save(product);

                    product.Name = string.Format("[{0}] {1}", product.Id, category.Name);
                    session.Save(product);

                    for (int j = 0; j < random.Next(10); j++)
                    {
                        Income income = new Income()
                        {
                            BuyPrice = (decimal) ((double)product.Price * (0.5 * random.NextDouble())),
                            Product = product,
                            QuantityCurrent = random.Next(100)
                        };
                        income.QuantityInital = income.QuantityCurrent;
                        session.Save(income);
                    }


                }
            }
            
            session.Flush();            
            
        }

        [Test]
        public void TestArticle()
        {
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();
            Article article = new Article() {Text = "123", Title = "56"};
            session.Save(article);
        }

        [Test]
        public void TestCount()
        {
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();
            OrderStatus[] reservedStatuses = { OrderStatus.Processing, OrderStatus.WaitPayment, OrderStatus.WaitPickup };
            DetachedCriteria reservedProductsCriteria = DetachedCriteria.For(typeof(Order))
                .CreateAlias("Lines", "ol")
                .CreateAlias("ol.Product", "p", JoinType.RightOuterJoin)
                .SetProjection(
                    Projections.ProjectionList()
                        .Add(Projections.GroupProperty("ol.Product").As("Product"))
                        .Add(Projections.Sum("ol.Quantity").As("Quantity")))
                .Add(Restrictions.In("Status", reservedStatuses))
                .SetResultTransformer(Transformers.AliasToBean(typeof(ProductReportResultRow)));
            var list = reservedProductsCriteria.GetExecutableCriteria(session).List();

            var count = CriteriaTransformer.Clone(reservedProductsCriteria).SetProjection(Projections.RowCount());

            var n = (int)count.GetExecutableCriteria(session).UniqueResult();
            Assert.True(n == list.Count);

        }


        private FluentConfiguration GetConfiguration()
        {
            var psqlConfig = GetPsqlConf();
            FluentConfiguration configuration = Fluently.Configure()
                .Database(psqlConfig)
                //.ExposeConfiguration(c => c.SetProperty("current_session_context_class", "call")) 
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<User>();
                    m.HbmMappings.AddFromAssemblyOf<User>();
                });
            return configuration;
        }

        [Test]
        public void SelectProducts()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();


//            return;
            IQuery query = session.CreateQuery(
                @"select p, sum(inc.QuantityCurrent)
                from Product p join p.Incomes inc 
                group by p.Id, p.Name, p.Description, p.ShortDescription, p.Price, p.Category.Id
                order by case when sum(inc.QuantityCurrent) > 100 then 0 else 1 end, p.Name
                ");
            var res = query.List();
            foreach (var re in res)
            {
                
            }

        }

        

        [Test]
        public void ProdReport()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();

            
            IList names = new ArrayList();
//            names.Add(OrderStatus.Processing);
//            names.Add(OrderStatus.WaitPayment);
//            names.Add(OrderStatus.WaitPickup);

            ICriteria criteria = session.CreateCriteria(typeof(Order));
            var t = criteria
                .CreateAlias("Lines", "ol")
                .CreateAlias("ol.Product", "p")
                .SetProjection(
                    Projections.ProjectionList()
                        .Add(Projections.GroupProperty("ol.Product"))
                        .Add(Projections.Sum("ol.Quantity")))
                .Add(Restrictions.In("Status", names))
                .List();
            foreach (var VARIABLE in t)
            {
                
            }
            return;
            var list = session.CreateQuery(
                @"select ol.Product.Id, sum(ol.Quantity) 
                from Order o join o.Lines ol join ol.Product p 
                group by ol.Product 
                where o.Status in (:r)
                ")
            .SetParameterList("r", names);
            
            Console.WriteLine(list.NamedParameters);

        }

        [Test]
        public void TestIncome()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();
            var rr = session.CreateQuery(@"select p.Id, out.Quantity, inc.SellPrice - inc.BuyPrice  from 
            Order o 
            join o.Outcomes out 
            join out.Income inc
            join inc.Product p
            where o.Status in (:statuses)
            order by p.Id
            ").SetParameterList("statuses", new OrderStatus[]{OrderStatus.Delivered, OrderStatus.Payed})
             .List();

            
            foreach (var VARIABLE in rr)
            {
                
            }
        }

        


        [Test]
        public void TestUserOrderCount()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();
            var rr = session.CreateQuery(@"select count(o), u.Id from User u join u.Orders o group by u.Id").List();
                   

            foreach (var VARIABLE in rr)
            {

            }
        } 
        
        [Test]
        public void TestFuckNhib()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            ISession session = GetConfiguration().BuildSessionFactory().OpenSession();
            var rr = session.CreateQuery(@"select p, sum(inc.QuantityCurrent) as sum1, max(inc.Date)
                from Product p left join p.Incomes inc 
                where p.Category.Id in (1,2,3)
                group by p.Id, p.Name, p.Description, p.ShortDescription, p.Price, p.Date, p.Category 
                order by sum(inc.QuantityCurrent)  asc").List();
                   

            foreach (var VARIABLE in rr)
            {

            }
        }
    }
}

