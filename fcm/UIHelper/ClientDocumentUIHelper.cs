using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using MackkadoITFramework;
using FCMMySQLBusinessLibrary.FCMUtils;

namespace fcm.UIHelper
{
    public class ClientDocumentUIHelper
    {
        // -----------------------------------------------------
        //    Load documents in a tree
        //    The list in tree expects that the list has been 
        //    called before to populate the instance
        // -----------------------------------------------------
        public static void ListInTree(TreeView fileList, string listType, List<scClientDocSetDocLink> clientDocSetDocLink)
        {

            // listType = CLIENT
            // listType = FCM = default;

            string ListType = listType;
            if (ListType == null)
                ListType = "FCM";


            foreach (var docLinkSet in clientDocSetDocLink)
            {
                // Check if folder has a parent

                string cdocumentUID = docLinkSet.clientDocument.UID.ToString();
                string cparentIUID = docLinkSet.clientDocument.ParentUID.ToString();
                TreeNode treeNode = new TreeNode();

                int image = 0;
                int imageSelected = 0;
                docLinkSet.clientDocument.RecordType = docLinkSet.clientDocument.RecordType.Trim();

                image = Utils.GetFileImage(docLinkSet.clientDocument.SourceFilePresent, docLinkSet.clientDocument.DestinationFilePresent, docLinkSet.clientDocument.DocumentType);
                imageSelected = image;

                //if (ListType == "CLIENT")
                //    treeNode = new TreeNode(docLinkSet.clientDocument.FileName, image, imageSelected);
                //else
                //    treeNode = new TreeNode(docLinkSet.document.Name, image, imageSelected);

//                string treenodename = docLinkSet.document.DisplayName;
                string treenodename = docLinkSet.document.FileName;

                if (string.IsNullOrEmpty(treenodename))
                    treenodename = docLinkSet.clientDocument.FileName;

                if (string.IsNullOrEmpty(treenodename))
                    treenodename = "Error: Name not found";

                treeNode = new TreeNode(treenodename, image, imageSelected);

                if (docLinkSet.clientDocument.ParentUID == 0)
                {

                    treeNode.Tag = docLinkSet;
                    treeNode.Name = cdocumentUID;
                    fileList.Nodes.Add(treeNode);

                }
                else
                {
                    // Find the parent node
                    //
                    var node = fileList.Nodes.Find(cparentIUID, true);

                    if (node.Count() > 0)
                    {

                        treeNode.Tag = docLinkSet;
                        treeNode.Name = cdocumentUID;

                        node[0].Nodes.Add(treeNode);
                    }
                    else
                    {
                        // Add Element to the root
                        //
                        treeNode.Tag = docLinkSet;
                        treeNode.Name = cdocumentUID;

                        fileList.Nodes.Add(treeNode);
                    }
                }
            }
        }

        /// <summary>
        /// Document Name
        /// </summary>
        /// <param name="simpleFileName"></param>
        /// <param name="issueNumber"></param>
        /// <param name="CUID"></param>
        /// <returns></returns>
        public static string SetDocumentName( string simpleFileName, string issueNumber, string CUID, string recordtype, string filename )
        {
            if ( string.IsNullOrEmpty( issueNumber ) )
            {
                issueNumber = "0";
            }

            int issue = Convert.ToInt32( issueNumber );
            string issueS = issue.ToString( "00" );

            if ( recordtype == "FOLDER")
                return filename;
            
            return String.Concat( CUID, "-", issueS, " ", simpleFileName );
        }

    }
}
