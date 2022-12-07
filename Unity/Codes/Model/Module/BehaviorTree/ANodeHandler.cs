﻿using System;
using UnityEditor.Experimental.GraphView;

namespace ET.Common
{
    public abstract class ANodeHandler<T> : INodeHandler where T : Node
    {
        public async ETTask Run(Blackboard blackboard, Node node)
        {

            try
            {
                await Handle(blackboard, node as T);

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
           
            

        }
        

        public abstract ETTask Handle(Blackboard bd, T t);
        
        
    }
}