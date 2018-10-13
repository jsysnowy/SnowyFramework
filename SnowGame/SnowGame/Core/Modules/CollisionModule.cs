using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnowGame.Core.Objects.Base;

/// <summary>
/// This module makes an object inside it collidable with callbacks for collisions.
/// </summary>

namespace SnowGame.Core.Modules {
    public class CollisionModule : Base.Module {
        /// <summary>
        /// Stores bounds of object which is colliding.
        /// </summary>
        public Rectangle Bounds { get; set; }

        /// <summary>
        /// Create new base module.
        /// </summary
        public CollisionModule() : base() {
            Managers.CollisionManager.Instance.AddCollisionModule(this);
        }

        /// <summary>
        /// Destructor, clean up this module from CollisionManager.
        /// </summary>
        ~CollisionModule() {
            Managers.CollisionManager.Instance.RemoveCollisionModule(this);
        }

        /// <summary>
        /// Update this collision manager, resets bounds from attached obj.
        /// </summary>
        /// <param name="gT"></param>
        /// <param name="obj"></param>
        public override void Update(GameTime gT, RenderableObject obj) {

            Bounds = new Rectangle((int)MyObj.X, (int)MyObj.Y, (int)MyObj.Width, (int)MyObj.Height);

            base.Update(gT, obj);
        }

        /// <summary>
        /// Called on a collision
        /// </summary>
        /// <param name="other"></param>
        public void OnCollision( CollisionModule other ) {
            MyObj.OnCollision(other.MyObj);
        }
    }
}
