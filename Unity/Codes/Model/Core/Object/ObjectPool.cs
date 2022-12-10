using System;
using System.Collections.Generic;

namespace ET
{
    public class ObjectPool: IDisposable
    {
        
        /*
         ET6的对象池逻辑
        private readonly Dictionary<Type, Queue<Entity>> pool = new Dictionary<Type, Queue<Entity>>();
        
        public static ObjectPool Instance = new ObjectPool();
        
        private ObjectPool()
        {
        }
        public Entity Fetch(Type type)
        {
            Queue<Entity> queue = null;
            if (!pool.TryGetValue(type, out queue))
            {
                return Activator.CreateInstance(type) as Entity;
            }

            if (queue.Count == 0)
            {
                return Activator.CreateInstance(type) as Entity;
            }
            return queue.Dequeue();
        }

        public void Recycle(Entity obj)
        {
            Type type = obj.GetType();
            Queue<Entity> queue = null;
            if (!pool.TryGetValue(type, out queue))
            {
                queue = new Queue<Entity>();
                pool.Add(type, queue);
            }
            queue.Enqueue(obj);
        }

*/
        
        //ET7版本的对象池
        private readonly Dictionary<Type, Queue<object>> pool = new Dictionary<Type, Queue<object>>();
        
        public static ObjectPool Instance = new ObjectPool();
        public T Fetch<T>() where T: class
        {
            return this.Fetch(typeof (T)) as T;
        }

        public object Fetch(Type type)
        {
            Queue<object> queue = null;
            if (!pool.TryGetValue(type, out queue))
            {
                return Activator.CreateInstance(type);
            }

            if (queue.Count == 0)
            {
                return Activator.CreateInstance(type);
            }
            return queue.Dequeue();
        }

        public void Recycle(object obj)
        {
            Type type = obj.GetType();
            Queue<object> queue = null;
            if (!pool.TryGetValue(type, out queue))
            {
                queue = new Queue<object>();
                pool.Add(type, queue);
            }

            // 一种对象最大为1000个
            if (queue.Count > 1000)
            {
                return;
            }
            queue.Enqueue(obj);
        }
        public void Dispose()
        {
            this.pool.Clear();
        }
    }
}