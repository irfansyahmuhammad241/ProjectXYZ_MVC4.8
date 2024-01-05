using ProjectXYZ_MVC4._8.Contracts;
using ProjectXYZ_MVC4._8.Data;
using ProjectXYZ_MVC4._8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Repositories
{
    public class CompanyRepository : GeneralRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDBContext context) : base(context)
        {

        }
    }

 }
