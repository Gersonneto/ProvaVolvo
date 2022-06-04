using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaVolvo.Application.DTO
{
    public class CaminhaoDTO
    {
        public int Id { get; set; } 
        public string Modelo { get; set; }
        public string AnoFabricacao { get; set; }
        public string AnoModelo { get; set; }
    }
}
