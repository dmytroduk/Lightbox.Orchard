using Orchard.Data.Migration;

namespace Duk.Lightbox.Orchard
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("SettingsRecord", table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("CurrentThemeName", column => column.WithLength(256))
                );
            return 1;
        }
    }
}