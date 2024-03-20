namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class PrecastReinforceOrderConfiguration : IEntityTypeConfiguration<PrecastReinforceOrder>
    {
        public void Configure(EntityTypeBuilder<PrecastReinforceOrder> builder)
        {
            builder
                .HasKey(pro => new { pro.PrecastId, pro.ReinforceOrderId });

            builder
                .HasOne(pro => pro.Precast)
                .WithMany(p => p.PrecastReinforceOrders)
                .HasForeignKey(pro => pro.PrecastId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
