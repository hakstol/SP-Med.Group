USE SPMedGroup;
GO

-- Converter a data de nascimento do usuário para o formato (mm-dd-yyyy) na exibição
SELECT nomePaciente Paciente, Convert(varchar,dataNascimento, 105) 'Data de Nascimento' FROM Paciente
GO

-- Calcular a idade do usuário a partir da data de nascimento
SELECT nomePaciente Paciente, DATEDIFF(YEAR,dataNascimento,GETDATE()) Idade FROM Paciente
GO

SELECT	idConsulta,
		dataConsulta [Data da Consulta],
		nomePaciente [Paciente],
		nomeUsuario [Nome de Usuário do Paciente],
		nomeMedico [Médico],
		nomeEspecialidade [Especialidade],
		Clinica.nomeClinica [Clínica],
		nomeSituacao [Situação da Consulta],
		Consulta.descricaoConsulta [Descrição da Consulta]
FROM Consulta
LEFT JOIN Situacao
ON Consulta.idSituacao = Situacao.idSituacao
LEFT JOIN Paciente
ON Consulta.idPaciente = Paciente.idPaciente
LEFT JOIN Medico
ON Consulta.idMedico = Medico.idMedico
LEFT JOIN Especialidade
ON Medico.idEspecialidade = Especialidade.idEspecialidade
LEFT JOIN Clinica
ON Medico.idClinica = Clinica.idClinica
INNER JOIN Usuario
ON Paciente.idUsuario = Usuario.idUsuario
GO

-- Busca um usuário através do seu e-mail e senha
SELECT nomeUsuario, email, senha
FROM usuario
WHERE email = 'adm@email.com'
AND senha = 'admsenai'