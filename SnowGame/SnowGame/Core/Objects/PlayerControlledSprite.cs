using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnowGame.Core.Objects {
    public class PlayerControlledSprite : Base.RenderableObject {

        #region Modules
        /// <summary>
        /// PlayerController module is stored and used by this sprite.
        /// </summary>
        private Core.Modules.PlayerController _playerController;
        #endregion

        #region getters/setters.
        public Core.Modules.PlayerController PlayerController {
            get {
                return _playerController;
            }
        }
        #endregion
        /// <summary>
        /// Create a new PlayerControlledSprite!
        /// </summary>
        /// <param name="playerIndex"></param>
        PlayerControlledSprite( PlayerIndex playerIndex ) {
            // Add a player controller and store it.
            _playerController = this.AddModule<Core.Modules.PlayerController>();
            _playerController.setPlayerIndex(playerIndex);
        }
    }
}
