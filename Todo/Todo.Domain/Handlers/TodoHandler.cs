using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandresult(false, "Ops, parece que sua tarefa esta errada!", command.Notifications);

            //gera o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //salva no banco
            _repository.Create(todo);

            //retorna o Resultado
            return new GenericCommandresult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandresult(false, "Ops, parece que sua tarefa esta errada!", command.Notifications);

            //Recupera o TodoItem(Reindratacao)
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o titulo
            todo.UpdateTitle(command.Title);


            //salva no banco
            _repository.Update(todo);

            //retorna o Resultado
            return new GenericCommandresult(true, "Tarefa salva", todo);
        }
    }
}