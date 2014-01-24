using System;
using System.Collections.Generic;

using WpfLearn.Server;
using WpfLearn.Server.NetworkNodes;


namespace WpfLearn.Wcf
{
    public class Service : IService
    {
        public IEnumerable<WorkstationDto> GetWorkstationDtoList(int page, int pageSize)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return new WorkstationRepository(unitOfWork).GetDtoList(page, pageSize);
            }
        }


        public Workstation GetWorkstation(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return new WorkstationRepository(unitOfWork).GetCopy(id);
            }
        }


        public void DeleteWorkstation(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                new WorkstationRepository(unitOfWork).Delete(id);
            }
        }


        public void SaveWorkstation(Workstation workstation)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                new WorkstationRepository(unitOfWork).SaveCopy(workstation);
            }
        }


        public IEnumerable<Coordinator> GetCoordinatorList(int page, int pageSize)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return new CoordinatorRepository(unitOfWork).GetCopyList(page, pageSize);
            }
        }
    }
}
