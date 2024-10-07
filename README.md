# Sorriso em Jogo

## Definição do Projeto

### Objetivo do Projeto

O **Sorriso em Jogo** é uma aplicação desenvolvida para promover hábitos saudáveis de higiene bucal entre os usuários, incentivando-os através de um sistema de recompensas e feedbacks. O objetivo principal é auxiliar na criação e manutenção de bons hábitos de saúde bucal, proporcionando uma plataforma interativa onde os usuários podem registrar suas práticas, acompanhar seu progresso e serem recompensados por suas conquistas.

### Escopo

O projeto consiste no desenvolvimento de uma API backend que oferece as seguintes funcionalidades principais:

- **Cadastro e Autenticação de Usuários**: Permitir que novos usuários se registrem e façam login na plataforma.
- **Registro de Hábitos**: Usuários podem registrar seus hábitos diários de higiene bucal, incluindo data, imagem e observações.
- **Sistema de Recompensas**: Implementação de um sistema de pontos que permite aos usuários acumularem pontos e resgatarem recompensas.
- **Feedbacks dos Usuários**: Os usuários podem enviar feedbacks sobre a aplicação, contribuindo para melhorias contínuas.
- **Gestão de Procedimentos e Unidades**: Administração dos procedimentos disponíveis e unidades de atendimento.
- **Integração com Serviços de Infraestrutura**: Persistência de dados utilizando Entity Framework Core e Oracle Database.

## Requisitos Funcionais e Não Funcionais

### Requisitos Funcionais

- **Cadastro de Usuários**: O sistema deve permitir o cadastro de novos usuários com nome, email e senha.
- **Autenticação**: Os usuários devem ser capazes de fazer login utilizando suas credenciais.
- **Registro de Hábitos**: Usuários podem registrar seus hábitos diários, incluindo data, imagem (opcional) e observações.
- **Acúmulo de Pontos**: Os usuários acumulam pontos ao registrar hábitos, que podem ser trocados por recompensas.
- **Resgate de Recompensas**: O sistema deve permitir que usuários resgatem recompensas utilizando seus pontos acumulados.
- **Envio de Feedbacks**: Usuários podem enviar feedbacks para a plataforma.
- **Gestão de Procedimentos e Unidades**: Administradores podem gerenciar procedimentos e unidades de atendimento.

### Requisitos Não Funcionais

- **Arquitetura Limpa (Clean Architecture)**: A aplicação deve ser desenvolvida seguindo os princípios da Clean Architecture, separando responsabilidades e mantendo o código desacoplado.
- **Persistência de Dados**: Utilização do Entity Framework Core com banco de dados Oracle para armazenamento de dados.
- **Segurança**: Implementação de validações e tratamento de exceções para garantir a integridade e segurança dos dados.
- **Escalabilidade**: A arquitetura deve permitir a fácil adição de novas funcionalidades e suportar um número crescente de usuários.
- **Usabilidade**: A API deve ser documentada e seguir padrões RESTful, facilitando o uso e integração com outras aplicações.

## Desenho da Arquitetura

### Clean Architecture

A aplicação foi desenvolvida seguindo os princípios da **Clean Architecture**, visando separar as responsabilidades e manter o código organizado e de fácil manutenção. Isso permite que cada camada da aplicação tenha um papel bem definido e independente das outras, facilitando testes, manutenção e escalabilidade.

#### Camadas da Aplicação

Sorriso_em_Jogo/
├── Domain/
│   └── Entities/
│       ├── Feedback.cs
│       ├── Habito.cs
│       ├── Procedimento.cs
│       ├── ...
├── Application/
│   ├── Services/
│   │   ├── FeedbackService.cs
│   │   ├── HabitoService.cs
│   │   ├── ...
│   └── DTOs/
│       ├── FeedbackDTO.cs
│       ├── HabitoDTO.cs
│       ├── ...
├── Infrastructure/
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   └── Repositories/
│       ├── Interfaces/
│       │   ├── IFeedbackRepository.cs
│       │   ├── IHabitoRepository.cs
│       │   ├── ...
│       └── Implementations/
│           ├── FeedbackRepository.cs
│           ├── HabitoRepository.cs
│           ├── ...
├── Presentation/
│   └── Controllers/
│       ├── FeedbackController.cs
│       ├── HabitoController.cs
│       ├── ...
├── Program.cs
├── appsettings.json
├── README.md


1. **Domínio**
   - **Descrição**: Contém os modelos (entidades) e regras de negócio essenciais da aplicação.
   - **Responsabilidades**:
     - Definição das entidades de negócio e seus atributos.
     - Implementação das regras de negócio e validações intrínsecas às entidades.
   - **Componentes**:
     - Classes como `Usuario`, `Habito`, `Recompensa`, `Feedback`, etc.

2. **Aplicação**
   - **Descrição**: Contém os serviços e casos de uso da aplicação que orquestram as operações entre as entidades e a infraestrutura.
   - **Responsabilidades**:
     - Implementação da lógica de aplicação e regras de negócio que envolvem múltiplas entidades.
     - Coordenação entre repositórios e entidades de domínio.
     - Validações e tratamento de exceções.
   - **Componentes**:
     - Serviços como `UsuarioService`, `HabitoService`, `RecompensaService`, etc.
     - DTOs para transferência de dados.

3. **Infraestrutura**
   - **Descrição**: Responsável pelo acesso a dados, implementações de repositórios e integração com serviços externos.
   - **Responsabilidades**:
     - Implementação dos repositórios que interagem com o banco de dados.
     - Configuração do contexto de banco de dados (Entity Framework Core).
     - Integração com serviços externos ou APIs de terceiros.
   - **Componentes**:
     - `ApplicationDbContext` para conexão com o banco de dados Oracle.
     - Repositórios como `UsuarioRepository`, `HabitoRepository`, etc.
     - Migrations do Entity Framework.

4. **Apresentação**
   - **Descrição**: Contém os controladores (Controllers) que expõem os endpoints da API para interação com os clientes.
   - **Responsabilidades**:
     - Exposição de APIs RESTful seguindo boas práticas.
     - Tratamento das requisições HTTP e validação dos dados de entrada.
     - Retorno de respostas adequadas aos clientes.
   - **Componentes**:
     - Controladores como `UsuarioController`, `HabitoController`, etc.
     - Configuração de rotas e middleware.

### Justificativa da Estrutura do Projeto

A separação em camadas seguindo os princípios da **Clean Architecture** permite:

- **Manutenção Facilitada**: Alterações em uma camada têm impacto mínimo nas outras, facilitando a manutenção e evolução do sistema.
- **Testabilidade**: Cada camada pode ser testada isoladamente, aumentando a confiabilidade do sistema.
- **Flexibilidade**: A aplicação pode ser adaptada para diferentes interfaces (por exemplo, adicionando uma interface web ou mobile) sem alterações significativas na lógica de negócio.
- **Escalabilidade**: Facilita a adição de novas funcionalidades e o crescimento da aplicação de forma organizada.

