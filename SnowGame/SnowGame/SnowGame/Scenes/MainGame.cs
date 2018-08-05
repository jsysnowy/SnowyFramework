using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.SnowGame.Scenes  {
    class MainGame : Core.Scenes.Scene {

        private List<Core.Objects.Core.RenderableObject> promptys;
        Random Random;

        /// <summary>
        /// Creates a new Menu Scene
        /// </summary>
        public MainGame(): base("MainGame") {

            // TODO: Move to new function? Set all the textures this scene will load.
            LoadedTextures = new string[] {
                "promptylogo"
            };

            Random = new Random();
        }

        /// <summary>
        /// Initialises this Scene.
        /// </summary>
        public override void Initialise() {
            promptys = new List<Core.Objects.Core.RenderableObject>();

            for ( int i = 0; i < 100; i++) {
                Core.Objects.Core.RenderableObject prompty = new Core.Objects.Core.RenderableObject();
                prompty.Texture = Textures["promptylogo"];
                prompty.X = -300 + i;
                prompty.Y = -500 + i;
                Add(prompty);
                promptys.Add(prompty);
            }

        }


        /// <summary>
        /// Update this scene:
        /// </summary>
        /// <param name="gT"></param>
        public override void Update(GameTime gT) {
            for ( int i = 0; i < promptys.Count; i++) {
            promptys[i].X = Core.Config.GameConfiguration.DEFAULT_WIDTH/2  +(float)Math.Cos(gT.TotalGameTime.TotalMilliseconds/ (600*Random.NextDouble())) * 300.0f;
            promptys[i].Y = Core.Config.GameConfiguration.DEFAULT_HEIGHT / 2 + (float)Math.Sin(gT.TotalGameTime.TotalMilliseconds / (500*Random.NextDouble())) * 300.0f;

            }

        }
    }
}
