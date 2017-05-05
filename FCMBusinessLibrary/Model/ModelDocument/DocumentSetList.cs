using System;
using System.Collections.Generic;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace FCMMySQLBusinessLibrary.Model.ModelDocument
{
    public class DocumentSetList
    {
        public List<DocumentSet> documentSetList;

        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        public void List()
        {
            this.documentSetList = new List<DocumentSet>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT UID " +
                " ,TemplateType " +
                " ,TemplateFolder " +
                " ,IsVoid " +

                "   FROM DocumentSet " +
                "  WHERE IsVoid = 'N' " 
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DocumentSet documentSet = new DocumentSet();
                            documentSet.UID = Convert.ToInt32(reader["UID"].ToString());
                            documentSet.TemplateType = reader["TemplateType"].ToString();
                            documentSet.TemplateFolder = reader["TemplateFolder"].ToString();
                            documentSet.IsVoid = Convert.ToChar(reader["IsVoid"].ToString());
                            documentSet.UIDNameDisplay = documentSet.UID.ToString() + "; " + documentSet.TemplateType; 

                            this.documentSetList.Add(documentSet);
                        }
                    }
                }
            }
        }

        public void ListInComboBox(ComboBox cbxList)
        {
            this.List();

            foreach (DocumentSet docSet in documentSetList)
            {
                cbxList.Items.Add(docSet.UID + "; " + docSet.TemplateType);
            }
            
        }
    }
}
