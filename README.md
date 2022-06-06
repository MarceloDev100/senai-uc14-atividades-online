## SENAI-SP

### UC-14 - Atividades Online (2 e 3)

### Criação de uma aplicação Web API em .NET6 para armazenar projetos, utilizando o _VSCode_. Os dados são armazenados no banco SQL Server 2019. 

## Visão geral da documentação do projeto pelo Swagger.

![swagger_marcelo](https://user-images.githubusercontent.com/88597534/172068993-12073cca-1807-4511-bdcf-e99554fd670c.jpg)

## Visão detalhada da documentação no Swagger com funcionalidades, serviços disponibilizados, retornos e argumentos necessários para as operações, como requests e responses (código de status).

## 📃 Documentação detalhada 

### Login de usuário.

![RequisicaoLogin](https://user-images.githubusercontent.com/88597534/172061163-e2376b23-4940-4d39-86be-770a4f59c07c.png)

👉 Entrada de dados do usuário.

![EntradaDadosLogin](https://user-images.githubusercontent.com/88597534/172060972-d47eb8f3-7bd4-4ff6-b021-0f1682a0181d.png)

👉 Token JWT gerado com status code 200 (Autenticação com sucesso).

![TokenLogin](https://user-images.githubusercontent.com/88597534/172062008-ee21558b-48f2-4672-879f-2cc5d884f254.png)

👉 Uso do token JWT para autorização.

![TokenAutorizacao](https://user-images.githubusercontent.com/88597534/172061330-738f6910-df2f-4b56-804b-0d2a9a703806.png)

👉 Token com autorização concedida.

![TokenAutorizacaoConcedida](https://user-images.githubusercontent.com/88597534/172061435-1ba8606b-ae8e-465d-aa76-8044f3b2a667.png)

------------------

### 📋 Listar todos os projetos.

![RequisicaoListarProjetos](https://user-images.githubusercontent.com/88597534/172061576-fb165212-f783-421a-aebf-df23d8b81790.png)

👍 Resposta com status code 200.

![RetornoListaProjetos](https://user-images.githubusercontent.com/88597534/172061684-b057964e-93ac-4544-89cf-812a9d28b324.png)

------------------

### 🔎 Buscar um projeto .

![RequisicaoBuscaPorProjeto](https://user-images.githubusercontent.com/88597534/172061762-47177b92-338b-4434-984b-578dcd81bd02.png)

👉 Entrada de dados (Busca pelo projeto de id = 3).

![EntradaDeDadosBuscarProjeto](https://user-images.githubusercontent.com/88597534/172061835-c65c8dd5-e42a-44c2-bfea-270c5ebb2c7e.png)

👍 Resposta com status code 200.

![RetornoProjeto](https://user-images.githubusercontent.com/88597534/172061917-f4c6107b-e3f3-4ca7-a8f2-e3f08ce2dec2.png)

------------------

### ➕ Cadastrar um projeto.

![RequisicaoCadastrarProjeto](https://user-images.githubusercontent.com/88597534/172062384-7e428312-7e59-4de8-b1fc-d09a820a218a.png)

👉 Entrada de dados (corpo da requisição).

![EntradaDeDadosCadastroProjeto](https://user-images.githubusercontent.com/88597534/172062301-71cdce62-d074-4b97-acc4-b951fc2fee5d.png)

👍 Resposta com status code 201 (cadastrado com sucesso).

![RetornoCadastroProjeto](https://user-images.githubusercontent.com/88597534/172062305-e9d3e1fe-658b-475d-aacd-d3f53e6f3691.png)

👉 Visualização do projeto cadastrado.

![VisualizacaoDoProjetoCadastrado](https://user-images.githubusercontent.com/88597534/172062307-2a7d6405-3198-4dbd-af3e-3e5f89a4eceb.png)

------------------
### ✏️ Atualização de dados do Projeto (Projeto com id = 4).

![RequisicaoAtualizacaoProjeto](https://user-images.githubusercontent.com/88597534/172062948-67c1d8b7-bd92-4a62-8512-fa5581d72bdb.png)

👉 Entrada de dados (corpo da requisição).

![EntradaDeDadosAtualizacaoProjeto](https://user-images.githubusercontent.com/88597534/172062954-6053029a-2881-4b48-9a1a-fbd817d4f944.png)

👍 Resposta com status code 204 (No content - requisição bem sucedida).

![RetornoAtualizacaoProjeto](https://user-images.githubusercontent.com/88597534/172062960-971545b8-78c6-4278-a658-d67f6d30f157.png)

👉 Visualização da atualização do projeto.

![VisualizacaoDoProjetoAlterado](https://user-images.githubusercontent.com/88597534/172062969-6cb72525-7b7a-4a15-90ed-5cd0ff86ea0c.png)

------------------

### :x: Exclusão de projeto (Projeto com id = 4).

![RequisicaoExclusaoProjeto](https://user-images.githubusercontent.com/88597534/172063282-eb2f60ed-66bd-479c-8aba-653a6cb1dcd8.png)

👉 Entrada de dados (Entrada do identificador do projeto).

![EntradaDeDadosExclusaoProjetoUsuario0](https://user-images.githubusercontent.com/88597534/172063289-13153be2-6345-4a2c-a51d-218b978dbe39.png)

👎 Resposta com status code 403 (Forbidden), indicando que o usuário não tem autorização para deletar este ou qualquer outro projeto, em função do seu nível de acesso ( Tipo 0 ).

![RetornoExclusaoProjeto](https://user-images.githubusercontent.com/88597534/172063293-d538d575-a0f7-4631-9eaa-aca0f4479f36.png)

-----------------
### ➕ Cadastro de um usuário com nível de acesso privilegiado (tipo = 1).

![RequisicaoCadastrarUsuario](https://user-images.githubusercontent.com/88597534/172064189-497fa4a0-41a5-4542-8a59-998b24effcd5.png)

👉 Entrada de dados (E-mail, Senha e Tipo).

![EntradaDeDadosCadastrarUsuario1](https://user-images.githubusercontent.com/88597534/172064201-ed29a669-3fc3-43c0-9651-c51429ae2b33.png)

👍 Resposta com status 201 (Usuário cadastrado com sucesso). 

![RetornoUsuarioCadastrado](https://user-images.githubusercontent.com/88597534/172064265-e2b9279b-95bc-4c40-a637-a827b3cd2a62.png)

👉 Token JWT gerado com status code 200 (Autenticação com sucesso).

![TokenUsuario1](https://user-images.githubusercontent.com/88597534/172064384-771715d5-3a49-486c-8af9-6961ca5fb000.png)

👉 Uso do token JWT para autorização.

![TokenAutorizacaoUsuario1](https://user-images.githubusercontent.com/88597534/172064389-f8c06030-627a-4d7b-9442-1763ae215634.png)

👉 Token com autorização concedida.

![TokenAutorizadoUsuario1](https://user-images.githubusercontent.com/88597534/172064392-163be856-1771-4fee-9c66-9d33ff970aa4.png)

👉 Tentativa de exclusão do projeto com Id = 4

![ExclusaoProjeto4PeloUsuario1](https://user-images.githubusercontent.com/88597534/172064400-eff53b6a-0053-49f0-b81c-1def57878f0c.png)

👍 Resposta com status 204 (No content - Requisição bem sucedida).

![RetornoProjetoDeletadoUsuario1](https://user-images.githubusercontent.com/88597534/172064407-dc898ac3-16ba-48a9-8316-3adc0396499e.png)

👉 Visualização da lista de projetos (Projeto com id = 4 não existe mais).

![VisualizacaoProjetosConfirmacaoExclusaoPeloUsuario1](https://user-images.githubusercontent.com/88597534/172064414-98a2fa51-09b3-4233-8d07-7d41252c5d76.png)

--------------------

### 📋 Listar todos os usuários

![RequisicaoListarUsuarios](https://user-images.githubusercontent.com/88597534/172064836-0b5d9867-c5c2-4b2d-890f-376827548ea9.png)

![ListarUsuarios](https://user-images.githubusercontent.com/88597534/172064845-0c8381af-d89f-403f-8af8-3986ab54b813.png)

--------------------

### 🔎 Buscar um usuário.

![RequisicaoBuscarUsuario](https://user-images.githubusercontent.com/88597534/172065088-d7617c88-6678-4e97-b5b6-de19d507b03c.png)

👉 Entrada de dados (Busca pelo usuário de id = 2)

![EntradaDadosBuscarUsuario](https://user-images.githubusercontent.com/88597534/172065097-2d4177b2-277f-4dcb-8275-614d13ba6937.png)

👍 Resposta com status 200.

![RetornoBuscarUsuario](https://user-images.githubusercontent.com/88597534/172065101-e376858e-22d1-48ec-8e4a-ebcda0d5a6ec.png)

--------------------

### ✏️ Atualizar um usuário.

![RequisicaoAtualizarUsuario](https://user-images.githubusercontent.com/88597534/172066810-9d016c5a-891e-49cf-8434-846a409c66d3.png)

👉 Entrada de dados (Atualização de usuário com id = 2).

![EntradaDadosAtualizarUsuario](https://user-images.githubusercontent.com/88597534/172075028-20ae4ac7-fecb-4d9f-ac81-df45f9d3f400.png)

👍 Resposta com status code 204 (No content - requisição bem sucedida).

![RetornoAtualizarUsuario](https://user-images.githubusercontent.com/88597534/172066832-7264e2cc-a9d0-4960-b76f-a980f456daaa.png)

👉 Visualização da atualização do usuário.

![ListaDeUsuarioAtualizado](https://user-images.githubusercontent.com/88597534/172066839-79359ab0-8524-4c52-8653-fcbac2251aaf.png)

----------------
### :x: Exclusão de usuário. (Usuário com id = 2)

![RequisicaoDeletarUsuario](https://user-images.githubusercontent.com/88597534/172067210-fdc136ed-a6d1-4df0-ba73-f34923f832bd.png)

👉 Entrada de dados (Identificador do usuário)

![EntradaExclusaoUsuario](https://user-images.githubusercontent.com/88597534/172067213-807b2b19-0191-4f83-8d40-c58a8e3196f8.png)

👍 Resposta com status code 204 (No content - Requisição bem sucedida)

![RetornoExclusaoUsuario](https://user-images.githubusercontent.com/88597534/172067225-00dad5b2-3ad1-4115-8213-78abcd975620.png)

👉 Visualização dos usuários cadastrados (Usuário com id = 2, não existe mais).

![ListarUsuarioDeletado](https://user-images.githubusercontent.com/88597534/172067231-5138efda-e45b-4046-b8ab-8a4447faaf90.png)

-------------

## 📁 Organização do projeto

Possui resumidamente:

✔️ __Arquivo Program.cs__:  Contém as configurações de autenticação JWT Bearer, do Swagger, de restrição de acesso (Cors), além de controllers, serviços e outros aspectos necessários ao pleno funcionamento da aplicação.

✔️ __Pasta Models__:  Contém as entidades envolvidas no projeto, descritas com os seus respectivos campos, carregando informações entre as camadas. Nesta pasta também foi criada uma enumeração de dados para detalhamento do status do projeto (0 = criado, 1 = Andamento, 2 = Finalizado).

✔️ __Pasta Repositories__:  Contém as classes do repositório e uma subpasta interfaces, com os arquivos IProjetoRepository e IUsuarioRepository que deverão ser implementados por meio de um contrato com as respectivas classes relacionadas, denominadas ProjetoRepository e UsuarioRepository. As classes do repositório fazem acesso e manipulação de dados no banco.

✔️ __Pasta Controllers__:  Contém os classes denominadas controladores que representam os endpoints da aplicação, recebendo as requisições do usuário de acordo com o seu nível de permissão e reconduzindo o fluxo de forma a realizar a comunicação com a camada do repositório, a fim de obter acesso aos recursos disponíveis. Podem retornar um status code específico em caso de sucesso, falha ou outros motivos.

✔️ __Pasta Contexts__:  Contém a classe ProjetoContext que possui as configurações para conexão com o banco. Essa classe de contexto também administra os objetos entidades durante o tempo de execução, o que inclui preencher objetos com dados de um banco de dados, controlar alterações, e persistir dados para o banco de dados.

✔️ __Pasta ViewModels__:  Contém uma classe, a qual irá carregar apenas os dados necessários para login de usuário (e-mail e senha) dentro da classe LoginController, que por sua vez, delega atribuições para a classe do repositório UsuarioRepository , permitindo a consulta no banco para realizar a autenticação.

✔️ __Arquivo exoapi.csproj__:  Contém basicamente as configurações do framework alvo, além de referências à instalações de pacotes ou dependências do projeto com suas respectivas versões.


## 🔧 Pré-requisitos do projeto

✔️ .NET SDK 6.0.

✔️ Visual Studio Code.

✔️ Insomnia ou Postman (opcionais).

## ⚙️ Tecnologias utilizadas

✔️ .NET 6.0 (linguagem C#).

✔️ Visual Studio Code.

## 💻 Sistema Operacional utilizado

✔️ Windows 10.

## 🏃 Execução da aplicação

👉 Após baixar o projeto em zip e fazer a sua descompactação, clicar com o botão direito na pasta do projeto e em seguida em abrir com o Code.

👉 Em seguida, no painel esquerdo, acessar o ícone run and debug (Ctrl + Shift + D) e no botão superior .NET Core Launch (web) para executar a aplicação. Uma janela do Swagger deverá ser aberta para que possam ser feitas as requisições necessárias.

__OU__ 

👉 Opcionalmente, um clone do projeto também poderá ser feito. No terminal do Git, deve-se usar o comando :

```
git clone https://github.com/MarceloDev100/senai-uc14-atividades-online.git
```
Em seguida, o mesmo procedimento anterior deve ser feito para execução do projeto no VS Code.

## 👪 Contribuidores

Aluno SENAI-SP : Marcelo Marques.

------------

##### Curso de Qualificação Desenvolvedor FullStack - Módulo BackEnd SENAI-SP.