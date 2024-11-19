using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.Entity.Warehouse
{
    public class NoteNaturalNumber
    {
        public int IdNoteNaturalNumber { get; set; }
        public int NumberSale { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
        public string RegisterUser { get; set; }
    }
}
