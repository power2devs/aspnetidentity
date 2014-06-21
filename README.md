ASP.NET Identity Demo
==============

Código produzido na reunião técnica de junho de 2014 sobre ASP.NET Identity.
Ficando algumas questões a serem evoluídas a respeito:

  - Os campos Not null (Required) na atualização via migrations são inseridos NULL para os registros que já existem. Para a criação este comportamento muda? Como resolver esta inconsistência?
  - Como remover uma coluna padrão do Identity de uma tabela
  - Como poderia integrar o Identity em uma aplicação utilizando Forms Authentication?
  - Trabalhar com Regras de autorização (usuário, grupo, páginas, seções, etc).
  - Interceptação do retorno do OAUth para guardar os dados da rede social no BD.
