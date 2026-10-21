# Blog

Sistema de blog e gestão de conteúdo em .NET, estruturado para persistência relacional, modelagem de domínio e operações de administração de usuários, categorias, tags e posts.

## Visão geral

Este projeto implementa a base de dados e a camada de acesso a dados de um blog pessoal, com foco em organização, integridade relacional e manutenção simples do modelo de domínio. A arquitetura segue um padrão de repositório genérico e separa claramente a lógica de persistência da interação com o usuário no console.

Em termos de engenharia, a proposta central é manter uma base sólida para o conteúdo do blog: usuários, papéis, categorias, tags, posts e relacionamento entre entidades. Esse desenho facilita evoluções futuras para interfaces mais ricas, dashboards, publicação e experiências interativas mais avançadas no front-end.

## Stack Tecnológica

A stack abaixo foi identificada diretamente a partir do arquivo do projeto e dos imports do código:

| Tecnologia | Papel no projeto | Observação |
| --- | --- | --- |
| C# / .NET 10 | Linguagem principal e runtime da aplicação | O projeto é um executável console em .NET, com foco em backend e manipulação de dados. |
| Microsoft.Data.SqlClient | Driver oficial de acesso ao SQL Server | Usado para abrir e gerenciar a conexão com o banco, permitindo consultas e operações de CRUD. |
| Dapper | Mapeamento objeto-relacional leve e performático | Central para consultas e materialização de modelos em objetos C#, mantendo baixa sobrecarga em comparação a ORMs mais pesados. |
| Dapper.Contrib | Extensões para CRUD genérico em modelos | Facilita operações como Insert, Update, Delete e Get em classes de domínio, reduzindo boilerplate e preservando clareza. |
| SQL Server | Banco de dados relacional principal | A estrutura de tabelas e chaves estrangeiras indica modelagem de conteúdo robusta e escalável. |
| System.Security.Cryptography.Pkcs | Suporte a operações criptográficas e certificados | Presente na dependência do projeto e útil para fluxos de segurança, autenticação e proteção de dados sensíveis. |

### Decisões de arquitetura

- Camada de repositório genérica: a classe `Repository<T>` centraliza operações recorrentes de persistência, reduzindo duplicação de código e padronizando acesso ao banco.
- Mapeamento de entidades com atributos: as classes de modelo usam `Table` e `Key` para espelhar a estrutura do banco sem exigir configuração extensa.
- Relacionamentos explícitos: `User`, `Role`, `Category`, `Tag`, `Post` e tabelas de associação demonstram uma base sólida para publicar conteúdo com filtros e agrupamentos.
- Conexão única de dados: `Database.Connection` mantém o acesso ao SQL Server organizado e simples em um executável de console.

Essa abordagem é especialmente adequada para projetos de conteúdo e CMS, onde consistência de dados e performance de leitura importam mais do que um layer UI pesado. Ela também funciona como base estável para futuras experiências interativas no browser, inclusive com animações baseadas em scroll, renderização 3D, vídeos como textura e interações em tempo real.

## Funcionalidades

- Gestão de usuários com relacionamento de papéis
- Cadastro e manutenção de categorias e tags
- Modelagem de posts com metadados e relacionamento com autor/categoria
- Operações de CRUD por meio de repositório genérico
- Relacionamento de conteúdo via tabelas de associação (`UserRole`, `PostTag`)
- Estrutura preparada para expansão em painéis administrativos e interfaces interativas

## Fluxo técnico

O projeto começa em `Program.cs`, onde a conexão com o banco é criada a partir da variável de ambiente `DB_CONNECTION_STRING`. Em seguida, o sistema entra em um menu de console para navegação entre módulos de gestão, com foco em domínio e manutenção de conteúdo.

A estrutura de dados e operações é simples, direta e eficiente, o que favorece manutenção, testes e avanços futuros em interface e experiência do usuário.

## Instalação e execução

Pré-requisitos:

- .NET 10 SDK
- SQL Server acessível localmente ou em ambiente configurado
- Variável de ambiente `DB_CONNECTION_STRING` com a string de conexão do banco

Passos:

```bash
# restaurar dependências
dotnet restore

# compilar a aplicação
dotnet build

# executar
dotnet run
```

Se a variável `DB_CONNECTION_STRING` não estiver configurada, a aplicação não será capaz de abrir a conexão com o banco.

## Observações

Este projeto demonstra um perfil técnico mais voltado para engenharia de backend e arquitetura de conteúdo. Em cenários de frontend criativo, a camada de dados aqui exposta funciona como base confiável para experiências interativas mais sofisticadas, respeitando desempenho, estrutura e previsibilidade do sistema.