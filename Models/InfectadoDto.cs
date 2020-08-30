using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiAspNetCoreCadastroCovid19.Models
{
    public class InfectadoDto
    {
        /*[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public String Id { get; set; }*/
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}