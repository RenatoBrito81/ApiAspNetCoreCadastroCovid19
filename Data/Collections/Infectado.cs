using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace ApiAspNetCoreCadastroCovid19.Data.Collections
{
    public class Infectado
    {
        //Classe com a estrutura dos dados dos infectados
        public Infectado(String id, DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.Id = id;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        [BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public String Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}