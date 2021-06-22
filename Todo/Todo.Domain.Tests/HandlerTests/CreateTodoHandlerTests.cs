using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoCommandHandlerTests
    {
        [TestMethod]
        public void Dado_comando_invalido_deve_interromper_a_execucao()
        {
            var command = new CreateTodoCommand("", "", DateTime.Now);
            var handler = new TodoHandler(null);
            Assert.Fail();
        }

        [TestMethod]
        public void Dado_comando_valido_deve_criar_a_tarefa()
        {
            Assert.Fail();
        }
    }
}
