using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnowGame.Core.Modules {
    public class PlayerController : Base.Module {

        /// <summary>
        /// Stores InteractionManager associated with this PlayerController.
        /// </summary>
        private Managers.InteractionManager _interactionManager;


        /// <summary>
        ///  Create a new PlayerController module.
        /// </summary>
        public PlayerController() {
            _interactionManager = new Managers.InteractionManager(PlayerIndex.One, true, true);
        }
            
        /// <summary>
        /// Pass in which playerindex you want this PlayerController to use.
        /// </summary>
        public void setPlayerIndex( PlayerIndex playerIndex) {
            _interactionManager.PlayerIndex = playerIndex;
        }

        /// <summary>
        /// Update this PlayerController.
        /// </summary>
        /// <param name="gT"></param>
        /// <param name="obj"></param>
        public override void Update(GameTime gT, Objects.Base.RenderableObject obj) {
            _interactionManager.Update();
        }
    }
}
