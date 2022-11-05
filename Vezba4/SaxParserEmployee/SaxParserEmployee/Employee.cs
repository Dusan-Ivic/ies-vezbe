using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaxParserEmployee
{
	public class Employee
	{
		private string typeOfEmployment = string.Empty;
		private string name = string.Empty;

		public string TypeOfEmployment
		{
			get { return typeOfEmployment; }
			set { typeOfEmployment = value; }
		}
		
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public override string ToString()
		{
			return string.Format("Employee:\t Name - {0},\t TypeOfEmployment - {1}", name, typeOfEmployment);
		}

	}
}
