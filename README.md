# ContatosAPI

Tech Challenge 2 - Pós Tech FIAP - Arquitetura de Sistemas .NET

Autor: Felipe Bolivar São Clemente

Versão 1.0

## Funcionalidades

Este projeto foi criado a partir de um branch do meu repositório TechChallenge1, que hospeda a solução ContatosAPI.

O foco do Tech Challenge 2 é o desenvolvimento de um pipeline CI/CD utilizando o GitHub Actions, que automatize as etapas de compilação do projeto e execução de testes, incluido testes unitários e de integração.

Desta forma, foi desenvolvido um pipeline do GitHub Actions para compilar a ContatosAPI e reconstruir suas dependências, garantindo que não haja erros no build do projeto. Ainda, o pipeline executa os testes unitários já existentes na solução, bem como um teste de integração com o banco de dados, conectando uma instância do SQL Server rodando em contâiner. O teste executa a migration mais recente do Entity Framework Core no SQL Server containerizado, de modo que o ambiente de testes do pipeline será idêntico ao de produção.
