using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnowGame.Core.Modules {
    class PlayerController : Base.Module {

        private Managers.InteractionManager _interactionManager;

        public float Speed { get; set; } = 0.1f;

        public PlayerController() {
            _interactionManager = new Managers.InteractionManager(PlayerIndex.One, true, true);
        }

        public override void Update(GameTime gT, Objects.Base.RenderableObject obj) {

            _interactionManager.Update();

            if ( _interactionManager.KeyboardState.IsKeyDown(Keys.W )) {
                obj.Y -= 2f;
            }
            if (_interactionManager.KeyboardState.IsKeyDown(Keys.A)) {
                obj.X -= 2f;
            }
            if (_interactionManager.KeyboardState.IsKeyDown(Keys.S)) {
                obj.Y += 2f;
            }
            if (_interactionManager.KeyboardState.IsKeyDown(Keys.D)) {
                obj.X += 2f;
            }
        }
    }
}
