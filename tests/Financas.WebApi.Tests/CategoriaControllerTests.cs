using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using Financas.WebApi.Controllers;
using Financas.WebApi.Tests.Fakes;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Financas.WebApi.Tests
{
	public class CategoriaControllerTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void BuscarTodasCategorias()
		{
			// Arrange
			var controller = new CategoriaController(GetMock().Object);

			// Action
			var resutado = controller.Get();
			var esperado = 3;
			var atual = resutado.Count();

			// Asset
			Assert.AreEqual(esperado, atual, "jakldjaklsdjkljakldja ");
		}
		[Test]
		public void RemoverCategoria()
		{
			var controller = new CategoriaController(CategoriaRepositoryFake.Create());
			controller.Delete(3);

			var categoria = controller.Get(3);

			Assert.IsTrue(categoria == null);
		}

		private Mock<ICategoriaRepository> GetMock()
		{
			var lista = new List<Categoria>
			{
				new Categoria(1, "MERCADO"),
				new Categoria(2, "REMEDIOS"),
				new Categoria(3, "ESCOLA")
			};

			var mock = new Mock<ICategoriaRepository>();
			mock.Setup(c => c.GetAll()).Returns(lista);
			mock.Setup(c => c.Get(It.IsAny<int>())).Returns(lista.FirstOrDefault());
			mock.Setup(c => c.Save(It.IsAny<Categoria>()));
			mock.Setup(c => c.Update(It.IsAny<Categoria>()));
			mock.Setup(c => c.Delete(It.IsAny<Categoria>()));

			return mock;
		}
	}
}