using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductDemo.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [DisplayName("Product")]
        public string ProductName { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }


        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime CreatedDate { get; set; }

        [DisplayName("Modified By")]
        public string? ModifiedBy { get; set; }

        [DisplayName("Modified Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedDate { get; set; }
    }
}
