﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceDemo.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
