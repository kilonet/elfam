using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using elfam.web.ViewModels;
using NHibernate.Criterion;

namespace elfam.web.Models
{
    public class Category: DomainEntity
    {
        public static string PARENT = "Parent";

        public virtual string Name { get; set; }
        public virtual Category Parent { get; set; }
        public virtual IList<Category> Subcategories { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsVisible { get; set; }
        public virtual Image Image { get; set; }

        public virtual bool ParentIsVisible
        {
            get
            {
                if (Parent == null) return true;
                return Parent.IsVisible;
            }
        }

        public Category()
        {
            Subcategories = new List<Category>();
            Description = "";
            IsVisible = true;
        }

        public virtual void CopyFrom(CategoryViewModel viewModel)
        {
            Name = viewModel.Name;
            Description = viewModel.Description;
            IsVisible = viewModel.IsVisible;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual void MoveToNewParent(Category newParent)
        {
            if (Parent != null)
            {
                Parent.Subcategories.Remove(this);
            }
            Parent = newParent;
            if (newParent != null)
                newParent.Subcategories.Add(this);
        }

        public virtual IList<Category> AllSubCategories()
        {
            var subs = new List<Category>();
            foreach (Category subcategory in Subcategories)
            {
                subs.Add(subcategory);
                subs.AddRange(subcategory.AllSubCategories());
            }
            return subs;
        }

        public virtual IList<Category> ThisAndSubcategories()
        {
            var subs = new List<Category>();
            subs.Add(this);
            subs.AddRange(AllSubCategories());
            return subs;
        }

        public virtual void AddSubCategory(Category category)
        {
            Subcategories.Add(category);
            category.Parent = this;
        }
    }
}
