using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.DAL
{
    public partial class ApplicationContext
    {

        private void ApplyAllSeedings(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedAdmin(builder);
            SeedDataLabels(builder);
            SeedDataPieces(builder);
            SeedSubstrates(builder);
            SeedPlants(builder);
        }

        private void SeedAdmin(ModelBuilder builder)
        {
            User user = new User
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin",
                Email = "admin@gmail.com",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            var password = passwordHasher.HashPassword(user, "admin123");
            user.PasswordHash = password;
            builder.Entity<User>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
        }

        private void SeedRoles(ModelBuilder builder) 
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
            );
        }

        private void SeedDataLabels(ModelBuilder builder)
        {
            builder.Entity<DataLabel>().HasData(
                new DataLabel() { Id = 1, Label = "PlantRequired" },
                new DataLabel() { Id = 2, Label = "SubstrateRequired" },
                new DataLabel() { Id = 3, Label = "OptimizingModelRequired"},
                new DataLabel() { Id = 4, Label = "DeviceActionRequired"},
                new DataLabel() { Id = 5, Label = "Optional"}
            );
        }

        private void SeedDataPieces(ModelBuilder builder)
        {
            var dataPieces = new List<DataPiece>()
            {
                new DataPiece() { Id = 1, Name = "Acidity", MeasureUnit = "pH" },
                new DataPiece() { Id = 2, Name = "Electrical Capacity", MeasureUnit = "mS cm" },
                new DataPiece() { Id = 3, Name = "Moisure Content", MeasureUnit = "%" }
            };

            var labelConnections = new List<DataLabelDataPiece>(); 

            foreach (var item in dataPieces)
            {
                labelConnections.Add(new DataLabelDataPiece { DataLabelId = 1, DataPieceId = item.Id });
                labelConnections.Add(new DataLabelDataPiece { DataLabelId = 2, DataPieceId = item.Id });
                labelConnections.Add(new DataLabelDataPiece { DataLabelId = 3, DataPieceId = item.Id });
                labelConnections.Add(new DataLabelDataPiece { DataLabelId = 4, DataPieceId = item.Id });
            }

            builder.Entity<DataPiece>().HasData(dataPieces);
            builder.Entity<DataLabelDataPiece>().HasData(labelConnections);
        }

        private void SeedSubstrates(ModelBuilder builder)
        {
            var substrates = new List<Substrate>()
            {
                new Substrate() { Id = 1, Name = "GT1", Price = 4, Volume = 2, Description = "GT1  (30%  sand  +20% organic  soil +  50% coco  coir)"},
                new Substrate() { Id = 2, Name = "GT2", Price = 14, Volume = 5, Description = "GT2  (75%  coco  coir  +  25% rice husk)"},
                new Substrate() { Id = 3, Name = "GT3", Price = 13.99, Volume = 3.5, Description = "GT3  (75% coco coir + CaO 2.2 mg/kg + acid humic 0.41%)"},
                new Substrate() { Id = 4, Name = "GT4", Price = 18, Volume = 6, Description = "GT4  (75% white sphagnum peat  +25% vermiculite (size  4–6  mm))"},
            };

            var dataPieces = new List<SubstrateDataPiece>()
            {
                new SubstrateDataPiece { SubstrateId = 1, DataPieceId = 1, Value = 6.2 },
                new SubstrateDataPiece { SubstrateId = 1, DataPieceId = 2, Value = 1.4 },
                new SubstrateDataPiece { SubstrateId = 1, DataPieceId = 3, Value = 48 },
                new SubstrateDataPiece { SubstrateId = 2, DataPieceId = 1, Value = 6.0 },
                new SubstrateDataPiece { SubstrateId = 2, DataPieceId = 2, Value = 0.4 },
                new SubstrateDataPiece { SubstrateId = 2, DataPieceId = 3, Value = 38 },
                new SubstrateDataPiece { SubstrateId = 3, DataPieceId = 1, Value = 6.5 },
                new SubstrateDataPiece { SubstrateId = 3, DataPieceId = 2, Value = 0.8 },
                new SubstrateDataPiece { SubstrateId = 3, DataPieceId = 3, Value = 55 },
                new SubstrateDataPiece { SubstrateId = 4, DataPieceId = 1, Value = 6.2 },
                new SubstrateDataPiece { SubstrateId = 4, DataPieceId = 2, Value = 0.6 },
                new SubstrateDataPiece { SubstrateId = 4, DataPieceId = 3, Value = 41 },
            };

            builder.Entity<Substrate>().HasData(substrates);
            builder.Entity<SubstrateDataPiece>().HasData(dataPieces);
        }

        private void SeedPlants(ModelBuilder builder)
        {
            var plants = new List<Plant>()
            {
                new Plant() { Id = 1, Name = "Beens", Description = "Regular beens"},
                new Plant() { Id = 2, Name = "Cucumber", Description = "Regular cucumber"},
            };

            var dataPieces = new List<PlantDataPiece>()
            {
                new PlantDataPiece { PlantId = 1, DataPieceId = 1, Value = 6.0 },
                new PlantDataPiece { PlantId = 1, DataPieceId = 2, Value = 0.9 },
                new PlantDataPiece { PlantId = 1, DataPieceId = 3, Value = 35 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 1, Value = 6.3 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 2, Value = 0.7 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 3, Value = 48 },
            };

            builder.Entity<Plant>().HasData(plants);
            builder.Entity<PlantDataPiece>().HasData(dataPieces);
        }
    }
}
