_Note: Catfood.AmbientOrb.dll is not thread safe._

Basic control is very easy. Just create the appropriate OrbController and call Update() to set the color and animation speed. See the [Web Developer's Kit](http://www.ambientdevices.com/developer/OrbWDK.pdf) (PDF) for charts showing the possible colors and animation values. 

{code:c#}
// for pager control, the parameter is the Device ID on the bottom of the Orb
OrbController orb = new OrbPagerController("111-222-333");

// for serial control, the parameter is the COM port that the Orb is connected to
OrbController orb = new OrbSerialController("COM1");

// update - color (0-36) and animation speed (0-9)
orb.Update(0, 9);

// dispose when you're finished with the Orb
orb.Dispose();
{code:c#}

The pager update uses Ambient's very simple web service. Serial control is more fun - you can override the default behavior for the Orb's buttons and you can change colors very quickly without waiting for the Orb to receive a pager message. 

{code:c#}
OrbSerialController orb = new OrbSerialController("COM1");
orb.OrbButtonChanged += new EventHandler<OrbButtonsEventArgs>(orb_OrbButtonChanged);
orb.SetButtonsEnabled(false); // disable default button behavior
{code:c#}

XML documentation is included for the library.