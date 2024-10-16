using System;
using System.Collections.Generic;

namespace LinqSamples
{
public static class InvoiceData
{
public static List<Invoice> GetInvoices(){
return new List<Invoice>(){
	new Invoice{
		InvoiceNumber = 2345,
		Created = new DateTime(2002,02,14)
	},
	new Invoice{
		InvoiceNumber = 2346,
		Created = new DateTime(2010,08,13)
	},
	new Invoice{
		InvoiceNumber = 6768,
		Created = new DateTime(2009,06,01)
	},
	new Invoice{
		InvoiceNumber = 6669,
		Created = new DateTime(2001,9,11)
	}
};
}
public static List<InvoiceDetails> GetDetails() {
return new List<InvoiceDetails>(){
	new InvoiceDetails{
	InvoiceNumber = 2345,
		ProductPrice = 83.00M,
		Quantity = 10
	},
	new InvoiceDetails{
		InvoiceNumber = 2346,
		ProductPrice = 75.86M,
		Quantity = 16
	},
	new InvoiceDetails{
		InvoiceNumber = 6768,
		ProductPrice = 88.00M,
		Quantity = 20
	},
	new InvoiceDetails{
		InvoiceNumber = 6669,
		ProductPrice = 666.11M,
		Quantity = 14
	}
};
}
}
}

