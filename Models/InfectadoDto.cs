using System;

namespace ApiAspNetCoreCadastroCovid19.Models
{
    //Classe com a estrutura dos dados a serem recebidos no body
    public class InfectadoDto
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}