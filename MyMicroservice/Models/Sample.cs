using System.ComponentModel.DataAnnotations.Schema;

namespace MyMicroservice.Models
{
    [Table("tblSamples")]
    public class Sample
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public DateTime Datetime { get; set; }
    }
}
