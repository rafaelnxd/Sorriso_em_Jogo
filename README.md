Sorriso em Jogo
===============

Definição do Projeto
--------------------

### Objetivo do Projeto

O **Sorriso em Jogo** é uma aplicação desenvolvida para promover hábitos saudáveis de higiene bucal entre os usuários, incentivando-os através de um sistema de recompensas e feedbacks. O objetivo principal é auxiliar na criação e manutenção de bons hábitos de saúde bucal, proporcionando uma plataforma interativa onde os usuários podem registrar suas práticas, acompanhar seu progresso e serem recompensados por suas conquistas.

### Escopo

O projeto consiste no desenvolvimento de uma aplicação web seguindo os princípios da **Clean Architecture**, que oferece as seguintes funcionalidades principais:

-   **Cadastro e Autenticação de Usuários**: Permitir que novos usuários se registrem e façam login na plataforma.
-   **Registro de Hábitos**: Usuários podem registrar seus hábitos diários de higiene bucal, incluindo data, imagem e observações.
-   **Sistema de Recompensas**: Implementação de um sistema de pontos que permite aos usuários acumularem pontos e resgatarem recompensas.
-   **Feedbacks dos Usuários**: Os usuários podem enviar feedbacks sobre a aplicação, contribuindo para melhorias contínuas.
-   **Gestão de Procedimentos e Unidades**: Administração dos procedimentos disponíveis e unidades de atendimento.
-   **Integração com Serviços de Infraestrutura**: Persistência de dados utilizando Entity Framework Core e Oracle Database.
-   **Interface Web MVC**: Implementação de controllers e views para interação com os usuários.
-   **Configuração de Segurança**: Configuração de SSL para conexões seguras.

Requisitos Funcionais e Não Funcionais
--------------------------------------

### Requisitos Funcionais

-   **Cadastro de Usuários**: O sistema deve permitir o cadastro de novos usuários com nome, email e senha.
-   **Autenticação**: Os usuários devem ser capazes de fazer login utilizando suas credenciais.
-   **Registro de Hábitos**: Usuários podem registrar seus hábitos diários, incluindo data, imagem (opcional) e observações.
-   **Acúmulo de Pontos**: Os usuários acumulam pontos ao registrar hábitos, que podem ser trocados por recompensas.
-   **Resgate de Recompensas**: O sistema deve permitir que usuários resgatem recompensas utilizando seus pontos acumulados.
-   **Envio de Feedbacks**: Usuários podem enviar feedbacks para a plataforma.
-   **Gestão de Procedimentos e Unidades**: Administradores podem gerenciar procedimentos e unidades de atendimento.
-   **Interação via Interface Web**: Implementação de controllers e views para permitir interação dos usuários com as funcionalidades da aplicação.

### Requisitos Não Funcionais

-   **Arquitetura Limpa (Clean Architecture)**: A aplicação deve ser desenvolvida seguindo os princípios da Clean Architecture, separando responsabilidades e mantendo o código desacoplado.
-   **Persistência de Dados**: Utilização do Entity Framework Core com banco de dados Oracle para armazenamento de dados.
-   **Segurança**: Implementação de validações, tratamento de exceções e configuração de SSL para garantir a integridade e segurança dos dados.
-   **Escalabilidade**: A arquitetura deve permitir a fácil adição de novas funcionalidades e suportar um número crescente de usuários.
-   **Usabilidade**: A aplicação deve possuir uma interface amigável e seguir padrões RESTful, facilitando o uso e integração com outras aplicações.
-   **Manutenibilidade**: Código organizado e seguindo boas práticas para facilitar a manutenção e evolução do sistema.

Desenho da Arquitetura
----------------------

### Clean Architecture

A aplicação foi desenvolvida seguindo os princípios da **Clean Architecture**, visando separar as responsabilidades e manter o código organizado e de fácil manutenção. Isso permite que cada camada da aplicação tenha um papel bem definido e independente das outras, facilitando testes, manutenção e escalabilidade.

#### Camadas da Aplicação

plaintext

Copiar código

