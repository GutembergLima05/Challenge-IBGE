using Projeto.Data;
using EFCore.BulkExtensions;
using Projeto.Models;

namespace Projeto.Service
{
    public class ImportacaoemLoteService
    {
        private readonly RelatorioDbContext _context;
        public ImportacaoemLoteService(RelatorioDbContext context)
        {
            _context = context;
        }

        public void InserirRegistrosEmMassa(List<Ibge> registros)
        {
            _context.BulkInsert(registros);
        }
    }
}