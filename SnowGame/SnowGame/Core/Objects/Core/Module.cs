using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.Core.Objects.Core {
    public class Module {
        /// <summary>
        /// Creates new instance of Module.
        /// </summary>
        public Module( ) {

        }

        /// <summary>
        /// Turn this module on.
        /// </summary>
        public void Enable() {

        }

        /// <summary>
        /// Turn this module off.
        /// </summary>
        public void Disable() {

        }

        /// <summary>
        /// Updates this module.
        /// </summary>
        /// <param name="gT"></param>
        public virtual void Update(GameTime gT, RenderableObject obj ) {
        }
    }
}
