namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Models;

	internal class PrecastReinforceConfiguration : IEntityTypeConfiguration<PrecastReinforce>
	{
		public void Configure(EntityTypeBuilder<PrecastReinforce> builder)
		{
			builder
				.HasData(SeedPrecastReinforce());
		}

		private IEnumerable<PrecastReinforce> SeedPrecastReinforce()
		{
			return new PrecastReinforce[]
			{
				new PrecastReinforce()
				{
					Id = 1,
					PrecastId = 1,
					Position = "1" ,
					Count = 4,
					ReinforceTypeId = 26,
					Length = 14.63m,
					Weight = 369.85m ,
				},
				new PrecastReinforce()
				{
					Id = 2,
					PrecastId = 1,
					Position = "2,3,4",
					Count = 16,
					ReinforceTypeId = 25,
					Length = 12m,
					Weight = 929.28m
				},
				new PrecastReinforce()
				{
					Id = 3,
					PrecastId = 1,
					Position = "2a",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 8.9m,
					Weight = 68.71m
				},
				new PrecastReinforce()
				{
					Id = 4,
					PrecastId = 1,
					Position = "4,8",
					Count = 8,
					ReinforceTypeId = 24,
					Length = 8.9m,
					Weight = 128.15m
				},
				new PrecastReinforce()
				{
					Id = 5,
					PrecastId = 1,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3m,
					Weight = 23.16m
				},
				new PrecastReinforce()
				{
					Id = 6,
					PrecastId = 1,
					Position = "6",
					Count = 8,
					ReinforceTypeId = 18,
					Length = 1.34m,
					Weight = 9.54m
				},
				new PrecastReinforce()
				{
					Id = 7,
					PrecastId = 1,
					Position = "7",
					Count = 3,
					ReinforceTypeId = 22,
					Length = 0.65m,
					Weight = 4.82m
				},
				new PrecastReinforce()
				{
					Id = 8,
					PrecastId = 1,
					Position = "9",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3.6m ,
					Weight = 27.29m
				},
				new PrecastReinforce()
				{
					Id = 9,
					PrecastId = 1,
					Position = "12,13",
					Count = 105,
					ReinforceTypeId = 16,
					Length = 6.4m ,
					Weight = 265.44m
				},
				new PrecastReinforce()
				{
					Id = 10,
					PrecastId = 2,
					Position = "1",
					Count = 4,
					ReinforceTypeId = 26,
					Length = 18.36m,
					Weight = 470.79m
				},
				new PrecastReinforce()
				{
					Id = 11,
					PrecastId = 2,
					Position = "2,3,4",
					Count = 16,
					ReinforceTypeId = 25,
					Length = 12m,
					Weight = 929.28m
				},
				new PrecastReinforce()
				{
					Id = 12,
					PrecastId = 2,
					Position = "4,8",
					Count = 14,
					ReinforceTypeId = 25,
					Length = 8.15m,
					Weight = 552.24m
				},
				new PrecastReinforce()
				{
					Id = 13,
					PrecastId = 2,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3m,
					Weight = 23.16m
				},
				new PrecastReinforce()
				{
					Id = 14,
					PrecastId = 2,
					Position = "6",
					Count = 8,
					ReinforceTypeId = 18,
					Length = 1.34m,
					Weight = 9.54m
				},
				new PrecastReinforce()
				{
					Id = 15,
					PrecastId = 2,
					Position = "7",
					Count = 3,
					ReinforceTypeId = 22,
					Length = 0.65m,
					Weight = 4.82m
				},
				new PrecastReinforce()
				{
					Id = 16,
					PrecastId = 2,
					Position = "9",
					Count = 4,
					ReinforceTypeId = 24,
					Length = 3.6m,
					Weight = 55.58m
				},
				new PrecastReinforce()
				{
					Id = 17,
					PrecastId = 2,
					Position = "12,13",
					Count = 135,
					ReinforceTypeId = 16,
					Length = 6.4m,
					Weight = 341.28m
				},
				new PrecastReinforce()
				{
					Id = 18,
					PrecastId = 3,
					Position = "1",
					Count = 4,
					ReinforceTypeId = 26,
					Length = 18.62m,
					Weight = 470.71m
				},
				new PrecastReinforce()
				{
					Id = 19,
					PrecastId = 3,
					Position = "2,4",
					Count = 8,
					ReinforceTypeId = 25,
					Length = 12m,
					Weight = 464.64m
				},
				new PrecastReinforce()
				{
					Id = 20,
					PrecastId = 3,
					Position = "2,4",
					Count = 8,
					ReinforceTypeId = 24,
					Length = 8.15m,
					Weight = 251.67m
				},
				new PrecastReinforce()
				{
					Id = 21,
					PrecastId = 3,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3m,
					Weight = 23.16m
				},
				new PrecastReinforce()
				{
					Id = 22,
					PrecastId = 3,
					Position = "6",
					Count = 8,
					ReinforceTypeId = 18,
					Length = 1.34m,
					Weight = 9.54m
				},
				new PrecastReinforce()
				{
					Id = 23,
					PrecastId = 3,
					Position = "7",
					Count = 3,
					ReinforceTypeId = 22,
					Length = 0.65m,
					Weight = 4.82m
				},
				new PrecastReinforce()
				{
					Id = 24,
					PrecastId = 3,
					Position = "8",
					Count = 6,
					ReinforceTypeId = 22,
					Length = 3.3m,
					Weight = 48.91m
				},
				new PrecastReinforce()
				{
					Id = 25,
					PrecastId = 3,
					Position = "8a" ,
					Count = 5,
					ReinforceTypeId = 16,
					Length = 3.7m,
					Weight = 7.31m
				},
				new PrecastReinforce()
				{
					Id = 26,
					PrecastId = 3,
					Position = "9",
					Count = 4,
					ReinforceTypeId = 24,
					Length = 3.6m,
					Weight = 55.58m
				},
				new PrecastReinforce()
				{
					Id = 27,
					PrecastId = 3,
					Position = "12,13",
					Count = 136,
					ReinforceTypeId = 16,
					Length = 6.4m,
					Weight = 343.81m
				},
				new PrecastReinforce()
				{
					Id = 28,
					PrecastId = 4,
					Position = "1",
					Count = 4,
					ReinforceTypeId = 25,
					Length = 14.67m,
					Weight = 284.01m
				},
				new PrecastReinforce()
				{
					Id = 29,
					PrecastId = 4,
					Position = "2,3,4",
					Count = 16,
					ReinforceTypeId = 24,
					Length = 12m,
					Weight = 741.12m
				},
				new PrecastReinforce()
				{
					Id = 30,
					PrecastId = 4,
					Position = "2a" ,
					Count = 2,
					ReinforceTypeId = 24,
					Length = 8.9m,
					Weight = 68.71m
				},
				new PrecastReinforce()
				{
					Id = 31,
					PrecastId = 4,
					Position = "4,8",
					Count = 4,
					ReinforceTypeId = 24,
					Length = 4.15m,
					Weight = 64.08m
				},
				new PrecastReinforce()
				{
					Id = 32,
					PrecastId = 4,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3m,
					Weight = 23.16m
				},
				new PrecastReinforce()
				{
					Id = 33,
					PrecastId = 4,
					Position = "6",
					Count = 8,
					ReinforceTypeId = 18,
					Length = 1.34m,
					Weight = 9.54m
				},
				new PrecastReinforce()
				{
					Id = 34,
					PrecastId = 4,
					Position = "7",
					Count = 3,
					ReinforceTypeId = 22,
					Length = 0.65m,
					Weight = 4.82m
				},
				new PrecastReinforce()
				{
					Id = 35,
					PrecastId = 4,
					Position = "9",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3.6m,
					Weight = 27.29m
				},
				new PrecastReinforce()
				{
					Id = 36,
					PrecastId = 4,
					Position = "12,13",
					Count = 105,
					ReinforceTypeId = 16,
					Length = 6.4m,
					Weight = 265.44m
				},
				new PrecastReinforce()
				{
					Id = 37,
					PrecastId = 5,
					Position = "1",
					Count = 4,
					ReinforceTypeId = 26,
					Length = 14.67m,
					Weight = 370.86m
				},
				new PrecastReinforce()
				{
					Id = 38,
					PrecastId = 5,
					Position = "2,3,4",
					Count = 16,
					ReinforceTypeId = 24,
					Length = 12m,
					Weight = 741.12m
				},
				new PrecastReinforce()
				{
					Id = 39,
					PrecastId = 5,
					Position = "2a" ,
					Count = 2,
					ReinforceTypeId = 24,
					Length = 8.9m,
					Weight = 68.71m
				},
				new PrecastReinforce()
				{
					Id = 40,
					PrecastId = 5,
					Position = "4,8",
					Count = 4,
					ReinforceTypeId = 24,
					Length = 4.15m,
					Weight = 64.08m
				},
				new PrecastReinforce()
				{
					Id = 41,
					PrecastId = 5,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3m,
					Weight = 23.16m
				},
				new PrecastReinforce()
				{
					Id = 42,
					PrecastId = 5,
					Position = "6",
					Count = 8,
					ReinforceTypeId = 18,
					Length = 1.34m,
					Weight = 9.54m
				},
				new PrecastReinforce()
				{
					Id = 43,
					PrecastId = 5,
					Position = "7",
					Count = 3,
					ReinforceTypeId = 22,
					Length = 0.65m,
					Weight = 4.82m
				},
				new PrecastReinforce()
				{
					Id = 44,
					PrecastId = 5,
					Position = "9",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3.6m,
					Weight = 27.29m
				},
				new PrecastReinforce()
				{
					Id = 45,
					PrecastId = 5,
					Position = "12,13",
					Count = 105,
					ReinforceTypeId = 16,
					Length = 6.4m,
					Weight = 265.44m
				},
				new PrecastReinforce()
				{
					Id = 46,
					PrecastId = 6,
					Position = "1",
					Count = 4,
					ReinforceTypeId = 26,
					Length = 14.67m,
					Weight = 370.86m
				},
				new PrecastReinforce()
				{
					Id = 47,
					PrecastId = 6,
					Position = "2,3,4",
					Count = 16,
					ReinforceTypeId = 24,
					Length = 12m,
					Weight = 741.12m
				},
				new PrecastReinforce()
				{
					Id = 48,
					PrecastId = 6,
					Position = "2a" ,
					Count = 2,
					ReinforceTypeId = 24,
					Length = 8.9m,
					Weight = 68.71m
				},
				new PrecastReinforce()
				{
					Id = 49,
					PrecastId = 6,
					Position = "4,8",
					Count = 12,
					ReinforceTypeId = 24,
					Length = 4.15m,
					Weight = 192.23m
				},
				new PrecastReinforce()
				{
					Id = 50,
					PrecastId = 6,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3m,
					Weight = 23.16m
				},
				new PrecastReinforce()
				{
					Id = 51,
					PrecastId = 6,
					Position = "6",
					Count = 8,
					ReinforceTypeId = 18,
					Length = 1.34m,
					Weight = 9.54m
				},
				new PrecastReinforce()
				{
					Id = 52,
					PrecastId = 6,
					Position = "7",
					Count = 3,
					ReinforceTypeId = 22,
					Length = 0.65m,
					Weight = 4.82m
				},
				new PrecastReinforce()
				{
					Id = 53,
					PrecastId = 6,
					Position = "9",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 3.6m,
					Weight = 27.29m
				},
				new PrecastReinforce()
				{
					Id = 54,
					PrecastId = 6,
					Position = "12,13",
					Count = 105,
					ReinforceTypeId = 16,
					Length = 6.4m,
					Weight = 265.44m
				},
				new PrecastReinforce()
				{
					Id = 55,
					PrecastId = 7,
					Position = "1",
					Count = 24,
					ReinforceTypeId = 20,
					Length = 4.33m,
					Weight = 164.19m
				},
				new PrecastReinforce()
				{
					Id = 56,
					PrecastId = 7,
					Position = "2",
					Count = 9,
					ReinforceTypeId = 18,
					Length = 5.88m,
					Weight = 64.03m
				},
				new PrecastReinforce()
				{
					Id = 57,
					PrecastId = 7,
					Position = "3",
					Count = 12,
					ReinforceTypeId = 22,
					Length = 1.93m,
					Weight = 57.21m
				},
				new PrecastReinforce()
				{
					Id = 58,
					PrecastId = 7,
					Position = "4",
					Count = 24,
					ReinforceTypeId = 19,
					Length = 1.93m,
					Weight = 56.05m
				},
				new PrecastReinforce()
				{
					Id = 59,
					PrecastId = 7,
					Position = "5",
					Count = 3,
					ReinforceTypeId = 26,
					Length = 1.1m,
					Weight = 20.86m
				},
				new PrecastReinforce()
				{
					Id = 60,
					PrecastId = 8,
					Position = "1",
					Count = 24,
					ReinforceTypeId = 20,
					Length = 4.88m,
					Weight = 169.88m
				},
				new PrecastReinforce()
				{
					Id = 61,
					PrecastId = 8,
					Position = "2",
					Count = 9,
					ReinforceTypeId = 18,
					Length = 6.28m,
					Weight = 68.39m
				},
				new PrecastReinforce()
				{
					Id = 62,
					PrecastId = 8,
					Position = "3",
					Count = 12,
					ReinforceTypeId = 22,
					Length = 2.03m,
					Weight = 60.17m
				},
				new PrecastReinforce()
				{
					Id = 63,
					PrecastId = 8,
					Position = "4",
					Count = 24 ,
					ReinforceTypeId = 19,
					Length = 1.93m,
					Weight = 56.05m
				},
				new PrecastReinforce()
				{
					Id = 64,
					PrecastId = 8,
					Position = "5",
					Count = 3,
					ReinforceTypeId = 26,
					Length = 1.1m,
					Weight = 20.86m
				},
				new PrecastReinforce()
				{
					Id = 65,
					PrecastId = 9,
					Position = "1",
					Count = 3,
					ReinforceTypeId = 26,
					Length = 1m,
					Weight = 18.96m
				},
				new PrecastReinforce()
				{
					Id = 66,
					PrecastId = 9,
					Position = "2",
					Count = 40,
					ReinforceTypeId = 18,
					Length = 4.22m,
					Weight = 150.23m
				},
				new PrecastReinforce()
				{
					Id = 67,
					PrecastId = 9,
					Position = "3",
					Count = 64,
					ReinforceTypeId = 16,
					Length = 0.4m,
					Weight = 10.11m
				},
				new PrecastReinforce()
				{
					Id = 68,
					PrecastId = 9,
					Position = "4",
					Count = 32,
					ReinforceTypeId = 18,
					Length = 2.03m,
					Weight = 57.81m
				},
				new PrecastReinforce()
				{
					Id = 69,
					PrecastId = 9,
					Position = "5",
					Count = 8,
					ReinforceTypeId = 18,
					Length = 6.68m,
					Weight = 47.56m
				},
				new PrecastReinforce()
				{
					Id = 70,
					PrecastId = 9,
					Position = "6",
					Count = 5,
					ReinforceTypeId = 19,
					Length = 6.68m,
					Weight = 40.41m
				},
				new PrecastReinforce()
				{
					Id = 71,
					PrecastId = 9,
					Position = "7",
					Count = 20,
					ReinforceTypeId = 19,
					Length = 2.13m,
					Weight = 51.55m
				},
				new PrecastReinforce()
				{
					Id = 72,
					PrecastId = 10,
					Position = "1",
					Count = 16,
					ReinforceTypeId = 23,
					Length = 12.5m,
					Weight = 598m
				},
				new PrecastReinforce()
				{
					Id = 73,
					PrecastId = 10,
					Position = "2",
					Count = 4,
					ReinforceTypeId = 23,
					Length = 11m,
					Weight = 131.56m
				},
				new PrecastReinforce()
				{
					Id = 74,
					PrecastId = 10,
					Position = "3",
					Count = 12,
					ReinforceTypeId = 22,
					Length = 2.8m,
					Weight = 82.99m
				},
				new PrecastReinforce()
				{
					Id = 75,
					PrecastId = 10,
					Position = "4,5",
					Count = 78,
					ReinforceTypeId = 16,
					Length = 6.92m,
					Weight = 213.21m
				},
				new PrecastReinforce()
				{
					Id = 76,
					PrecastId = 10,
					Position = "5",
					Count = 156,
					ReinforceTypeId = 16,
					Length = 2.06m,
					Weight = 126.94m
				},
				new PrecastReinforce()
				{
					Id = 77,
					PrecastId = 10,
					Position = "6",
					Count = 11,
					ReinforceTypeId = 16,
					Length = 2m,
					Weight = 8.69m
				},
				new PrecastReinforce()
				{
					Id = 78,
					PrecastId = 10,
					Position = "7",
					Count = 4,
					ReinforceTypeId = 16,
					Length = 0.92m,
					Weight = 4m
				},
				new PrecastReinforce()
				{
					Id = 79,
					PrecastId = 10,
					Position = "8",
					Count = 4,
					ReinforceTypeId = 20,
					Length = 5m,
					Weight = 31.6m
				},
				new PrecastReinforce()
				{
					Id = 80,
					PrecastId = 10,
					Position = "9",
					Count = 10,
					ReinforceTypeId = 20,
					Length = 3m,
					Weight = 47.4m
				},
				new PrecastReinforce()
				{
					Id = 81,
					PrecastId = 10,
					Position = "10",
					Count = 8,
					ReinforceTypeId = 16,
					Length = 2.6m,
					Weight = 8.22m
				},
				new PrecastReinforce()
				{
					Id = 82,
					PrecastId = 10,
					Position = "11",
					Count = 22,
					ReinforceTypeId = 16,
					Length = 2.6m,
					Weight = 22.59m
				},
				new PrecastReinforce()
				{
					Id = 83,
					PrecastId = 10,
					Position = "12",
					Count = 44,
					ReinforceTypeId = 16,
					Length = 0.4m,
					Weight = 6.95m
				},
				new PrecastReinforce()
				{
					Id = 84,
					PrecastId = 11,
					Position = "1",
					Count = 44,
					ReinforceTypeId = 23,
					Length = 12.96m,
					Weight = 620.01m
				},
				new PrecastReinforce()
				{
					Id = 85,
					PrecastId = 11,
					Position = "2",
					Count = 4,
					ReinforceTypeId = 23,
					Length = 11.46m,
					Weight = 137.06m
				},
				new PrecastReinforce()
				{
					Id = 86,
					PrecastId = 11,
					Position = "3",
					Count = 8,
					ReinforceTypeId = 22,
					Length = 2.8m,
					Weight = 55.33m
				},
				new PrecastReinforce()
				{
					Id = 87,
					PrecastId = 11,
					Position = "4,5",
					Count = 81,
					ReinforceTypeId = 16,
					Length = 6.92m,
					Weight = 221.41m
				},
				new PrecastReinforce()
				{
					Id = 88,
					PrecastId = 11,
					Position = "5",
					Count = 162,
					ReinforceTypeId = 16,
					Length = 2.06m,
					Weight = 131.82m
				},
				new PrecastReinforce()
				{
					Id = 89,
					PrecastId = 11,
					Position = "6",
					Count = 11,
					ReinforceTypeId = 16,
					Length = 2m,
					Weight = 8.69m
				},
				new PrecastReinforce()
				{
					Id = 90,
					PrecastId = 11,
					Position = "7",
					Count = 11,
					ReinforceTypeId = 16,
					Length = 0.92m,
					Weight = 4m
				},
				new PrecastReinforce()
				{
					Id = 91,
					PrecastId = 11,
					Position = "8",
					Count = 4,
					ReinforceTypeId = 20,
					Length = 5m,
					Weight = 31.6m
				},
				new PrecastReinforce()
				{
					Id = 92,
					PrecastId = 11,
					Position = "9",
					Count = 10,
					ReinforceTypeId = 20,
					Length = 3m,
					Weight = 47.4m
				},
				new PrecastReinforce()
				{
					Id = 93,
					PrecastId = 11,
					Position = "10",
					Count = 8,
					ReinforceTypeId = 16,
					Length = 2.6m,
					Weight = 8.22m
				},
				new PrecastReinforce()
				{
					Id = 94,
					PrecastId = 11,
					Position = "11",
					Count = 22,
					ReinforceTypeId = 16,
					Length = 2.6m,
					Weight = 22.59m
				},
				new PrecastReinforce()
				{
					Id = 95,
					PrecastId = 11,
					Position = "12",
					Count = 44,
					ReinforceTypeId = 16,
					Length = 0.4m,
					Weight = 6.95m
				},
				new PrecastReinforce()
				{
					Id = 96,
					PrecastId = 12,
					Position = "1",
					Count = 4,
					ReinforceTypeId = 22,
					Length = 14m,
					Weight = 138.32m
				},
				new PrecastReinforce()
				{
					Id = 97,
					PrecastId = 12,
					Position = "2",
					Count = 2,
					ReinforceTypeId = 22,
					Length = 11.35m,
					Weight = 56.07m
				},
				new PrecastReinforce()
				{
					Id = 98,
					PrecastId = 12,
					Position = "3",
					Count = 4,
					ReinforceTypeId = 22,
					Length = 6.3m,
					Weight = 562.44m
				},
				new PrecastReinforce()
				{
					Id = 99,
					PrecastId = 12,
					Position = "4",
					Count = 4,
					ReinforceTypeId = 24,
					Length = 14m,
					Weight = 216.16m
				},
				new PrecastReinforce()
				{
					Id = 100,
					PrecastId = 12,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 24,
					Length = 10.85m,
					Weight = 167.52m
				},
				new PrecastReinforce()
				{
					Id = 101,
					PrecastId = 12,
					Position = "6",
					Count = 14,
					ReinforceTypeId = 17,
					Length = 14m,
					Weight = 121.52m
				},
				new PrecastReinforce()
				{
					Id = 102,
					PrecastId = 12,
					Position = "7",
					Count = 14,
					ReinforceTypeId = 17,
					Length = 10.85m,
					Weight = 94.18m
				},
				new PrecastReinforce()
				{
					Id = 103,
					PrecastId = 12,
					Position = "8",
					Count = 4,
					ReinforceTypeId = 20,
					Length = 14m,
					Weight = 88.48m
				},
				new PrecastReinforce()
				{
					Id = 104,
					PrecastId = 12,
					Position = "9",
					Count = 2,
					ReinforceTypeId = 20,
					Length = 10m,
					Weight = 31.6m
				},
				new PrecastReinforce()
				{
					Id = 105,
					PrecastId = 12,
					Position = "10",
					Count = 2,
					ReinforceTypeId = 20,
					Length = 11.35m,
					Weight = 35.87m
				},
				new PrecastReinforce()
				{
					Id = 106,
					PrecastId = 12,
					Position = "11",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 2.6m,
					Weight = 10.4m
				},
				new PrecastReinforce()
				{
					Id = 107,
					PrecastId = 12,
					Position = "12",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 3.23m,
					Weight = 12.92m
				},
				new PrecastReinforce()
				{
					Id = 108,
					PrecastId = 12,
					Position = "13",
					Count = 7,
					ReinforceTypeId = 19,
					Length = 2.23m,
					Weight = 18.89m
				},
				new PrecastReinforce()
				{
					Id = 109,
					PrecastId = 12,
					Position = "14",
					Count = 4,
					ReinforceTypeId = 22,
					Length = 3.7m,
					Weight = 36.56m
				},
				new PrecastReinforce()
				{
					Id = 110,
					PrecastId = 12,
					Position = "15",
					Count = 8,
					ReinforceTypeId = 16,
					Length = 3.64m,
					Weight = 11.5m
				},
				new PrecastReinforce()
				{
					Id = 111,
					PrecastId = 12,
					Position = "16,20",
					Count = 128,
					ReinforceTypeId = 16,
					Length = 4.78m,
					Weight = 241.68m
				},
				new PrecastReinforce()
				{
					Id = 112,
					PrecastId = 12,
					Position = "17",
					Count = 10,
					ReinforceTypeId = 16,
					Length = 3.6m,
					Weight = 14.22m
				},
				new PrecastReinforce()
				{
					Id = 113,
					PrecastId = 12,
					Position = "18,20",
					Count = 10,
					ReinforceTypeId = 16,
					Length = 4.72m,
					Weight = 18.64m
				},
				new PrecastReinforce()
				{
					Id = 114,
					PrecastId = 12,
					Position = "19",
					Count = 126,
					ReinforceTypeId = 16,
					Length = 1.83m,
					Weight = 91.08m
				},
				new PrecastReinforce()
				{
					Id = 115,
					PrecastId = 12,
					Position = "21",
					Count = 36,
					ReinforceTypeId = 16,
					Length = 0.44m,
					Weight = 5.69m
				},
				new PrecastReinforce()
				{
					Id = 116,
					PrecastId = 12,
					Position = "22",
					Count = 292,
					ReinforceTypeId = 16,
					Length = 0.2m,
					Weight = 23.07m
				},
				new PrecastReinforce()
				{
					Id = 117,
					PrecastId = 12,
					Position = "23",
					Count = 7,
					ReinforceTypeId = 19,
					Length = 3.13m,
					Weight = 26.51m
				},
				new PrecastReinforce()
				{
					Id = 118,
					PrecastId = 12,
					Position = "24",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 3m,
					Weight = 12m
				},
				new PrecastReinforce()
				{
					Id = 119,
					PrecastId = 12,
					Position = "25",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 4.03m,
					Weight = 16.12m
				},
				new PrecastReinforce()
				{
					Id = 120,
					PrecastId = 12,
					Position = "26",
					Count = 8,
					ReinforceTypeId = 16,
					Length = 7.36m,
					Weight = 23.26m
				},
				new PrecastReinforce()
				{
					Id = 121,
					PrecastId = 12,
					Position = "27",
					Count = 2,
					ReinforceTypeId = 16,
					Length = 9m,
					Weight = 7.11m
				},
				new PrecastReinforce()
				{
					Id = 122,
					PrecastId = 12,
					Position = "28",
					Count = 2,
					ReinforceTypeId = 16,
					Length = 11m,
					Weight = 8.69m
				},
				new PrecastReinforce()
				{
					Id = 123,
					PrecastId = 13,
					Position = "1",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 8.9m,
					Weight = 35.6m
				},
				new PrecastReinforce()
				{
					Id = 124,
					PrecastId = 13,
					Position = "2",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 8.9m,
					Weight = 11.04m
				},
				new PrecastReinforce()
				{
					Id = 125,
					PrecastId = 13,
					Position = "3",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 10.15m,
					Weight = 12.59m
				},
				new PrecastReinforce()
				{
					Id = 126,
					PrecastId = 13,
					Position = "4",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 2.31m,
					Weight = 5.59m
				},
				new PrecastReinforce()
				{
					Id = 127,
					PrecastId = 13,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 5.11m,
					Weight = 12.37m
				},	
				new PrecastReinforce()
				{
					Id = 128,
					PrecastId = 13,
					Position = "6",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 1.61m,
					Weight = 2m
				},
				new PrecastReinforce()
				{
					Id = 129,
					PrecastId = 13,
					Position = "7,8",
					Count = 14,
					ReinforceTypeId = 16,
					Length = 1.77m,
					Weight = 9.79m
				},
				new PrecastReinforce()
				{
					Id = 130,
					PrecastId = 13,
					Position = "8,10",
					Count = 74,
					ReinforceTypeId = 16,
					Length = 2.37m,
					Weight = 69.28m
				},
				new PrecastReinforce()
				{
					Id = 131,
					PrecastId = 13,
					Position = "9",
					Count = 90,
					ReinforceTypeId = 16,
					Length = 0.35m,
					Weight = 12.59m
				},
				new PrecastReinforce()
				{
					Id = 132,
					PrecastId = 13,
					Position = "11",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 4.41m,
					Weight = 10.67m
				},
				new PrecastReinforce()
				{
					Id = 133,
					PrecastId = 13,
					Position = "12",
					Count = 5,
					ReinforceTypeId = 16,
					Length = 1.56m,
					Weight = 3.08m
				},
				new PrecastReinforce()
				{
					Id = 134,
					PrecastId = 13,
					Position = "13",
					Count = 2,
					ReinforceTypeId = 16,
					Length = 1.33m,
					Weight = 1.58m
				},
				new PrecastReinforce()
				{
					Id = 135,
					PrecastId = 13,
					Position = "14",
					Count = 2,
					ReinforceTypeId = 18,
					Length = 1.9m,
					Weight = 3.38m
				},
				new PrecastReinforce()
				{
					Id = 136,
					PrecastId = 14,
					Position = "1",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 8.95m,
					Weight = 35.8m
				},
				new PrecastReinforce()
				{
					Id = 137,
					PrecastId = 14,
					Position = "2",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 8.95m,
					Weight = 11.1m
				},
				new PrecastReinforce()
				{
					Id = 138,
					PrecastId = 14,
					Position = "3",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 10.15m,
					Weight = 12.59m
				},
				new PrecastReinforce()
				{
					Id = 139,
					PrecastId = 14,
					Position = "4",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 2.31m,
					Weight = 5.59m
				},
				new PrecastReinforce()
				{
					Id = 140,
					PrecastId = 14,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 5.11m,
					Weight = 12.37m
				},
				new PrecastReinforce()
				{
					Id = 141,
					PrecastId = 14,
					Position = "6",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 1.61m,
					Weight = 2m
				},
				new PrecastReinforce()
				{
					Id = 142,
					PrecastId = 14,
					Position = "7,8",
					Count = 14,
					ReinforceTypeId = 16,
					Length = 1.77m,
					Weight = 9.79m
				},	
				new PrecastReinforce()
				{
					Id = 143,
					PrecastId = 14,
					Position = "8,10",
					Count = 75,
					ReinforceTypeId = 16,
					Length = 2.37m,
					Weight = 70.21m
				},
				new PrecastReinforce()
				{
					Id = 144,
					PrecastId = 14,
					Position = "9",
					Count = 90,
					ReinforceTypeId = 16,
					Length = 0.35m,
					Weight = 12.44m
				},
				new PrecastReinforce()
				{
					Id = 145,
					PrecastId = 14,
					Position = "11",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 4.41m,
					Weight = 10.67m
				},
				new PrecastReinforce()
				{
					Id = 146,
					PrecastId = 14,
					Position = "12",
					Count = 5,
					ReinforceTypeId = 16,
					Length = 1.56m,
					Weight = 3.08m
				},
				new PrecastReinforce()
				{
					Id = 147,
					PrecastId = 14,
					Position = "13",
					Count = 4,
					ReinforceTypeId = 20,
					Length = 10.15m,
					Weight = 64.15m
				},
				new PrecastReinforce()
				{
					Id = 148,
					PrecastId = 14,
					Position = "14",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 2.18m,
					Weight = 5.28m
				},
				new PrecastReinforce()
				{
					Id = 149,
					PrecastId = 14,
					Position = "15",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 1.9m,
					Weight = 3.38m
				},
				new PrecastReinforce()
				{
					Id = 150,
					PrecastId = 15,
					Position = "1",
					Count = 6,
					ReinforceTypeId = 18,
					Length = 6.62m,
					Weight = 35.35m
				},
				new PrecastReinforce()
				{
					Id = 151,
					PrecastId = 15,
					Position = "2",
					Count = 5,
					ReinforceTypeId = 21,
					Length = 6.62m,
					Weight = 66.20m
				},
				new PrecastReinforce()
				{
					Id = 152,
					PrecastId = 15,
					Position = "3",
					Count = 12,
					ReinforceTypeId = 18,
					Length = 5.72m,
					Weight = 61.09m
				},
				new PrecastReinforce()
				{
					Id = 153,
					PrecastId = 15,
					Position = "4",
					Count = 10,
					ReinforceTypeId = 21,
					Length = 4.64m,
					Weight = 92.8m
				},
				new PrecastReinforce()
				{
					Id = 154,
					PrecastId = 15,
					Position = "5",
					Count = 32,
					ReinforceTypeId = 18,
					Length = 4.36m,
					Weight = 124.17m
				},
				new PrecastReinforce()
				{
					Id = 155,
					PrecastId = 15,
					Position = "6",
					Count = 3,
					ReinforceTypeId = 26,
					Length = 1.35m,
					Weight = 25.6m
				},
				new PrecastReinforce()
				{
					Id = 156,
					PrecastId = 16,
					Position = "1",
					Count = 6,
					ReinforceTypeId = 18,
					Length = 5.42m,
					Weight = 28.94m
				},
				new PrecastReinforce()
				{
					Id = 157,
					PrecastId = 16,
					Position = "2",
					Count = 5,
					ReinforceTypeId = 19,
					Length = 5.42m,
					Weight = 32.79m
				},
				new PrecastReinforce()
				{
					Id = 158,
					PrecastId = 16,
					Position = "3",
					Count = 12,
					ReinforceTypeId = 18,
					Length = 4.64m,
					Weight = 49.56m
				},
				new PrecastReinforce()
				{
					Id = 159,
					PrecastId = 16,
					Position = "4",
					Count = 10,
					ReinforceTypeId = 19,
					Length = 4.64m,
					Weight = 56.14m
				},
				new PrecastReinforce()
				{
					Id = 160,
					PrecastId = 16,
					Position = "5",
					Count = 24,
					ReinforceTypeId = 18,
					Length = 4.36m,
					Weight = 93.13m
				},
				new PrecastReinforce()
				{
					Id = 161,
					PrecastId = 16,
					Position = "6",
					Count = 3,
					ReinforceTypeId = 26,
					Length = 1.35m,
					Weight = 25.6m
				},
				new PrecastReinforce()
				{
					Id = 162,
					PrecastId = 17,
					Position = "1",
					Count = 56,
					ReinforceTypeId = 16,
					Length = 1.75m,
					Weight = 38.71m
				},
				new PrecastReinforce()
				{
					Id = 163,
					PrecastId = 17,
					Position = "2,4",
					Count = 12,
					ReinforceTypeId = 23,
					Length = 9.2m,
					Weight = 330.1m
				},
				new PrecastReinforce()
				{
					Id = 164,
					PrecastId = 17,
					Position = "3",
					Count = 11,
					ReinforceTypeId = 21,
					Length = 9.2m,
					Weight = 202.4m
				},
				new PrecastReinforce()
				{
					Id = 165,
					PrecastId = 17,
					Position = "5",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 1.44m,
					Weight = 3.48m
				},
				new PrecastReinforce()
				{
					Id = 166,
					PrecastId = 17,
					Position = "6",
					Count = 4,
					ReinforceTypeId = 21,
					Length = 2.71m,
					Weight = 21.68m
				},
				new PrecastReinforce()
				{
					Id = 167,
					PrecastId = 17,
					Position = "7",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 2.98m,
					Weight = 11.92m
				},
				new PrecastReinforce()
				{
					Id = 168,
					PrecastId = 17,
					Position = "8",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 1.93m,
					Weight = 7.72m
				},
				new PrecastReinforce()
				{
					Id = 169,
					PrecastId = 17,
					Position = "9",
					Count = 77,
					ReinforceTypeId = 18,
					Length = 1.67m,
					Weight = 114.45m
				},
				new PrecastReinforce()
				{
					Id = 170,
					PrecastId = 17,
					Position = "10,12",
					Count = 77,
					ReinforceTypeId = 18,
					Length = 4.24m,
					Weight = 290.57m
				},
				new PrecastReinforce()
				{
					Id = 171,
					PrecastId = 17,
					Position = "11",
					Count = 77,
					ReinforceTypeId = 17,
					Length = 2.46m,
					Weight = 117.44m
				},
				new PrecastReinforce()
				{
					Id = 172,
					PrecastId = 17,
					Position = "13",
					Count = 6,
					ReinforceTypeId = 21,
					Length = 2.86m,
					Weight = 34.32m
				},
				new PrecastReinforce()
				{
					Id = 173,
					PrecastId = 17,
					Position = "14",
					Count = 24,
					ReinforceTypeId = 17,
					Length = 2.12m,
					Weight = 31.55m
				},
				new PrecastReinforce()
				{
					Id = 174,
					PrecastId = 17,
					Position = "15",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 1.82m,
					Weight = 2.26m
				},
				new PrecastReinforce()
				{
					Id = 175,
					PrecastId = 17,
					Position = "16",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 2.69m,
					Weight = 6.51m
				},
				new PrecastReinforce()
				{
					Id = 176,
					PrecastId = 17,
					Position = "17",
					Count = 39,
					ReinforceTypeId = 17,
					Length = 0.65m,
					Weight = 15.72m
				},
				new PrecastReinforce()
				{
					Id = 177,
					PrecastId = 17,
					Position = "18",
					Count = 8,
					ReinforceTypeId = 24,
					Length = 0.5m,
					Weight = 15.44m
				},
				new PrecastReinforce()
				{
					Id = 178,
					PrecastId = 18,
					Position = "1",
					Count = 64,
					ReinforceTypeId = 16,
					Length = 3.45m,
					Weight = 38.76m
				},
				new PrecastReinforce()
				{
					Id = 179,
					PrecastId = 18,
					Position = "2",
					Count = 8,
					ReinforceTypeId = 24,
					Length = 9.2m,
					Weight = 284.1m
				},
				new PrecastReinforce()
				{
					Id = 180,
					PrecastId = 18,
					Position = "3",
					Count = 12,
					ReinforceTypeId = 21,
					Length = 9.2m,
					Weight = 220.8m
				},
				new PrecastReinforce()
				{
					Id = 181,
					PrecastId = 18,
					Position = "4",
					Count = 4,
					ReinforceTypeId = 23,
					Length = 9.20m,
					Weight = 110.03m
				},
				new PrecastReinforce()
				{
					Id = 182,
					PrecastId = 18,
					Position = "5",
					Count = 4,
					ReinforceTypeId = 19,
					Length = 1.44m,
					Weight = 6.97m
				},
				new PrecastReinforce()
				{
					Id = 183,
					PrecastId = 18,
					Position = "6",
					Count = 4,
					ReinforceTypeId = 21,
					Length = 2.71m,
					Weight = 21.68m
				},
				new PrecastReinforce()
				{
					Id = 184,
					PrecastId = 18,
					Position = "7",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 2.23m,
					Weight = 8.92m
				},
				new PrecastReinforce()
				{
					Id = 185,
					PrecastId = 18,
					Position = "8",
					Count = 2,
					ReinforceTypeId = 21,
					Length = 1.93m,
					Weight = 7.72m
				},
				new PrecastReinforce()
				{
					Id = 186,
					PrecastId = 18,
					Position = "9",
					Count = 77,
					ReinforceTypeId = 18,
					Length = 1.67m,
					Weight = 114.45m
				},
				new PrecastReinforce()
				{
					Id = 187,
					PrecastId = 18,
					Position = "10,12",
					Count = 77,
					ReinforceTypeId = 18,
					Length = 4.02m,
					Weight = 275.49m
				},
				new PrecastReinforce()
				{
					Id = 188,
					PrecastId = 18,
					Position = "11",
					Count = 77,
					ReinforceTypeId = 17,
					Length = 2.66m,
					Weight = 126.99m
				},
				new PrecastReinforce()
				{
					Id = 189,
					PrecastId = 18,
					Position = "13",
					Count = 12,
					ReinforceTypeId = 21,
					Length = 1.9m,
					Weight = 45.6m
				},
				new PrecastReinforce()
				{
					Id = 190,
					PrecastId = 18,
					Position = "13a",
					Count = 6,
					ReinforceTypeId = 17,
					Length = 3.23m,
					Weight = 38.76m
				},
				new PrecastReinforce()
				{
					Id = 191,
					PrecastId = 18,
					Position = "14",
					Count = 24,
					ReinforceTypeId = 17,
					Length = 2.12m,
					Weight = 31.55m
				},
				new PrecastReinforce()
				{
					Id = 192,
					PrecastId = 18,
					Position = "15",
					Count = 39,
					ReinforceTypeId = 17,
					Length = 0.65m,
					Weight = 15.72m

				},
				new PrecastReinforce()
				{
					Id = 193,
					PrecastId = 18,
					Position = "16",
					Count = 8,
					ReinforceTypeId = 24,
					Length = 0.5m,
					Weight = 15.44m
				},
				new PrecastReinforce()
				{
					Id = 194,
					PrecastId = 19,
					Position = "1",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 10.10m,
					Weight = 24.44m
				},
				new PrecastReinforce()
				{
					Id = 195,
					PrecastId = 19,
					Position = "2",
					Count = 4,
					ReinforceTypeId = 19,
					Length = 10.90m,
					Weight = 52.76m
				},
				new PrecastReinforce()
				{
					Id = 196,
					PrecastId = 19,
					Position = "3",
					Count = 3,
					ReinforceTypeId = 21,
					Length = 10.10m,
					Weight = 60.6m
				},
				new PrecastReinforce()
				{
					Id = 197,
					PrecastId = 19,
					Position = "4",
					Count = 3,
					ReinforceTypeId = 21,
					Length = 10.90m,
					Weight = 65.4m
				},
				new PrecastReinforce()
				{
					Id = 198,
					PrecastId = 19,
					Position = "5",
					Count = 8,
					ReinforceTypeId = 20,
					Length = 2.42m,
					Weight = 30.59m
				},
				new PrecastReinforce()
				{
					Id = 199,
					PrecastId = 19,
					Position = "6",
					Count = 2,
					ReinforceTypeId = 23,
					Length = 3.12m,
					Weight = 18.66m
				},
				new PrecastReinforce()
				{
					Id = 200,
					PrecastId = 19,
					Position = "7",
					Count = 4,
					ReinforceTypeId = 24,
					Length = 0.17m,
					Weight = 2.62m
				},
				new PrecastReinforce()
				{
					Id = 201,
					PrecastId = 19,
					Position = "8",
					Count = 146,
					ReinforceTypeId = 16,
					Length = 0.4m,
					Weight = 23.07m
				},
				new PrecastReinforce()
				{
					Id = 202,
					PrecastId = 19,
					Position = "9",
					Count = 95,
					ReinforceTypeId = 16,
					Length = 2m,
					Weight = 75.05m
				},
				new PrecastReinforce()
				{
					Id = 203,
					PrecastId = 19,
					Position = "10",
					Count = 18,
					ReinforceTypeId = 16,
					Length = 1.34m,
					Weight = 9.53m
				},
				new PrecastReinforce()
				{
					Id = 204,
					PrecastId = 19,
					Position = "11",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 3.46m,
					Weight = 6.16m
				},
				new PrecastReinforce()
				{
					Id = 205,
					PrecastId = 20,
					Position = "1",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 10,
					Weight = 24.2m
				},
				new PrecastReinforce()
				{
					Id = 206,
					PrecastId = 20,
					Position = "2",
					Count = 4,
					ReinforceTypeId = 19,
					Length = 10.9m,
					Weight = 52.76m
				},
				new PrecastReinforce()
				{
					Id = 207,
					PrecastId = 20,
					Position = "3",
					Count = 3,
					ReinforceTypeId = 21,
					Length = 10m,
					Weight = 60m
				},
				new PrecastReinforce()
				{
					Id = 208,
					PrecastId = 20,
					Position = "4",
					Count = 3,
					ReinforceTypeId = 21,
					Length = 10.9m,
					Weight = 65.4m
				},
				new PrecastReinforce()
				{
					Id = 209,
					PrecastId = 20,
					Position = "5",
					Count = 8,
					ReinforceTypeId = 20,
					Length = 2.42m,
					Weight = 30.59m
				},
				new PrecastReinforce()
				{
					Id = 210,
					PrecastId = 20,
					Position = "6",
					Count = 2,
					ReinforceTypeId = 23,
					Length = 3.12m,
					Weight = 18.66m
				},
				new PrecastReinforce()
				{
					Id = 211,
					PrecastId = 20,
					Position = "7",
					Count = 4,
					ReinforceTypeId = 24,
					Length = 0.17m,
					Weight = 2.62m
				},
				new PrecastReinforce()
				{
					Id = 212,
					PrecastId = 20,
					Position = "8",
					Count = 146,
					ReinforceTypeId = 16,
					Length = 0.4m,
					Weight = 23.07m
				},
				new PrecastReinforce()
				{
					Id = 213,
					PrecastId = 20,
					Position = "9",
					Count = 94,
					ReinforceTypeId = 16,
					Length = 2m,
					Weight = 74.26m
				},
				new PrecastReinforce()
				{
					Id = 214,
					PrecastId = 20,
					Position = "10",
					Count = 20,
					ReinforceTypeId = 16,
					Length = 1.34m,
					Weight = 10.59m
				},
				new PrecastReinforce()
				{
					Id = 215,
					PrecastId = 20,
					Position = "11",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 3.46m,
					Weight = 6.16m
				},
				new PrecastReinforce()
				{
					Id = 216,
					PrecastId = 21,
					Position = "1",
					Count = 2,
					ReinforceTypeId = 19,
					Length = 9.65m,
					Weight = 23.35m
				},
				new PrecastReinforce()
				{
					Id = 217,
					PrecastId = 21,
					Position = "2",
					Count = 4,
					ReinforceTypeId = 19,
					Length = 10.55m,
					Weight = 51.06m
				},
				new PrecastReinforce()
				{
					Id = 218,
					PrecastId = 21,
					Position = "3",
					Count = 3,
					ReinforceTypeId = 21,
					Length = 9.65m,
					Weight = 57.9m
				},
				new PrecastReinforce()
				{
					Id = 219,
					PrecastId = 21,
					Position = "4",
					Count = 3,
					ReinforceTypeId = 21,
					Length = 10.95m,
					Weight = 65.7m
				},
				new PrecastReinforce()
				{
					Id = 220,
					PrecastId = 21,
					Position = "5",
					Count = 8,
					ReinforceTypeId = 20,
					Length = 2.42m,
					Weight = 30.59m
				},
				new PrecastReinforce()
				{
					Id = 221,
					PrecastId = 21,
					Position = "6",
					Count = 2,
					ReinforceTypeId = 23,
					Length = 3.12m,
					Weight = 18.66m
				},
				new PrecastReinforce()
				{
					Id = 222,
					PrecastId = 21,
					Position = "7",
					Count = 4,
					ReinforceTypeId = 24,
					Length = 0.17m,
					Weight = 2.62m
				},
				new PrecastReinforce()
				{
					Id = 223,
					PrecastId = 21,
					Position = "8",
					Count = 146,
					ReinforceTypeId = 16,
					Length = 0.4m,
					Weight = 23.07m
				},
				new PrecastReinforce()
				{
					Id = 224,
					PrecastId = 21,
					Position = "9",
					Count = 89,
					ReinforceTypeId = 16,
					Length = 2m,
					Weight = 70.31m
				},
				new PrecastReinforce()
				{
					Id = 225,
					PrecastId = 21,
					Position = "10",
					Count = 20,
					ReinforceTypeId = 16,
					Length = 1.34m,
					Weight = 10.59m
				},
				new PrecastReinforce()
				{
					Id = 226,
					PrecastId = 21,
					Position = "11",
					Count = 2,
					ReinforceTypeId = 17,
					Length = 3.46m,
					Weight = 6.16m
				}
			};
		}
	}
}
