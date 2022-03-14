using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Turnos.Infraestructure.Repositories;
using Xunit;

namespace Turnos.Test.Unit.Respositories
{
    public class ServicioRepositoryTest
    {

        [Fact]
        public void GetAll()
        {

            // Arrange
            var myConfiguration = new Dictionary<string, string>
            {
                {"ConnectionStrings:DefaultConnection", "Server=localhost\\SQLEXPRESS; Database=Turnos; Trusted_Connection=True; MultipleActiveResultSets=true"},
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();


            ServicioRepository repository = new ServicioRepository(configuration);


            // Act
            var entitites = repository.GetAll();

            // Assert            
            Assert.True(entitites.Count > 0);
        }
    }
}
