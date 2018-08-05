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
                "backgroundgrass",
                "character",
                "bow",
                "arrow"
            };

            Random = new Random();
        }

        /// <summary>
        /// Initialises this Scene.
        /// </summary>
        public override void Initialise() {
            promptys = new List<Core.Objects.Core.RenderableObject>();

            Core.Objects.Core.RenderableObject background = new Core.Objects.Core.RenderableObject();
            background.Texture = Textures["backgroundgrass"];
            background.X = 0 ;
            background.Y = 0;
            Add(background);

            Core.Objects.Core.RenderableObject character = new Core.Objects.Core.RenderableObject();
            Add(character);
            character.Texture = Textures["character"];
            character.X = 100;
            character.Y = 100;
            character.AddModule<Core.Objects.Modules.MoveRightModule>();

            Core.Objects.Core.RenderableObject bow = new Core.Objects.Core.RenderableObject();
            character.Add(bow);
            bow.Texture = Textures["bow"];
            bow.X = 0;
            bow.Y = 0;

            Core.Objects.Core.RenderableObject arrow = new Core.Objects.Core.RenderableObject();
            bow.Add(arrow);
            arrow.Texture = Textures["arrow"];
            arrow.X = 0;
            arrow.Y = 0;
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
