﻿using Sortly.Api.Common.File;
using Sortly.Api.Model.Abstractions;

namespace Sortly.Api.Http
{
    public interface IPayloadResolver 
    {
        /// <summary>
        /// Resolve to either a multipart form payload or a json payload
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        HttpContent ResolveMultiPart(IPhotoRequest request);
    }

    public class PayloadResolver : IPayloadResolver
    {
        private readonly IFileAdapter _fileSystem;

        public PayloadResolver(IFileAdapter fileSystem) 
        {
            _fileSystem = fileSystem;
        }

        public HttpContent ResolveMultiPart(IPhotoRequest request) 
        {
            return request.AsHttpPayload(_fileSystem);
        }
    }
}
