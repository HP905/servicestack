using System.IO;
using System.Web;
using ServiceStack.Service;
using ServiceStack.ServiceModel.Serialization;
using ServiceStack.WebHost.Endpoints.Extensions;
using ServiceStack.WebHost.Endpoints.Support;

namespace ServiceStack.WebHost.Endpoints
{
	public class JsonSyncReplyHandler : JsonHandlerBase
	{
		public override void ProcessRequest(HttpContext context)
		{
			var operationName = context.Request.GetOperationName();
			if (string.IsNullOrEmpty(operationName)) return;

			var request = CreateRequest(context.Request, operationName);

			var endpointAttributes = EndpointAttributes.SyncReply | EndpointAttributes.Json 
				| GetEndpointAttributes(context.Request);
			
			var result = ExecuteService(request, endpointAttributes);

			context.Response.WriteToResponse(result, x => JsonDataContractSerializer.Instance.Parse(x), ContentType.Json);
		}

	}
}