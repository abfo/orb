/* ------------------------------------------------------------------------
 * (c)copyright 2010 Catfood Software - http://www.catfood.net
 * Provided under the ms-PL license, see LICENSE.txt
 * ------------------------------------------------------------------------ */

using System;
using System.Collections.Generic;
using System.Text;

namespace Catfood.AmbientOrb
{
    /// <summary>
    /// Abstract controlloer for an Ambient Orb device
    /// </summary>
    public abstract class OrbController : IDisposable
    {
        /// <summary>
        /// Update the orb with a color from 0 to 36 and no animation
        /// </summary>
        /// <param name="color">Color value from 0 to 36</param>
        /// <exception cref="ArgumentException">Thrown if the color value is out of range</exception>
        public void Update(int color)
        {
            if ((color < 0) || (color > 36))
            {
                throw new ArgumentException("color must be between 0 and 36");
            }

            Update(color, 0);
        }

        /// <summary>
        /// Update the orb with a color from 0 to 36 and an animation from 0 to 9
        /// </summary>
        /// <param name="color">Color value from 0 to 36</param>
        /// <param name="animation">Animation from 0 (none) to 9 (heartbeat - fastest)</param>
        public abstract void Update(int color, int animation);

        /// <summary>
        /// Disposes the OrbController
        /// </summary>
        public abstract void Dispose();
    }
}
