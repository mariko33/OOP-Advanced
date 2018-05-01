using System;
using System.IO;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
	using System.IO;

	public class Reader:IReader
	{
		//private readonly System.IO.StreamReader reader;

		//public Reader(string contents)
		//{
		//	//this.reader = new System.IO.StreamReader(new System.IO.FileStream(contents, FileMode.Open, FileAccess.Read & FileAccess.Write));
            
		//}

	    public string ReadLine()
	    {
	        return Console.ReadLine();
	    }
	}
}