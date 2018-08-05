using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.SnowGame.Scenes  {
    class MainGame : Core.Scenes.Scene {

        private List<Core.Objects.Base.RenderableObject> promptys;
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
            promptys = new List<Core.Objects.Base.RenderableObject>();

            Core.Objects.Base.RenderableObject background = new Core.Objects.Base.RenderableObject();
            background.Texture = Textures["backgroundgrass"];
            background.X = 0 ;
            background.Y = 0;
            Add(background);

            Core.Objects.Base.RenderableObject character = new Core.Objects.Base.RenderableObject();
            Add(character);
            character.Texture = Textures["character"];
            character.X = 100;
            character.Y = 100;
            character.AddModule<Core.Modules.PlayerController>();
            character.AddModule<Core.Modules.MoveRightModule>();

            Core.Objects.Base.RenderableObject bow = new Core.Objects.Base.RenderableObject();
            character.Add(bow);
            bow.Texture = Textures["bow"];
            bow.X = 90;
            bow.Y = 60;

            Core.Objects.Base.RenderableObject arrow = new Core.Objects.Base.RenderableObject();
            bow.Add(arrow);
            arrow.Texture = Textures["arrow"];
            arrow.X = 5;
            arrow.Y = 50;
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
