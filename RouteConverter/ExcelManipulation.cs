using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace RouteConverter
{
    class ExcelManipulation
    {
        private Excel.Application excelApp;
        private Waypoint[] waypoints;

        public Waypoint[] Waypoints
        {
            get { return waypoints; }
        }

        public Excel.Application ExcelApp
        {
            set { excelApp = value; }
        }

        public ExcelManipulation(Excel.Application manApp)
        {
            excelApp = manApp;
        }

        public void ReadData(int lat, int lon, int wayptNum, int speed, int startRow)
        {
            int length = NumRecords(startRow);
            waypoints = new Waypoint[length];
            for (int row = startRow; row < (startRow + length); row++)
            {
                waypoints[row-startRow] = new Waypoint(excelApp.Range[numToLetter(wayptNum) + row.ToString()].Text, 
                    Convert.ToDouble(excelApp.Range[numToLetter(lat) + row.ToString()].Value), 
                    Convert.ToDouble(excelApp.Range[numToLetter(lon) + row.ToString()].Value), 
                    Convert.ToInt32(excelApp.Range[numToLetter(speed)+row.ToString()].Value));
            }
            return;
        }

        private int NumRecords(int startRow)
        {
            Excel.Range testRange;
            //arbitary 1000 limit to prevent infinite loop
            for (int i = startRow; i < 1000; i++)
            {
                testRange = excelApp.get_Range(numToLetter(1) + i.ToString());
                if (testRange.Text == "")
                {
                    return (i - startRow);
                }
            }
            return 0;
        }

        private string numToLetter(int num)
        {
            string retVal = System.Convert.ToChar(num + 64).ToString();
            return retVal;
        }


    }
}
