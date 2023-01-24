using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    /// <summary>
    /// Exception used when an obstacle is encountred on the grid.
    /// </summary>
    public class ObstacleOnGridException : Exception
    {
        public GridPoint GridPoint { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ObstacleOnGridException"/> class.
        /// </summary>
        /// <param name="message">An error message</param>
        public ObstacleOnGridException(string message, GridPoint point)
            : base(message)
        {
            this.GridPoint = point;
        }
    }
}
