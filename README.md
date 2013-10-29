core-net-library
================

Is a set of useful libraries and extensions for microsoft .net.

CoreNetLibrary.Infraestructure
================

...


Adding soap extensions
---------------------
  
Add the Assembly reference to your proyect and in your .config file add this configuration section, change the type attribute value according to the soap extension you want to load:
```xml
  <system.web>
   <webServices>
      <soapExtensionTypes>
        <add type="CoreNetLibrary.Infraestructure.WebServices.Extensions.EncoderExtension, CoreNetLibrary.Infraestructure" priority="1" group="0"/>
      </soapExtensionTypes>
    </webServices>
  </system.web>
```
