using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface ICrudStatements
    {
        SqlOperation GetCreateStatement(BaseClass entityDTO);
        SqlOperation GetUpdateStatement(BaseClass entityDTO);
        SqlOperation GetDeleteStatement(BaseClass entityDTO);
        SqlOperation RetrieveAllStatement();
        SqlOperation RetrieveByIdStatement(int Id);

    }
}
