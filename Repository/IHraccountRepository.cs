using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IHraccountRepository
    {
        Hraccount Authenticate(string email, string password);
    }
}
