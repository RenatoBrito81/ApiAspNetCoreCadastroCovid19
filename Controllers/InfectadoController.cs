using System;
using ApiAspNetCoreCadastroCovid19.Data.Collections;
using ApiAspNetCoreCadastroCovid19.Models;
using Microsoft.AspNetCore.Mvc;
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
            //Instância referêncnai ao mongo
            _mongoDB = mongoDB;

            //Instância referência ao banco de dados da api
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            //Define os dados do infectado enviados no body 
            var infectado = new Infectado(String.Empty, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            //Inseri o infectado no banco de dados
            _infectadosCollection.InsertOne(infectado);
            
            //Retorna o status 201 e a mensagem de sucesso
            return StatusCode(201, "Infectado adicionado com sucesso.");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            //Consulta no banco de dados todos os infectados
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            //Retorna o status 200 e todos os infectados
            return Ok(infectados);
        }

        [HttpGet("{id}")]
        public ActionResult ObterInfectadoById(String id){
            //Consulta no banco de dados pelo infectado através do Id
            var infectado = _infectadosCollection.Find(Builders<Infectado>.Filter.Where(inf => inf.Id == id)).FirstOrDefault();

            //Retorna o status 200 e o infectado selecionado pelo Id
            return Ok(infectado);
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarInfectadoById(String id, [FromBody] InfectadoDto dto){
            //Define os dados do infectado enviados no body 
            var infectado = new Infectado(id, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            //Define o filtro pelo Id do infectado
            var filtro = Builders<Infectado>.Filter.Where(inf => inf.Id == id);

            //Efetua um replace nos dados do infectado no banco de dado
            _infectadosCollection.ReplaceOne(filtro, infectado);

            //Retorna o status 200 e a mensagem de sucesso
            return Ok("Infectado atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarInfectadoById(String id){
            //Define o filtro pelo Id do infectado
            var filtro = Builders<Infectado>.Filter.Where(inf => inf.Id == id);

            //Deleta o infectado do banco de dados
            _infectadosCollection.DeleteOne(filtro);

            //Retorna o status 200 e a mensagem de sucesso
            return Ok("Infectado deletado com sucesso.");
        }
    }
}