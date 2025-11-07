using Microsoft.Extensions.Configuration;
using ProjetoCoelApi.Application.Services;
using ProjetoCoelAPI.Infrastructure.Data;

namespace ProjetoCoelAPI.Infrastructure.Service
{
    public class ProjetoCoelService : IProjetoCoelService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
    }
}
