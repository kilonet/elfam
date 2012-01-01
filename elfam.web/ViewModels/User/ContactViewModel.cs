using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using elfam.web.Models;

namespace elfam.web.ViewModels.User
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Введите страну")]
        [DisplayName("Страна")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        public virtual string Country { get; set; }

        [Required(ErrorMessage = "Введите город *")]
        [DisplayName("Город *")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "Введите улицу *")]
        [DisplayName("Улица *")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        public virtual string Street { get; set; }

        [Required(ErrorMessage = "Введите номер дома *")]
        [DisplayName("Дом *")]
        [StringLength(50, ErrorMessage = "Слишком длинное значение")]
        public virtual string House { get; set; }

        [Required(ErrorMessage = "Введите индекс *")]
        [DisplayName("Индекс *")]
        [StringLength(50, ErrorMessage = "Слишком длинное значение")]
        public virtual string Zip { get; set; }

        [Required(ErrorMessage = "Введите номер квартиры или офиса")]
        [DisplayName("Квартира *")]
        [StringLength(50, ErrorMessage = "Слишком длинное значение")]
        public virtual string Room { get; set; }

        [Required(ErrorMessage = "Введите область")]
        [DisplayName("Область *")]
        [StringLength(50, ErrorMessage = "Слишком длинное значение")]
        public virtual string Region { get; set; }

        [Required(ErrorMessage = "Введите имя *")]
        [DisplayName("Имя *")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию *")]
        [DisplayName("Фамилия *")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        public virtual string Surname { get; set; }

        [DisplayName("Телефон")]
        [StringLength(255, ErrorMessage = "Слишком длинное значение")]
        public string Phone { get; set; }

        public static ContactViewModel From(Contact contact)
        {
            ContactViewModel contactViewModel = new ContactViewModel();
            contactViewModel.City = contact.City;
            contactViewModel.Country = contact.Country;
            contactViewModel.House = contact.House;
            contactViewModel.Room = contact.Room;
            contactViewModel.Street = contact.Street;
            contactViewModel.Zip = contact.Zip;
            contactViewModel.Region = contact.Region;

            contactViewModel.Name = contact.Name;
            contactViewModel.Surname = contact.Surname;
            contactViewModel.Phone = contact.Phone;

            return contactViewModel;
        }
    }
}
