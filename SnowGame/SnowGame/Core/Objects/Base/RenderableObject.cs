using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.Core.Objects.Base {
    public class RenderableObject {

        #region TextureParams
        /// <summary>
        /// Stores base texture for this RenderableObject.
        /// </summary>
        private Texture2D _baseTexture;
        #endregion

        #region ObjectSize

        /// <summary>
        /// Stores bounds (x,y,w,h) of this RenderableObject.
        /// </summary>
        private Rectangle _bounds;

        /// <summary>
        /// Stores current width of this RenderableObject.
        /// </summary>
        private float _width;

        /// <summary>
        /// Stores current height of this RenderableObject.
        /// </summary>
        private float _height;
        #endregion

        #region Object Translation.

        /// <summary>
        /// Stores local position of this RenderableObject.
        /// </summary>
        private Vector2 _localPosition;

        /// <summary>
        /// Stores world position of this RenderableObject.
        /// </summary>
        private Vector2 _globalPosition;

        /// <summary>
        /// Stores current zIndez of this RenderableObject.
        /// </summary>
        private float _zIndex;
        #endregion

        #region Children.

        /// <summary>
        /// Stores the parent of this RenderableObject.
        /// </summary>
        private RenderableObject _parent;

        /// <summary>
        /// Managed used to store all children of this object.
        /// </summary>
        private ObjectsManager _objects;

        #endregion

        #region Modules.
        private List<Core.Modules.Base.Module> _modules;
        #endregion

        #region Get/Sets 

        /// <summary>
        /// Set current texture of this RenderableObject.
        /// </summary>
        public Texture2D Texture {
            get {
                return this._baseTexture;
            }
            set {
                // TODO: Sort out casting? Make own rect function using floats?
                _baseTexture = value;
                _width = _baseTexture.Width;
                _height = _baseTexture.Height;
                _bounds.Width = (int)Math.Round(_width);
                _bounds.Height = (int)Math.Round(_height);
            }
        } 
        
        /// <summary>
        /// Get/Set current position of this RenderableObject.
        /// </summary>
        public Vector2 LocalPosition {
            get {
                return _localPosition;
            }
            set {
                _localPosition = value;
                _bounds.X = (int)Math.Round(value.X);
                _bounds.Y = (int)Math.Round(value.Y);
            }
        }

        /// <summary>
        /// Get/Set current position of this RenderableObject.
        /// </summary>
        public Vector2 GlobalPosition {
            get {
                return _globalPosition;
            }
            set {
                _globalPosition = value;
            }
        }

        /// <summary>
        /// Get/Set the X value of this RenderableObject.
        /// </summary>
        public float X {
            get {
                return _localPosition.X;
            }
            set {
                // Set local coord
                _localPosition.X = value;
                _bounds.X = (int)Math.Round(value); 
            }
        }

        /// <summary>
        /// Get/Set the Y value of this RenderableObject.
        /// </summary>
        public float Y {
            get {
                return _localPosition.Y;
            }
            set {
                _localPosition.Y = value;
                _bounds.Y = (int)Math.Round(value);
            }
        }

        /// <summary>
        /// Get/Set the X value of this RenderableObject.
        /// </summary>
        public float GlobalX {
            get {
                return _globalPosition.X;
            }
        }

        /// <summary>
        /// Get/Set the Y value of this RenderableObject.
        /// </summary>
        public float GlobalY {
            get {
                return _globalPosition.Y;
            }
        }

        /// <summary>
        /// Get/Set the Z value of this RenderableObject.
        /// </summary>
        public float Z {
            get {
                return _zIndex;
            }
            set {
                _zIndex = value;
            }
        }

        /// <summary>
        /// Returns parent of this object.
        /// </summary>
        public RenderableObject Parent {
            get {
                return _parent;
            }
            set {
                value.Add(this);
            }
        }


        #endregion

        #region Constructor
        public RenderableObject() {
            // Create modules list:
            _localPosition = new Vector2(0, 0);
            _globalPosition = new Vector2(0, 0);
            _objects = new ObjectsManager();
            _modules = new List<Modules.Base.Module>();
        }
        #endregion

        #region Children functions.

        /// <summary>
        /// Add an object to this manager.
        /// </summary>
        /// <param name="obj"></param>
        public void Add(Objects.Base.RenderableObject obj) {
            _objects.Add(obj);
            obj._parent = this;
        }

        /// <summary>
        ///  Remove an object from this manager.
        /// </summary>
        /// <param name="obj"></param>
        public void Remove(Objects.Base.RenderableObject obj) {
            _objects.Remove(obj);
        }

        /// <summary>
        ///  Clear all objects from this ObjectManager.
        /// </summary>
        public void Clear() {
            _objects.Clear();
        }

        #endregion

        #region ModuleManagement.
        /// <summary>
        /// Add a module to a RenderableObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool AddModule<T>() where T : Modules.Base.Module, new() {
                // Made our Module List if it doesn't exist:
                // Make sure module can only be added once.
                for ( int i = 0; i < _modules.Count; i++) {
                    if ( typeof(T).IsInstanceOfType(_modules[i])) {
                        return false;
                    }
                }

                _modules.Add( new T() );
                return true;
            }

            /// <summary>
            /// Get and return module with type T.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public T GetModule<T>() where T : Modules.Base.Module {
                // Find and return our module.
                for (int i = 0; i < _modules.Count; i++) {
                    if (typeof(T).IsInstanceOfType(_modules[i])) {
                        return (T)_modules[i];
                    }
                }

                // No module was found.
                return null;
            }

            /// <summary>
            /// Find and remove module with type T.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public bool RemoveModule<T>() where T : Modules.Base.Module {
                // Find and remove our module.
                for (int i = 0; i < _modules.Count; i++) {
                    if (typeof(T).IsInstanceOfType(_modules[i])) {
                        _modules.RemoveAt(i);
                        return true;
                    }
                }

                // No module was removed.
                return false;
            }
        #endregion

        #region Virtual Functions.
        /// <summary>
        /// Updates this Renderable Object - this handles all module updates.
        /// </summary>
        /// <param name="gT"></param>
        public virtual void Update( GameTime gT ) {

            // Updates all modules:
            for ( int i = 0; i < _modules.Count; i++) {
                _modules[i].Update(gT, this);
            }

            // TODO: Flag for if _localPosition has changed, only trigger this code if its true?
            // Set global coord:
            if (Parent != null) {
                _globalPosition.X = Parent.GlobalX + _localPosition.X;
                _globalPosition.Y = Parent.GlobalY + _localPosition.Y;
            } else {
                _globalPosition.X = _localPosition.X;
                _globalPosition.Y = _localPosition.Y;
            }

            // Update all children:
            _objects.Update(gT);
        }
        #endregion

        #region Draw.
        /// <summary>
        /// Draw texture if it is setup correctly.
        /// </summary>
        /// <param name="sB"></param>
        public virtual void Draw( SpriteBatch sB ) {
            if ( _baseTexture != null && _globalPosition != null ) {
                sB.Draw(_baseTexture, _globalPosition, Color.White);
            }

            // Draw all children.
            _objects.Draw(sB);
        }
        #endregion
    }
}