`Sorriso_em_Jogo/
├── Application/
│   ├── Services/
│   │   ├── FeedbackService.cs
│   │   ├── HabitoService.cs
│   │   ├── ...
│   └── ViewModels/
│       ├── FeedbackViewModel.cs
│       ├── HabitoViewModel.cs
│       ├── ...
├── Domain/
│   └── Entities/
│       └── Models/
│           ├── Feedback.cs
│           ├── Habito.cs
│           ├── Procedimento.cs
│           ├── ...
├── Infrastructure/
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   └── Repositories/
│       ├── IFeedbackRepository.cs
│       ├── IHabitoRepository.cs
│       ├── FeedbackRepository.cs
│       ├── HabitoRepository.cs
│       ├── ...
├── Presentation/
│   ├── Controllers/
│   │   ├── HomeController.cs
│   │   ├── FeedbacksController.cs
│   │   ├── HabitosController.cs
│   │   ├── ...
│   ├── Views/
│   │   ├── Home/
│   │   │   └── Index.cshtml
│   │   ├── Feedbacks/
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │   ├── Delete.cshtml
│   │   │   └── Details.cshtml
│   │   ├── Habitos/
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │   ├── Delete.cshtml
│   │   │   └── Details.cshtml
│   │   └── Shared/
│   │       ├── _Layout.cshtml
│   │       └── _ValidationScriptsPartial.cshtml
│   └── Properties/
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── images/
│   └── ...
├── Program.cs
├── Sorriso_em_Jogo.csproj
├── appsettings.Development.json
├── appsettings.json
├── README.md`

1.  **Domínio**

    -   **Descrição**: Contém os modelos (entidades) e regras de negócio essenciais da aplicação.
    -   **Responsabilidades**:
        -   Definição das entidades de negócio e seus atributos.
        -   Implementação das regras de negócio e validações intrínsecas às entidades.
    -   **Componentes**:
        -   Classes como `Usuario`, `Habito`, `Recompensa`, `Feedback`, etc.
2.  **Aplicação**

    -   **Descrição**: Contém os serviços e casos de uso da aplicação que orquestram as operações entre as entidades e a infraestrutura.
    -   **Responsabilidades**:
        -   Implementação da lógica de aplicação e regras de negócio que envolvem múltiplas entidades.
        -   Coordenação entre repositórios e entidades de domínio.
        -   Validações e tratamento de exceções.
    -   **Componentes**:
        -   Serviços como `UsuarioService`, `HabitoService`, `RecompensaService`, etc.
        -   ViewModels para transferência de dados entre a aplicação e a apresentação.
3.  **Infraestrutura**

    -   **Descrição**: Responsável pelo acesso a dados, implementações de repositórios e integração com serviços externos.
    -   **Responsabilidades**:
        -   Implementação dos repositórios que interagem com o banco de dados.
        -   Configuração do contexto de banco de dados (Entity Framework Core).
        -   Integração com serviços externos ou APIs de terceiros.
    -   **Componentes**:
        -   `ApplicationDbContext` para conexão com o banco de dados Oracle.
        -   Repositórios como `FeedbackRepository`, `HabitoRepository`, etc.
        -   Migrations do Entity Framework.
4.  **Apresentação**

    -   **Descrição**: Contém os controladores (Controllers) e as views que expõem os endpoints da aplicação para interação com os usuários.
    -   **Responsabilidades**:
        -   Exposição de interfaces MVC para interação dos usuários com as funcionalidades da aplicação.
        -   Tratamento das requisições HTTP e validação dos dados de entrada.
        -   Retorno de respostas adequadas aos usuários.
    -   **Componentes**:
        -   Controllers como `HomeController`, `FeedbacksController`, `HabitosController`, etc.
        -   Views organizadas por controlador em subpastas dentro de `Views`.
        -   Layout compartilhado `_Layout.cshtml` para consistência visual.

### Justificativa da Estrutura do Projeto

A separação em camadas seguindo os princípios da **Clean Architecture** permite:

