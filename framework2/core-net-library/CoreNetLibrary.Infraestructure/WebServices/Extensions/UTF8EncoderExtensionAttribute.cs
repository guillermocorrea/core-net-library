using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;

namespace CoreNetLibrary.Infraestructure.WebServices.Extensions
{
    // Create a SoapExtensionAttribute for the SOAP Extension that can be
    // applied to a Web service method.
    [AttributeUsage(AttributeTargets.Method)]
    public class UTF8EncoderExtensionAttribute : SoapExtensionAttribute
    {
        private int priority;

        public override Type ExtensionType
        {
            get { return typeof(UTF8EncoderExtension); }
        }

        public override int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
    }
}
