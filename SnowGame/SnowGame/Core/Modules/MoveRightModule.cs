using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SnowGame.Core.Modules {
    class MoveRightModule : Base.Module {
        public float Speed { get; set; } = 0.8f;
        public override void Update(GameTime gT, Objects.Base.RenderableObject obj) {
            obj.X += Speed;
            base.Update(gT, obj);
        }
    }
}
