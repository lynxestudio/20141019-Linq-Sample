using System;

namespace LinqSamples
{
	public sealed class Invoice
	{
		public uint InvoiceNumber {set;get;}
		public DateTime Created { set; get; }
		public InvoiceDetails? Details { set; get; }
		public decimal Subtotal {set;get;}
	}
}

