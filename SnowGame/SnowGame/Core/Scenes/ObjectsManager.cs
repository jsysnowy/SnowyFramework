﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.Core.Scenes {
    public class ObjectsManager {
        #region Objects List.
        private List<Objects.Core.RenderableObject> _objects;
        #endregion.

        /// <summary>
        /// Create new instance of ObjectsManager.
        /// </summary>
        public ObjectsManager() {
            _objects = new List<Objects.Core.RenderableObject>();
        }

        /// <summary>
        /// Add an object to this manager.
        /// </summary>
        /// <param name="obj"></param>
        public void Add( Objects.Core.RenderableObject obj ) {
            _objects.Add(obj);
        }

        /// <summary>
        ///  Remove an object from this manager.
        /// </summary>
        /// <param name="obj"></param>
        public void Remove( Objects.Core.RenderableObject obj) {
            _objects.Remove(obj);
        }

        /// <summary>
        ///  Clear all objects from this ObjectManager.
        /// </summary>
        public void Clear() {
            _objects.Clear();
        }

        /// <summary>
        /// Order all objects in this manager.
        /// </summary>
        public void Order() {

        }

        /// <summary>
        /// Draws all objects in this manager.
        /// </summary>
        public void Draw( SpriteBatch sB ) {
            for ( int i = 0; i < _objects.Count; i++) {
                sB.Draw(_objects[i].Texture, _objects[i].Position, Color.White);
            }
        }
    }
}
