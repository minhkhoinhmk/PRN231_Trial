using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HraccountRepository : IHraccountRepository
    {
        public Hraccount Authenticate(string email, string password)
        {
            return HraccountDAO.Instance.Authenticate(email, password);
        }
    }
}
