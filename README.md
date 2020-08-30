<h1 align="center">API em ASP.Net Core para cadastro de infectados pelo Covid19 com geolocalização</h1>

### Descrição
- API para o cadastro de infectados pelo vírus Covid19 com o intuito de definir as áreas com maiores índices de casos.
  Está sendo registrado a data de nascimento, sexo e as coordenadas (longitute e latitude) do infectado.

- Foi gerado através do Mongo Charts um dashboard para a visualização dos dados dos infectados.

- Gráfico circular demonstrando os casos dos infectados por sexo:
<p align="center">
  <img src="GraficoCircularInfectados.jpg" title="Gráfico dos infectados dividido por sexo">
</p>

- Gráfico com a geolocalização dos infectados:
<p align="center">
  <img src="GraficoGeolocalizacaoInfectados.jpg" title="Gráfico com a localização dos infectados">
</p>


### Utilização
- Foram criados end-points para a  API com a possibilidade de listar todos os infectados, lista um infectado pelo Id, cadastrar um infectado, alterar os dados de um infectado e excluir os dados de um infectado.

- Métodos HTTP disponíveis: GET, POST, PUT e DELETE.

- Para cadastrar e/ou alterar os dados de um infectado deve-se utilizar a estrutura em Json abaixo:
  ```jason
  {
	"dataNascimento": "2007-07-07",
	"sexo": "M",
	"latitude": -23.567218,
	"longitude": -46.303472
  }
  ```


### Dependência
- Mongo Driver = dotnet add package Mongo.Driver

### Execução
- Executar o comando dotnet run na pasta da API ou utilizar o Visual Studio Code pressionado a tecla F5.


### Autor
Renato Brito