using Microsoft.EntityFrameworkCore;
using ProvaVolvo.Domain.Caminhoes;
using ProvaVolvo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Domain.Caminhoes;

namespace ProvaVolvo.Infrastructure
{
    public class CaminhaoRepository : ICaminhaoRepository
    {

        private readonly ApplicationContext context;
        public CaminhaoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Atualizar(Caminhao caminhao)
        {
            this.context.Caminhoes.Update(caminhao);
        }

        public void Cadastrar(Caminhao caminhao)
        {
            this.context.Caminhoes.Add(caminhao);
        }

        public Caminhao ListarPorId(long id)
        {
            return this.context.Caminhoes.AsNoTracking().Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Caminhao> ListarTodos()
        {
            return context.Caminhoes.AsNoTracking().ToList();
        }
    }
}

