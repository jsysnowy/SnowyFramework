using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SnowGame.Core.Objects.Base;

namespace SnowGame.Core.Modules {
    class GravityModule : Base.Module {

        /// <summary>
        /// Strength of the gravity.
        /// </summary>
        private float strength = 0.4f;

        /// <summary>
        /// Current effect of gravity on this object.
        /// </summary>
        private float acceleration = 0.0f;

        /// <summary>
        /// Baseline to land on.
        /// </summary>
        private int _floor = Core.Config.GameConfiguration.DEFAULT_HEIGHT;



        public override void Update(GameTime gT, RenderableObject obj) {
            obj.Y += acceleration;

            if ( obj.Y > _floor-obj.Height) {
                obj.Y = _floor - obj.Height;
                acceleration = 0;
            } else {
                acceleration += strength;
            }

            base.Update(gT, obj);
        }
    }
}
