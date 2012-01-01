using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using elfam.web.Dao;
using elfam.web.Models;

namespace elfam.web.Extensions
{
    public class ComplexEntityModelBinder: DefaultModelBinder
    {
        DaoTemplate daoTemplate = new DaoTemplate();

        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
        {
            if (value is DomainEntity)
            {
                DomainEntity domainEntityValue = (DomainEntity) value;
                if (domainEntityValue.Id > 0)
                {
                    value = daoTemplate.Get(propertyDescriptor.PropertyType.FullName,
                                                                       domainEntityValue.Id);
                }
            }
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }

        protected override bool OnModelUpdating(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return true;
            var bindedObject = base.BindModel(controllerContext, bindingContext);
            foreach (PropertyInfo propertyInfo in bindedObject.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType.IsSubclassOf(typeof(DomainEntity)))
                {
                    DomainEntity domainEntityValue = (DomainEntity)propertyInfo.GetValue(bindedObject, null);
                    if (domainEntityValue != null && domainEntityValue.Id > 0)
                    {
                        domainEntityValue = (DomainEntity)daoTemplate.Get(propertyInfo.PropertyType.FullName,
                                                                           domainEntityValue.Id);
                    }
                    bindedObject.GetType().GetProperty(propertyInfo.Name).SetValue(bindedObject, domainEntityValue, null);
                }
            }

            
        }

        
    }
}
