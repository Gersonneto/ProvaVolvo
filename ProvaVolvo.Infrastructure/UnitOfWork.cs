using ProvaVolvo.Domain;
using ProvaVolvo.Domain.Caminhoes;
using ProvaVolvo.Infrastructure.Context;

namespace ProvaVolvo.Infrastructure
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly ApplicationContext context;

        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
            this.CaminhaoRepository = new CaminhaoRepository(context);
        }

        public ICaminhaoRepository CaminhaoRepository { get; }

        public void Commit()
        {
            this.context.SaveChanges();
        }

    }
}
