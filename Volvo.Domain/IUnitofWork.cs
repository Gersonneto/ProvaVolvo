using ProvaVolvo.Domain.Caminhoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaVolvo.Domain
{

    public interface IUnitofWork
    {
        ICaminhaoRepository CaminhaoRepository { get; }
        void Commit();
    }

}
