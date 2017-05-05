using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using System.Drawing;
using System.IO;
using System.Reflection;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using HeaderInfo = MackkadoITFramework.Utils.HeaderInfo;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Repository.RepositoryClient;

namespace fcm
{
    /// <summary>
    /// This class was designed after extracting the business logic from the UI.
    /// The essential methods from the Utils (in Business layer now) are now listed here.
    /// </summary>
    public class ControllerUtils
    {

        // -----------------------------------------------------
        //    Load documents in a tree
        //    The list in tree expects that the list has been 
        //    called before to populate the instance
        // -----------------------------------------------------
        public void ListInTree( List<scClientDocSetDocLink> clientDocSetDocLink, TreeView fileList )
        {

            foreach (var docLinkSet in clientDocSetDocLink)
            {
                // Check if folder has a parent

                string cdocumentUID = docLinkSet.clientDocument.UID.ToString();
                string cparentIUID = docLinkSet.clientDocument.ParentUID.ToString();

                int image = 0;
                int imageSelected = 0;
                docLinkSet.clientDocument.RecordType = docLinkSet.clientDocument.RecordType.Trim();

                if (docLinkSet.clientDocument.RecordType == FCMConstant.RecordType.DOCUMENT)
                {
                    //image = FCMConstant.Image.Document;
                    //imageSelected = FCMConstant.Image.Document;
                    
                    image = FCMConstant.Image.Word32;
                    imageSelected = FCMConstant.Image.Word32;

                }
                else
                {
                    image = FCMConstant.Image.Folder;
                    imageSelected = FCMConstant.Image.Folder;
                }

                if (docLinkSet.clientDocument.ParentUID == 0)
                {
                    var treeNode = new TreeNode( docLinkSet.document.Name, image, imageSelected );
                    treeNode.Tag = docLinkSet;
                    treeNode.Name = cdocumentUID;
                    fileList.Nodes.Add( treeNode );

                    // rootNode.Nodes.Add(treeNode);
                }
                else
                {
                    // Find the parent node
                    //
                    var node = fileList.Nodes.Find( cparentIUID, true );

                    if (node.Count() > 0)
                    {

                        var treeNode = new TreeNode( docLinkSet.document.Name, image, imageSelected );
                        treeNode.Tag = docLinkSet;
                        treeNode.Name = cdocumentUID;

                        node[0].Nodes.Add( treeNode );
                    }
                    else
                    {
                        // Add Element to the root
                        //
                        var treeNode = new TreeNode( docLinkSet.document.Name, image, imageSelected );
                        treeNode.Tag = docLinkSet;
                        treeNode.Name = cdocumentUID;

                        fileList.Nodes.Add( treeNode );
                        // rootNode.Nodes.Add(treeNode);

                    }
                }
            }
        }

