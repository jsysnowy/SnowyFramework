using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.Core.Managers {
    public class ObjectsManager {
        #region Objects List.
        private List<Objects.Base.RenderableObject> _objects;
        #endregion.

        /// <summary>
        ///  Readonly getter of objects.
        /// </summary>
        public List<Objects.Base.RenderableObject> Objects {
            get {
                return _objects;
            }
        }

        /// <summary>
        /// Create new instance of ObjectsManager.
        /// </summary>
        public ObjectsManager() {
            _objects = new List<Objects.Base.RenderableObject>();
        }

        /// <summary>
        /// Add an object to this manager.
        /// </summary>
        /// <param name="obj"></param>
        public void Add( Objects.Base.RenderableObject obj ) {
            _objects.Add(obj);
        }

        /// <summary>
        ///  Remove an object from this manager.
        /// </summary>
        /// <param name="obj"></param>
        public void Remove( Objects.Base.RenderableObject obj) {
            _objects.Remove(obj);
        }

        /// <summary>
        /// Return an array of all the current objects in this manager.
        /// </summary>
        /// <returns></returns>
        public Objects.Base.RenderableObject[] GetAllObjects() {
            return _objects.ToArray();
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
        /// Updates all objects in ObjectsManager
        /// </summary>
        /// <param name="gT"></param>
        public void Update( GameTime gT) {
            // Loops through and calls update on all object in this manager.
            for (int i = 0; i < _objects.Count; i++) {
                _objects[i].Update(gT);
            }
        }

        /// <summary>
        /// Draws all objects in this manager.
        /// </summary>
        public void Draw( SpriteBatch sB ) {
            // Draw all Objects in manager to screen:
            for ( int i = 0; i < _objects.Count; i++) {
                _objects[i].Draw(sB);
            }
        }
    }
}
