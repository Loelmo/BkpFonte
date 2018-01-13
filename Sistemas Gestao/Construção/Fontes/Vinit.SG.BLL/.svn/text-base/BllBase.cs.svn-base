using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Vinit.SG.BLL
{
    public class BllBase
    {
        public static Database db;

        public BllBase()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
