using CeramicaCSharp.Models;

namespace CeramicaCSharp.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();

        Client GetClient(int clientId);
        Client GetClient(string clientName);

        bool ClientExists(int clientId);
        bool CreateClient(Client client);
        bool Save();

    }
}
