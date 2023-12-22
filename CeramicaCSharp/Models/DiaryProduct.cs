namespace CeramicaCSharp.Models
{
    public class DiaryProduct
    {
        public int DiaryId { get; set; }

        public int ProductId { get; set; }
        public Diary Diary { get; set; }
        public Product Product { get; set; }

    }
}
