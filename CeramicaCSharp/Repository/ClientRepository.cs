using CeramicaCSharp.Data;
using CeramicaCSharp.Interfaces;
using CeramicaCSharp.Models;

namespace CeramicaCSharp.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateClient(Client client)
        {
            _context.Add(client);
            return Save();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.OrderBy(p => p.Id).ToList();
        }

        public Client GetClient(int clientId)
        {
            return _context.Clients.Where(p => p.Id == clientId).FirstOrDefault();
        }

        public Client GetClient(string clientName)
        {
            return _context.Clients.Where(p => p.Name == clientName).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool ClientExists(int clientId)
        {
            return _context.Clients.Any(p => p.Id == clientId);
        }

        public bool ClientExistsCpf(string clientCpf)
        {
            return _context.Clients.Any(p => p.Cpf == clientCpf);
        }

        public bool ClientExistsPhone(string clientPhone)
        {
            return _context.Clients.Any(p => p.Phone == clientPhone);
        }
    }
}
