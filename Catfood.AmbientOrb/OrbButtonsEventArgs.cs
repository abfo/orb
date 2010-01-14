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
    /// Contains the current state of an Orb's buttons
    /// </summary>
    public class OrbButtonsEventArgs : EventArgs
    {
        private bool _brightnessButtonDown;
        private bool _resetButtonDown;

        /// <summary>
        /// Contains the current state of an Orb's buttons
        /// </summary>
        /// <param name="brightnessButtonDown">The current state of the brightness button (true if depressed)</param>
        /// <param name="resetButtonDown">The current state of the reset button (true if depressed)</param>
        public OrbButtonsEventArgs(bool brightnessButtonDown, bool resetButtonDown)
        {
            _brightnessButtonDown = brightnessButtonDown;
            _resetButtonDown = resetButtonDown;
        }

        /// <summary>
        /// Gets the current state of the brightness button (true if depressed)
        /// </summary>
        public bool BrightnessButtonDown
        {
            get { return _brightnessButtonDown; }
        }

        /// <summary>
        /// Gets the current state of the reset button (true if depressed)
        /// </summary>
        public bool ResetButtonDown
        {
            get { return _resetButtonDown; }
        }
    }
}
