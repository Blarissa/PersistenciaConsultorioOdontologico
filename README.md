# Curso de Residência em Software – Formação Back-end C #

## Desafio 1 - Administração da Agenda de um Consultório Odontológico

### Instruções

- A aplicação deve ser desenvolvida individualmente ou em dupla.
- A aplicação deve ser versionada e disponibilizada no Github.

### Descrição

Desenvolver uma aplicação console em C# para administrar a agenda de um consultório
odontológico. As funcionalidades da aplicação estão definidas a seguir e os layouts da interface
com o usuário estão definidos no final deste documento.
Funcionalidades

1. Inclusão de pacientes no cadastro: são necessários CPF, nome e data de nascimento.

    a. CPF deve ser válido (vide Anexo A da lista de exercícios 2 do Aquecimento).

    b. O nome do usuário deve ter pelo menos 5 caracteres.

    c. A data de nascimento deve ser fornecida no formato DD/MM/AAAA.

    d. Caso algum dado seja inválido, deve ser apresentada uma mensagem de erro e o dado
    deve ser solicitado novamente.

    e. Não podem existir dois pacientes com o mesmo CPF.

    f. O dentista não atende crianças, logo o paciente deve ter 13 anos ou mais no momento do
    cadastro (data atual).

2. Exclusão de pacientes do cadastro: é necessário fornecer o CPF.

    a. Um paciente com uma consulta agendada futura não pode ser excluído.

    b. Se o paciente tiver uma ou mais consultas agendadas passadas, ele pode ser excluído.
    Nesse caso, os respectivos agendamentos também devem ser excluídos.

3. Agendamento de uma consulta: são necessários CPF do paciente, data da consulta, hora
inicial e hora final.

    a. CPF deve existir no cadastro.

    b. A data da consulta deve ser fornecida no formato DD/MM/AAAA.

    c. Hora inicial e final devem ser fornecidos no formato HHMM (padrão brasileiro).

    d. O agendamento deve ser para um período futuro: data da consulta > data atual ou (data da
    consulta = data atual e hora inicial > hora atual).

    e. Hora final > hora inicial.

    f. Cada paciente só pode realizar um agendamento futuro por vez (os agendamentos
    passados não podem ser usados nessa verificação).

    g. Não pode haver agendamentos sobrepostos.

    h. As horas inicial e final são definidas sempre de 15 em 15 minutos. Assim, são válidas
    horas como 1400, 1730, 1615, 1000 e 0715. Por outro lado, não são válidas horas como
    1820, 1235, 0810 e 1950.

    i. O horário de funcionamento do consultório é das 8:00h às 19:00h, logo os horários de
    agendamento não podem sair desses limites.

4. Cancelamento de um agendamento: são necessários CPF do paciente, data da consulta e
hora inicial.

    a. O cancelamento só pode ser realizado se for de um agendamento futuro (data do
    agendamento > data atual ou (data do agendamento = data atual e hora inicial > hora
    atual)).

5. Listagem dos Pacientes

    a. A listagem de pacientes deve ser apresentada conforme o layout definido no final desse
    documento e pode estar ordenada de forma crescente por CPF ou nome, à escolha do
    usuário.

    b. Se o paciente possuir um agendamento futuro, os dados do agendamento devem ser
    apresentados abaixo dos dados do paciente.

6. Listagem da Agenda

    a. A listagem da agenda deve ser apresentada conforme o layout definido no final desse
    documento e deve estar ordenada de forma crescente por data e hora inicial.

    b. O usuário pode listar toda a agenda ou a agenda de um período. Nesse último caso, deve
    ser solicitada a data inicial e final (formato DD/MM/AAAA).

### Regras

- Todas as datas e horas fornecidas pelo usuário devem ser válidas. Caso não sejam, deve
ser apresentada uma mensagem de erro e o dado deve ser solicitado novamente.
- Nas listagens, os dados devem estar formatados e alinhados conforme os layouts
definidos no final deste documento.

## Desafio 2 - Conversor de Moedas com acesso a API REST

### Instruções

- A aplicação deve ser desenvolvida individualmente ou em dupla.
- Data limite de entrega: 18/01/2023 (quarta-feira).
- A aplicação deve ser versionada e disponibilizada no github.

### Descrição

Desenvolver uma aplicação modo texto (console) em C# que realize a conversão de
valores monetários entre diferentes moedas. A aplicação deve ler a moeda origem, a
moeda destino e um valor monetário e apresentar esse valor convertido da moeda
origem para a moeda destino e a taxa de conversão.
Para realizar a conversão
propriamente dita deve ser consumido o serviço de conversão de moedas
exchangerate.

#### Serviço exchangerate

- [Documentação da API](https://exchangerate.host/#docs)
- URI de exemplo que converte o valor de USD 100,00 para reais

  <https://api.exchangerate.host/convert?from=USD&to=BRL&amount=100.0>

### Regras

- Moeda origem ≠ moeda destino.
- Moeda de origem e de destino devem ter exatamente 3 caracteres.
- Valor de entrada > 0.
- O valor convertido deve ser arredondado para 2 casas decimais.
- A taxa deve ser apresentada com 6 casas decimais.
- O programa deve terminar quando o usuário digitar string vazia para a moeda
  de origem.
- Erro na comunicação com a API: deve ser apresentada a mensagem de erro
  correspondente.
- Problemas na conversão: deve ser apresentada a mensagem de erro
  correspondente.

## Desafio 3 - Persistência dos Dados da Clínica Odontológica

### Instruções

- A aplicação deverá ser desenvolvida em dupla.
- Data limite de entrega: 08/02/2023 (quarta-feira).
- A aplicação deverá ser versionada e disponibilizada no github.

### Descrição

Implementar a persistência dos dados na aplicação desenvolvida no Desafio #1. A
persistência deverá ser implementada, obrigatoriamente, usando o Entity Framework.
Além disso, os recursos do LINQ podem e devem ser explorados onde fizer sentido. O
projeto do Desafio #1 pode ser refatorado se você entender que é necessário ou
importante aprimorar a estrutura da solução adotada no Desafio #1.

### Regras

- Use o Entity Framework para o mapeamento OO - Relacional.
- Como SGBD use o Postgresql ou SQL Server.
- O SGBD pode ser instalado localmente ou acessado via docker.
- Não realize a implementação da persistência no código do repositório do
Desafio #1. Crie um clone desse repositório (fork) para o Desafio #3.
- Problemas no acesso ao SGBD: deve ser apresentada a mensagem de erro
correspondente.

### Dicas

- [Postgresql](https://www.postgresql.org/download/)
- [SQL Server Developer Edition e SQL Server Express Edition](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
