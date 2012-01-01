using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Attributes;

namespace elfam.web.Models
{
    public enum OrderStatus
    {
        [Description("Доставлен")]
        Delivered,
        [Description("Оплачен")]
        Payed,
        [Description("Отправлен")]
        Sent,
        [Description("Ожидает оплаты")]
        WaitPayment,
        [Description("В обработке")]
        Processing,
        [Description("Ожидает самовывоза")]
        WaitPickup,
        [Description("Отменен")]
        Revoked
    }

    public enum PaymentType
    {
        [Description("Выберите способ оплаты")]
        NULL = 0,
        [Description("Банковский перевод")]
        Bank,
        [Description("Яндекс деньги")]
        YandexMoney,
        [Description("Наличные")]
        Cash, 
        [Description("При получении на почте")]
        OnPost
    }

    public enum DeliverType
    {
        [Description("Выберите способ доставки")]
        NULL = 0,
        [Description("Курьером по Москве")]
        CourierMoscow = 1,
        [Description("Курьером по Подмосковью")]
        CourierSubMoscow = 2,
        [Description("Почта России")]
        Post = 3,
        [Description("Самовывоз")]
        Myself = 4
    }

    public enum Role
    {
        Admin,
        User
    }

    public enum ArticlePlacement
    {
        [Description("Верхнее меню")]
        TopMenu,
        [Description("Главная страница")]
        MainPage,
        [Description("Нигде")]
        Nowhere,
        [Description("Новость")]
        News
    }

}
