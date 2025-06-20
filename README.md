# ApiControleDeEstoque

## Descrição

A **ApiControleDeEstoque** é uma API RESTful desenvolvida em .NET para gerenciar o controle de estoque de produtos de forma eficiente e segura. Ela permite operações CRUD (Criar, Ler, Atualizar e Deletar) para categorias e produtos, além de implementar autenticação JWT para garantir que somente usuários autorizados possam acessar os recursos da API.

Este projeto é ideal para quem deseja aprender boas práticas de desenvolvimento com ASP.NET Core, Entity Framework, autenticação via JWT e arquitetura em camadas.

---

## Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT (JSON Web Token) para autenticação
- Swagger/OpenAPI para documentação da API

---

## Funcionalidades

- **Gerenciamento de Categorias**: criação, leitura, atualização e exclusão de categorias de produtos.
- **Gerenciamento de Produtos**: CRUD completo para produtos, com associação a categorias.
- **Autenticação JWT**: segurança com tokens para controle de acesso.
- **Documentação interativa**: via Swagger para testar endpoints diretamente pelo navegador.

---

## Configuração do Projeto

### Banco de Dados

A API utiliza SQL Server como banco de dados. Configure a string de conexão no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=ControleEstoqueDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

> **Importante:** Não exponha informações sensíveis (como usuário, senha e chave JWT) no repositório público. Utilize o arquivo `appsettings.json.example` para referência.

### Autenticação JWT

Configure as seguintes propriedades no `appsettings.json`:

```json
"Jwt": {
  "Key": "SUA_CHAVE_SECRETA_AQUI",
  "Issuer": "ControleDeEstoqueApi",
  "Audience": "ControleDeEstoqueApi"
}
```

---

## Como Rodar o Projeto

1. Clone este repositório:

```bash
git clone git@github.com:MenndesX/ApiControleDeEstoque.git
```

2. Acesse a pasta do projeto:

```bash
cd ApiControleDeEstoque
```

3. Configure o arquivo `appsettings.json` com sua string de conexão e chave JWT.

4. Execute as migrações para criar o banco de dados:

```bash
dotnet ef database update
```

5. Execute a aplicação:

```bash
dotnet run
```

6. Abra o Swagger para testar os endpoints:

```
http://localhost:5000/swagger
```

---

## Endpoints Principais

- `POST /api/auth/login` — Autenticação e geração do token JWT.
- `GET /api/categorias` — Lista todas as categorias.
- `POST /api/categorias` — Cria uma nova categoria.
- `PUT /api/categorias/{id}` — Atualiza uma categoria existente.
- `DELETE /api/categorias/{id}` — Deleta uma categoria.
- `GET /api/produtos` — Lista todos os produtos.
- `POST /api/produtos` — Cria um novo produto.
- `PUT /api/produtos/{id}` — Atualiza um produto.
- `DELETE /api/produtos/{id}` — Deleta um produto.

---

## Estrutura do Projeto

- **Controllers** — Controladores da API que expõem os endpoints.
- **Models** — Classes de domínio e entidades do banco.
- **DTOs** — Objetos de transferência de dados para entrada e saída.
- **Repositories** — Classes responsáveis pelo acesso a dados.
- **Services** — Lógica de negócio da aplicação.
- **Configurations** — Configurações de JWT, Swagger e DB.

---

## Contribuição

Contribuições são bem-vindas! Para contribuir, faça um fork do projeto, crie uma branch com sua feature, faça commit e envie um pull request.

---

## Contato

Para dúvidas ou sugestões, entre em contato:  
**Anderson Mendes** — [linkedin.com/in/menndesx](https://www.linkedin.com/in/anderson-mendes-34880724a)  
Email: seuemail@example.com

---

Obrigado por visitar o projeto! 🚀
