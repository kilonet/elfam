using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using elfam.web.Dao;

namespace elfam.web.Services
{
    public class BaseService
    {
        protected DaoTemplate daoTemplate = new DaoTemplate();
    }
}
