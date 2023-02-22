using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabiesSeccondGame.Scenes;

namespace BabiesSeccondGame
{
    public abstract class SceneObject
    {
        public string Name { get; set; }

        public bool Alive { get; private set; }
        public Scene Scene { get; private set; }

        public SceneObject() : this(MyGame.ActiveScene) { }

        public SceneObject (Scene scene)
        {
            Scene = scene;
            Scene.Register(this);

            Alive = true;
        }

        public virtual void Initalize() { }
        public virtual void Update() { }
        public virtual void Draw() { }

        public void Destroy ()
        {
            Scene.Deregister(this);
            Scene = null;
            
            Alive = false;
        }
    }
}
