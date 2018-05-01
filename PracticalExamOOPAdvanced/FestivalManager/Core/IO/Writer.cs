using System;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
	public class Writer:IWriter
	{
		//private readonly System.IO.StringReader reader;

		//public Writer(string contents)
		//{
		//	this.reader = new System.IO.StringReader(contents);
		//}

		//public string ReadLine() => this.reader.ReadLine();
	    public void WriteLine(string contents)
	    {
	        Console.WriteLine(contents);
	    }

	    public void Write(string contents)
	    {
	        Console.Write(contents);
	    }
	}
}