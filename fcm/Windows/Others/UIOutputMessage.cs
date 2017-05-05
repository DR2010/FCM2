using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MackkadoITFramework.Interfaces;
using MackkadoITFramework.Utils;

namespace fcm.Windows
{
    public partial class UIOutputMessage : Form, IOutputMessage
    {
        public DataTable elementSourceDataTable;
        public DataTable errorDataTable;

        public UIOutputMessage()
        {
            InitializeComponent();

            // Create datatable
            var outputMessage = new DataColumn("outputMessage", typeof(String));
            elementSourceDataTable = new DataTable("ElementSourceDataTable");
            elementSourceDataTable.Columns.Add(outputMessage);
            dgvOutputMessage.DataSource = elementSourceDataTable;


            // Create datatable
            var errorMessage = new DataColumn( "errorMessage", typeof( String ) );
            errorDataTable = new DataTable( "ElementSourceDataTable" );
            errorDataTable.Columns.Add( errorMessage );
            dgvErrorList.DataSource = errorDataTable;

        }

        private void UIOutputMessage_Load(object sender, EventArgs e)
        {
            txtStartTime.Text = System.DateTime.Now.ToString();

        }

        public void AddOutputMessage( string outputMessage, string processName, string userID )
        {
            DataRow elementRow = elementSourceDataTable.NewRow();
            elementRow["outputMessage"] = outputMessage;
            elementSourceDataTable.Rows.Add(elementRow);
            txtEndTime.Text = System.DateTime.Now.ToString();

            dgvOutputMessage.FirstDisplayedCell = dgvOutputMessage[0, dgvOutputMessage.Rows.Count - 1];

            LogFile.WriteToTodaysLogFile( what: outputMessage,userID:userID,messageCode:"",programName:"UIOutputMessage.cs", processname: processName  );

            this.Refresh();
        }

        public void AddErrorMessage( string errorMessage, string processName, string userID )
        {
            DataRow elementRow = errorDataTable.NewRow();
            elementRow["errorMessage"] = errorMessage;
            errorDataTable.Rows.Add( elementRow );
            txtEndTime.Text = System.DateTime.Now.ToString();

            dgvOutputMessage.FirstDisplayedCell = dgvOutputMessage[0, dgvOutputMessage.Rows.Count - 1];

            LogFile.WriteToTodaysLogFile( what: errorMessage, userID: userID, messageCode: "", programName: "UIOutputMessage.cs", processname: processName );

            this.Refresh();
        }

        public void UpdateProgressBar( double value, DateTime estimatedTime, int documentsToBeGenerated = 0 )
        {
            if (value > 100)
                return;

            progressBar1.Value = Convert.ToInt32( value );
            txtEstimatedTime.Text = estimatedTime.ToString();
            txtDocsToBeGenerated.Text = documentsToBeGenerated.ToString();

            this.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
