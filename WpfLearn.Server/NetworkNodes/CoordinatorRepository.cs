using System;
using System.Collections.Generic;
using System.Linq;

using NHibernate.Linq;


namespace WpfLearn.Server.NetworkNodes
{
    public class CoordinatorRepository : Repository<Coordinator>
    {
        public CoordinatorRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }


        public IEnumerable<Coordinator> GetCopyList(int page, int pageSize)
        {
            return _unitOfWork.Query<Coordinator>()
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(x => new Coordinator
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToArray();
        }
    }
}
