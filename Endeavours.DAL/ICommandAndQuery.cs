using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endeavours.Entities;

namespace Endeavours.DAL
{
    public interface ICommandAndQuery<T>
    {
        public List<T> GetAll();
        public T GetByID(int ID);
        public int Count();
        public int Insert(T data);
        public bool Update(T data,int ID);
        public bool Delete(int ID);
    }

   

}
