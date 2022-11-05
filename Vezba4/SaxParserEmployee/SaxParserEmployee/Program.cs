using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SaxParserEmployee
{

	class Program
	{

		static void Main(string[] args)
		{
			try
			{
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.IgnoreComments = true;
				settings.IgnoreWhitespace = true;
				XmlTextReader readerTXT = new XmlTextReader("Employee.xml");
				XmlReader reader = XmlReader.Create(readerTXT, settings);

				EmployeeParser parser = new EmployeeParser();
				parser.StartDocumet();

				Dictionary<string, string> attributes = null;
				string tagName = string.Empty;				

				while (reader.Read()) // citamo element po element
				{
					reader.MoveToElement(); // pomeramo se do elementa

					switch (reader.NodeType) // proveravamo kog tipa je element
					{
						case XmlNodeType.Element: // ukoliko je u pitanju otvoreni tag
							{
								attributes = new Dictionary<string, string>();								
								tagName = reader.Name;

								if (reader.HasAttributes) // ukoliko imamo atributa citamo sve atribute
								{
									reader.MoveToFirstAttribute(); //pozicioniraj se na prvi atribut

									do
									{

										attributes.Add(reader.Name, reader.Value.ToString()); // dodaj atribut u mapu atributa

									}
									while (reader.MoveToNextAttribute());  // pomeri se do narednog atributa
								}

								parser.StartElement(tagName, attributes);

								break;
							}

						case XmlNodeType.EndElement: // ukoliko je u pitanju zatvoreni tag
							{
								tagName = reader.Name;
								parser.EndElement(tagName);
								break;
							}

						case XmlNodeType.Text: // ukoliko je u pitanju vrednost (tekst) unutar taga
							{
                                parser.Characters(tagName, reader.Value.ToString());
								break;
							}
					}
				}


				List<Employee> employers = null;
				parser.EndDocumet(out employers);

				// write result to console
				Console.WriteLine("Result employers:\n");
				foreach (Employee employee in employers)
				{
					Console.WriteLine(employee.ToString());
				}

				Console.WriteLine("\nParsing finished. Press Enter to exit.");
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message + "  Press Enter to exit.");
				Console.ReadLine();
			}
		}
	}	
}
