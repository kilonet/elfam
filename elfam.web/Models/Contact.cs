using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.ViewModels;
using elfam.web.ViewModels.User;

namespace elfam.web.Models
{
    public class Contact
    {
        public Contact(){}

        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual string Zip { get; set; }
        public virtual string Street { get; set; }
        public virtual string House { get; set; }
        public virtual string Room { get; set; }
        public virtual string Region { get; set; }

        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }

        public virtual string Phone { get; set; }

        public string FullName { get { return Name + " " + Surname; } }

        public static Contact From(ContactViewModel v)
        {
            Contact c = new Contact();
            c.City = v.City;
            c.Country = v.Country;
            c.House = v.House;
            c.Room = v.Room;
            c.Street = v.Street;
            c.Zip = v.Zip;
            c.Region = v.Region;

            c.Name = v.Name;
            c.Surname = v.Surname;

            c.Phone = v.Phone;
            return c;
        }

        public string Address()
        {
            return string.Format("{0}, {1}, г. {2}, {3}, ул. {4}, д. {5}, кв. {6}", Country, Region, City, Zip, Street, House, Room);
        }
        
        public string AddressBill()
        {
            return string.Format("{0}, {1}, г. {2}, ул. {3}, д. {4}, кв. {5}", Zip, Region, City, Street, House, Room);
        }


    }
}
