using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Turnos.Infraestructure.Repositories;
using Xunit;

namespace Turnos.Test.Unit.Respositories
{
    public class TurnoRepositoryTest
    {

        [Fact]
        public void Generate()
        {
            // Arrange
            var myConfiguration = new Dictionary<string, string>
            {
                {"ConnectionStrings:DefaultConnection", "Server=localhost\\SQLEXPRESS; Database=Turnos; Trusted_Connection=True; MultipleActiveResultSets=true"},
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            ServicioRepository serviceRepository = new ServicioRepository(configuration);
            TurnoRepository turnoRepository = new TurnoRepository(configuration);
            var services = serviceRepository.GetAll();

            DateTime fecha_inicio = Convert.ToDateTime("2021-01-16");
            DateTime fecha_fin = Convert.ToDateTime("2021-01-31");
            int id_servicio = services.LastOrDefault().Id_servicio;

            // Act
            var turnos = turnoRepository.Generate(fecha_inicio, fecha_fin, id_servicio);

            // Assert
            Assert.True(turnos.Count > 0);

        }

    }
}
