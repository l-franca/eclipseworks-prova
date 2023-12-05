#Como rodar
Na raiz do projeto, execute o comando
docker-compose up
depois acesse a URL: http://localhost:8081/swagger

#Relatório Coverage
Para visualizar o relatório de Teste Unitário, acesse "./report/index.html".

#Perguntas para o PO
- Se um projeto tiver 20 tarefas concluídas, é permitido adicionar novas?
- Por questões de segurança, não deveríamos limitar o acesso ao projeto por usuários? Apenas Gerentes deveriam ter acesso a todos.
- Deveríamos limitar a edição de tarefas apenas para o usuário que criou ou participam do projeto?
- Por motivo de auditoria, não seria melhor criar um campo de Status para ativar/desativar uma tarefa ou projeto ao invés de removê-lo completamente do banco?

#Melhorias 
- Adicionar ViewModels para cada processo: visualização, edição e adição.
- Retornar as listas com paginação, facilitando assim a visualização.
- Otimizar o banco de dados para lidar melhor com escalabilidade.
- Gerar documentação.
- Implementar uma forma melhor de executar as migrations do banco de dados.