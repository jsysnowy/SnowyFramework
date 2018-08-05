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

        #region Virtual Functions.
        public virtual void Update( GameTime gt ) {

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