        // -----------------------------------------------------
        //           Load documents in a tree
        // -----------------------------------------------------
        public static void ListInTree(
            TreeView fileList,
            ClientDocumentLinkList documentList,
            Document root )
        {

            // Find root folder
            //
            Document rootDocument = new Document();

            rootDocument.CUID = root.CUID;
            rootDocument.RecordType = root.RecordType;
            rootDocument.UID = root.UID;
            // rootDocument.Read();

            // rootDocument = RepDocument.Read(false, root.UID);

            // Using Business Layer
            var documentReadRequest = new DocumentReadRequest();
            documentReadRequest.UID = root.UID;
            documentReadRequest.CUID = root.CUID;
            documentReadRequest.retrieveVoidedDocuments = false;

            var docreadresp = BUSDocument.DocumentRead(documentReadRequest);

            if (docreadresp.response.ReturnCode == 0001)
            {
                // all good
            }
            else
            {
                MessageBox.Show(docreadresp.response.Message);
                return;
            }

            rootDocument = docreadresp.document;
            //


            // Create root
            //
            var rootNode = new TreeNode(rootDocument.Name, FCMConstant.Image.Folder, FCMConstant.Image.Folder);

            // Add root node to tree
            //
            fileList.Nodes.Add( rootNode );
            rootNode.Tag = rootDocument;
            rootNode.Name = rootDocument.Name;

            foreach (var document in documentList.clientDocumentLinkList)
            {
                // Ignore root folder
                if (document.childDocument.CUID == "ROOT") continue;

                // Check if folder has a parent
                string cdocumentUID = document.UID.ToString();
                string cparentIUID = document.childDocument.ParentUID.ToString();

                int image = 0;

                if (document.childDocument.RecordType != null)
                {
                    document.childDocument.RecordType = document.childDocument.RecordType.Trim();
                }

                image = Utils.ImageSelect( document.childDocument.RecordType );

                if (document.childDocument.ParentUID == 0)
                {
                    var treeNode = new TreeNode( document.childDocument.Name, image, image );
                    treeNode.Tag = document;
                    treeNode.Name = cdocumentUID;

                    rootNode.Nodes.Add( treeNode );
                }
                else
                {
                    // Find the parent node
                    //
                    var node = fileList.Nodes.Find( cparentIUID, true );

                    if (node.Count() > 0)
                    {

                        var treeNode = new TreeNode( document.childDocument.Name, image, image );
                        treeNode.Tag = document;
                        treeNode.Name = cdocumentUID;

                        node[0].Nodes.Add( treeNode );
                    }
                    else
                    {
                        // Add Element to the root
                        //
                        var treeNode = new TreeNode( document.childDocument.Name, image, image );
                        treeNode.Tag = document;
                        treeNode.Name = cdocumentUID;

                        rootNode.Nodes.Add( treeNode );

                    }
                }
            }
        }

        // ------------------------------------------------------
        //        Return list of images
        // ------------------------------------------------------
        public static ImageList GetImageList()
        {
            // Image list
            //
            var imageList = new ImageList();
            imageList.Images.Add( Properties.Resources.ImageSelected ); // image 0 
            imageList.Images.Add( Properties.Resources.ImageWordDocument ); // image 1 
            imageList.Images.Add( Properties.Resources.ImageFolder ); // image 2
            imageList.Images.Add( Properties.Resources.ImageClient ); // image 3
            imageList.Images.Add( Properties.Resources.Appendix ); // image 4
            imageList.Images.Add( Properties.Resources.Excel ); // image 5
            imageList.Images.Add( Properties.Resources.PDF ); // image 6
            imageList.Images.Add( Properties.Resources.Undefined ); // image 7
            imageList.Images.Add( Properties.Resources.Checked ); // image 8
            imageList.Images.Add( Properties.Resources.Unchecked ); // image 9

            imageList.Images.Add(Properties.Resources.WordFile32); // image 10
            imageList.Images.Add(Properties.Resources.WordFileExists32); // image 11
            imageList.Images.Add(Properties.Resources.WordFileNotFound32); // image 12

            // Word Images 
            imageList.Images.Add(Properties.Resources.WordFileSourceNoDestinationNo); // image 13
            imageList.Images.Add(Properties.Resources.WordFileSourceNoDestinationYes); // image 14
            imageList.Images.Add(Properties.Resources.WordFileSourceYesDestinationNo); // image 15
            imageList.Images.Add(Properties.Resources.WordFileSourceYesDestinationYes); // image 16

            // Excel Images 
            imageList.Images.Add(Properties.Resources.ExcelFileSourceNoDestinationNo); // image 17
            imageList.Images.Add(Properties.Resources.ExcelFileSourceNoDestinationYes); // image 18
            imageList.Images.Add(Properties.Resources.ExcelFileSourceYesDestinationNo); // image 19
            imageList.Images.Add(Properties.Resources.ExcelFileSourceYesDestinationYes); // image 20

            // PDF Images 
            imageList.Images.Add(Properties.Resources.PDFFileSourceNoDestinationNo); // image 21
            imageList.Images.Add(Properties.Resources.PDFFileSourceNoDestinationYes); // image 22
            imageList.Images.Add(Properties.Resources.PDFFileSourceYesDestinationNo); // image 23
            imageList.Images.Add(Properties.Resources.PDFFileSourceYesDestinationYes); // image 24

            Utils.ImageLogoStartsFrom = 25;

            // load client's logo images
            //
            int logoClientNum = 25;

            foreach (var client in Utils.ClientList)
            {
                // Get Company Logo
                //
                string logoLocation = RepClient.GetClientLogoLocation(client.UID, HeaderInfo.Instance);

                // Check if location exists
                if (!File.Exists(logoLocation))
                {
                    LogFile.WriteToTodaysLogFile(
                        " FCMERR00000009 (02)" +
                        " Error. Client logo not found. " +
                        logoLocation +
                        " Client : " + client.UID,
                        Utils.UserID);
                    return imageList;
                }

                Bitmap clientImage;
                clientImage = new Bitmap(logoLocation);
                imageList.Images.Add((Image)clientImage);

                client.LogoImageSeqNum = logoClientNum;
                logoClientNum++;
            }

            return imageList;
        }

