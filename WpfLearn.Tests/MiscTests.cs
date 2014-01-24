using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using WpfLearn.Server;
using WpfLearn.Server.NetworkNodes;


namespace WpfLearn.Tests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void T1()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                WorkstationRepository repository = new WorkstationRepository(unitOfWork);
                Workstation workstation = repository.GetById(1);
            }
        }

        [TestMethod]
        public void T2()
        {
        }
    }
}
