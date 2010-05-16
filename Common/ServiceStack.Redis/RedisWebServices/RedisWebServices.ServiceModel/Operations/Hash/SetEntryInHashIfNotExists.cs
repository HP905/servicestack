﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceInterface.ServiceModel;

namespace RedisWebServices.ServiceModel.Operations.Hash
{
	[DataContract]
	public class SetEntryInHashIfNotExists
		: IHasStringId
	{
		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public string Key { get; set; }

		[DataMember]
		public string Value { get; set; }
	}

	[DataContract]
	public class SetEntryInHashIfNotExistsResponse
	{
		public SetEntryInHashIfNotExistsResponse()
		{
			this.ResponseStatus = new ResponseStatus();
		}

		[DataMember]
		public bool Result { get; set; }

		[DataMember]
		public ResponseStatus ResponseStatus { get; set; }
	}
}