using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elfam.web.Exceptions
{
    public class NotFoundException: HttpException
    {
        public NotFoundException(): base(404, "Запрашиваемая страница не найдена") {}
    }
}
