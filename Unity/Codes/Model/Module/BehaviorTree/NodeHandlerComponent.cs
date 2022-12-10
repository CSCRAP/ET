using System;
using System.Collections.Generic;
using ET.Common;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class NodeHandlerComponent : Entity, IAwake, ILoad
    {
                
        public static NodeHandlerComponent Instance { get; set; }
		
        public Dictionary<Type, INodeHandler> AllNodeHandlers;
        
        
        
    }
}