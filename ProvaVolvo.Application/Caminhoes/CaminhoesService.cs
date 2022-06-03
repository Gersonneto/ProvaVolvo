using ProvaVolvo.Application.DTO;
using ProvaVolvo.Domain;
using ProvaVolvo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Domain.Caminhoes;

namespace ProvaVolvo.Application.Caminhoes
{
    public class CaminhoesService
    {
        private readonly IUnitofWork unitOfWork;
        public CaminhoesService(IUnitofWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Atualizar(CaminhaoDTO caminhao)
        {
            var _caminhao = this.unitOfWork.CaminhaoRepository.ListarPorId(caminhao.Id);

            if (_caminhao is null)
            {
                throw new Exception("Processo não encontrado.");
            }
            try
            {
                _caminhao.Modelo = caminhao.Modelo;
                _caminhao.AnoFabricacao = caminhao.AnoFabricacao;
                _caminhao.AnoModelo = caminhao.AnoModelo;



                this.unitOfWork.CaminhaoRepository.Atualizar(_caminhao);
                this.unitOfWork.Commit();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public void Cadastrar(CaminhaoDTO caminhao)
        {
            var _caminhao = new Caminhao();
            _caminhao.Modelo = caminhao.Modelo;
            _caminhao.AnoFabricacao = caminhao.AnoFabricacao;
            _caminhao.AnoModelo = caminhao.AnoModelo;

            this.unitOfWork.CaminhaoRepository.Cadastrar(_caminhao);
            this.unitOfWork.Commit();
        }

        public CaminhaoDTO ListarPorId(long id)
        {
            var _caminhao = this.unitOfWork.CaminhaoRepository.ListarPorId(id);

            if (_caminhao is null)
            {
                throw new Exception("Processo não encontrado.");
            }

            var dto = new CaminhaoDTO() { Id = _caminhao.Id, Modelo = _caminhao.Modelo, AnoModelo = _caminhao.AnoModelo, AnoFabricacao = _caminhao.AnoFabricacao };
            return dto;
        }

        public IEnumerable<CaminhaoDTO> ListarTodos()
        {
            var _caminhao = this.unitOfWork.CaminhaoRepository.ListarTodos();
            var resultado = _caminhao.Select(caminho => new CaminhaoDTO() { Id = caminho.Id, Modelo = caminho.Modelo, AnoModelo = caminho.AnoModelo, AnoFabricacao = caminho.AnoFabricacao });
            return resultado;
        }
    }
}
