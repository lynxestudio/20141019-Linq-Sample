using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSamples
{
class MainClass
{
public static void Main (string[] args)
{
	var invoices = InvoiceData.GetInvoices ();
	var details = InvoiceData.GetDetails ();
	Console.WriteLine ("Working with Join.");
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
	};
	foreach (Invoice item in queryjoin) 
	{
	Console.WriteLine("+---------------------------------+");
	Console.WriteLine("Invoice number {0} ",item.InvoiceNumber);
	Console.WriteLine("Invoice date {0:dd/MM/yyyy}",item.Created);
	Console.WriteLine("ProductPrice {0:C}",item.Details.ProductPrice);
	Console.WriteLine("Quantity {0}",item.Details.Quantity);
	}
}


}
}
