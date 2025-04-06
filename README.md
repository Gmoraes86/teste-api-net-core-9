# Documentação do MainAPI

## Visão Geral

O projeto `MainAPI` é uma aplicação backend projetada para gerenciar distribuidores, seus endereços e contatos. Já a `DistributorAPI` é uma aplicação para que Distribuidores cadastradaos na Main possam receber pedidos de seus clientes, fazer a gestão dos produtos e clientes, assim como fazer pedidos maiores para a MAIN.

---

## Estrutura do Projeto

### Componentes Principais

| Componente         | Descrição                                                                   |
| ------------------ | --------------------------------------------------------------------------- |
| **Domain**         | Contém a lógica de negócios principal e as entidades.                       |
| **Infrastructure** | Gerencia o acesso a dados, migrações e integrações externas.                |
| **Application**    | Contém serviços de aplicação e DTOs para comunicação entre camadas.         |
| **API**            | Expõe endpoints RESTful para que clientes externos interajam com o sistema. |

---

## Como Executar a Aplicação

### Pré-requisitos

- SDK do .NET 9.0 instalado.
- Instância do SQL Server em execução.
- Visual Studio ou qualquer IDE de sua preferência.

### Passos para Executar

1. **Clonar o Repositório**

   ```bash
   git clone <repository-url>
   cd teste-api-net-core-9
   ```

2. **Configurar o Banco de Dados (esse processo deve ser realizado em ambos projetos)**

   - Atualize a string de conexão no arquivo `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=<servidor>;Database=<banco>;Trusted_Connection=True;"
     }
     ```
   - Aplique as migrações:
     ```bash
     dotnet ef database update
     ```

3. **Executar a Aplicação**

   ```bash
   dotnet run --project src/MainAPI
   ou
   dotnet run --project src/DistributorAPI
   ```

---

## Endpoints da API MAIN

### Gestão de distribuidores

| Método | Endpoint                 | Descrição                            |
| ------ | ------------------------ | ------------------------------------ |
| GET    | `/api/distributors`      | Obter todos os distribuidores.       |
| GET    | `/api/distributors/{id}` | Obter um distribuidor pelo ID.       |
| POST   | `/api/distributors`      | Criar um novo distribuidor.          |
| PUT    | `/api/distributors/{id}` | Atualizar um distribuidor existente. |
| DELETE | `/api/distributors/{id}` | Excluir um distribuidor.             |

---

# Endpoints da API de Distribuidores

### Endpoints de Produtos

| Método | Endpoint             | Descrição                       |
| ------ | -------------------- | ------------------------------- |
| GET    | `/api/products`      | Obter todos os produtos.        |
| GET    | `/api/products/{id}` | Obter um produto pelo ID.       |
| POST   | `/api/products`      | Criar um novo produto.          |
| PUT    | `/api/products/{id}` | Atualizar um produto existente. |
| DELETE | `/api/products/{id}` | Excluir um produto.             |

### Endpoints de Pedidos

| Método | Endpoint                  | Descrição                        |
| ------ | ------------------------- | -------------------------------- |
| GET    | `/api/orders`             | Obter todos os pedidos.          |
| GET    | `/api/orders/{id}`        | Obter um pedido pelo ID.         |
| POST   | `/api/orders`             | Criar um novo pedido.            |
| PUT    | `/api/orders/{id}/status` | Atualizar o status de um pedido. |

### Endpoints de Clientes

| Método | Endpoint              | Descrição                       |
| ------ | --------------------- | ------------------------------- |
| GET    | `/api/customers`      | Obter todos os clientes.        |
| GET    | `/api/customers/{id}` | Obter um cliente pelo ID.       |
| POST   | `/api/customers`      | Criar um novo cliente.          |
| PUT    | `/api/customers/{id}` | Atualizar um cliente existente. |
| DELETE | `/api/customers/{id}` | Excluir um cliente.             |

### Endpoints de Endereços

| Método | Endpoint              | Descrição                        |
| ------ | --------------------- | -------------------------------- |
| GET    | `/api/addresses`      | Obter todos os endereços.        |
| GET    | `/api/addresses/{id}` | Obter um endereço pelo ID.       |
| POST   | `/api/addresses`      | Criar um novo endereço.          |
| PUT    | `/api/addresses/{id}` | Atualizar um endereço existente. |
| DELETE | `/api/addresses/{id}` | Excluir um endereço.             |

### Endpoints de Contatos

| Método | Endpoint             | Descrição                       |
| ------ | -------------------- | ------------------------------- |
| GET    | `/api/contacts`      | Obter todos os contatos.        |
| GET    | `/api/contacts/{id}` | Obter um contato pelo ID.       |
| POST   | `/api/contacts`      | Criar um novo contato.          |
| PUT    | `/api/contacts/{id}` | Atualizar um contato existente. |
| DELETE | `/api/contacts/{id}` | Excluir um contato.             |

---

## Tecnologias Utilizadas

- **.NET 9.0**: Framework backend.
- **Entity Framework Core**: ORM para gerenciamento de banco de dados.
- **SQL Server**: Banco de dados.
- **Swashbuckle**: Para documentação da API (Swagger).
