using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnowGame.Core.Interaction {

    /// <summary>
    /// This interface holds bindings which can be shared across different Keys and Buttons.
    /// </summary>
    public interface InteractionBinding {
        /// <summary>
        /// Stores all Keyboard kets associated with this binding.
        /// </summary>
        List<Keys> AssociatedKeys { get; set; }


        /// <summary>
        ///  Stores all Mouse 
        /// </summary>
        List<MouseState> AssociatedMouseState { get; set; }

        /// <summary>
        /// Stores all Gamepad buttons associated with this binding.
        /// </summary>
        List<Buttons> AssociatedButtons { get; set; }

        /// <summary>
        /// Stores all Thumbstick controls associated with this binding.
        /// </summary>
        List<GamePadThumbSticks> AssociatedThumbsticks { get; set; }

        /// <summary>
        /// Stores if this binding is currenly being held by any of the associated keys or buttons.
        /// </summary>
        bool IsHeld { get; set; }

        /// <summary>
        /// Stores if this binding was triggered this frame. Useful for making sure something only happens once.
        /// </summary>
        bool HeldThisFrame { get; set; }


        /// <summary>
        /// Get current value in this binding.
        /// </summary>
        float Value { get; set; }
    }
}
