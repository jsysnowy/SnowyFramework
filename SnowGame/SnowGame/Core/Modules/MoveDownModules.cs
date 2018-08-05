using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SnowGame.Core.Modules {
    class MoveDownModules : Base.Module {
        public override void Update(GameTime gT, Objects.Base.RenderableObject obj) {
            obj.Y += 0.1f;
            base.Update(gT, obj);
        }
    }
}
