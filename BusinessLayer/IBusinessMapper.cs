using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    interface IBusinessMapper<TEntity>
    {

        List<TEntity> GetAll();
        TEntity Get(int id);
        bool Save(TEntity obj);
        bool Delete(TEntity obj);





    }
}
