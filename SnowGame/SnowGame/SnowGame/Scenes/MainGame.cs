﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.SnowGame.Scenes  {
    class MainGame : Core.Scenes.Scene {

        private Vector2 position;

        /// <summary>
        /// Creates a new Menu Scene
        /// </summary>
        public MainGame(): base("MainGame") {

            // TODO: Move to new function? Set all the textures this scene will load.
            LoadedTextures = new string[] {
                "promptylogo"
            };

            position = new Vector2(20, 20);

        }

        /// <summary>
        /// Update this scene:
        /// </summary>
        /// <param name="gT"></param>
        public override void Update(GameTime gT) {
            position.X = Core.Config.GameConfiguration.DEFAULT_WIDTH/2  +(float)Math.Cos(gT.TotalGameTime.TotalMilliseconds/600) * 300.0f;
            position.Y = Core.Config.GameConfiguration.DEFAULT_HEIGHT / 2 + (float)Math.Sin(gT.TotalGameTime.TotalMilliseconds / 500) * 300.0f;

        }

        /// <summary>
        /// Draw this scene:
        /// </summary>
        public override void Draw() {
            spriteBatch.Begin();

            spriteBatch.Draw(Textures["promptylogo"], position, Color.White);

            spriteBatch.End();
        }
    }
}
