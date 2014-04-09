using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RouteConverter
{
    public partial class InputForm : Form
    {
        private XMLOutput.Format format;

        public InputForm(XMLOutput.Format format)
        {
            InitializeComponent();
            this.format = format;
            this.Text = "Convert to " + (format == XMLOutput.Format.Transas ? " Transas ECDIS" : (format == XMLOutput.Format.GPX ? " GPX" : " VisionMaster ECDIS"));
        }

        private void btnRunConversion_Click(object sender, EventArgs e)
        {
            //Read in column locations from dialog
            int latCol = Convert.ToInt32(txtLatCol.Text);
            int lonCol = Convert.ToInt32(txtLonCol.Text);
            int wayptNum = Convert.ToInt32(txtNameCol.Text);
            int speedCol = Convert.ToInt32(txtSpeedCol.Text);
            int rowsAtTop = Convert.ToInt32(txtHeaderRows.Text);

            ExcelManipulation manipulator = new ExcelManipulation(Globals.ThisAddIn.Application);
            manipulator.ReadData(latCol, lonCol, wayptNum, speedCol, rowsAtTop + 1);
            XMLOutput outputWriter = new XMLOutput(format,txtRouteName.Text);
            outputWriter.WriteData(manipulator.Waypoints);

            this.Close();
        }
    }
}