-   **Manutenção Facilitada**: Alterações em uma camada têm impacto mínimo nas outras, facilitando a manutenção e evolução do sistema.
-   **Testabilidade**: Cada camada pode ser testada isoladamente, aumentando a confiabilidade do sistema.
-   **Flexibilidade**: A aplicação pode ser adaptada para diferentes interfaces (por exemplo, adicionando uma interface mobile) sem alterações significativas na lógica de negócio.
-   **Escalabilidade**: Facilita a adição de novas funcionalidades e o crescimento da aplicação de forma organizada.

Como Executar o Projeto
-----------------------

### Pré-Requisitos

Certifique-se de que você tem o seguinte instalado em sua máquina:

-   **.NET SDK** (versão 6.0 ou superior)
-   **Visual Studio 2022** (ou Visual Studio Code com as extensões necessárias)
-   **Banco de Dados Oracle** (caso utilize um banco Oracle)

### Passo a Passo

1.  **Clonar o Repositório**

    bash

    Copiar código

    `git clone https://github.com/seu-usuario/Sorriso_em_Jogo.git
    cd Sorriso_em_Jogo`

2.  **Restaurar Pacotes NuGet**

    No terminal, execute:

    bash

    Copiar código

    `dotnet restore`

3.  **Aplicar as Migrações do Entity Framework**

    Certifique-se de que o banco de dados Oracle está configurado e acessível com as credenciais fornecidas no `appsettings.json`.

    **Adicionar Migrações:**

    bash

    Copiar código

    `dotnet ef migrations add SegundaEntregaUpdates`

    **Atualizar o Banco de Dados:**

    bash

    Copiar código

    `dotnet ef database update`

4.  **Compilar a Aplicação**

    bash

    Copiar código

    `dotnet build`

5.  **Executar a Aplicação**

    bash

    Copiar código

    `dotnet run`

    A aplicação estará disponível nos seguintes endereços:

    -   **HTTPS**: <https://localhost:55839>
    -   **HTTP**: <http://localhost:55840>
6.  **Acessar a Aplicação**

    Abra o navegador e acesse um dos URLs acima para interagir com a aplicação.

### Notas Adicionais

-   **Configuração de SSL**: Se encontrar erros relacionados ao SSL (`ERR_SSL_PROTOCOL_ERROR`), você pode temporariamente desabilitar o redirecionamento HTTPS comentando a linha `app.UseHttpsRedirection();` no `Program.cs`. Contudo, para produção, é altamente recomendado manter a segurança com SSL configurado corretamente.

-   **Estrutura das Pastas de Views**: As views devem estar organizadas dentro da pasta `Views`, seguindo a nomenclatura dos controllers. Por exemplo, as views do `HomeController` ficam em `Views/Home/`, as do `FeedbacksController` em `Views/Feedbacks/`, e assim por diante.

-   **Verificar Rotas**: As rotas estão configuradas no `Program.cs` para apontar para o `HomeController` como padrão. Se desejar alterar o controller inicial, ajuste a configuração de rotas conforme necessário.

    csharp

    Copiar código

    `app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");`

Tecnologias Utilizadas
----------------------

-   **.NET 6**: Framework utilizado para o desenvolvimento da aplicação.
-   **ASP.NET Core MVC**: Padrão arquitetural para criação de aplicações web.
-   **Entity Framework Core**: ORM para acesso a dados.
-   **Oracle Database**: Banco de dados relacional utilizado para persistência de dados.
-   **Clean Architecture**: Princípios arquiteturais para separação de responsabilidades e manutenção do código.

Considerações Finais
--------------------

-   **Validações e Segurança**: As entidades possuem validações utilizando data annotations e regras de negócio para garantir a integridade dos dados.
-   **Documentação da API**: Utilização do Swagger para documentação e testes da API.
-   **Estrutura Modular**: Separação clara entre domínio, aplicação, infraestrutura e apresentação, facilitando a manutenção e evolução do sistema.
-   **Futuras Melhorias**: Implementação de autenticação robusta, melhorias na interface do usuário e integração com serviços externos para ampliar as funcionalidades da aplicação.
