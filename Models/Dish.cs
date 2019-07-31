using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        //auto-implemented properties need to match the columns in your table
        //the [Key] attribue is used to mark the Model property being used for your table's Primary Key
       [Key]
       public int DishId {get; set;}

       //MySQL VARCHAR and TEXT types can be represented by a string
       [Required]
       [Display(Name = "Chef's Name")]
       public string ChefName {get; set;}

       [Required]
       [Display(Name = "Name of Dish")]
       public string DishName {get; set;}

       [Required]
       [Range(0, 10000)]
       [Display(Name = "# of Calories")]
       public int Calories {get; set;}

       [Required]
       public int Tastiness {get; set;}

       [Required]
       public string Description {get; set;}
       //The MySQL DATETIME type can be represented by a DateTime
       public DateTime CreatedAt {get; set;}
       public DateTime UpdatedAt {get; set;}
       
    }
}