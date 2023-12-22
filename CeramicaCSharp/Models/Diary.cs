namespace CeramicaCSharp.Models
{
    public class Diary
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public DateTime DataC { get; set; }
        public DateTime DataF { get; set; }
        public Client Client { get; set; }
        public ICollection<DiaryProduct> DiaryProducts { get; set; }
    }
}
