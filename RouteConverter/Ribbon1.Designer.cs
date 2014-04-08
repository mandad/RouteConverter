namespace RouteConverter
{
    partial class mainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public mainRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpTransas = this.Factory.CreateRibbonGroup();
            this.btnRunTransasConvert = this.Factory.CreateRibbonButton();
            this.btnRunGPX = this.Factory.CreateRibbonButton();
            this.btnVisionMaster = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpTransas.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpTransas);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // grpTransas
            // 
            this.grpTransas.Items.Add(this.btnRunTransasConvert);
            this.grpTransas.Items.Add(this.btnRunGPX);
            this.grpTransas.Items.Add(this.btnVisionMaster);
            this.grpTransas.Label = "Route Export";
            this.grpTransas.Name = "grpTransas";
            // 
            // btnRunTransasConvert
            // 
            this.btnRunTransasConvert.Label = "Transas ECDIS";
            this.btnRunTransasConvert.Name = "btnRunTransasConvert";
            this.btnRunTransasConvert.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRunTransasConvert_Click);
            // 
            // btnRunGPX
            // 
            this.btnRunGPX.Label = "GPX";
            this.btnRunGPX.Name = "btnRunGPX";
            this.btnRunGPX.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRunGPX_Click);
            // 
            // btnVisionMaster
            // 
            this.btnVisionMaster.Label = "VisionMaster";
            this.btnVisionMaster.Name = "btnVisionMaster";
            this.btnVisionMaster.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnVisionMaster_Click);
            // 
            // mainRibbon
            // 
            this.Name = "mainRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpTransas.ResumeLayout(false);
            this.grpTransas.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpTransas;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRunTransasConvert;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRunGPX;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnVisionMaster;
    }

    partial class ThisRibbonCollection
    {
        internal mainRibbon Ribbon1
        {
            get { return this.GetRibbon<mainRibbon>(); }
        }
    }
}
