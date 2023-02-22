using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabiesSeccondGame.Scenes
{
    public class Scene
    {
        public List<SceneObject> children;
        public Queue<SceneObject> newChildren;

        public Scene ()
        {
            children = new();
            newChildren = new();

            MyGame.RegisterScene(this);
        }

        public void Update ()
        {
            while (newChildren.Count > 0)
            {
                newChildren.Dequeue().Initalize();
            }

            foreach (var child in children)
            {
                child.Update();
            }
        }

        public void Draw ()
        {
            foreach (var child in children)
            {
                child.Draw();
            }
        }

        public void Destroy()
        {
            MyGame.Deregister(this);
        }

        public void Register(SceneObject child)
        {
            if (child.Alive) return;
            children.Add(child);
            newChildren.Enqueue(child);
        }

        public void Deregister(SceneObject child)
        {
            if (!child.Alive) return;
            children.Remove(child);
        }
    }
}
