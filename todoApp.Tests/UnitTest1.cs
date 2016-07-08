using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using todoApp.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;


namespace todoApp.Tests
{

    [TestClass]
    public class UnitTest1
    {
        private ToDoEntities db = new ToDoEntities();
        

        [TestMethod]
        public void CheckGetAll()
        {
            var todos = db.toDos.Include(t => t.priorityType);
            Assert.IsTrue(todos.ToList().Count > 0);
        }
    }
}
