using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Resources;

namespace RouteConverter
{
    public class XMLOutput
    {
        private Format format;
        private XmlDocument baseXML;
        private string routeName;

        public enum Format
        {
            Transas,
            GPX,
            VisionMaster
        };

        public XMLOutput(Format format, string routeName)
        {
            this.format = format;
            this.routeName = routeName;
            CreateXML();
        }

        private void CreateXML()
        {
            baseXML = new XmlDocument();
            XmlElement root;
            switch (format)
            {
                case Format.Transas:
                    root = baseXML.CreateElement("TSH_Route");
                    root.SetAttribute("RtVersion", "3");
                    root.SetAttribute("RtName", routeName);
                    //root.InnerText = "TSH RtServer route data file. Info: amo.";
                    baseXML.AppendChild(root);
                    break;
                case Format.GPX:
                    root = (XmlElement)baseXML.AppendChild(baseXML.CreateElement("gpx", "http://www.topografix.com/GPX/1/1"));
                    root.SetAttribute("version", "1.1");
                    break;
                case Format.VisionMaster:
                    root = baseXML.CreateElement("NewDataSet");
                    baseXML.AppendChild(root);
                    break;

            }
        }


        internal void WriteData(Waypoint[] waypoints)
        {
            XmlElement root = (XmlElement)baseXML.FirstChild;
            XmlElement waypointXML;
            ResourceManager rm = new ResourceManager("RouteConverter.Resources",
                                               this.GetType().Assembly);

            switch (format)
            {
                case Format.Transas:
                    //<WayPoint ="" LegType="0" RudderAngle="0" Lat="2448.674" Lon="-4425.922" PortXTE="0.100000001490116" StbXTE="0.100000001490116" TurnRate="0" TurnRadius="0.300000011920929" ArrivalC="0"/>

                    waypointXML = baseXML.CreateElement("WayPoints");
                    waypointXML.SetAttribute("WPCount", waypoints.Length.ToString());

                    //create calculations bloc
                    XmlElement calculations = baseXML.CreateElement("Calculations");
                    calculations.SetAttribute("CalcCount", "1");
                    XmlElement curElement = (XmlElement)calculations.AppendChild(baseXML.CreateElement("Calculation"));
                    curElement.SetAttribute("CalcName", "Base Calculation");
                    curElement.SetAttribute("CalcOptions", "0");
                    curElement.SetAttribute("CalcForecast", "0");
                    curElement.SetAttribute("CalcDone", "0");
                    curElement = (XmlElement)curElement.AppendChild(baseXML.CreateElement("WayPointExs"));

                    foreach (Waypoint wp in waypoints)
                    {
                        //waypoint info
                        XmlElement wpXML = baseXML.CreateElement("WayPoint");
                        wpXML.SetAttribute("WPName", wp.PtName);
                        wpXML.SetAttribute("LegType", "0");
                        wpXML.SetAttribute("RudderAngle", "0");
                        wpXML.SetAttribute("Lat", (wp.PtLat * 60).ToString());
                        wpXML.SetAttribute("Lon", (wp.PtLon * 60).ToString());
                        wpXML.SetAttribute("PortXTE", "0.050000");         //set XTE here
                        wpXML.SetAttribute("StbXTE", "0.050000");
                        wpXML.SetAttribute("TurnRate", "0");
                        wpXML.SetAttribute("TurnRadius", "0");              //set Turn Radius here
                        wpXML.SetAttribute("ArrivalC", "0");
                        waypointXML.AppendChild(wpXML);

                        //calculation file
                        AddWaypointEx(curElement, wp);
                    }
                    root.AppendChild(waypointXML);
                    root.AppendChild(calculations);
                    break;
                case Format.GPX:
                    waypointXML = baseXML.CreateElement("rte");
                    AppendChildText(waypointXML, "name", routeName);
                    AppendChildText(waypointXML, "number", "1");

                    foreach (Waypoint wp in waypoints)
                    {
                        XmlElement wpXML = baseXML.CreateElement("rtept");
                        wpXML.SetAttribute("lat", wp.PtLat.ToString());
                        wpXML.SetAttribute("lon", (wp.PtLon).ToString());
                        AppendChildText(wpXML, "time", DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH':'mm':'ss'Z'"));
                        AppendChildText(wpXML, "name", wp.PtName);
                        AppendChildText(wpXML, "sym", "square");
                        AppendChildText(wpXML, "type", "WPT");
                        waypointXML.AppendChild(wpXML);
                    }
                    root.AppendChild(waypointXML);
                    break;
                case Format.VisionMaster:
                    //<Summaries>
                    //    <Name>Annapolis to Baltimore InnerHar</Name>
                    //    <DepartureTime>2012-06-14T15:05:31.207+00:00</DepartureTime>
                    //    <Distance>48319.536012207835</Distance>
                    //    <Description />
                    //    <Notes />
                    //    <Valid>true</Valid>
                    //    <LastModified>2012-06-15T10:23:25.533+00:00</LastModified>
                    //    <ReadOnly>false</ReadOnly>
                    //</Summaries>
                    XmlElement summaryXML = baseXML.CreateElement("Summaries");
                    AppendChildText(summaryXML, "Name", routeName);
                    AppendChildText(summaryXML, "DepartureTime", DateTime.Now.AddHours(1).ToString("yyyy-MM-dd\\THH:mm:ss.fffzzz"));
                    AppendChildText(summaryXML, "Distance", "2000");
                    summaryXML.AppendChild(baseXML.CreateElement("Description"));
                    summaryXML.AppendChild(baseXML.CreateElement("Notes"));
                    AppendChildText(summaryXML, "Valid", "true");
                    AppendChildText(summaryXML, "LastModified", DateTime.Now.ToString("yyyy-MM-dd\\THH:mm:ss.fffzzz"));
                    AppendChildText(summaryXML, "ReadOnly", "false");
                    root.AppendChild(summaryXML);

                    //<ControlPoints>
                        //<RouteName>Annapolis to Baltimore InnerHar</RouteName>
                        //<SequenceNumber>1</SequenceNumber>
                        //<Latitude>0.67998987588787674</Latitude>
                        //<Longitude>-1.3340697572534803</Longitude>
                        //<TurnRadius>294.75495460619021</TurnRadius>
                        //<TurnSpeed>5.1444444444444448</TurnSpeed>
                        //<OffTrackAlarmLimitForTurn>100</OffTrackAlarmLimitForTurn>
                        //<DepartingTrackSpeed>5.1444444444444448</DepartingTrackSpeed>
                        //<OffTrackAlarmLimitForDepartingTrack>100</OffTrackAlarmLimitForDepartingTrack>
                        //<DepartingControlLineType>RhumbLine</DepartingControlLineType>
                        //<MinTurnSpeed>4.1155555555555559</MinTurnSpeed>
                        //<MaxTurnSpeed>6.1733333333333338</MaxTurnSpeed>
                        //<MinDepartingTrackSpeed>4.1155555555555559</MinDepartingTrackSpeed>
                        //<MaxDepartingTrackSpeed>6.1733333333333338</MaxDepartingTrackSpeed>
                        //<AdditionalData>&lt;AllAdditionalData /&gt;</AdditionalData>
                    //</ControlPoints>
                    int wpNum = 1;
                    foreach (Waypoint wp in waypoints)
                    {
                        XmlElement wpXML = baseXML.CreateElement("ControlPoints");
                        AppendChildText(wpXML, "RouteName", routeName);
                        AppendChildText(wpXML, "SequenceNumber", wpNum.ToString());
                        AppendChildText(wpXML, "Latitude", (wp.PtLat * Math.PI / 180).ToString());
                        AppendChildText(wpXML, "Longitude", (wp.PtLon * Math.PI / 180).ToString());
                        AppendChildText(wpXML, "TurnRadius", "294.75495460619021");
                        AppendChildText(wpXML, "TurnSpeed", wp.PtSpeed.ToString());
                        AppendChildText(wpXML, "OffTrackAlarmLimitForTurn", "100");
                        AppendChildText(wpXML, "DepartingTrackSpeed", wp.PtSpeed.ToString());
                        AppendChildText(wpXML, "OffTrackAlarmLimitForDepartingTrack", "100");
                        AppendChildText(wpXML, "DepartingControlLineType", "RhumbLine");
                        AppendChildText(wpXML, "MinTurnSpeed", (wp.PtSpeed - 1).ToString());
                        AppendChildText(wpXML, "MaxTurnSpeed", (wp.PtSpeed + 1).ToString());
                        AppendChildText(wpXML, "MinDepartingTrackSpeed", (wp.PtSpeed - 1).ToString());
                        AppendChildText(wpXML, "MaxDepartingTrackSpeed", (wp.PtSpeed + 1).ToString());
                        AppendChildText(wpXML, "AdditionalData", "&lt;AllAdditionalData /&gt;");
                        root.AppendChild(wpXML);
                        wpNum++;
                    }
                    break;


            }

            System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
            saveFile.AddExtension = true;
            saveFile.RestoreDirectory = true;

            switch (format)
            {
                case Format.Transas:
                    saveFile.DefaultExt = "RT3";
                    saveFile.Filter = "Transas Route|*.RT3";
                    break;
                case Format.GPX:
                    saveFile.DefaultExt = "gpx";
                    saveFile.Filter = "GPS Route|*.gpx";
                    break;
                case Format.VisionMaster:
                    saveFile.DefaultExt = "route";
                    saveFile.Filter = "VisionMaster Route|*.route";
                    break;
            }

            try
            {
                saveFile.ShowDialog();
            }
            catch (Exception Ex) { return; }

            if (saveFile.FileName != "")
            {
                switch (format)
                {
                    case Format.GPX:
                        XmlTextWriter xmlWriter = new XmlTextWriter(saveFile.FileName, new UTF8Encoding(false));
                        xmlWriter.Formatting = Formatting.Indented;
                        baseXML.Save(xmlWriter);
                        xmlWriter.Flush();
                        xmlWriter.Close();
                        break;
                    case Format.Transas:
                        StreamWriter writer = new StreamWriter(saveFile.FileName, false);
                        string xmlText = Beautify(baseXML);
                        //eliminate <?xml line
                        xmlText = xmlText.Substring(xmlText.IndexOf("\n") + 1);
                        //add inner text to first element (that otherwise prevents proper formatting)
                        xmlText = xmlText.Replace("RtName=\"" + routeName + "\">", "RtName=\"" + routeName + "\">TSH RtServer route data file. Info: amo.");
                        writer.Write(xmlText);
                        writer.Flush();
                        writer.Close();
                        break;
                    case Format.VisionMaster:
                        writer = new StreamWriter(saveFile.FileName, false);
                        xmlText = Beautify(baseXML);
                        //eliminate <?xml line
                        xmlText = xmlText.Substring(xmlText.IndexOf("\n") + 1);
                        //write schema info
                        xmlText = xmlText.Replace("<NewDataSet>", "<NewDataSet>\r\n" + RouteConverter.Properties.Resources.VisionMasterSchema);
                        //The format has two spaces for indents, should not matter but let's convert:
                        xmlText = xmlText.Replace("\t", "  ");
                        writer.Write(xmlText);
                        writer.Flush();
                        writer.Close();
                        break;
                }
            }


        }

        //this version has a settable speed
        private void AddWaypointEx(XmlElement wayPointExs, Waypoint wp)
        {
            XmlElement wayPointEx = (XmlElement)wayPointExs.AppendChild(baseXML.CreateElement("WayPointEx"));
            wayPointEx.SetAttribute("ChangedData", "0");
            wayPointEx.SetAttribute("TimeZone", "0");
            wayPointEx.SetAttribute("ETA", "0");
            wayPointEx.SetAttribute("ETD", "0");
            wayPointEx.SetAttribute("Stay", "0");
            wayPointEx.SetAttribute("TTG", "0");
            wayPointEx.SetAttribute("TotalTime", "0");
            wayPointEx.SetAttribute("Speed", wp.PtSpeed.ToString());     //set speed here
        }

        private void AddWaypointEx(XmlElement wayPointExs)
        {
            //<WayPointEx ChangedData="0" TimeZone="0" ETA="0" ETD="0" Stay="0" TTG="0" TotalTime="0" Speed="0"/>

            XmlElement wayPointEx = (XmlElement)wayPointExs.AppendChild(baseXML.CreateElement("WayPointEx"));
            wayPointEx.SetAttribute("ChangedData", "0");
            wayPointEx.SetAttribute("TimeZone", "0");
            wayPointEx.SetAttribute("ETA", "0");
            wayPointEx.SetAttribute("ETD", "0");
            wayPointEx.SetAttribute("Stay", "0");
            wayPointEx.SetAttribute("TTG", "0");
            wayPointEx.SetAttribute("TotalTime", "0");
            wayPointEx.SetAttribute("Speed", "12");     //set speed here
        }

        //For VisionMaster
        private XmlElement MakeControlPoints(Waypoint wp)
        {

            return (XmlElement)baseXML.CreateElement("ControlPoints");
        }

        private void AppendChildText(XmlElement parentNode, string nodeName, string innerText)
        {
            XmlElement nameXml = (XmlElement)parentNode.AppendChild(baseXML.CreateElement(nodeName));
            nameXml.InnerText = innerText;
        }

        private string Beautify(XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            settings.NewLineHandling = NewLineHandling.Replace;
            settings.Encoding = new UTF8Encoding(false);
            XmlWriter writer = XmlWriter.Create(sb, settings);
            doc.Save(writer);
            writer.Close();
            return sb.ToString();
        }

    }
}
