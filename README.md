# Ejemplos con Join,Let y Where utilizando LINQ con C#
		
<p align="justify">LINQ cuyo acrónimo significa <b>Language INtegrated Query</b> es un lenguaje declarativo con una sintaxis tipo SQL para consultar, buscar y manipular datos en estructuras y colecciones de .NET. Estas operaciones denominadas query expressions se aplican a Objetos, Datatables, Archivos XML, entidades, Schemas, llaves de registro, archivos de Excel,Objetos de WMI, etc.</p>
<p align="justify">Desde su aparición como una extensión a la versión 3.5 de Microsoft .NET, ha sido una poderosa herramienta que unifica las técnicas de acceso a datos en un modelo orientado a objetos .NET independiente de la fuente de datos.</p>
<p align="justify">Para ilustrar algunos ejemplos, usaré colecciones de las siguientes clases que representan la relación entre entre una factura y sus detalles como parte de una entidad factura (esto se supone en un sistema de facturación).</p>
<div>
<IMG src="images/fig1.png">
</div><br>
<p>Aquí la imagen del programa en ejecución.</p>
<div>
<IMG src="images/fig2.png">
</div><br>
<p>Aquí la imagen de los datos de ejemplo.</p>
<div>
<IMG src="images/fig3.png">
</div><br>
<h1>El operador <b>Join</b></h1>
<p align="justify">El operador Join funciona para encontrar la intersección entre dos colecciones de datos en base a un criterio, similar al INNER JOIN de SQL.
<p>En este programa las colecciones a unir son:</p>
<pre>
var invoices = InvoiceData.GetInvoices ();
var details = InvoiceData.GetDetails ();
</pre>
<p>Aquí la imagen utilizando Join.</p>
<div>
<IMG src="images/fig4.png">
</div><br>
<h1><b>El operador Let</b></h1>
<p align="justify">
Este operador permite calcular valores cuando se trabaja con múltiples colecciones de datos, en este ejemplo asignamos el valor de la propiedad <i>Subtotal</i> en la clase <i>Invoice</i>.</p>
<!-- Code Let -->
<p>La consulta utilizando <b>Let</b> queda de la siguiente manera:</p>
<p>El resultado al ejecutar este programa es el siguiente:</p>
<div>
<IMG src="images/fig6.png">
</div><br>
<h1><b>El operador Where</b></h1>
<p align="justify">Si necesitamos múltiples criterios de selección podemos agregarlos con la palabra  where justo después de los operadores let y join.</p>
<p>El resultado al ejecutar este programa es el siguiente:</p>
<div>
<IMG src="images/fig5.png">
</div><br>
