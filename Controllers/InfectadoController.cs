using System;
using ApiAspNetCoreCadastroCovid19.Data.Collections;
using ApiAspNetCoreCadastroCovid19.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiAspNetCoreCadastroCovid19.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(String.Empty, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso.");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

        [HttpGet("{id}")]
        public ActionResult ObterInfectadorById(String id){
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Where(inf => inf.Id == id)).FirstOrDefault();

            return Ok(infectados);
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarInfectadoById(String id, [FromBody] InfectadoDto dto){
            var infectado = new Infectado(id, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            var filtro = Builders<Infectado>.Filter.Where(inf => inf.Id == id);
            _infectadosCollection.ReplaceOne(filtro, infectado);

            return Ok("Infectado atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarInfectadoById(String id){
            var filtro = Builders<Infectado>.Filter.Where(inf => inf.Id == id);
            _infectadosCollection.DeleteOne(filtro);

            return Ok("Infectado deletado com sucesso.");
        }
    }
}