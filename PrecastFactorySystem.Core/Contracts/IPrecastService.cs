namespace PrecastFactorySystem.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    using PrecastFactorySystem.Core.Models.Precast;
    using PrecastFactorySystem.Data.Models;

    public interface IPrecastService
    {
        Task AddPrecastAsync(PrecastFormViewModel model);
        Task<IEnumerable<PrecastInfoViewModel>> GetAllPrecastAsync();
        Task<IEnumerable<PrecastInfoViewModel>> GetPrecastAsync(Expression<Func<Precast, bool>> findWhereClause);
    }
}
