// Create by Felix A. Bueno
namespace Angkor.O7Web.Common.Security.Entity
{
    public class Menu
    {
        public string Id { get; set; }
        public string FatherId { get; set; }
        public string Title { get; set; }
        public string Observacion { get; set; }
        public string Folder { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

        public Menu()
        {
            
        }

        public Menu(string id, string fatherId, string title, string observacion, string folder, string url, string icon)
        {
            Id = id;
            FatherId = fatherId;
            Title = title;
            Observacion = observacion;
            Folder = folder;
            Url = url;
            Icon = icon;
        }
    }
}