using System;
using System.Collections.Generic;
using ET.Codes.Model.Module.BehaviorTree;
using ET.Common;


namespace ET
{
    [FriendClass(typeof (NodeHandlerComponent))]
    public static class NodeHandlerComponentSystem
    {


        [ObjectSystem]
        public class NodeHandlerComponentAwakeSystem: AwakeSystem<NodeHandlerComponent>
        {
            public override void Awake(NodeHandlerComponent self)
            {
                NodeHandlerComponent.Instance = self;
                self.Init();
            }
        }

        public class NodeHandlerComponentLoadSystem: LoadSystem<NodeHandlerComponent>
        {
            public override void Load(NodeHandlerComponent self)
            {
                self.Init();
            }
        }


        private static void Init(this NodeHandlerComponent self)
        {
            self.AllNodeHandlers = new Dictionary<Type, INodeHandler>();


            var baseType = typeof (INodeHandler);
            foreach (Type type in Game.EventSystem.GetTypes(typeof (NodeHandlerAttribute)))
            {
                if (type.IsAssignableFrom(baseType))
                {
                    throw new Exception($"{type.FullName} 没有实现INodeHandler类");
                }

                INodeHandler obj = (INodeHandler) Activator.CreateInstance(type);
                self.AllNodeHandlers[type] = obj;
            }

        }

        public static void Run<T>(this NodeHandlerComponent self, Entity entity, BTEventType eventType)
        {
            if (!self.AllNodeHandlers.TryGetValue(typeof (T), out var nodeHandler))
            {
                throw new Exception($"没有{typeof (T).FullName}类型相应的NodeHandler");
            }
            
            Blackboard blackboard = ObjectPool.Instance.Fetch<Blackboard>();

            Node node  = (Node) Activator.CreateInstance(typeof (T));
           
            nodeHandler.Run(blackboard, node).Coroutine();

            ObjectPool.Instance.Recycle(blackboard);
            

        }



    }

}