using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using WpfLearn.Server.NetworkNodes;


namespace WpfLearn.Wcf
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        IEnumerable<WorkstationDto> GetWorkstationDtoList(int page, int pageSize);

        [OperationContract]
        Workstation GetWorkstation(int id);

        [OperationContract]
        void DeleteWorkstation(int id);

        [OperationContract]
        void SaveWorkstation(Workstation workstation);

        [OperationContract]
        IEnumerable<Coordinator> GetCoordinatorList(int page, int pageSize);
    }
}
