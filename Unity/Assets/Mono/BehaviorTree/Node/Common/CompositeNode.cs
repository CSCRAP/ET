using System.Collections.Generic;

namespace ET.Common
{
    public class CompositeNode : Node
    {
        
        public CompositeNode(long Id) : base(Id)
        {
          
        }
        
       
        
        public List<Node> Childs = new List<Node>();
        
    }
}