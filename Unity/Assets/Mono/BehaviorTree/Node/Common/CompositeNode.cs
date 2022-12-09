using System;
using System.Collections.Generic;

namespace ET.Common
{
    [Serializable]
    public abstract class CompositeNode : Node
    {
        
        protected CompositeNode(int Id) : base(Id)
        {
          
        }



        public readonly List<Node> Childs  = new List<Node>();

    }
}