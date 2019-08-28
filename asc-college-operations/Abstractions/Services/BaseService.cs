using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Abstractions.Services
{
    public abstract class BaseService
    {
        protected CollegeContext Context { get; }
        public BaseService(CollegeContext context)
        {
            this.Context = context;
        }
    }
}
