using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_crud_mvc.ValidationAttributes;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Pizza
    {
        public int Id { get; set; }


        [MaxLength(100)]
        [Required(ErrorMessage = "Il campo del nome è obbligatorio")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Il campo della descrizione è obbligatorio")]
        //validazione customizzata
        [moreThanFiveWord]
        public string Description { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Il campo del path immagine è obbligatorio")]
        [StringLength(500, ErrorMessage = "Il path dell'immagine non può superare i 500 caratteri")]
        // validazione customizzata
        [ValidFormatImage]
        public string PathImage { get; set; }

        [Required(ErrorMessage = "Il campo del prezzo è obbligatorio")]
        [Range(2, 100, ErrorMessage ="Il prezzo deve essere compreso tra 2 e 100")]
        public float Price { get; set; }


        // relazione 1 a N con category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // relazione N a N con ingredient
        // aggiungo il ? per includere la possibilità in cui ad una pizza non è associato nessun ingrediente
        public List<Ingredient>? Ingredients { get; set; }

        public Pizza()
        {
        }

        public Pizza(string name, string description, string pathImage, float price)
        {
            this.Name = name;
            this.Description = description;
            this.PathImage = pathImage;
            this.Price = price;
        }
    }
}
