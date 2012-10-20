using Orchard.Data.Migration;

namespace Duk.Lightbox.Orchard
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("SettingsRecord", table => table
                .Column<int>("Id", 
                    column => column.PrimaryKey().Identity())
                .Column<bool>("Enabled", 
                    enabled => enabled.WithDefault(true))
                .Column<string>("ContainerSelector", 
                    selector => selector.WithLength(1024))
                .Column<string>("LinkClasses",
                    linkClasses => linkClasses.WithLength(1024))
                .Column<string>("LinkRelAttributeValue",
                    relValue => relValue.WithLength(1024))
                .Column<bool>("ImageChildTagRequired",
                    imageChildTagRequired => imageChildTagRequired.WithDefault(false))
                .Column<bool>("LinkToImageRequired",
                    linkToImageRequired => linkToImageRequired.WithDefault(true))
                .Column<string>("ImageFileExtensions",
                    imageFileExtensions => imageFileExtensions.WithLength(1024))
                .Column<string>("CurrentTheme",
                    theme => theme.WithLength(1024))
                );
            return 1;
        }
    }
}