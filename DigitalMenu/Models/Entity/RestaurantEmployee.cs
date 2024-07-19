namespace DigitalMenu.Models.Entity
{
    public class RestaurantEmployee
    {
        public int IdRestaurant { get; set; }
        public int IdEmployee { get; set; }
        public Restaurant Restaurant { get; set; }
        public string RegisterUser { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime LastUpdateUser { get; set; }
        public bool Active { get; set; }
    }
}
