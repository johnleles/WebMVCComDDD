﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCComDDD.Application.Helpers;

namespace WebMVCComDDD.Application.Interfaces
{
    public interface IEmailApplication
    {
        Task SendEmailAsyncc(EmailRequest emailRequest);
        Task SendEmailAsyncc();
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
