using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.Core.Modules {
    class ProjectileComponent : Base.Module{
    public float Speed { get; set; } = 0.1f;
    public Vector2 Direction { get; set; } = new Vector2(5, 5);

        public override void Update(GameTime gT, Objects.Base.RenderableObject obj) {
            obj.X += Direction.X;
            obj.Y += Direction.Y;
             
            base.Update(gT, obj);
        }
    }
}
