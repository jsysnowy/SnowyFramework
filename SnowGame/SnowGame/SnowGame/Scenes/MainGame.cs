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

            for ( int i = 0; i < 10; i++) {
                Core.Objects.Core.RenderableObject prompty = new Core.Objects.Core.RenderableObject();
                prompty.Texture = Textures["promptylogo"];
                prompty.X = 0 ;
                prompty.Y =  i;
                Add(prompty);
                promptys.Add(prompty);


                prompty.AddModule<Core.Objects.Modules.MoveRightModule>();
                prompty.AddModule<Core.Objects.Modules.MoveDownModules>();
            }

        }


        /// <summary>
        /// Update this scene:
        /// </summary>
        /// <param name="gT"></param>
        public override void Update(GameTime gT) {
    

            base.Update(gT);
        }
    }
}
