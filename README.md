# Ejemplos con Join,Let y Where utilizando LINQ con C#

LINQ cuyo acrónimo significa Language INtegrated Query es un lenguaje declarativo con una sintaxis tipo SQL para consultar, buscar y manipular datos en estructuras y colecciones de .NET. Estas operaciones denominadas query expressions se aplican a Objetos, Datatables, Archivos XML, entidades, Schemas, llaves de registro, archivos de Excel,Objetos de WMI, etc.

Desde su aparición como una extensión a la versión 3.5 de Microsoft .NET, ha sido una poderosa herramienta que unifica las técnicas de acceso a datos en un modelo orientado a objetos .NET independiente de la fuente de datos.

Para ilustrar algunos ejemplos, usaré colecciones de las siguientes clases que representan la relación entre entre una factura y sus detalles como parte de una entidad factura (esto se supone en un sistema de facturación).



Con el siguiente código cargaré algunos datos para los ejemplos:



Bien ahora unos programas como ejemplos.

El operador Join
El operador Join funciona para encontrar la intersección entre dos colecciones de datos en base a un criterio, similar al INNER JOIN de SQL. El código fuente del ejemplo es el siguiente:



En este código las colecciones a unir son:

var invoices = InvoiceData.GetInvoices ();
var details = InvoiceData.GetDetails ();
El código de la consulta utilizando Join es el siguiente:

var queryjoin = from invoice in invoices
  join detail in details on invoice.InvoiceNumber equals detail.InvoiceNumber
 select new Invoice
 {
  InvoiceNumber = invoice.InvoiceNumber,
  Created = invoice.Created,
  Details = new InvoiceDetails
  {
   InvoiceNumber = detail.InvoiceNumber,
   ProductPrice = detail.ProductPrice,
   Quantity = detail.Quantity
  }
 } ;
Para compilar y ejecutar el programa con Mono se utilizan los siguientes comandos:

mcs /t:library Invoice.cs InvoiceData.cs InvoiceDetails.cs /o:LinqSamples.dll
mcs -r:Invoice.dll Main.cs
mono Main.exe
Aquí la imagen del programa en ejecución.



El operador Let
Este operador permite calcular valores cuando se trabaja con múltiples colecciones de datos, en este ejemplo asignamos el valor de la propiedad Subtotal en la clase Invoice.

El código fuente del programa es el siguiente:



La consulta utilizando Let queda de la siguiente manera:

var queryLet = from invoice in invoices
 join detail in details on
 invoice.InvoiceNumber equals detail.InvoiceNumber
 let subtotal = detail.ProductPrice * detail.Quantity
 select new Invoice
 {
  InvoiceNumber = invoice.InvoiceNumber,
  Created = invoice.Created,
  Details = new InvoiceDetails
  {
   InvoiceNumber = detail.InvoiceNumber,
   ProductPrice = detail.ProductPrice,
   Quantity = detail.Quantity
  } ,
  Subtotal = subtotal
 } ;
El resultado al ejecutar este programa es el siguiente:



El operador Where
Si necesitamos múltiples criterios de selección podemos agregarlos con la palabra where justo después de los operadores let y join.

El código de la consulta utilizando Let, Join y Where es el siguiente:



El resultado al ejecutar este programa es el siguiente:
