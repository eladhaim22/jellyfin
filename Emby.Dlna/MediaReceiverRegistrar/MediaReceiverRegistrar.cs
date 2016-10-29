﻿using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Configuration;
using MediaBrowser.Controller.Dlna;
using Emby.Dlna.Service;
using MediaBrowser.Model.Logging;
using System;
using System.Collections.Generic;

namespace Emby.Dlna.MediaReceiverRegistrar
{
    public class MediaReceiverRegistrar : BaseService, IMediaReceiverRegistrar, IDisposable
    {
        private readonly IServerConfigurationManager _config;

        public MediaReceiverRegistrar(ILogger logger, IHttpClient httpClient, IServerConfigurationManager config)
            : base(logger, httpClient)
        {
            _config = config;
        }

        public string GetServiceXml(IDictionary<string, string> headers)
        {
            return new MediaReceiverRegistrarXmlBuilder().GetXml();
        }

        public ControlResponse ProcessControlRequest(ControlRequest request)
        {
            return new ControlHandler(
                _config,
                Logger)
                .ProcessControlRequest(request);
        }

        public void Dispose()
        {

        }
    }
}
