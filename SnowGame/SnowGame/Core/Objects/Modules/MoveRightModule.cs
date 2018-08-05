using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SnowGame.Core.Objects.Core;

namespace SnowGame.Core.Objects.Modules {
    class MoveRightModule : Core.Module {
        public float Speed { get; set; } = 0.1f;
        public override void Update(GameTime gT, RenderableObject obj) {
            obj.X += Speed;
            base.Update(gT, obj);
        }
    }
}
