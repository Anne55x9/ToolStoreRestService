using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolStoreRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStoreRestService.Tests
{
    [TestClass()]
    public class ToolstoreServiceTests
    {
        [TestMethod()]
        public void GetToolsListCount()
        {
            //Arrange

            IToolstoreService toolstore = new ToolstoreService();

            //Act

            IList<Tool> tools = toolstore.GetTools();

            //Assert
            Assert.AreEqual(3, tools.Count);
        }

        [TestMethod()]
        public void GetToolId1()
        {
            //Arrange

            IToolstoreService toolstore = new ToolstoreService();

            //Act

            Tool tool = toolstore.GetTool("1");

            //Assert

            Assert.AreEqual("SuperSqruer", tool.Name);
            Assert.IsNull(toolstore.GetTool("100"));
        }

        [TestMethod()]
        public void AddToolTolistTest()
        {
            //Arrange
            IToolstoreService toolstore = new ToolstoreService();


            //Act

            Tool t1 = new Tool{Name = "KampBænk", Type = "Materialer", Brand = "Bonse", Price = 498};
            Tool t1copy = toolstore.AddTool(t1);

            //Arrange
            Assert.AreEqual(4, t1copy.Id);
            Assert.AreEqual("KampBænk", t1copy.Name);

        }

        [TestMethod()]
        public void UpdateToolTest()
        {
            //Arrange
            IToolstoreService toolstore = new ToolstoreService();

            //Act
            Tool t1 = new Tool { Name = "KampBænk2", Type = "Materialer", Brand = "Bonse", Price = 498 };
            toolstore.AddTool(t1);
            t1.Name = "testUpdate";
            Tool updatedTool = toolstore.UpdateTool(t1.Id.ToString(), t1);


            //Assert
            Assert.AreEqual("testUpdate",updatedTool.Name);

        }

        [TestMethod()]
        public void DeleteToolTest()
        {
            //Arrange
            IToolstoreService toolstore = new ToolstoreService();

            //Act
            Tool tdel = toolstore.DeleteTool("3");


            //Assert
            Assert.AreEqual(3, tdel.Id);
            Assert.AreEqual("Hammerhaj",tdel.Name);

            Assert.IsNull(toolstore.DeleteTool("100"));

        }
    }
}