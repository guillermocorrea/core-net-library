using System;
using System.Collections.Generic;
using System.Text;

namespace CoreNetLibrary.Infraestructure.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new WebReference.IBancorRecaudoWSservice();
            var seq = "4381393571346912" + new Random().Next(1, 9999);
            var req = "<RequestWSDLBancor><DatosBasicos><TipoCanal>8</TipoCanal><TipoTransa/><TipoOperacion/><DirIPOrigen>172.17.200.29</DirIPOrigen><DirIPServidor/><PtoIPServidor/><Aplicacion>WSPR08</Aplicacion><CodEntOrigen>91</CodEntOrigen><CodSedOrigen/><CodEstOrigen/><FecTranOrigen>10/23/2013</FecTranOrigen><HorTranOrigen>12:00:00 </HorTranOrigen><SecOrigen>"+seq+"</SecOrigen><SecReversion/><CodUsuario>123</CodUsuario><CodTransaccion>469</CodTransaccion><CodCausal>00</CodCausal><CodSubCausal>000</CodSubCausal><TipKeyMaestro>0</TipKeyMaestro><KeyMaestroAso/></DatosBasicos><DatosEntrada><TipCert>2</TipCert><NumPrest>4820000043</NumPrest></DatosEntrada></RequestWSDLBancor>";
            var res = proxy.EmitaCertificados(req);
            var r = proxy.ConsDetEstadoCuentaEmpresa(null);
            Console.ReadKey();
        }
    }
}
