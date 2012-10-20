namespace Duk.Lightbox.Orchard.Records
{
    public class SettingsRecord
    {
        public virtual int Id { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual string ContainerSelector { get; set; }

        public virtual string LinkClasses { get; set; }
        
        public virtual string LinkRelAttributeValue { get; set; }

        public virtual bool ImageChildTagRequired { get; set; }

        public virtual bool LinkToImageRequired { get; set; }

        public virtual string ImageFileExtensions { get; set; }

        public virtual string CurrentTheme { get; set; }
    }
}