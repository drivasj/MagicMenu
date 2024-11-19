using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMenu.Models.Entity.Client
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Alias { get; set; }
        public int NumberClient { get; set; }

        public int TypeDocumentId { get; set; }
        public Typedocument typedocument { get; set; }

        [StringLength(50)]
        public string document {  get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [StringLength(100)]
        public string RegisterUser { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(100)]
        public string LastUpdateUser { get; set; }
        public bool Active { get; set; }

    }
}
