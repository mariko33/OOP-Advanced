using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string Details()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine(base.Details());
            sb.AppendLine(string.Join(Environment.NewLine, this.Documents));
            
            return sb.ToString().Trim();
        }
    }
}
