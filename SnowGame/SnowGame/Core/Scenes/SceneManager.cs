using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SnowGame.Core.Scenes {
    public sealed class SceneManager {
        #region Class Field
        /// <summary>
        /// Stores instance of sceneLoader, used to load and 
        /// </summary>
        private Loader.Loader _sceneLoader;

        /// <summary>
        /// Stores the currently active scene.
        /// </summary>
        private Scene _currentActiveScene;

        /// <summary>
        /// Stores list of all scenes added to SceneManager.
        /// </summary>
        private List<Scene> _scenes;

        #endregion

        #region Singleton Initialisation
        private static readonly SceneManager instance = new SceneManager();
        static SceneManager() {}
        private SceneManager() { Init(); }
        public static SceneManager Instance {
            get {
                return instance;
            }
        }
        #endregion

        #region Public functions
        /// <summary>
        /// Initialises SceneManager:
        /// </summary>
        public void Init() {
            // Create instance of Loader, used to load Scenes:
            _sceneLoader = new Loader.Loader();

            // Create list of all scenes:
            _scenes = new List<Scene>();
        }

        /// <summary>
        /// Add a scene to this SceneManager.
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        public bool AddScene( Scene scene ) {
            for ( int i = 0; i < _scenes.Count; i++) {
                if ( _scenes[i].Name == scene.Name ) {
                    return false;
                }
            }
            System.Diagnostics.Trace.WriteLine("Scene added: " + scene.Name);
            _scenes.Add(scene);
            return true;
        }
            

        /// <summary>
        /// Tell passed in scene to activate.
        /// </summary>
        /// <param name="scene"></param>
        public bool ActivateScene( Scene scene ) {
            if ( AddScene(scene) ) {
                _activateScene(scene);
                return true;
             } else {
                _activateScene(scene);
                System.Diagnostics.Trace.WriteLine("Returned false");
                return false;
            }
        }
            
        /// <summary>
        /// Tell scene with passed in name to activate.
        /// </summary>
        /// <param name="sceneName"></param>
        public bool ActivateScene ( string sceneName ) {
            for (int i = 0; i < _scenes.Count; i++) {
                if (_scenes[i].Name == sceneName) {
                    _activateScene(_scenes[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

        /// <summary>
        /// Updates the current scene:
        /// </summary>
        /// <param name="gT"></param>
        public void Update( GameTime gT ) {
            if (_currentActiveScene != null) {
                _currentActiveScene.Update(gT);// derp
            }
        } 

        /// <summary>
        /// Draws the current scene
        /// </summary>
        public void Draw (  ) {
            if ( _currentActiveScene != null) {
            _currentActiveScene.Draw();

            } 
        }

        #region Private Functions
        /// <summary>
        /// Previous scene is unloaded, new scene is activated and loaded.
        /// </summary>
        /// <param name="scene"></param>
        private void _activateScene( Scene scene ) {

            // Unload a scene if one is already loaded:
            if ( _currentActiveScene != null) {
                _currentActiveScene.Unload();
                _sceneLoader.unloadScene(_currentActiveScene);
            }

            // Set current active scene:
            _currentActiveScene = scene;

            // Load all content for new scene:
            _sceneLoader.loadScene(_currentActiveScene);

            // Initialises the scene:
            _currentActiveScene.Initialise();
        }
        #endregion


    }
}
