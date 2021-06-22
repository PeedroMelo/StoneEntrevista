# Stone | Participação de lucros

## Descrição
Uma empresa fechou o ano de operação com lucro e deseja reparti-lo entre seus funcionários, com o objetivo
de ser justa criou uma regra para a distribuição deste montante por: área, tempo de empresa, e faixa salarial
(os funcionários que ganham menos teriam sua participação incrementada). Para isso foi solicitado ao time de
tecnologia que desenvolva uma API REST que receba um valor máximo para distribuir e distribua o montante
para os funcionários já cadastrados com os dados abaixo. Tal distribuição segue determinadas regras descritas
a seguir.


## Introdução
No desenvolvimento do projeto, busquei mesclar alguns conceitos sobre API REST e os novos conhecimentos adquiridos a respeito das especificidades técnicas sobre C# e .NET Core.

Durante todo o processo, utilizei o **Visual Studio Code** + **.NET CLI** (com WSL2) para a execução de comandos, instalação de pacotes, criação dos arquivos *.csproj*, etc.

## Como executar
É possível executar o projeto utilizando a **.NET CLI**, a partir do comando:

    dotnet run --project StoneEntrevista.API/StoneEntrevista.API.csproj

A partir disso, o endpoint base já é sugerido no console, sendo: *http://localhost:5000*

Melhores detalhes a respeito da API podem ser encontrados acessando o endereço *http://localhost:5000/swagger/index.html*, onde fica a documentação feita utilizando o *Swagger*.

Caso a execução acima falhe, é possível executar utilizando o Docker Compose:

    docker-compose up --build

## Observação
Como sugestão, no endpoint *[GET] api/participacao*, utilizar no parâmetro "total_disponibilizado" o valor de R$ 30.000,00 para obter o resultado válido logo de cara.

## Arquitetura
Com o intuito de prover melhor coesão, mais organização e menos acoplamento possível, a arquitetura foi construída em base nos conceitos da Clean Architecture, onde é possível encontrar as camadas:

- **API**: Responsável por conter os Controllers e servir de ponto de acesso às funcionalidades do projeto.
- **Application**: Onde o *Core* do projeto se encontra. Aqui é possível encontrar todas as Entidades, Interfaces e Serviços que nossa aplicação utiliza. É pensada também para prover o compartilhamento de funcionalidades entre as diferentes camadas do projeto.
- **Infra**: É a camada de acesso ao banco de dados. Foi pensada para conter a complexidade de operações e conexão, bem como ser flexível para eventuais trocas de bancos ou múltiplas conexões.
- **Test.{Camada}**: Aqui, em uma camada específica para testes, cada diretório é repsonsável pelos testes unitários de suas devídas camadas. Em um processo mais avançado de CI/CD, é possível manter a camada de testes de integração dentro deste ambiente.

## Tecnologias
- .NET Core 5.0
- Swagger
- Docker
- MongoDB
- XUnit

<HR>

### Autor: Pedro Melo
### E-mail: vieirapcm@gmail.com
### Github: https://github.com/vieirapcm
