using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Data.Migrations;
using System.Configuration;
using System.Data.Entity;

namespace FoodSupplementsSystem.App_Start
{
    public static class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FoodSupplementsSystemDbContext, Data.Migrations.Configuration>());
        }
    }
}