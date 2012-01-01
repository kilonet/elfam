using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using elfam.web.Extensions;
using elfam.web.ViewModels;
using Iesi.Collections.Generic;

namespace elfam.web.Models
{
    //[ModelBinder(typeof(ComplexEntityModelBinder))]
    public class Product: DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Description { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual IList<Image> Images { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Income> Incomes { get; set; }
        public virtual ISet<Product> Recomended { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string SKU { get; set; }
        public virtual string Size { get; set; }
        public virtual string Weight { get; set; }
        public virtual string Color { get; set; }
        public virtual string Country { get; set; }
        public virtual bool IsVisible{ get; set; }
        public virtual bool IsNew{ get; set; }

        public static string NameProperty = "Name";
        public static string IsVisibleProperty = "IsVisible";



        public virtual bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Price == Price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Product)) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        
        

        public Product()
        {
            Images = new List<Image>();
            Comments = new List<Comment>();
            Recomended = new HashedSet<Product>();
            IsVisible = true;
        }

        public virtual void CopyFrom(ProductViewModel viewModel)
        {
            Name = viewModel.Name;
            Price = viewModel.Price;
            Description = viewModel.Description;
            ShortDescription = viewModel.ShortDescription;
            Category = new Category() { Id = viewModel.CategoryId };
            Date = viewModel.Date;

            SKU = viewModel.SKU;
            Size = viewModel.Size;
            Color = viewModel.Color;
            Weight = viewModel.Weight;
            Country = viewModel.Country;
            IsVisible = viewModel.IsVisible;
            IsNew = viewModel.IsNew;
        }

        public virtual int Rest()
        {
            return Incomes.Sum(income => income.QuantityCurrent);
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual bool IsAvailable
        {
            get { return Rest() > 0; }
        }

        public virtual bool NotAvailable
        {
            get { return !IsAvailable; }
        }

        public virtual IList<Category> BreadCrumb()
        {
            var result = new List<Category>();
            var parent = Category;
            while (true)
            {
                if (parent == null) break;
                result.Add(parent);
                parent = parent.Parent;
            }
            result.Reverse();
            return result;
        }

       
    }
}
