using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class HraccountDAO
    {
        private static HraccountDAO instance = null;
        private static readonly object instanceLock = new object();

        private HraccountDAO() { }

        public static HraccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new HraccountDAO();
                    }
                    return instance;
                }
            }
        }

        public Hraccount Authenticate(string email, string password)
        {
            Hraccount hraccount = null;
            try
            {
                var context = new CandidateManagementContext();
                hraccount = context.Hraccounts
                    .FirstOrDefault(c => c.Email == email && c.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception("Hraccount not found");
            }
            return hraccount;
        }
    }
}
