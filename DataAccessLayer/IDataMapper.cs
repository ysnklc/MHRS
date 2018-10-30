using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface IDataMapper<TEntity>
    {
        int Insert(TEntity obj);
        int Update(TEntity obj);
        int Delete(TEntity obj);
        List<TEntity> GetAll();
        TEntity Get(int id);
    }
}
