using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.Core.Scenes {
    public class Scene {
        #region ClassParams

        /// <summary>
        /// Stores the name of this scene: this is used to access Scene through SceneManager.
        /// </summary>
        private readonly string _sceneName;
            
        /// <summary>
        /// Stores array of all loadedTextures required for this scene.
        /// </summary>
        public string[] _loadedTextures;

        /// <summary>
        /// Store Spritebatch for this Scene..
        /// </summary>
        public SpriteBatch spriteBatch { get; set; }

        /// <summary>
        /// Dictionary reference to all loaded textures in this scene. Probs will change to some interface kinda thing..?
        /// </summary>
        public Dictionary<string, Texture2D> Textures { get; set; }

        #endregion

        #region Get/Sets

        /// <summary>
        /// Readonly access for _sceneName param.
        /// </summary>
        public string Name {
            get {
                return _sceneName;
            }
        }

        /// <summary>
        /// Readonly access for all textures to be loaded with this scene.
        /// </summary>
        public string[] LoadedTextures {
            get {
                if (_loadedTextures == null) {
                    return new string[0];
                } else {
                    return _loadedTextures;
                }
            }
            set {
                this._loadedTextures = value;
            }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Create scene with passed in name, name used for management.
        /// </summary>
        /// <param name="name"></param>
        public Scene(string name) {
            // Store Scenes name:
            _sceneName = name;

            // Store all textures in dictionary?  Is there a better way - probably..
            Textures = new Dictionary<string, Texture2D>();
        }
        #endregion

        #region Loading Scene Assets


        #endregion

        /// <summary>
        /// Overwritable Update function:
        /// </summary>
        /// <param name="gT"></param>
        public virtual void Update( GameTime gT) {
            
        }

        /// <summary>
        /// Draws Scene to the game context:
        /// </summary>
        public virtual void Draw( ) {

        }
    }
}
    