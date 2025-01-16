# httpValidaCpf

Este é um projeto desenvolvido como parte da formação da DIO para a certificação AZ-204. O projeto consiste em uma Azure Function que valida números de CPF (Cadastro de Pessoas Físicas) no Brasil.

## Estrutura do Projeto

- **HttpValidaCpf.csproj**: Arquivo de projeto que define as configurações do projeto, incluindo o framework alvo (.NET 8.0) e as dependências necessárias para o Azure Functions.

- **ValidateCpfFunction.cs**: Contém a lógica da função Azure que valida o CPF. A função é acionada por uma requisição HTTP POST e verifica se o CPF fornecido é válido.

- **config.json**: Arquivo de configuração que contém as configurações necessárias para a execução local da Azure Function, como `AzureWebJobsStorage` e `FUNCTIONS_WORKER_RUNTIME`.

- **.vscode/launch.json**: Configurações para depuração do projeto no Visual Studio Code.

- **.vscode/tasks.json**: Tarefas de build para compilar o projeto usando o comando `dotnet build`.

## Como Executar

1. Certifique-se de ter o .NET 8.0 SDK instalado em sua máquina.
2. Abra o projeto no Visual Studio Code ou em outra IDE de sua preferência.
3. Use o terminal para navegar até o diretório do projeto e execute `dotnet build` para compilar o projeto.
4. Inicie a função usando o comando `func start` para executar a Azure Function localmente.

## Desenvolvedor

Este projeto foi desenvolvido por Willian Carlos Gomes como parte do treinamento para a certificação AZ-204 da DIO.