using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnowGame.Core.Objects.Core {
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
        /// Stores current screen position of this RenderableObject.
        /// </summary>
        private Vector2 _screenPosition;

        /// <summary>
        /// Stores current zIndez of this RenderableObject.
        /// </summary>
        private float _zIndex;
        #endregion

        #region Modules.
        private List<Module> _modules;
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
        public Vector2 Position {
            get {
                return _screenPosition;
            }
            set {
                _screenPosition = value;
                _bounds.X = (int)Math.Round(value.X);
                _bounds.Y = (int)Math.Round(value.Y);
            }
        } 

        /// <summary>
        /// Get/Set the X value of this RenderableObject.
        /// </summary>
        public float X {
            get {
                return _screenPosition.X;
            }
            set {
                _screenPosition.X = value;
                _bounds.X = (int)Math.Round(value);
            }
        }

        /// <summary>
        /// Get/Set the Y value of this RenderableObject.
        /// </summary>
        public float Y {
            get {
                return _screenPosition.Y;
            }
            set {
                _screenPosition.Y = value;
                _bounds.Y = (int)Math.Round(value);
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
        #endregion

        #region Constructor
        public RenderableObject() {
            // Create modules list:
            _modules = new List<Module>();
        }
        #endregion

        #region ModuleManagement.
            /// <summary>
            /// Add a module to a RenderableObject
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public bool AddModule<T>() where T : Module, new() {
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
            public T GetModule<T>() where T : Module {
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
            public bool RemoveModule<T>() where T : Module {
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
            for ( int i = 0; i < _modules.Count; i++) {
                _modules[i].Update(gT, this);
            }
        }
        #endregion

        #region Draw.
        /// <summary>
        /// Draw texture if it is setup correctly.
        /// </summary>
        /// <param name="sB"></param>
        public virtual void Draw( SpriteBatch sB ) {
            if ( _baseTexture != null && _screenPosition != null ) {
                sB.Draw(_baseTexture, _screenPosition, Color.White);
            }
        }
        #endregion
    }
}
