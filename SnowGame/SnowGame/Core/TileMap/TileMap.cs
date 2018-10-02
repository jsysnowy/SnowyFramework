using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowGame.Core.TileMap {
    class TileMap {

        /// <summary>
        /// How big across X the tilemap is.
        /// </summary>
        private int _xSize;

        /// <summary>
        /// How big across Y the tilemap is.
        /// </summary>
        private int _ySize;

        /// <summary>
        /// Stores all avail tiles with numbers.
        /// </summary>
        private Dictionary<int, Tile> _availTiles;

        /// <summary>
        /// Stores array of the tileMap.
        /// </summary>
        private Tile[][] _tiles;

        public TileMap(int x, int y) {
            _xSize = x;
            _ySize = y;
        }
    }
}
