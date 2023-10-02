﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMail.UI.DAL.Interface
{
   public interface IMailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }

}
