using AutoFixture.Xunit2;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nox.Lib.Tests.Factories.Types
{
    public class NoxTypeMoneyFactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution)
        {
            // Arrange            
            NoxTypeMoneyFactory sut = new NoxTypeMoneyFactory(noxSolution);

            // Act


            // Assert

        }        
    }
}
