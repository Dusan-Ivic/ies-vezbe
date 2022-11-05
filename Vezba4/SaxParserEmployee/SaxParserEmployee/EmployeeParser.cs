using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SaxParserEmployee
{
	public class EmployeeParser
	{		
		private List<Employee> resultEmployers = null;
		private string characters = string.Empty;
		private Employee currentEmployee = null;

		public EmployeeParser()
		{			
		}

		public void StartDocumet()
		{
			resultEmployers = new List<Employee>();
		}

		public void StartElement(string tagName, Dictionary<string, string > attributes)
		{
			characters = string.Empty;

			if(String.Equals(tagName, "Employee")) 
			{ 
				currentEmployee = new Employee(); 
				currentEmployee.TypeOfEmployment = attributes["typeOfEmployment"]; 
			}			
		}

		public void Characters(string tagName, string xmlCharacters)
		{
            if (String.Equals(tagName, "Name"))
            {
                characters = xmlCharacters;
            }
		}

		public void EndElement(string tagName)
		{
			if(String.Equals(tagName, "Employee"))  
			{ 
				resultEmployers.Add(currentEmployee); 
			}
			else if (String.Equals(tagName, "Name"))
			{
				currentEmployee.Name = characters;
			}
		}

		public void EndDocumet(out List<Employee> result)
		{
			result = resultEmployers;
		}
	}
}
