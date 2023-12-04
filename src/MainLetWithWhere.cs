using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSamples
{
public class MainLetWithWhere
{
public static void Main(string[] args)
{
	var invoices = InvoiceData.GetInvoices ();
	var details = InvoiceData.GetDetails ();
	Console.WriteLine ("Working with let and where.");
	var queryLet = from invoice in invoices
	join detail in details on
	invoice.InvoiceNumber equals detail.InvoiceNumber
	let subtotal = detail.ProductPrice * detail.Quantity
	where detail.ProductPrice > 80 && detail.ProductPrice < 90
	select new Invoice
	{
		InvoiceNumber = invoice.InvoiceNumber,
		Created = invoice.Created,
		Details = new InvoiceDetails
		{
			InvoiceNumber = detail.InvoiceNumber,
			ProductPrice = detail.ProductPrice,
			Quantity = detail.Quantity
		},
		Subtotal = subtotal
	};
	foreach (Invoice item in queryLet) 
	{
		Console.WriteLine("+---------------------------------+");
		Console.WriteLine("Invoice number: {0}",item.InvoiceNumber);
		Console.WriteLine("Invoice date: {0:dd/MM/yyyy}",item.Created);
		Console.WriteLine("ProductPrice: {0:C}",item.Details.ProductPrice);
		Console.WriteLine("Quantity: {0}",item.Details.Quantity);
		Console.WriteLine("Subtotal: {0:C}",item.Subtotal);
	}
}
}
}

