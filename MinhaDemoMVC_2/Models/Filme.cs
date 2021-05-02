using System;

namespace MinhaDemoMVC_2.Models
{
    public class Filme
    {
        // Propriedades
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Genero { get; set; }
        public decimal Valor { get; set; }
        public int Avaliacao { get; set; }
    }
}
