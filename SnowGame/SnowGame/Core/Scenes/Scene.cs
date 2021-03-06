﻿using System;
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

        /// <summary>
        /// ObjectsManager stores all objects inside this scene.
        /// </summary>
        private ObjectsManager _objectsManager;

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

            // ObjectsManager on each scene, handles references to all objects in this scene.
            _objectsManager = new ObjectsManager();

            // Store all textures in dictionary?  Is there a better way - probably..
            Textures = new Dictionary<string, Texture2D>();

        }
        #endregion
            
        /// <summary>
        /// Called once the state has been loaded. 
        /// </summary>
        public virtual void Initialise() {

        }

        /// <summary>
        /// Called when state is unloaded.
        /// </summary>
        public void Unload() {
            _objectsManager.Clear();
        }


        /// <summary>
        /// Add an object to this scene
        /// </summary>
        /// <param name="obj"></param>
        public void Add( Core.Objects.Core.RenderableObject obj) {
            _objectsManager.Add(obj);
        }

        /// <summary>
        /// Overwritable Update function:
        /// </summary>
        /// <param name="gT"></param>
        public virtual void Update( GameTime gT) {
            _objectsManager.Update(gT);
        }

        /// <summary>
        /// Draws Scene to the game context:
        /// </summary>
        public void Draw( ) {
            spriteBatch.Begin();
            _objectsManager.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
    