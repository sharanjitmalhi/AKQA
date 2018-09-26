using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NumericToWord.Entities
{
    public class InputModel
    {
        [Required(ErrorMessage = "Please enter Name")]
        [DisplayName("Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Number")]
        [Range(-999999999999999.99, 999999999999999.99, ErrorMessage = "Number range is between -999999999999999.99 to 999999999999999.99")]
        [DisplayName("Enter Number")]
        public decimal Number { get; set; }
    }
}
