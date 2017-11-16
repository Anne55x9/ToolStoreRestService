using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ToolStoreRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ToolstoreService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ToolstoreService.svc or ToolstoreService.svc.cs at the Solution Explorer and start debugging.
    public class ToolstoreService : IToolstoreService
    {

        private static readonly IList<Tool> toolsList = new List<Tool>();
        private static int _nextid = 4;

        static ToolstoreService()
        {
            Tool firstTool = new Tool
            {
                Id = 1,
                Name = "SuperSqruer",
                Type = "Skruetrækker",
                Brand = "DeckerDig",
                Price = 100
                
            };

            toolsList.Add(firstTool);

            Tool secondTool = new Tool
            {
                Id = 2,
                Name = "SlangeLange",
                Type = "Tilbehør",
                Brand = "Wrecks",
                Price = 50

            };

            toolsList.Add(secondTool);

            Tool thirdTool = new Tool
            {
                Id = 3,
                Name = "Hammerhaj",
                Type = "Slåtøj",
                Brand = "Håkon",
                Price = 450

            };

            toolsList.Add(thirdTool);
        }

        public IList<Tool> GetTools()
        {
            return toolsList;
        }

        public Tool GetTool(string id)
        {
            int idNumber = int.Parse(id);
            return toolsList.FirstOrDefault(tool => tool.Id == idNumber);
        }

        public string GetToolName(string id)
        {
            Tool tool = GetTool(id);
            if (tool == null)
            {
                return null;
            }
            return tool.Name;
        }

        public IEnumerable<Tool> GetToolByName(string nameFragment)
        {
            return toolsList.Where(tool => tool.Name.ToLower().Contains(nameFragment.ToLower()));
        }

        public Tool AddTool(Tool tool)
        {
            tool.Id = _nextid++;
            toolsList.Add(tool);
            return tool;
        }

        public Tool UpdateTool(string id, Tool tool)
        {
            int idNumber = int.Parse(id);
            Tool existingTool = toolsList.FirstOrDefault(b => b.Id == idNumber);
            if (existingTool == null)
            {
                return null;
            }
            existingTool.Name = tool.Name;
            existingTool.Type = tool.Type;
            existingTool.Brand = tool.Brand;
            existingTool.Price = tool.Price;
            return existingTool;
        }

        public Tool DeleteTool(string id)
        {
            Tool tool = GetTool(id);
            if (tool == null)
            {
                return null;
            }
            bool removed = toolsList.Remove(tool);
            if (removed)
            {
                return tool;
            }
            return null;
        }
    }
}
