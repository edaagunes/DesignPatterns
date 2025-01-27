﻿using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public abstract class Employee
	{
		// Zincirin sonraki halkasının ne olacağını belirledik
		protected Employee NextApprover;
		public void SetNextApprover(Employee superVisor)
		{
			this.NextApprover = superVisor;
		}
		public abstract void ProcessRequest(CustomerProcessViewModel request);
	}
}
