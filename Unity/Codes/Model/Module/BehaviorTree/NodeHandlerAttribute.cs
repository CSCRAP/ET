using System;

namespace ET.Codes.Model.Module.BehaviorTree
{
    public class NodeHandlerAttribute
    {
        public Type NodeType { get; }

        public NodeHandlerAttribute(Type type)
        {
            this.NodeType = type;
        }
    }
}