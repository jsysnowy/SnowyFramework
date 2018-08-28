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
        /// Stores the acceleration speed (How fast this gets up to maximum speed).
        /// </summary>
        private float _accelerationSpeed = 2;

        /// <summary>
        /// Stores the maximum speed this can move.
        /// </summary>
        private float _maxSpeed = 8;

        /// <summary>
        /// How fast this slows down.
        /// </summary>
        private float _slowDownRate = 0.2f;

        /// <summary>
        /// Current acceleration of the object
        /// </summary>
        private Vector2 _acceleration = new Vector2(0, 0);

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

            // Calculate new Acceleration:


            // First, apply slowdown
            Vector2 dpadLeft = _interactionManager.GamePadState.ThumbSticks.Left;
            if ( dpadLeft.X == 0) {
                _acceleration.X *= _slowDownRate;
                if ( Math.Abs(_acceleration.X) < 1) {
                    _acceleration.X = 0;
                }
            }

            if ( dpadLeft.Y == 0) {
                _acceleration.Y *= _slowDownRate;
                if (Math.Abs(_acceleration.Y) < 1) {
                    _acceleration.Y = 0;
                }
            }

            // Apply speeeed:
            _acceleration.X += _interactionManager.GamePadState.ThumbSticks.Left.X* _accelerationSpeed;
            _acceleration.Y -= _interactionManager.GamePadState.ThumbSticks.Left.Y * _accelerationSpeed;

            // Cap Speed:
            if ( _acceleration.X > _maxSpeed) {
                _acceleration.X = _maxSpeed;
            } else if (_acceleration.X < -_maxSpeed) {
                _acceleration.X = -_maxSpeed;
            }

            if (_acceleration.Y > _maxSpeed) {
                _acceleration.Y = _maxSpeed;
            } else if (_acceleration.Y < -_maxSpeed) {
                _acceleration.Y = -_maxSpeed;
            }

            obj.X += _acceleration.X;
            obj.Y += _acceleration.Y;
        }
    }
}
