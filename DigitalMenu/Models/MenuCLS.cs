namespace DigitalMenu.Models
{
    public class MenuCLS
    {
        public string controller { get; set; }
        public string action { get; set; }
        public string area { get; set; }
        public string display { get; set; }
        public string nameMenu { get; set; }
        public bool movil { get; set; }
        public string icon { get; set; }
        public List<SubMenu> elements { get; set; }
    }

    public class SubMenu
    {
        public string controller { get; set; }
        public string action { get; set; }
        public string area { get; set; }
        public string display { get; set; }
        public bool movil { get; set; }
    }
}
