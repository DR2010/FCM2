using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using FCMMySQLBusinessLibrary.Repository.RepositoryClient;

namespace fcm.Components
{
    public partial class UCClientOtherInfo : UserControl
    {
        private Client client;

        private List<ClientOtherInfo> clientOtherInfoList;

        public UCClientOtherInfo()
        {
            InitializeComponent();
        }

        private void UCClientOtherInfo_Load(object sender, EventArgs e)
        {

        }

        public void PopulateData(int iclientUID)
        {

            client = new Client(HeaderInfo.Instance);
            client.UID = iclientUID;


            var repclient = RepClient.Read(client.UID);
            var response = repclient.responseStatus;

            // var response = client.Read(); 

            if (response.ReturnCode == 1 && response.ReasonCode == 1)
            {
                clientOtherInfoList = ClientOtherInfo.List(client.UID);
                clientOtherInfoBindingSource.DataSource = clientOtherInfoList;

                var codeValue = new CodeValue();
                var list = new List<CodeValue>();
                var codeValueResponse = codeValue.ListS(CodeType.CodeTypeValue.ClientOtherField, list);

                codeValueBindingSource.DataSource = list;
            }
            else
            {
                MessageBox.Show(response.Message, "Error Populating Data.", MessageBoxButtons.OK, response.Icon);
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
         
            //if (dataGridView1.SelectedRows.Count <= 0)
            //    return;

            //var selectedRow = dataGridView1.SelectedRows;

            //selectedRow[0].Cells["dgv" + ClientOtherInfo.FieldName.UID].Value = 0;
            //selectedRow[0].Cells["dgv" + ClientOtherInfo.FieldName.FKClientUID].Value = client.UID;

        }
    }
}
