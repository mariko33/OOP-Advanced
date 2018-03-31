using System;
using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Entites;

namespace SOLID_Exercise.Models.Entites
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;
            
            switch (layoutType)
            {
                case "SimpleLayout":
                    layout=new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout=new XmlLayout();
                    break;
                    default:throw new ArgumentException("Invalid Layout Type");
                        
            }

            return layout;
        }
        
        
    }
}