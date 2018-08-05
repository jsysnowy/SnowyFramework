using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SnowGame.Core.Objects.Core;

namespace SnowGame.Core.Objects.Modules {
    class MoveDownModules : Core.Module {
        public override void Update(GameTime gT, RenderableObject obj) {
            obj.Y += 0.1f;
            base.Update(gT, obj);
        }
    }
}
