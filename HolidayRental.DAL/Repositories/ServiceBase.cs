using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.DAL.Repositories
{
    public abstract class ServiceBase
    {
        protected string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HolyDayRental;Integrated Security=True";
    }
}
