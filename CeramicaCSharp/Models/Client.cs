namespace CeramicaCSharp.Models
{
    public class Client
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Cpf { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Classification { get; set; }
        public ICollection<Diary> Diaries { get; set; }

    }
}
