using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;

namespace WebAPI.Interfaces
{
     public interface IUnitOfWork
    {
        ICityRepository cityRepository { get; }
       
        Task<bool> SaveAsync();

    }
}
