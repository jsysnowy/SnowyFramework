using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnowGame.Core.Managers {
    public class InteractionManager {

        #region Flags.

        /// <summary>
        /// Stores which player this InteractionManager is tied to.
        /// </summary>
        private PlayerIndex _playerIndex;

        /// <summary>
        /// Stores if this InteractionManager is using keyboard/mouse inputs.
        /// </summary>
        private bool _usingKeyboard;

        /// <summary>
        /// Stores if this InteractionManager is using gamepad inputs.
        /// </summary>
        private bool _usingGamePad;
        #endregion

        #region Custom events.

        #endregion

        #region Mouse Interaction events.

        /// <summary>
        /// Stores the current state of the mouse.
        /// </summary>
        private MouseState _mouseState;

        #endregion

        #region Keyboard Interaction events.

        /// <summary>
        /// Stores the current state of the keyboard.
        /// </summary>
        private KeyboardState _keyState;
        #endregion

        #region Gamepad Interaction events.

        /// <summary>
        /// Stores the current state of the gamepad.
        /// </summary>
        private GamePadState _gamepadState;
        #endregion

        #region Gets/Sets

        /// <summary>
        /// Get/Set current playerIndex.
        /// </summary>
        public PlayerIndex PlayerIndex {
            get {
                return _playerIndex;
            }
            set {
                _playerIndex = value;
            }
        }


        /// <summary>
        /// Return current KeyboardState
        /// </summary>
        public KeyboardState KeyboardState {
            get {
                return this._keyState;
            }
        }
        /// <summary>
        /// Return current MouseState
        /// </summary>
        public MouseState MouseState {
            get {
                return this._mouseState;
            }
        }

        /// <summary>
        /// Return current GamepadState
        /// </summary>
        public GamePadState GamePadState {
            get {
                return this._gamepadState;
            }
        }
        #endregion


        #region Constructor.
        /// <summary>
        /// Creates a new instance of InteractionManager.
        /// </summary>
        public InteractionManager( PlayerIndex playerIndex, bool usingKeyboard, bool usingGamePad ) {

            // Set flags
            _playerIndex = playerIndex;
            _usingKeyboard = usingKeyboard;
            _usingGamePad = usingGamePad;
        }
        #endregion

        #region Public Functions.
        /// <summary>
        /// Binds an eventName to a key.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="key"></param>
        public void BindKeyToEvent(string eventName, Keys key) {
            
        }

        /// <summary>
        /// Updates current state of InteractionManager.
        /// </summary>
        public void Update() {



            if ( _usingKeyboard) {
                _keyState = Keyboard.GetState();
                _mouseState = Mouse.GetState();
            }
            

            if (_usingGamePad) {
                _gamepadState = GamePad.GetState( _playerIndex);
            }
        }
        #endregion

        #region Private Functions
        #endregion
    }
}
