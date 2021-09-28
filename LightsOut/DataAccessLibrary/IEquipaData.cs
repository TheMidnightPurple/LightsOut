using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IEquipaData
    {
        Task<List<EquipaModel>> GetEquipasEpoca(int ano);
    }
}