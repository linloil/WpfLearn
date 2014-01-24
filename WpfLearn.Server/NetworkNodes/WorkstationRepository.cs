using System;
using System.Collections.Generic;
using System.Linq;

using NHibernate;
using NHibernate.Linq;


namespace WpfLearn.Server.NetworkNodes
{
    public class WorkstationRepository : Repository<Workstation>
    {
        public WorkstationRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public IEnumerable<WorkstationDto> GetDtoList(int page, int pageSize)
        {
            return _unitOfWork.Query<Workstation>()
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(x => new WorkstationDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CoordinatorName = x.Coordinator.Name,
                    RoleCount = x.RoleRegistrations.Count
                })
                .ToArray();
        }


        public Workstation GetCopy(int id)
        {
            Workstation workstation = GetById(id);

            return new Workstation
            {
                Id = workstation.Id,
                Name = workstation.Name,
                ChangeStamp = workstation.ChangeStamp,
                Coordinator = new Coordinator
                {
                    Id = workstation.Coordinator.Id,
                    Name = workstation.Coordinator.Name
                }
            };
        }


        public void SaveCopy(Workstation copy)
        {
            Workstation workstation;

            if (copy.IsTransient())
            {
                workstation = new Workstation();
            }
            else
            {
                workstation = GetById(copy.Id);
            }

            workstation.Name = copy.Name;
            workstation.Coordinator = _unitOfWork.Load<Coordinator>(copy.Coordinator.Id);
            SyncRegistrations(workstation.RoleRegistrations, copy.RoleRegistrations);
            Save(workstation);
        }


        private void SyncRegistrations(IList<RoleRegistration> dest, IList<RoleRegistration> source)
        {
            var newItems = source.Except(dest);
            var modifiedItems = dest.Intersect(source);
            var deletedItems = dest.Except(source).ToArray();

            foreach (RoleRegistration newItem in newItems)
            {
                dest.Add(newItem);
            }

            foreach (RoleRegistration deletedItem in deletedItems)
            {
                dest.Remove(deletedItem);
            }

            foreach (RoleRegistration modifiedItem in modifiedItems)
            {
                RoleRegistration item = dest.Single(x => x == modifiedItem);
                item.PermissionLevel = modifiedItem.PermissionLevel;
            }
        }
    }
}
