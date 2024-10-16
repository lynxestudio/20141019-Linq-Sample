using System;
using System.Runtime.Intrinsics.Arm;
using LinqSamples;

string? readResult;
string menuSelection = "";
var invoices = InvoiceData.GetInvoices ();
var details = InvoiceData.GetDetails ();

do
{
		Console.Clear();
		Console.WriteLine();
		Console.WriteLine(" +----------------------------------------------------------+");
		Console.WriteLine(" | Welcome to Linq sample. Your main menu options are:  |");
		Console.WriteLine(" | 1. Show Data                                         |");
		Console.WriteLine(" | 2. Join                                              |");
		Console.WriteLine(" | 3. Where & Let                                       |");
		Console.WriteLine(" | 4. Let                                               |");
		Console.WriteLine(" +------------------------------------------------------+");
		Console.Write("[ Enter your selection number (or type Exit to exit) ] ");
		readResult = Console.ReadLine();
		if (readResult != null)
		{
			menuSelection = readResult.ToLower();	
			if (menuSelection == "exit")
			break;
			//Begin
			switch(menuSelection)
			{
				case "1":
					ShowData();
				break;
				case "2":
					Join();
				break;
				case "3":
					Where();
				break;
				case "4":
					Let();
				break;				
				default:
					ShowData();
					break;
			}
			//End
		}
}while(menuSelection != "exit");

void ShowData()
{
	Console.WriteLine("Invoices:");
	Console.WriteLine ("\tNumber \tCreated");
	foreach (var item in invoices)
	{
		
		Console.WriteLine ("\t" + item.InvoiceNumber + "\t" + item.Created.ToString("dd/MM/yyyy"));	
	}
	Console.WriteLine("");
	Console.WriteLine("Details:");
	Console.WriteLine ("\tNumber \tPrice\tQuantity");
	foreach (var item in details)
	{
		
		Console.WriteLine ("\t" + item.InvoiceNumber + "\t" + item.ProductPrice + "\t" + item.Quantity);
	}
	Console.WriteLine("Press [ENTER] to return to main menu.");
	Console.ReadLine();
}

void Where()
{
	Console.WriteLine("Working with where and let...");
	Console.Write("[ Enter a minimum price ] ");
	var a = Console.ReadLine();
	Console.Write("[ Enter a maximum price ] ");
	var b = Console.ReadLine();
	decimal minimumPrice = 0;
	Decimal.TryParse(a, out minimumPrice);
	decimal maximumPrice = 0;
	Decimal.TryParse(b, out maximumPrice);

	var collection = from invoice in invoices
	join detail in details on
	invoice.InvoiceNumber equals detail.InvoiceNumber
	let subtotal = detail.ProductPrice * detail.Quantity
	where detail.ProductPrice > minimumPrice && detail.ProductPrice < maximumPrice
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
	Console.WriteLine("\tNumber\tDate\t\tPrice\tQuantity\tSubtotal");
	foreach (var item in collection)
	{
		
		Console.WriteLine($"\t{item.InvoiceNumber}\t{item.Created.ToString("dd/MM/yyyy")}\t{item.Details.ProductPrice}\t{item.Details.Quantity}\t\t{item.Subtotal}");
	}
	Console.WriteLine("Press [ENTER] to return to main menu.");
	Console.ReadLine();
}

void Let()
{
	Console.WriteLine("Working with let...");
	var collection = from invoice in invoices
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
		},
		Subtotal = subtotal
	};
	Console.WriteLine("\tNumber\tDate\tPrice\tQuantity\tSubtotal");
	foreach(var item in collection)
	{
		
		Console.WriteLine($"\t{item.InvoiceNumber}\t{item.Created.ToString("dd/MM/yyyy")}\t{item.Details.ProductPrice}\t{item.Details.Quantity}\t{item.Subtotal}");
	}
	Console.WriteLine("Press [ENTER] to return to main menu.");
	Console.ReadLine();
}

void Join()
{
	Console.WriteLine("Working with join...");
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
	Console.WriteLine("\tNumber\tDate\t\tPrice\tQuantity");
	foreach (Invoice item in queryjoin) 
	{
		Console.WriteLine($"\t{item.InvoiceNumber}\t{item.Created.ToString("dd/MM/yyyy")}\t{item.Details.ProductPrice}\t{item.Details.Quantity}");
	}
	Console.WriteLine("Press [ENTER] to return to main menu.");
	Console.ReadLine();
}