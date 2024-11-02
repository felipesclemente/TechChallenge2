# ContatosAPI

Tech Challenge 1 - Pós Tech FIAP - Arquitetura de Sistemas .NET

Autor: Felipe Bolivar São Clemente

Versão 1.0

## Apresentação

A ContatosAPI é uma solução desenvolvida através da plataforma .Net 8.0, voltada para a criação e administração de uma base de dados de contatos telefônicos regionais, com endpoints para operações de pesquisa, inserção, atualização e remoção de registros (CRUD) em um banco de dados SQL Server.

Utilizando o Entity Framework Core, a solução automaticamente associa cada contato criado à região geográfica e UF do DDD do telefone, sendo possível filtrar todos os contatos pertencentes a determinada região ou DDD.

Ainda, a solução contém um projeto de testes unitários, desenvolvidos com xUnit, que validam as regras internas definidas para a criação de novas entidades.

A ContatosAPI foi desenvolvida integralmente em C#, e tem como dependência os pacotes NuGet referidos em cada projeto.

## Setup do Ambiente

Primeiramente, efetue o clone do repositório e abra a solução no Visual Studio 2022. Em seguida, abra o arquivo `appsettings.json` localizado no projeto ContatosAPI, e altere a `ConnectionString` contida no topo do arquivo para conectar no seu banco de dados SQL Server, fornecendo as credenciais de acesso que forem necessárias.

Após, para criar as tabelas `Contato` e `Regioes` no banco de dados, abra o Console de Gerenciador de Pacotes do Visual Studio, e execute o seguinte comando:

```
Update-Database -Project Infrastructure -StartupProject Infrastructure -Connection "Sua-Connection-String"
```

Havendo êxito na migração dos dados, a API pode ser inicializada no Visual Studio.

## Funcionalidades

Com a API rodando, é possível visualizar e testar todos os endpoints da API por meio da interface do Swagger. 
No corpo do projeto, está documentada a finalidade de cada rota, bem como os parâmetros necessários para realizar requisições em cada uma. A interface do Swagger exibe estas informações, que devem ser consultadas para a utilização correta da solução.
