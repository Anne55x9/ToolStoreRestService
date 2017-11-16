using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ToolStoreRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IToolstoreService" in both code and config file together.
    [ServiceContract]
    public interface IToolstoreService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "tools")]
        IList<Tool> GetTools();


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "tools/{id}")]
        Tool GetTool(string id);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "tools/{id}/name")]
        string GetToolName(string id);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "tools/name/{nameFragment}")]
        IEnumerable<Tool> GetToolByName(string nameFragment);

        /// <summary>
        /// Post commando kald.
        /// </summary>
        /// <param name="tool"></param>
        /// <returns></returns>

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "tools")]
        Tool AddTool(Tool tool);

        /// <summary>
        /// Update/put kommando kald.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tool"></param>
        /// <returns></returns>

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "tools/{id}")]
        Tool UpdateTool(string id, Tool tool);

        /// <summary>
        /// Delete kommando kald.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "tools/{id}")]

        Tool DeleteTool(string id);
    }
  
}
