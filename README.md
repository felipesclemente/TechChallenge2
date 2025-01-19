# ContatosAPI

Tech Challenge 2 - Pós Tech FIAP - Arquitetura de Sistemas .NET

Autor: Felipe Bolivar São Clemente

Versão 1.0

## Funcionalidades

Este projeto foi criado a partir de um branch do meu repositório TechChallenge1, que hospeda a solução ContatosAPI.

O foco do Tech Challenge 2 é o desenvolvimento de um pipeline CI/CD utilizando o GitHub Actions, que automatize as etapas de compilação do projeto e execução de testes, incluido testes unitários e de integração.

Eu optei por hospedar uma instância do SQL Server em um contâiner, que passará a ser utilizado como o banco de dados da ContatosAPI. O pipeline de CI desenvolvido com GitHub Actions irá rodar os testes unitários existentes, e também irá testar a conexão com o banco de dados hospedado no servidor remoto.

O servidor está instrumentado com agents do Zabbix e do Prometheus, que colhem continuamente dados de latência, tráfego de rede, e consumo de recursos como memória e CPU. Estas informações são organizadas e apresentadas em um dashboard Grafana, que facilita a visualização e correlação dos traces, e gera alertas automáticos ao desenvolvedor caso algum dos indicadores registre valores insatisfatórios. 

Unindo metodologias de CI/CD com ferramentas de monitoramento, é possível reduzir ao mínimo falhas e períodos de indisponibilidade da aplicação, gerando maior confiança e satisfação nos usuários finais.
