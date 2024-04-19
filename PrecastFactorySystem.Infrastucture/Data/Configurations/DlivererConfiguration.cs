namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Models;

	internal class DlivererConfiguration : IEntityTypeConfiguration<Deliverer>
	{
		public void Configure(EntityTypeBuilder<Deliverer> builder)
		{
			builder
				.HasData(SeedDeliverers());
		}

		private IEnumerable<Deliverer> SeedDeliverers()
		{
			return new Deliverer[]
			{
				new Deliverer()
				{
					Id = 1,
					Name = "TestDeliverer",
					//My email is used for testing purposes
					Email = "ioannaabadjieva@gmail.com"
				}
			};
		}
	}

}
