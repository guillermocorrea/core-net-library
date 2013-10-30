using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;
using System.IO;

namespace CoreNetLibrary.Infraestructure.WebServices.Extensions
{
    public class UTF8EncoderExtension : SoapExtension
    {
        Stream oldStream;
        Stream newStream;

        // Save the Stream representing the SOAP request or SOAP response into
        // a local memory buffer.
        public override Stream ChainStream(Stream stream)
        {
            oldStream = stream;
            newStream = new MemoryStream();
            return newStream;
        }

        // When the SOAP extension is accessed for the first time, the XML Web
        // service method it is applied to is accessed to store the file
        // name passed in, using the corresponding SoapExtensionAttribute.   
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }

        // The SOAP extension was configured to run using a configuration file
        // instead of an attribute applied to a specific Web service
        // method.
        public override object GetInitializer(Type WebServiceType)
        {
            return null;
        }

        // Receive the file name stored by GetInitializer and store it in a
        // member variable for this specific instance.
        public override void Initialize(object initializer)
        {
        }

        //  If the SoapMessageStage is such that the SoapRequest or
        //  SoapResponse is still in the SOAP format to be sent or received,
        //  save it out to a file.
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                    newStream.Position = 0;
                    Copy(newStream, oldStream);
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    message.ContentType = "application/soap+xml; utf-8";
                    Copy(oldStream, newStream);
                    newStream.Position = 0;
                    break;
                case SoapMessageStage.AfterDeserialize:
                    break;
            }
        }

        void Copy(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from, System.Text.Encoding.GetEncoding("utf-8"));
            TextWriter writer = new StreamWriter(to, System.Text.Encoding.GetEncoding("utf-8"));
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }
    }
}
