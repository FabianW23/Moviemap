using Moviemap.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Helpers
{
    public interface IEmailHelper
    {
        Response SendMail(string to, string subject, string body);
    }
}