        /// <summary>
        /// Show error message.
        /// </summary>
        /// <param name="errorCode"></param>
        public static void ShowFCMMessage(ResponseStatus response, string userID, string message = "")
        {

            switch (response.XMessageType)
            {
                case MessageType.Error:
                    response.Icon = MessageBoxIcon.Error;
                    break;
                case MessageType.Warning:
                    response.Icon = MessageBoxIcon.Warning;
                    break;
                case MessageType.Informational:
                    response.Icon = MessageBoxIcon.Information;
                    break;
            }

            if (string.IsNullOrEmpty(response.Message))
            {
                response.Message =
                    fcm.Windows.Cache.CachedInfo.GetDescription(
                             FCMConstant.CodeTypeString.ErrorCode, 
                             response.UniqueCode);
            }

            MessageBox.Show(response.Message + " " + message,
                            response.UniqueCode,
                            MessageBoxButtons.OK,
                            response.Icon);

            LogFile.WriteToTodaysLogFile(response.Message + " <> " + message, userID);

            return;

        }

        /// <summary>
        /// Show error message.
        /// </summary>
        /// <param name="errorCode"></param>
        public static void ShowFCMMessage(
                string errorCode, 
                string userID, 
                string additionalMessage = "",
                string programName = "")
        {
            if (string.IsNullOrEmpty(errorCode))
                return;

            string messageType = errorCode.Substring(3, 3);
            MessageBoxIcon icon = MessageBoxIcon.Error;

            switch (messageType)
            {
                case "ERR":
                    icon = MessageBoxIcon.Error;
                    break;
                case "WAR":
                    icon = MessageBoxIcon.Warning;
                    break;
                case "INF":
                    icon = MessageBoxIcon.Information;
                    break;
            }    

            string errorDescription = 
            CodeValue.GetCodeValueDescription(
                        FCMConstant.CodeTypeString.ErrorCode,
                        errorCode);

            MessageBox.Show(errorDescription + " " + additionalMessage,
                            errorCode, 
                            MessageBoxButtons.OK,
                            icon);

            LogFile.WriteToTodaysLogFile(
                errorDescription + " " + additionalMessage,
                userID,
                errorCode,
                programName);

            return;
        }
    
    
        /// <summary>
        /// Get current assembly version
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentAssemblyVersion()
        {

            string localAssembly = FCMXmlConfig.Read(FCMConstant.fcmConfigXml.LocalAssemblyFolder);
            string serverAssembly = FCMXmlConfig.Read(FCMConstant.fcmConfigXml.ServerAssemblyFolder);

            string LocalPath = @localAssembly;
            string LocalPathMainAssembly = @LocalPath + "fcm.exe";

            AssemblyName localAssemblyName = new AssemblyName();
            string versionLocal = "";

            // Get the local version of the assembly
            if (File.Exists(LocalPathMainAssembly))
            {
                localAssemblyName = AssemblyName.GetAssemblyName(LocalPathMainAssembly);
                versionLocal = localAssemblyName.Version.ToString();
            }

            return versionLocal;
        }
    }
}
