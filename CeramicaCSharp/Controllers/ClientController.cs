using AutoMapper;
using CeramicaCSharp.Dto;
using CeramicaCSharp.Interfaces;
using CeramicaCSharp.Models;
using CeramicaCSharp.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CeramicaCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientController(IClientRepository clientRepository, IMapper mapper) 
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]

        public IActionResult GetClients()
        {
            var clients = _mapper.Map<List<ClientDto>>(_clientRepository.GetClients());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            

            return Ok(clients);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClient([FromBody] ClientDto clientCreate) 
        {
            string[] classifications = { "VIP", "NORMAL" };

            if (clientCreate == null)
                return BadRequest(ModelState);

            if (!Array.Exists(classifications, element => element == clientCreate.Classification))
            {
                ModelState.AddModelError("", "This Classification is invalid");
                return StatusCode(400, ModelState);
            }

            if (!CpfValidator.ValidateCPF(clientCreate.Cpf)) 
            {
                ModelState.AddModelError("", "This CPF is invalid");
                return StatusCode(400, ModelState);
            }

            if (!PhoneValidator.VerifyPhoneNumber(clientCreate.Phone))
            {
                ModelState.AddModelError("", "This Phone is invalid");
                return StatusCode(400, ModelState);
            }

            if (_clientRepository.ClientExistsCpf(clientCreate.Cpf))
            {
                ModelState.AddModelError("", "This CPF is already being used");
                return StatusCode(400, ModelState);
            }

            if (_clientRepository.ClientExistsPhone(clientCreate.Phone))
            {
                ModelState.AddModelError("", "This Phone is already being used");
                return StatusCode(400, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clientMap = _mapper.Map<Client>(clientCreate);

            if (!_clientRepository.CreateClient(clientMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpGet("{clientId}")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(400)]
        public IActionResult GetClient(int clientId)
        {
            if(!_clientRepository.ClientExists(clientId))
                return NotFound();

            var client = _mapper.Map<Client>(_clientRepository.GetClient(clientId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(client);
        }
    }
}
