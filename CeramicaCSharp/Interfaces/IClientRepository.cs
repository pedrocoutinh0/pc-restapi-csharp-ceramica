using CeramicaCSharp.Models;

namespace CeramicaCSharp.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();

        Client GetClient(int clientId);
        Client GetClient(string clientName);

        bool ClientExists(int clientId);
        bool ClientExistsCpf(string clientCpf);
        bool ClientExistsPhone(string clientPhone);
        bool CreateClient(Client client);
        bool Save();

    }
}
