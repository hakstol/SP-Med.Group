# SP-Med.Group

<h1>Documentação</h1>

<h2>Resumo</h2>
  <p>Projeto proposto com o intuito de avaliar o conhecimento nos conteúdos de modelagem e scripts de um Banco de Dados relacional e não relacional, construção de uma API como Back-end, estruturação de páginas web com ferramentas de uso comum como HTML, CSS e integração de dinamismo com JavaScript utilizando a biblioteca ReactJs para consumo da API e desenvolvimento do mesmo numa aplicação Mobile construída em React Native.</p>

<h2>Descrição do projeto</h2>
  <p>Uma nova clínica médica chamada SP Medical Group, empresa de pequeno porte que atua no ramo da saúde, foi criada pelo médico Fernando Strada em 2020 na região da Paulista em São Paulo. Fernando tem uma equipe de médicos que atuam em diversas áreas (pediatria, odontologia, gastrenterologia etc.). Sua empresa, por ser nova, iniciou a administração dos registros de forma simples, utilizando softwares de planilhas eletrônicas e, com o sucesso da clínica, sua gestão passou a se tornar complicada devido à alta demanda dos pacientes.</p>

<h2>Banco de Dados Relacional</h2>
  <p>Banco de dados relacional é aquele que ordena os dados para que eles sejam vistos como tabelas ou relações. Ele é importante pois nos permite ordenar nossos dados de forma mais intendivel</p>

<h2>Modelagem de Dados</h2>
  <p>Modelagem de dados é o método de criar um modelo do sistema para explicar suas características e comportamento para facilitar o entendimento do projeto, para evitar erros em seu desenvolvimento.</p>

<h3>Modelo Conceitual</h3>
  <p>Esse modelo mostra as entidades de forma mais simples e estabelece as relações de cardinalidade.</p>
  <img src ="https://github.com/hakstol/SP-Med.Group/blob/main/Sprint1-Banco%20de%20Dados/Modelagens/modelo-conceitual-spmedgroup.png" style = "width = 100%">

<h3>Modelo Lógico</h3>
  <p>Esse modelo mostra as entidades de forma mais complexa já contendo seus campos e também apresenta cardinalidade.</p>
  <img src = "https://github.com/hakstol/SP-Med.Group/blob/main/Sprint1-Banco%20de%20Dados/Modelagens/modelo-logico-spmedgroup.drawio.png" style = "width = 100%">

<h3>Modelo Físico</h3>
  <p>Esse modelo representa de forma visual o banco de dados contendo as entidades, os campos e os dados armazenados nesses campos.</p>
  <img src = "https://github.com/hakstol/SP-Med.Group/blob/main/Sprint1-Banco%20de%20Dados/Modelagens/modelo-físico-spmedgroup.png" width = "100%" height = "600">


<h2><strong>Cronograma</strong></h2>
  <img src="https://github.com/hakstol/SP-Med.Group/blob/main/Sprint3-UX-UI/assets/img/cronogama.png" width = "100%" height = "600">
  
<h2><strong>Back-End</strong></h2>
  <p>Para este projeto optamos por desenvolver a nossa aplicação no formato de uma API, ela foi desenvolvida utilizando o Microsoft Visual Studio.</p>
  <p><strong>Api</strong> é um conjunto de padrões e instruções estabelecidos para utilização do software, definindo as requisições e as respostas seguindo o protocolo HTTP, neste caso expresso no formato JSON, para que seja possível acessar o sistema em diversos dispositivos distintos sem a preocupação com a linguagem que será utilizada por estes.</p>
  <p>Além disso, foi utilizado o estilo de arquitetura REST.</p>
  <p><strong>API -</strong> Application Programming Interface – Interface de Programação de Aplicativos.</p>
  <p><strong>HTTP -</strong> Hypertext Transfer Protocol – Protocolo de Transferência de Hipertexto.</p>
  <p><strong>JSON -</strong> JavaScript Object Notation – Notação de Objetos JavaScript.</p>
  <p><strong>REST -</strong> Representational State Transfer – Interface de Programação de Aplicativos.</p>
  
  <p><strong>Entity Framework</strong> é um conjunto de tecnologias no ADO.NET que dão suporte ao desenvolvimento de aplicativos de software orientado a dados. O Entity Framework permite que os desenvolvedores trabalhem com dados na forma de objetos e propriedades específicos de domínio, como clientes e endereços de clientes, sem ter que se preocupar com as tabelas e colunas de banco de dados subjacentes em que esses data são armazenados.</p>
  <p><strong>Swagger</strong> é uma ferramenta usada para documentar os endpoints da nossa API.</p>
  <p><strong>DataBase First</strong> é o método de construção da API onde se usa as tabelas preexististentes no banco de dados, e os transforma em classes dentro da API</p>
  <p><strong>JWT</strong> é o método de autenticação usado, onde a autenticação é por meio de tokens.</p>

<h2><strong>Sistemas Web</strong></h2>
  <p><strong>Perfis de usuário:</strong></p>
    <ul>
      <li><strong>Administrador:</strong> Para o colaborador da área administrativa da clínica;</li>
      <li><strong>Médico:</strong> Colaboradores que atuam na área da saúde;</li>
      <li><strong>Paciente:</strong> Clientes da clínica;</li>
    </ul>
  <p><strong>Funcionalidades:</strong>
    <ul>
      <li>O <strong>administrador</strong> poderá cadastrar qualquer tipo de usuário (administrador, paciente ou médico);</li>
      <li>O <strong>administrador</strong> poderá agendar uma consulta, onde será informado o paciente, data e hora do agendamento e qual médico irá atender a consulta (o médico possuirá sua determinada especialidade);</li>
      <li>O <strong>administrador</strong> poderá cancelar o agendamento;</li>
      <li>O <strong>administrador</strong> deverá informar os dados da clínica (como endereço, horário de funcionamento, CNPJ, nome fantasia e razão social);</li>
      <li>O <strong>médico</strong> poderá ver os agendamentos (consultas) associados a ele;</li>
      <li>O <strong>médico</strong> poderá incluir a descrição da consulta que estará vinculada ao paciente (prontuário);</li>
      <li>O <strong>>paciente</strong> poderá visualizar suas próprias consultas;</li>
    </ul>

<h2><strong>Sistema Mobile</strong></h2>
  <p><strong>Perfis de usuário:</strong></p>
    <ul>
      <li><strong>Médico:</strong> Colaboradores que atuam na área da saúde;</li>
      <li><strong>Paciente:</strong> Clientes da clínica;</li>
    </ul>
  <p><strong>Funcionalidades:</strong></p>
    <ul>
      <li>O <strong>médico</strong> poderá ver as consultas (agendamentos) associados a ele;</li>
      <li>O <strong>paciente</strong> poderá visualizar suas próprias consultas;</li>
    </ul>

<h3><strong>Trello:</strong> https://trello.com/b/wim7ZS4U/projeto-sp-medical-group</h3>
