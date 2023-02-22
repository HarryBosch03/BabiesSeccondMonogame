using System.Collections.Generic;
using BabiesSeccondGame.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BabiesSeccondGame
{
    public class MyGame : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        
        public static MyGame Instance { get; set; }
        public static List<Scene> Scenes { get; } = new();
        public static Scene ActiveScene { get; set; }
        public static GameTime Time { get; private set; }

        public MyGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            Instance = this;
        }

        protected override void Initialize()
        {
            Drawinator.Initalize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Drawinator.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Time = gameTime;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var scene in Scenes)
            {
                scene.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Time = gameTime;

            GraphicsDevice.Clear(Color.DarkGray);

            foreach (var scene in Scenes)
            {
                scene.Draw();
            }

            Drawinator.Draw();

            base.Draw(gameTime);
        }

        public static void RegisterScene (Scene newScene)
        {
            Scenes.Add(newScene);
            if (ActiveScene == null) ActiveScene = newScene;
        }

        public static void Deregister (Scene oldScene)
        {
            Scenes.Remove(oldScene);
            if (ActiveScene != oldScene) return;

            ActiveScene = Scenes.Count > 0 ? Scenes[0] : null;
        }
    }
}