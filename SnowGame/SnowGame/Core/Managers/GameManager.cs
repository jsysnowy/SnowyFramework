using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SnowGame.Core.Managers {
   
    public sealed class GameManager {

        #region Private variables
        /// <summary>
        /// Stores reference to the games ContentManager.
        /// </summary>
        private ContentManager _contentManager;

        /// <summary>
        /// Stores reference to the games GraphicsDevice.
        /// </summary>
        private GraphicsDevice _graphicsDevice;

        #endregion

        #region Get and Sets

        /// <summary>
        /// Readonly access to games ContentManager.
        /// </summary>
        public ContentManager Content {
            get {
                return _contentManager;
            }
        }

        /// <summary>
        /// Readonly access to games GraphicsDevice
        /// </summary>
        public GraphicsDevice GraphicsDevice {
            get {
                return _graphicsDevice;
            }
        }

        #endregion

        #region Singleton Initialisation
        private static readonly GameManager instance = new GameManager();
        static GameManager() { }
        private GameManager() { }
        public static GameManager Instance {
            get {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Initialise the GameManager:
        /// </summary>
        /// <param name="content_"></param>
        /// <param name="gd_"></param>
        public void Init( ContentManager content_, GraphicsDevice gd_) {
            _contentManager = content_;
            _graphicsDevice = gd_;
        }
    }

}
