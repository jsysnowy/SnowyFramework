using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

/// <summary>
/// Loader class has all functionality to handle loading assets for scenes etc etc.
/// </summary>

namespace SnowGame.Loader {
    public class Loader {

        /// <summary>
        /// Stores the games ContentManager used to handle loading.
        /// </summary>
        private ContentManager _content;
        

        /// <summary>
        /// Creates a new instance of loader.
        /// </summary>
        public Loader() {
            // Store content from GameManager:
            _content = Core.Game.GameManager.Instance.Content;
        }
   

        /// <summary>
        /// Loads current scene:
        /// </summary>
        public void loadScene( Core.Scenes.Scene scene ) {
            // Setup new SpriteBatch:
            SpriteBatch _spriteBatch = new SpriteBatch( Core.Game.GameManager.Instance.GraphicsDevice );

            // Create dictionary for textures..?
            Dictionary<string, Texture2D> textureDict = new Dictionary<string, Texture2D>();

            // Load the scenes Images:
            for (int i = 0; i < scene.LoadedTextures.Length; i++) {
                System.Diagnostics.Trace.WriteLine("Loaded: " + scene.LoadedTextures[i]);
                textureDict[scene.LoadedTextures[i]] =  this._content.Load<Texture2D>(scene.LoadedTextures[i]);               
            }

            scene.spriteBatch = _spriteBatch;
            scene.Textures = textureDict;
        }
            
        /// <summary>
        /// Sets current scene:
        /// </summary>
        public void unloadScene( Core.Scenes.Scene scene ) {
            this._content.Unload();
        }
    }
}
