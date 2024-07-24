# Projeto de Avaliação de Filmes

Este projeto foi desenvolvido como parte de um trabalho acadêmico, com o objetivo de criar uma aplicação para avaliação de filmes utilizando tecnologias modernas como WebAPI, Blazor WASM e C# Generics. O projeto também implementa injeção de dependência para gerenciamento eficiente dos serviços.

## Tecnologias Utilizadas

- **C# Generics**: Utilizados para implementar tipos e métodos genéricos, permitindo maior reutilização de código e segurança de tipo.
- **WebAPI**: Criada para fornecer uma API que será consumida pela aplicação cliente.
- **Blazor WebAssembly (Blazor WASM)**: Utilizado para desenvolver a aplicação cliente que consome a API.
- **Injeção de Dependência**: Utilizada para gerenciar a criação e o ciclo de vida dos serviços, utilizando métodos como `AddScoped`, `AddTransient` e `AddSingleton`.

## Estrutura do Projeto

### Backend (API)

O backend foi desenvolvido utilizando ASP.NET Core WebAPI. Ele fornece endpoints para as operações CRUD (Create, Read, Update, Delete) relacionadas às avaliações de filmes.

### Frontend (Cliente)

O frontend foi desenvolvido utilizando Blazor WebAssembly. Ele consome a API fornecida pelo backend para exibir, adicionar, editar e remover avaliações de filmes.

## Dependências

- .NET 5.0 ou superior
- Visual Studio 2019 ou superior
- Blazor WebAssembly
- Entity Framework Core (para ORM)
- Injeção de Dependência com `AddScoped`, `AddTransient` e `AddSingleton`

## Configuração e Execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
