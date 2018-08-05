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
                obj.Y -= 6f;
            }
            if (_interactionManager.KeyboardState.IsKeyDown(Keys.A)) {
                obj.X -= 6f;
            }
            if (_interactionManager.KeyboardState.IsKeyDown(Keys.S)) {
                obj.Y += 6f;
            }
            if (_interactionManager.KeyboardState.IsKeyDown(Keys.D)) {
                obj.X += 6f;
            }

            if ( _interactionManager.GamePadState.IsButtonDown(Buttons.RightTrigger)) {
                if (!(_interactionManager.GamePadState.ThumbSticks.Right.X == 0 && _interactionManager.GamePadState.ThumbSticks.Right.Y == 0)) {
                    Vector2 direction = new Vector2(_interactionManager.GamePadState.ThumbSticks.Right.X * 12.0f, _interactionManager.GamePadState.ThumbSticks.Right.Y * -12.0f);
                    SnowGame.Scenes.MainGame.Instance.fireArrow(direction);
                }
            }

            obj.X += _interactionManager.GamePadState.ThumbSticks.Left.X * 6.0f;
            obj.Y -= _interactionManager.GamePadState.ThumbSticks.Left.Y * 6.0f;
        }
    }
}
