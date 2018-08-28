using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Each "Scene" will have an instance of CameraManager, used to control cameras.
/// </summary>
namespace SnowGame.Core.Camera {
    public class CameraManager {
        /// <summary>
        /// Stores list of all cameras existing in this CameraManager.
        /// </summary>
        private Dictionary<string, Camera> _cameras;

        /// <summary>
        /// Stores the currently active camera.
        /// </summary>
        private Camera _activeCamera;

        /// <summary>
        /// Readonly accessor for the active camera.
        /// </summary>
        public Camera ActiveCamera { get {
                return _activeCamera;
            }
        }

        /// <summary>
        /// Creates a new instance of CameraManager.
        /// </summary>
        public CameraManager( Viewport viewport ) {
            _activeCamera = new Camera( viewport );

            _cameras = new Dictionary<string, Camera>();
            _cameras.Add("default", _activeCamera);
        }

        /// <summary>
        /// Add a camera to the CameraManager.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="camera"></param>
        /// <param name="makeActive"></param>
        public void AddCamera(string id, Camera camera, bool makeActive = false ) {
            // Make sure camera with this id doesn't already exist.
            if (_cameras[id] == null) {
                // Add camera, if active then set it as active too.
                _cameras.Add(id, camera);
                if ( makeActive) {
                    _activeCamera = camera;
                }
            }
        }

        /// <summary>
        /// Set active camera to one passed in if it exists.
        /// </summary>
        /// <param name="id"></param>
        public void SetActiveCameraByID( string id ) {
            if ( _cameras[id] != null) {
                _activeCamera = _cameras[id];
            }
        }
    }
}
