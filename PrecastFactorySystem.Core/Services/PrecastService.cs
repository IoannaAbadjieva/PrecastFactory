namespace PrecastFactorySystem.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PrecastFactorySystem.Core.Contracts;
    using PrecastFactorySystem.Core.Models.Precast;
    using PrecastFactorySystem.Data.Models;
    using PrecastFactorySystem.Infrastructure.Data.Common;

    public class PrecastService : IPrecastService
    {
        private readonly IRepository repository;

        public PrecastService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddPrecastAsync(PrecastFormViewModel model)
        {
            Precast entity = new Precast()
            {
                Name = model.Name,
                PrecastTypeId = model.PrecastTypeId,
                Count = model.Count,
                AddedOn = DateTime.Now,
                ProjectId = model.ProjectId,
                ConcreteClassId = model.ConcreteClassId,
                ConcreteProjectAmount = model.ConcreteProjectAmount,
                ReinforceProjectWeight = model.ReinforceProjectAmount
            };

            await repository.AddAsync<Precast>(entity);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PrecastInfoViewModel>> GetAllPrecastAsync()
        {
            return await repository.AllReadonly<Precast>()
                  .Select(p => new PrecastInfoViewModel()
                  {
                      Id = p.Id,
                      PrecastType = p.PrecastType.Name,
                      Name = p.Name,
                      Count = p.Count,
                      Project = p.Project.Name,
                      Reinforced = p.PrecastReinforceOrders.Sum(p => p.ReinforceOrder.Count),
                      Produced = p.DepartmentPrecast.Sum(dp => dp.Count)
                  }).ToArrayAsync();
        }

        public async Task<IEnumerable<PrecastInfoViewModel>> GetPrecastAsync(Expression<Func<Precast, bool>> findWhereClause)
        {

            return await repository.AllReadonly<Precast>()
                .Where(findWhereClause)
                .Select(p => new PrecastInfoViewModel()
                {
                    Id = p.Id,
                    PrecastType = p.PrecastType.Name,
                    Name = p.Name,
                    Count = p.Count,
                    Project = p.Project.Name,
                    Reinforced = p.PrecastReinforceOrders.Sum(p => p.ReinforceOrder.Count),
                    Produced = p.DepartmentPrecast.Sum(dp => dp.Count)
                }).ToArrayAsync();
        }
    }
}
