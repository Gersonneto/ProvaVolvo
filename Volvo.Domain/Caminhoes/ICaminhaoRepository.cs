using System.Collections.Generic;
using Volvo.Domain.Caminhoes;

namespace ProvaVolvo.Domain.Caminhoes
{
    public interface ICaminhaoRepository
    {
        IEnumerable<Caminhao> ListarTodos();
        Caminhao ListarPorId(long id);
        void Cadastrar(Caminhao caminhao);
        void Atualizar(Caminhao caminhao);
        void Deletar(Caminhao caminhao);
    }
}
