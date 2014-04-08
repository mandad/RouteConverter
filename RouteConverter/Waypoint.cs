using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RouteConverter
{
    class Waypoint
    {
        private string ptName;

        public string PtName
        {
            get { return ptName; }
        }
        
        private double ptLat;

        public double PtLat
        {
            get { return ptLat; }
        }
        
        private double ptLon;

        public double PtLon
        {
            get { return ptLon; }
        }

        private int ptSpeed;

        public int PtSpeed
        {
            get { return ptSpeed; }
        }

        public Waypoint(string name, double lat, double lon, int speed)
        {
            ptName = name;
            ptLat = lat;
            ptLon = lon;
            ptSpeed = speed;
        }


    }
}
