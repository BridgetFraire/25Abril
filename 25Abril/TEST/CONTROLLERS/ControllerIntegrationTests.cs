using System;
using Abril25.ITD.PERROSPERDIDOS.DOMAIN.INTERFACES;
using Microsoft.AspNetCore.Hosting;
using Mysqlx.Crud;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace _25Abril.TEST.CONTROLLERS
{
	public class ControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public ControllerIntegrationTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public async Task Get_ReturnsPublicacionesRecientes()
		{
			// Arrange
			var client = _factory.CreateClient();

			// Act
			var response = await client.GetAsync("/api/MascotaPerdida");

			// Assert
			response.EnsureSuccessStatusCode(); // Status Code 200-299
			Assert.Equal("application/json; charset=utf-8",
						 response.Content.Headers.ContentType.ToString());
		}

		[Fact]
		public async Task Post_ReportarPerroPerdido_ReturnsSuccessStatusCode()
		{
			// Arrange
			var client = _factory.CreateClient();
			var mascotaPerdida = new MascotaPerdida
			{
				// Rellena con datos de prueba
			};
			var content = new StringContent(JsonContent.SerializeObject(mascotaPerdida), Encoding.UTF8, "application/json");

			// Act
			var response = await client.PostAsync("/api/MascotaPerdida", content);

			// Assert
			response.EnsureSuccessStatusCode();
		}

		[Fact]
		public async Task Patch_ModificarCaracteristicasPerroPerdido_ReturnsSuccessStatusCode()
		{
			// Arrange
			var client = _factory.CreateClient();
			var mascotaPerdida = new MascotaPerdida
			{
				// Rellena con datos de prueba
			};
			var content = new StringContent(JsonConverter.SerializeObject(mascotaPerdida), Encoding.UTF8, "application/json");

			// Act
			var response = await client.PatchAsync($"/api/MascotaPerdida/{mascotaPerdida.IdUsuario}", content);

			// Assert
			response.EnsureSuccessStatusCode();
		}
	}

}

