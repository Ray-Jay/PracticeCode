using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Point
    {
        // fields and properties
        private double x;
        private double y;

        public double X
        {
            get { return x; }
            //set { x = value; }
            set                 // change set to set value and cal OnPointChanged to see if event is raised
            {
                x = value;
                OnPointChanged();
            }
        }

        public double Y
        {
            get { return y; }
            //set { y = value; }
            set
            {
                y = value;      // change set to set value and cal OnPointChanged to see if event is raised
                OnPointChanged();
            }
        }

        // event keyword defines this as event
        // EventHandler is the name of the delegate
        // PointChanged is the name of the event
        public event EventHandler PointChanged;

        public void OnPointChanged()            // code to raise event PointChanged
        {
            if (PointChanged != null)
                PointChanged(this, EventArgs.Empty);        // required parameters for EventHandler delegate
        }

    }
}
