namespace DigitalMenu.Models
{
    public class PagedList
    {
        public int page { get; set; }
        public int rowTotal { get; set; }
        public string area { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public string panelUpdate { get; set; }
        public string filter { get; set; }
        public double pageTotal { get { return ((float)rowTotal / 10); } }
        public int pageInicial { get; set; }
    }
}
