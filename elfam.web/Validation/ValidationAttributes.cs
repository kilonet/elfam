using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using elfam.web.Dao;
using elfam.web.Services;
using NHibernate.Criterion;

namespace elfam.web.Validation
{
    public class EmailAttribute : RegularExpressionAttribute
    {
        public EmailAttribute() : base(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        {
            ErrorMessage = "Введите корректный e-mail";
        }
    }

    public class PasswordAttribute : ValidationAttribute
    {
        public PasswordAttribute()
        {
            ErrorMessage = "Минимальная длина пароля 4 символа";
        }

        public override bool IsValid(object value)
        {
            return UserService.IsValidPassword(value as string);
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class UniqueFiledAttribute: ValidationAttribute
    {
        private string Name { get; set; }
        
        public UniqueFiledAttribute(string name, string errorMessage)
        {
            Name = name;
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(Name, true).GetValue(value);
            object o = Activator.CreateInstance(value.GetType());
            properties.Find(Name, true).SetValue(o, originalValue);

            DaoTemplate daoTemplate = new DaoTemplate();
            DetachedCriteria criteria = DetachedCriteria.For(value.GetType()).Add(Restrictions.Eq(Name, originalValue));
            IList results = daoTemplate.FindByCriteria(criteria);
            return results.Count == 0;
        }
    }
}
