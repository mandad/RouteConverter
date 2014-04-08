using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace RouteConverter
{
    public partial class mainRibbon
    {
        private Excel.Application excelApp;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            excelApp = Globals.ThisAddIn.Application;
        }

        private void btnRunTransasConvert_Click(object sender, RibbonControlEventArgs e)
        {
            //MessageBox.Show("Select column with Waypoint #s");
            //((Excel.Range)excelApp.Selection).Column;

            RunConversion(XMLOutput.Format.Transas);

        }

        private void RunConversion(XMLOutput.Format format)
        {

            InputForm frmInput = new InputForm(format);
            frmInput.ShowDialog();

        }

        private void btnRunGPX_Click(object sender, RibbonControlEventArgs e)
        {
            RunConversion(XMLOutput.Format.GPX);
           
        }

        private void btnVisionMaster_Click(object sender, RibbonControlEventArgs e)
        {
            RunConversion(XMLOutput.Format.VisionMaster);
        }
    }
}
