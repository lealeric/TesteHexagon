# Relatório do Projeto - Teste de Habilidade (DEV) - Hexagon

## **1. Introdução**
Este documento apresenta um resumo detalhado do projeto desenvolvido para o **Teste de Habilidade - Hexagon**. Ele abrange as tecnologias utilizadas, as funcionalidades implementadas e as decisões tomadas durante o desenvolvimento.

## **2. Tecnologias Utilizadas**
O projeto foi desenvolvido utilizando as seguintes tecnologias:

### **Back-End (API RESTful)**
- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Banco de Dados:** SQL Server
- **ORM:** Entity Framework Core
- **Autenticação (Opcional):** JWT

### **Front-End**
- **Framework:** Vue.js 3
- **Biblioteca UI:** Vuetify 3
- **Requisições HTTP:** Axios

### **Ferramentas e Ambiente**
- **IDE:** Visual Studio 2022
- **Gerenciador de Pacotes:** npm e NuGet
- **Banco de Dados:** SQL Server Management Studio (SSMS)
- **Controle de Versão:** Git/GitHub

---

## **3. Funcionalidades Implementadas**
A aplicação permite a gestão de registros de pessoas, oferecendo as seguintes funcionalidades:

### **3.1. Back-End (API RESTful em ASP.NET Core)**
- **CRUD Completo** para a entidade **Pessoas**:
  - **Criar** novo registro (POST `/api/pessoas`)
  - **Listar** registros com paginação (GET `/api/pessoas`)
  - **Atualizar** um registro existente (PUT `/api/pessoas/{id}`)
  - **Excluir** um registro (DELETE `/api/pessoas/{id}`)
- **Conexão Segura com Banco de Dados** utilizando Entity Framework Core.
- **Validação de Dados** no Model, garantindo CPF único.
- **Autenticação JWT** (Opcional).

### **3.2. Front-End (Vue.js + Vuetify 3)**
- **Exibição de Tabela Dinâmica** com paginação usando `v-data-table`.
- **Formulário para Adicionar e Editar Registros**.
- **Botões de Ação (Editar e Excluir)** em cada linha da tabela.
- **Consumo da API REST** via Axios.

---

## **4. Estrutura do Projeto**

### **Back-End (ASP.NET Core)**
```
/TesteHexagon.API
│── Controllers
│   ├── PessoasController.cs
│── Models
│   ├── Pessoa.cs
|   ├── MeuBancoContext.cs
│── Program.cs
```

### **Front-End (Vue.js + Vuetify 3)**
```
/TesteHexagon.Front
│── src
│   ├── components
│   │   ├── TabelaPessoas.vue
│   ├── App.vue
│   ├── main.js
```

---

## **5. Decisões de Desenvolvimento**
1. **Banco de Dados:** Optamos pelo SQL Server devido à sua robustez e integração com ASP.NET.
2. **Framework Front-End:** O Vue.js foi escolhido por sua leveza e facilidade de integração com Vuetify.
3. **Entity Framework Core:** Utilizado para facilitar a comunicação com o banco de dados.
4. **Vuetify 3:** Permite criar uma interface moderna e responsiva rapidamente.

---

## **6. Como Executar o Projeto**

### **Back-End (ASP.NET Core)**
1. Navegue até a pasta do projeto:
   ```sh
   cd TesteHexagon.API
   ```
2. Instale as dependências:
   ```sh
   dotnet restore
   ```
3. Rode as migrações para criar a base de dados:
   ```sh
   dotnet ef database update
   ```
4. Inicie o servidor:
   ```sh
   dotnet run
   ```

### **Front-End (Vue.js + Vuetify 3)**
1. Navegue até a pasta do front-end:
   ```sh
   cd TesteHexagon.Front
   ```
2. Instale as dependências:
   ```sh
   npm install
   ```
3. Inicie o servidor Vue:
   ```sh
   npm run serve
   ```

A aplicação estará acessível em **http://localhost:8080** e a API em **http://localhost:5000**.

---

**Observação:** As funcionalidades implementadas **não foram devidamente testadas** devido à indisponibilidade do banco de dados fornecido para a execução dos testes.
