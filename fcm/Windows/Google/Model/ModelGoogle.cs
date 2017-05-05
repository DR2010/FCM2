using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary.FCMUtils;
using Google.GData.Documents;
using Google.GData.Client;

using fcm.Windows.Google.Model;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using Utils = MackkadoITFramework.Helper.Utils;

namespace fcm.Windows.Google.Model
{
    public class ModelGoogle
    {

        //Keeps track of our logged in state.
        public bool loggedIn = false;
        //A connection with the DocList API.
        private DocumentsService service;
        //The name of the shell context menu option.
        private const string KEY_NAME = "Send to Google Docs";
        //Keeps track of if we've minimized the OptionsForm before.
        private bool firstMinimize = true;
        //The timer in milliseconds to display balloon tips.
        private const int BALLOON_TIMER = 10000;
        //The most recently uploaded document.
        private DocumentEntry lastUploadEntry = null;
        //Keeps track of if the last balloon tip was an upload complete message.
        private bool lastToolTipWasUpload = false;

        /// <summary>
        /// Authenticates to Google servers
        /// </summary>
        /// <param name="username">The user's username (e-mail)</param>
        /// <param name="password">The user's password</param>
        /// <exception cref="AuthenticationException">Thrown on invalid credentials.</exception>
        public void Login( string username, string password )
        {
            if (loggedIn)
            {
                throw new ApplicationException( "Already logged in." );
            }
            try
            {
                service = new DocumentsService( "DocListUploader" );
                ((GDataRequestFactory)service.RequestFactory).KeepAlive = false;
                service.setUserCredentials( username, password );
                //force the service to authenticate
                DocumentsListQuery query = new DocumentsListQuery();
                query.NumberToRetrieve = 1;
                service.Query( query );
                loggedIn = true;
            }
            catch (AuthenticationException e)
            {
                loggedIn = false;
                service = null;
                throw e;
            }
        }

        /// <summary>
        /// Retrieves a list of documents from the server.
        /// </summary>
        /// <returns>The list of documents as a DocumentsFeed.</returns>
        public DocumentsFeed GetDocs()
        {
            DocumentsListQuery query = new DocumentsListQuery();
            query.ShowFolders = true;

            DocumentsFeed feed = service.Query( query );
            return feed;
        }


        public DocumentsFeed GetFolderList(string folderID) 
        {

            FolderQuery query = new FolderQuery( folderID ); 
            query.ShowFolders = false; 
            DocumentsFeed feed = service.Query(query); 
            return feed; 
        } 

        /// <summary>
        /// Logs the user out of Google Docs.
        /// </summary>
        public void Logout()
        {
            loggedIn = false;
            service = null;
        }

        /// <summary>
        /// Uploads the file to Google Docs
        /// </summary>
        /// <param name="fileName">The file with path to upload</param>
        /// <exception cref="ApplicationException">Thrown when user isn't logged in.</exception>
        public void UploadFile( string fileName )
        {
            if (!loggedIn)
            {
                throw new ApplicationException( "Need to be logged in to upload documents." );
            }
            else
            {
                lastUploadEntry = service.UploadDocument( fileName, null );
            }
        
        }


        /// <summary>
        /// Create a new folder with the name folderName inside parent folder with ID destFolderId
        /// </summary>
        /// <param name="folderName"> new folder's name </param>
        /// <param name="destFolderId"> destination folder's ID </param>
        /// <returns> The ID of the newly created folder </returns>
        public String CreateFolder( String folderName, String destFolderId )
        {
            AtomCategory category = new AtomCategory( "http://schemas.google.com/docs/2007#folder", new AtomUri( "http://schemas.google.com/g/2005#kind" ) );
            category.Label = "folder";

            AtomEntry folder = new AtomEntry();
            folder.Categories.Add( category );
            folder.Title = new AtomTextConstruct( AtomTextConstructElementType.Title, folderName );

            Uri feedUri;
            AtomEntry newFolderEntry;
            if (destFolderId.Equals( "" ))
            {
                feedUri = new Uri( "http://docs.google.com/feeds/documents/private/full" );
                newFolderEntry = this.service.Insert( feedUri, folder );             // send request
            }
            else
            { // !! PROBLEM, "Can not update a read-only feed"; URI: "http://docs.google.com/feeds/documents/private/full/folder:0B5S1An4gAziBNGYxOWI1M2ItYzVjNC00MDViLWFiZWYtM2VhZGUzZDRkZmZl/contents"
                feedUri = new Uri( "http://docs.google.com/feeds/documents/private/full/folder" + "%3A" + destFolderId + "/contents" );
                Console.WriteLine( feedUri.ToString() );
                AtomFeed feed = new AtomFeed( feedUri, this.service );
                newFolderEntry = this.service.Insert( feed, folder );            // send request
            }

            //Console.WriteLine(FolderQuery.DocumentId(newFolderEntry.Id.AbsoluteUri));
            // String folderId = FolderQuery.DocumentID( newFolderEntry.Id.AbsoluteUri );
            String folderId = newFolderEntry.Id.AbsoluteUri;
            Console.WriteLine( folderId );
            return folderId;
        }


        public static void LoadGoogleDocsInTree( TreeView tvGoogle, DocumentsFeed feed )
        {
            // Create folders first
            //
            foreach (DocumentEntry entry in feed.Entries)
            {
                if (!entry.IsFolder)
                    continue;

                int image = 0;
                int imageSelected = 0;

                image = FCMConstant.Image.Folder;
                imageSelected = FCMConstant.Image.Folder;

                TreeNode tn = new TreeNode( entry.Title.Text, image, imageSelected );

                tvGoogle.Nodes.Add( tn );
                tn.Tag = entry;

            }


            // Load documents
            //


            foreach (DocumentEntry entry in feed.Entries)
            {
                if (entry.IsFolder)
                    continue;

                TreeNode parent = new TreeNode();
                parent = tvGoogle.Nodes[0];

                foreach (var folder in entry.ParentFolders)
                {
                    foreach( TreeNode tn in tvGoogle.Nodes)
                    {
                        if (tn.Text == folder.Title)
                        {
                            parent = tn;
                        }
                    }
                }


                int image = 0;
                int imageSelected = 0;

                string documentType = MackkadoITFramework.Helper.Utils.DocumentType.WORD;

                if (entry.IsFolder)
                {
                    documentType = MackkadoITFramework.Helper.Utils.DocumentType.FOLDER;
                    image = FCMConstant.Image.Folder;
                    imageSelected = FCMConstant.Image.Folder;
                }
                else
                {
                    if (entry.IsDocument)
                    {
                        documentType = MackkadoITFramework.Helper.Utils.DocumentType.WORD;
                        image = FCMConstant.Image.Document;
                        imageSelected = FCMConstant.Image.Document;
                    }
                    else
                    {
                        if (entry.IsSpreadsheet)
                        {
                            documentType = Utils.DocumentType.EXCEL;
                            image = FCMConstant.Image.Excel;
                            imageSelected = FCMConstant.Image.Excel;
                        }
                        else
                        {
                            if (entry.IsPDF)
                            {
                                documentType = MackkadoITFramework.Helper.Utils.DocumentType.PDF;
                                image = FCMConstant.Image.PDF;
                                imageSelected = FCMConstant.Image.PDF;
                            }
                        }
                    }
                }

                TreeNode child = new TreeNode( entry.Title.Text, image, imageSelected );
                child.Tag = entry;

                parent.Nodes.Add( child );

            }

            return;
        }
    
    }
}
