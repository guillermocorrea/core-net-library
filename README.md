core-net-library
================

Set of useful libraries and extensions for microsoft .net.

framework2/CoreNetLibrary.Infraestructure
---------------------

...


### Adding soap extensions
  
Add the Assembly reference to your proyect and in your .config file add this configuration section, change the type attribute value according to the soap extension you want to load:
```xml
  <system.web>
   <webServices>
      <soapExtensionTypes>
        <add type="CoreNetLibrary.Infraestructure.WebServices.Extensions.UTF8EncoderExtension, CoreNetLibrary.Infraestructure" priority="1" group="0"/>
      </soapExtensionTypes>
    </webServices>
  </system.web>
```

Or you can add this attribute to your WebService method(s) or proxy client method(s) you want to instrument.
```
[UTF8EncoderExtension]
```
