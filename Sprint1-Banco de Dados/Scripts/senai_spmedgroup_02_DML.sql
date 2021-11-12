USE SPMedGroup;
GO

INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES ('Administrador'),('Medico'),('Paciente');
GO

INSERT INTO Endereco(Rua,Numero,Bairro,Cidade,Estado,CEP)
VALUES
('Av. Barão Limeira','532','Santa Cecilia','São Paulo','SP','01202001'),('R. Estado de Israel','240','Vila Mariana','São Paulo','SP','04022000'),('Av. Paulista','1578','Bela Vista','São Paulo','SP','01310200'),('Av. Ibirapuera','2927','Indianopolis','São Paulo','SP','04029200'),('R. Vitória','120','Vila São Jorge','Barueri','SP','06402030'),('R. Ver. Geraldo de Camargo','66','Santa Luzia','Ribeirão Pires','SP','09405380'),('Alameda dos Arapanés','945','Indianopolis','São Paulo','SP','04524001'),('R Sao Antonio','232','Vila Universal','Barueri','SP','06407140')

INSERT INTO Clinica(IdEndereco,nomeClinica,CNPJ,razaoSocial,Telefone)
VALUES (1,'Clinica Pclinics','86400902000130','SP Medical Group','(11) 29812920');
GO

INSERT INTO Especialidade(nomeEspecialidade)
VALUES ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),
('Cirurgia da Mão'),('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pediatrica'),('Cirurgia Plástica'),('Cirurgia Torácica'),('Cirurgia Vascular'),('Dermatolgia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria');
GO

INSERT INTO Situacao(nomeSituacao)
VALUES ('Agendada'),('Realizada'),('Cancelada');
GO

INSERT INTO Usuario(IdTipoUsuario,Senha,Email,nomeUsuario)
VALUES (1,'admsenai','adm@email.com','adm'),(2,'hitman123','ricardo.lemos@spmedgroup.com.br','hitman'),(2,'possa033','roberto.possarle@spmedicalgroup.com.br','possa'),(2,'helena12','helena.souza@spmedicalgroup.com.br','lena'),(3,'ligiafood','ligia@gmail.com','ligia'),(3,'17011968','alexandre@gmail.com','alex'),(3,'fefedograu','fernando@gmail.com','naosei123'),(3,'senha321','henrique@gmail.com','rique'),(3,'password5','joao@hotmail.com','joaozin'),(3,'crypto09','bruno@gmail.com','brunin'),(3,'miojo012','mariana@outlook.com','marianja');
GO

INSERT INTO Medico(IdUsuario,nomeMedico,IdClinica,IdEspecialidade,CRM)
VALUES (1,'Ricardo Lemos',1,2,'54356-SP'),(2,'Roberto Possarle',1,17,'53452-SP'),(3,'Helena Strada',1,16,'65463-SP');
GO

INSERT INTO Paciente(IdUsuario,IdEndereco,nomePaciente,dataNascimento,Telefone,RG,CPF)
VALUES (4,2,'Ligia','13/10/1983','1134567654','435225435','94839859000'),(5,3,'Alexandre','23/07/2001','11987656543','326543457','73556944057'),(6,4,'Fernando','10/10/1978','11972084453','546365253','16839338002'),(7,5,'Henrique','13/10/1985','1134566543','543663625','14332654765'),(8,6,'João','27/08/1975','1176566377','532544441','91305348010'),(9,7,'Bruno','21/03/1972','11954368769','545662667','79799299004'),(10,8,'Mariana','03/05/2018','NULL','545662668','13771913039');
GO

INSERT INTO Consulta(IdPaciente,IdMedico,IdSituacao,dataConsulta,descricaoConsulta)
VALUES (7,3,2,'20/01/20 15:00',''),(4,2,3,'06/01/20 10:00',''),(5,2,2,'07/02/20 11:00',''),(4,2,2,'06/02/18 10:00',''),(6,1,3,'07/02/19 11:00',''),(7,3,1,'08/03/20 15:00',''),(6,1,1,'09/03/20 11:00','');
GO


