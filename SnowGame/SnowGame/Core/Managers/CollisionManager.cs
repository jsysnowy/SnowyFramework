using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.Core.Managers {
    public class CollisionManager {

        /// <summary>
        /// Whether or not this collision detection system is active or not:
        /// </summary>
        bool Active { get; set; }

        /// <summary>
        /// The bounds in which this CollisionManager checks:
        /// </summary>
        private Camera.Camera MyCamera { get; set; }

        /// <summary>
        /// Stores all active modules in this collision manager.
        /// </summary>
        private List<Modules.CollisionModule> objects;

        /// <summary>
        /// List of objects returned by this collision manager.
        /// </summary>
        private List<Modules.CollisionModule> returnObjects;

        /// <summary>
        /// Quadtree instance used for spatial partitioning.
        /// </summary>
        Collision.QuadTree collisionDetectionArea;

        /// <summary>
        /// Singleton collector.
        /// </summary>
        public static CollisionManager Instance { get; } = new CollisionManager();

        /// <summary>
        /// Creates a new instance of CollisionManager.
        /// </summary>
        public void Init(Camera.Camera camera_, bool startsActive) {
            // Sets passed in params
            MyCamera = camera_;
            Active = startsActive;

            // Create list of objects
            objects = new List<Modules.CollisionModule>();

            // Creates the QuadTree:
            collisionDetectionArea = new Collision.QuadTree(0, MyCamera.VisibleArea);

            // Creates list
            returnObjects = new List<Modules.CollisionModule>();
        }

        public void AddCollisionModule(Modules.CollisionModule module) {
            if (objects.IndexOf(module) == -1) {
                objects.Add(module);
            }
        }

        public void RemoveCollisionModule(Modules.CollisionModule module) {
            if (objects.IndexOf(module) != -1) {
                objects.Remove(module);
            }
        }

        /// <summary>
        /// Collision system runs checks on all objects and triggers any colliding functions:
        /// </summary>
        public void Update( Camera.Camera camera) {
            // Set new camera
            MyCamera = camera;

            // Wipe the current area:
            collisionDetectionArea.Clear();

            // Get new camera position:
            collisionDetectionArea.Bounds = MyCamera.VisibleArea;

            // Insert all colliding objects
            for (int i = 0; i < objects.Count; i++) {
                Modules.CollisionModule testObj = objects[i];
            
                // Insert our object into the QuadTree:
                collisionDetectionArea.Insert(testObj);
            }

            for (int i = 0; i < objects.Count; i++) {
                Modules.CollisionModule testObj = objects[i];
                // Wipe returnObjects:
                returnObjects.Clear();

                // Retrieve all collidable objects:
                returnObjects = collisionDetectionArea.Retrieve(returnObjects, testObj.Bounds);

                // Perform collision detection on all returnedObjects with our testObj:
                for (int ii = 0; ii < returnObjects.Count; ii++) {
                    
                    Modules.CollisionModule other = returnObjects[ii];
                    if (testObj != other) {
                        if (testObj.Bounds.Intersects(other.Bounds)) {
                            testObj.OnCollision(other);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Debuf draws the QuadTree area.
        /// </summary>
        /// <param name="sB"></param>
        /// <param name="gD"></param>
        public void Draw(SpriteBatch sB, GraphicsDevice gD) {
            collisionDetectionArea.Draw(sB, gD, Color.White);
        }
    }
}
