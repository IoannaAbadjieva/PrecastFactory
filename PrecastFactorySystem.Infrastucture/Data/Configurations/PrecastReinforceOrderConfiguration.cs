namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Models;

	internal class PrecastReinforceOrderConfiguration : IEntityTypeConfiguration<PrecastReinforceOrder>
	{
		public void Configure(EntityTypeBuilder<PrecastReinforceOrder> builder)
		{
			builder
				.HasKey(pro => new { pro.PrecastId, pro.ReinforceOrderId });

			builder
				.HasOne(pro => pro.Precast)
				.WithMany(p => p.PrecastReinforceOrders)
				.HasForeignKey(pro => pro.PrecastId);

			builder
				.HasData(SeedPrecastReinforceOrders());
		}

		private IEnumerable<PrecastReinforceOrder> SeedPrecastReinforceOrders()
		{
			return new PrecastReinforceOrder[]
			{
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 1,
					PrecastId = 7,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 2,
					PrecastId = 8,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 3,
					PrecastId = 1,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 4,
					PrecastId = 5,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 5,
					PrecastId = 10,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 6,
					PrecastId = 12,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 7,
					PrecastId = 13,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 8,
					PrecastId = 14,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 9,
					PrecastId = 1,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 10,
					PrecastId = 7,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 11,
					PrecastId = 8,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 12,
					PrecastId = 5,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 13,
					PrecastId = 6,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 14,
					PrecastId = 10,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 15,
					PrecastId = 16,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 16,
					PrecastId = 2,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 17,
					PrecastId = 19,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 18,
					PrecastId = 20,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 19,
					PrecastId = 21,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 20,
					PrecastId = 6,
				},
				new PrecastReinforceOrder
				{
					ReinforceOrderId = 21,
					PrecastId = 11,
				},
			};
		}

	}
}

