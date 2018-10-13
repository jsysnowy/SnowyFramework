using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.SnowGame.Scenes  {
    class MainGame : Core.Scenes.Scene {

        public static MainGame Instance;
        /// <summary>
        /// Arrow fired..?
        /// </summary>
        public Core.Objects.Base.RenderableObject character;

        /// <summary>
        /// Creates a new Menu Scene
        /// </summary>
        public MainGame(): base("MainGame") {

            MainGame.Instance = this;

            // TODO: Move to new function? Set all the textures this scene will load.
            LoadedTextures = new string[] {
                "backgroundgrass",
                "character",
                "bow",
                "arrow"
            };

        }

        /// <summary>
        /// Initialises this Scene.
        /// </summary>
        public override void Initialise() {

            Core.Objects.Base.RenderableObject background = new Core.Objects.Base.RenderableObject();
            background.Texture = Textures["backgroundgrass"];
            background.X = 0 ;
            background.Y = 0;
            Add(background);

            character = new Core.Objects.Base.RenderableObject();
            Add(character);
            character.Texture = Textures["character"];
            character.X = 100;
            character.Y = 100;
            // character.AddModule<Core.Modules.PlayerController>();
            character.AddModule<Core.Modules.MoveRightModule>();
            character.AddModule<Core.Modules.CollisionModule>();

            Core.Objects.Base.RenderableObject bow = new Core.Objects.Base.RenderableObject();
            Add(bow);
            bow.Texture = Textures["bow"];
            bow.X = 600;
            bow.Y = 60;
            bow.AddModule<Core.Modules.CollisionModule>();
        }

        public void fireArrow(Vector2 direction) {
            Core.Objects.Base.RenderableObject arrow = new Core.Objects.Base.RenderableObject();
            Add(arrow);
            arrow.X = character.X + 35;
            arrow.Y = character.Y + 100;
            arrow.Texture = Textures["arrow"];
            System.Diagnostics.Trace.WriteLine(direction);
            arrow.AddModule<Core.Modules.ProjectileComponent>();
            arrow.GetModule<Core.Modules.ProjectileComponent>().Direction = direction;
        }



        /// <summary>
        /// Update this scene:
        /// </summary>
        /// <param name="gT"></param>
        public override void Update(GameTime gT) {
            defaultCamera.X = character.X;
            defaultCamera.Y = character.Y;
            base.Update(gT);
        }
    }
}
