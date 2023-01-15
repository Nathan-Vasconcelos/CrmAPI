# CrmAPI
API Restful de gestão de relacionamento com o cliente (CRM) em ASP.NET CORE.
<hr>
<br>
<h2>Rotas:</h2>
<h3>/Atendimento</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo Atendimento</p>
<p>Get: retorna todos os Atendimento</p>
<p>Get com o statusAtendimento como parâmetro na URL (Atendimento?statusAtendimento=1): retorna todos os Atendimentos com o StatusAtendimento passado</p>
<p>Get com o Id como parâmetro (Atendimento/Id): retorna o Atendimento referente ao Id passado</p>
<p>Put passando o Id como parâmetro (Atendimento/Id): atualiza os dados do Atendimento referente ao Id passado</p>
<p>Delete passando o Id como parâmetro (Atendimento/Id): Deleta o Atendimento referente ao Id passado. Obs.: Deleção em cascata, ao deletar um atendimento os pareceres relacionados serão deletados</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{<br>
  "UsuarioId": ,<br>
  "ClienteId": ,<br>
  "TipoAtendimentoId": ,<br>
  "StatusAtendimentoId":<br>
}
</p>
<h3>/Cliente</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo Cliente</p>
<p>Get: retorna todos os Cliente</p>
<p>Get com o Id como parâmetro (Cliente/Id): retorna o Cliente referente ao Id passado</p>
<p>Put passando o Id como parâmetro (Cliente/Id): atualiza os dados do Cliente referente ao Id passado</p>
<p>Delete passando o Id como parâmetro (Cliente/Id): Deleta o Cliente referente ao Id passado. Obs.: Deleção em cascata</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{<br>
  "RazaoSocial": "",<br>
  "NomeFantasia": "",<br>
  "Cnpj": "00.000.000/0000-00"<br>
}
</p>
<h3>/Usuario</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo Usuario</p>
<p>Get: retorna todos os Usuarios</p>
<p>Get com o Id como parâmetro (Usuario/Id): retorna o Usuario referente ao Id passado</p>
<p>Put passando o Id como parâmetro (Usuario/Id): atualiza os dados do Usuario referente ao Id passado</p>
<p>Delete passando o Id como parâmetro (Usuario/Id): Deleta o Usuario referente ao Id passado. Obs.: Deleção em cascata</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{<br>
  "Nome": "",<br>
  "Cpf": "000.000.000-00"<br>
}
</p>
<h3>/ContatoAtendimento</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo ContatoAtendimento</p>
<p>Get: retorna todos os ContatosAtendimentos</p>
<p>Get com o Id como parâmetro (ContatoAtendimento/Id): retorna o ContatoAtendimento referente ao Id passado</p>
<p>Put passando o Id como parâmetro (ContatoAtendimento/Id): atualiza os dados do ContatoAtendimento referente ao Id passado</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{<br>
  "Descricao": ""<br>
}
</p>
<h3>/Parecer</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo Parecer</p>
<p>Get: retorna todos os Pareceres</p>
<p>Get com o Id como parâmetro (Parecer/Id): retorna o Parecer referente ao Id passado</p>
<p>Put passando o Id como parâmetro (Parecer/Id): atualiza os dados do Parecer referente ao Id passado</p>
<p>Delete passando o Id como parâmetro (Parecer/Id): Deleta o Parecer referente ao Id passado. Obs.: Deleção em cascata</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{<br>
  "Descricao": "",<br>
  "AtendimentoId": ,<br>
  "ContatoAtendimentoId": <br>
}
</p>
<h3>/StatusAtendimento</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo StatusAtendimento</p>
<p>Get: retorna todos os StatusAtendimentos</p>
<p>Get com o Id como parâmetro (StatusAtendimento/Id): retorna o StatusAtendimento referente ao Id passado</p>
<p>Put passando o Id como parâmetro (StatusAtendimento/Id): atualiza os dados do StatusAtendimento referente ao Id passado</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{<br>
  "Descricao": ""<br>
}
</p>
<h3>/TipoAtendimento</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo TipoAtendimento</p>
<p>Get: retorna todos os TiposAtendimento</p>
<p>Get com o Id como parâmetro (TipoAtendimento/Id): retorna o TipoAtendimento referente ao Id passado</p>
<p>Put passando o Id como parâmetro (TipoAtendimento/Id): atualiza os dados do TipoAtendimento referente ao Id passado</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{<br>
  "Descricao": ""<br>
}
</p>
<br>
<h2>Relacionamentos:</h2>
<h3>Atendimento e Parecer (n:1)</h3>
<p>Um Atendimento pode ter um, nunhum ou muitos Pareceres, e um Parecer pode ter um Atendimento.</p>
<h3>Atendimento e Usuario (1:n)</h3>
<p>Um Atendimento pode ter um Usuario, e um Usuario pode ter um, nunhum ou muitos Atendimentos.</p>
<h3>Atendimento e Cliente (1:n)</h3>
<p>Um Atendimento pode ter um Cliente, e um Cliente pode ter um, nunhum ou muitos Atendimentos.</p>
<h3>Atendimento e TipoAtendimento (1:n)</h3>
<p>Um Atendimento pode ter um TipoAtendimento, e um TipoAtendimento pode ter um, nunhum ou muitos Atendimentos.</p>
<h3>Atendimento e StatusAtendimento (1:n)</h3>
<p>Um Atendimento pode ter um StatusAtendimento, e um StatusAtendimento pode ter um, nunhum ou muitos Atendimentos.</p>
<h3>ContatoAtendimento e Parecer (n:1)</h3>
<p>Um Parecer pode ter um ContatoAtendimento, e um ContatoAtendimento pode ter um, nunhum ou muitos Pareceres.</p>
