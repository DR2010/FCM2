using System;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Interface;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Security;
using MackkadoITFramework.Utils;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using MySql.Data.MySqlClient;
using System.Transactions;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Repository.RepositoryClient;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Service
{


    public class BUSClient : IBUSClientList, IBUSClientDetails
    {

        /// <summary>
        /// Add client
        /// </summary>
        /// <param name="headerInfo"> </param>
        /// <param name="eventClient"></param>
        /// <param name="linkInitialSet"> </param>
        /// <returns></returns>
        public ClientAddResponse ClientAdd( ClientAddRequest clientAddRequest )
        {
            var response = new ClientAddResponse();

            // This is a new client.
            //
            if ( string.IsNullOrEmpty( clientAddRequest.eventClient.Name ) )
            {
                response.responseStatus = new ResponseStatus()
                {
                    ReturnCode = -0010,
                    ReasonCode = 0001,
                    Message = "Client Name is mandatory."
                };
                return response;
            }
            // --------------------------------------------------------------
            // Check if user ID is already connected to a client
            // --------------------------------------------------------------
            #region Check if user is already connected to a client
            if ( !string.IsNullOrEmpty( clientAddRequest.eventClient.FKUserID ) )
            {
                var checkLinkedUser = new Client( clientAddRequest.headerInfo ) { FKUserID = clientAddRequest.eventClient.FKUserID };
                //var responseLinked = checkLinkedUser.ReadLinkedUser();

                var responseLinked = RepClient.ReadLinkedUser( checkLinkedUser );

                if ( !responseLinked.Successful )
                {
                    response.responseStatus = new ResponseStatus();
                    response.responseStatus = responseLinked;
                    return response;
                }

                if ( responseLinked.ReturnCode == 0001 && responseLinked.ReasonCode == 0001 )
                {
                    response.responseStatus = new ResponseStatus()
                    {
                        ReturnCode = -0010,
                        ReasonCode = 0002,
                        Message = "User ID is already linked to another client."
                    };
                    return response;
                }
            }
            #endregion

            var newClientUid = 0;

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {

                using ( var tr = new TransactionScope( TransactionScopeOption.Required ) )
                {
                    connection.Open();

                    // -------------------------------
                    // Call method to add new client
                    // -------------------------------
                    //var newClient = clientAddRequest.eventClient.Insert(clientAddRequest.headerInfo, connection);

                    var newClient = RepClient.Insert( clientAddRequest.headerInfo, clientAddRequest.eventClient, connection );

                    //   var newClientX = eventClient.MySQLInsert(headerInfo);

                    newClientUid = Convert.ToInt32( newClient.Contents );

                    // -------------------------------------------
                    // Call method to add client extra information
                    // -------------------------------------------
                    clientAddRequest.eventClient.clientExtraInformation.FKClientUID = clientAddRequest.eventClient.UID;
                    var cei = RepClientExtraInformation.Insert(
                                    HeaderInfo.Instance,
                                    clientAddRequest.eventClient.clientExtraInformation,
                                    connection );

                    if ( cei.ReturnCode != 1 )
                    {
                        // Rollback transaction
                        //
                        tr.Dispose();

                        response.responseStatus = new ResponseStatus();
                        response.responseStatus = cei;
                        return response;

                    }

                    // --------------------------------------------
                    // Add first document set
                    // --------------------------------------------
                    var cds = new ClientDocumentSet();
                    cds.FKClientUID = newClientUid;

                    // cds.FolderOnly = "CLIENT" + newClientUID.ToString().Trim().PadLeft(4, '0');
                    cds.FolderOnly = "CLIENT" + newClientUid.ToString().Trim().PadLeft( 4, '0' );

                    // cds.Folder = FCMConstant.SYSFOLDER.CLIENTFOLDER + "\\CLIENT" + newClientUID.ToString().Trim().PadLeft(4, '0');
                    cds.Folder = FCMConstant.SYSFOLDER.CLIENTFOLDER + @"\" + cds.FolderOnly;

                    cds.SourceFolder = FCMConstant.SYSFOLDER.TEMPLATEFOLDER;
                    cds.Add( clientAddRequest.headerInfo, connection );

                    // --------------------------------------------
                    // Apply initial document set
                    // --------------------------------------------
                    if ( clientAddRequest.linkInitialSet == "Y" )
                    {
                        BUSClientDocument.AssociateDocumentsToClient(
                                clientDocumentSet: cds,
                                documentSetUID: clientAddRequest.eventClient.FKDocumentSetUID,
                                headerInfo: clientAddRequest.headerInfo );

                        // Fix Destination Folder Location 
                        //
                        BUSClientDocumentGeneration.UpdateLocation( cds.FKClientUID, cds.ClientSetID );
                    }

                    // Commit transaction
                    //
                    tr.Complete();
                }
            }

            ClientList( clientAddRequest.headerInfo );

            // List();

            // Return new client id
            response.clientUID = newClientUid;
            response.responseStatus = new ResponseStatus();

            return response;
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="clientAddRequest"></param>
        /// <param name="employeeName"> </param>
        /// <param name="roleType"></param>
        private static void AddEmployee( string employeeName, string roleType, string userID, int clientUID )
        {

            if ( string.IsNullOrEmpty( employeeName ) )
                return;

            Employee employee = new Employee();
            employee.UserIdCreatedBy = userID;
            employee.UserIdUpdatedBy = userID;
            employee.FKCompanyUID = clientUID;
            employee.Name = employeeName;
            employee.RoleType = roleType;
            employee.RoleDescription =
                MackkadoITFramework.ReferenceData.CodeValue.GetCodeValueDescription( "ROLETYPE", employee.RoleType );
            employee.Insert();
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="clientAddRequest"></param>
        /// <param name="employeeName"> </param>
        /// <param name="roleType"></param>
        private static void UpdateEmployee( string employeeName, string roleType, string userID, int clientUID )
        {

            if ( string.IsNullOrEmpty( employeeName ) )
                return;

            Employee employee = new Employee();
            employee.UserIdCreatedBy = userID;
            employee.UserIdUpdatedBy = userID;
            employee.FKCompanyUID = clientUID;
            employee.Name = employeeName;
            employee.RoleType = roleType;
            employee.RoleDescription =
                MackkadoITFramework.ReferenceData.CodeValue.GetCodeValueDescription( "ROLETYPE", employee.RoleType );
            employee.Update();
        }
        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="clientAddRequest"></param>
        /// <param name="employeeName"> </param>
        /// <param name="roleType"></param>
        private static void SaveEmployees( int clientUID, ClientEmployee inClientEmployee, string userID )
        {

            ClientEmployee clientEmployee = new ClientEmployee();
            clientEmployee = RepEmployee.ReadEmployees( clientUID );

            // ManagingDirector
            if ( string.IsNullOrEmpty( clientEmployee.ManagingDirector ) )
                AddEmployee( inClientEmployee.ManagingDirector, FCMConstant.RoleTypeCode.ManagingDirector, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.ManagingDirector, FCMConstant.RoleTypeCode.ManagingDirector, userID, clientUID );

            // ProjectManager
            if ( string.IsNullOrEmpty( clientEmployee.ProjectManager ) )
                AddEmployee( inClientEmployee.ProjectManager, FCMConstant.RoleTypeCode.ProjectManager, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.ProjectManager, FCMConstant.RoleTypeCode.ProjectManager, userID, clientUID );

            // ProjectOHSRepresentative
            if ( string.IsNullOrEmpty( clientEmployee.ProjectOHSRepresentative ) )
                AddEmployee( inClientEmployee.ProjectOHSRepresentative, FCMConstant.RoleTypeCode.ProjectOHSRepresentative, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.ProjectOHSRepresentative, FCMConstant.RoleTypeCode.ProjectOHSRepresentative, userID, clientUID );

            // OHSEAuditor  
            if ( string.IsNullOrEmpty( clientEmployee.OHSEAuditor ) )
                AddEmployee( inClientEmployee.ProjectOHSRepresentative, FCMConstant.RoleTypeCode.OHSEAuditor, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.ProjectOHSRepresentative, FCMConstant.RoleTypeCode.OHSEAuditor, userID, clientUID );
            
            // SystemsManager
            if ( string.IsNullOrEmpty( clientEmployee.SystemsManager ) )
                AddEmployee( inClientEmployee.SystemsManager, FCMConstant.RoleTypeCode.SystemsManager, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.SystemsManager, FCMConstant.RoleTypeCode.SystemsManager, userID, clientUID );

            // SiteManager
            if ( string.IsNullOrEmpty( clientEmployee.SiteManager ) )
                AddEmployee( inClientEmployee.SiteManager, FCMConstant.RoleTypeCode.SiteManager, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.SiteManager, FCMConstant.RoleTypeCode.SiteManager, userID, clientUID );

            // Supervisor
            if ( string.IsNullOrEmpty( clientEmployee.Supervisor ) )
                AddEmployee( inClientEmployee.Supervisor, FCMConstant.RoleTypeCode.Supervisor, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.Supervisor, FCMConstant.RoleTypeCode.Supervisor, userID, clientUID );

            // LeadingHand1
            if ( string.IsNullOrEmpty( clientEmployee.LeadingHand1 ) )
                AddEmployee( inClientEmployee.LeadingHand1, FCMConstant.RoleTypeCode.LeadingHand1, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.LeadingHand1, FCMConstant.RoleTypeCode.LeadingHand1, userID, clientUID );

            // LeadingHand2
            if ( string.IsNullOrEmpty( clientEmployee.LeadingHand2 ) )
                AddEmployee( inClientEmployee.LeadingHand1, FCMConstant.RoleTypeCode.LeadingHand2, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.LeadingHand1, FCMConstant.RoleTypeCode.LeadingHand2, userID, clientUID );

            // LeadingHand2
            if ( string.IsNullOrEmpty( clientEmployee.HealthAndSafetyRep ) )
                AddEmployee( inClientEmployee.LeadingHand1, FCMConstant.RoleTypeCode.HealthAndSafetyRep, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.LeadingHand1, FCMConstant.RoleTypeCode.HealthAndSafetyRep, userID, clientUID );

            // AdministrationPerson
            if ( string.IsNullOrEmpty( clientEmployee.HealthAndSafetyRep ) )
                AddEmployee( inClientEmployee.AdministrationPerson, FCMConstant.RoleTypeCode.AdministrationPerson, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.AdministrationPerson, FCMConstant.RoleTypeCode.AdministrationPerson, userID, clientUID );

            // WorkersCompensationCoordinator
            if ( string.IsNullOrEmpty( clientEmployee.HealthAndSafetyRep ) )
                AddEmployee( inClientEmployee.WorkersCompensationCoordinator, FCMConstant.RoleTypeCode.WorkersCompensationCoordinator, userID, clientUID );
            else
                UpdateEmployee( inClientEmployee.WorkersCompensationCoordinator, FCMConstant.RoleTypeCode.WorkersCompensationCoordinator, userID, clientUID );

        }


        /// <summary>
        /// List of clients
        /// </summary>
        public ClientListResponse ClientList( HeaderInfo headerInfo )
        {
            var clientListResponse = new ClientListResponse();
            clientListResponse.response = new ResponseStatus();
            // clientListResponse.clientList = Client.List(headerInfo);

            clientListResponse.clientList = RepClient.List( headerInfo );

            return clientListResponse;
        }

        /// <summary>
        /// Update client details
        /// </summary>
        /// <param name="headerInfo"> </param>
        /// <param name="eventClient"> </param>
        public ClientUpdateResponse ClientUpdate( ClientUpdateRequest clientUpdateRequest )
        {
            var clientUpdateResponse = new ClientUpdateResponse();

            clientUpdateResponse.response = new ResponseStatus();

            // --------------------------------------------------------------
            // Check if user ID is already connected to a client
            // --------------------------------------------------------------

            //var checkLinkedUser = new Client(clientUpdateRequest.headerInfo) 
            //{ FKUserID = clientUpdateRequest.eventClient.FKUserID };

            var checkLinkedUser = new Model.ModelClient.Client( clientUpdateRequest.headerInfo )
            {
                FKUserID = clientUpdateRequest.eventClient.FKUserID,
                UID = clientUpdateRequest.eventClient.UID
            };

            if ( !string.IsNullOrEmpty( checkLinkedUser.FKUserID ) )
            {
                var responseLinked = RepClient.ReadLinkedUser( checkLinkedUser );
                // var responseLinked = checkLinkedUser.ReadLinkedUser();

                if ( responseLinked.ReturnCode == 0001 && responseLinked.ReasonCode == 0001 )
                {
                    clientUpdateResponse.response =
                        new ResponseStatus() { ReturnCode = -0010, ReasonCode = 0001, Message = "User ID is already linked to another client." };
                    return clientUpdateResponse;
                }

                if ( responseLinked.ReturnCode == 0001 && responseLinked.ReasonCode == 0003 )
                {
                    // All good. User ID is connected to Client Supplied.
                    //
                }
            }


            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {
                using ( var tr = new TransactionScope( TransactionScopeOption.Required ) )
                {

                    connection.Open();
                    var newClient = RepClient.Update( clientUpdateRequest.headerInfo, clientUpdateRequest.eventClient, connection );

                    //var responseClientUpdate = clientUpdateRequest.eventClient.Update();
                    var responseClientUpdate = newClient;

                    if ( !responseClientUpdate.Successful )
                    {
                        // Rollback
                        tr.Dispose();

                        clientUpdateResponse.response = new ResponseStatus( MessageType.Error );

                        clientUpdateResponse.response.Message = responseClientUpdate.Message;
                        clientUpdateResponse.response.ReturnCode = responseClientUpdate.ReturnCode;
                        clientUpdateResponse.response.ReasonCode = responseClientUpdate.ReasonCode;

                        return clientUpdateResponse;
                    }
                    // -------------------------------------------
                    // Call method to add client extra information
                    // -------------------------------------------

                    var ceiRead = new RepClientExtraInformation( clientUpdateRequest.headerInfo );
                    ceiRead.FKClientUID = clientUpdateRequest.eventClient.UID;

                    // var ceiResponse = ceiRead.Read();

                    var ceiResponse = RepClientExtraInformation.Read( ceiRead );

                    if ( ceiResponse.ReturnCode != 1 )
                    {
                        // Rollback
                        tr.Dispose();

                        clientUpdateResponse.response = new ResponseStatus( MessageType.Error );
                        return clientUpdateResponse;
                    }

                    // Return Code = 1, Reason Code = 2 means "Record not found"
                    //
                    if ( ceiResponse.ReturnCode == 1 && ceiResponse.ReasonCode == 1 )
                    {

                        clientUpdateRequest.eventClient.clientExtraInformation.RecordVersion = ceiRead.RecordVersion;

                        var cei = RepClientExtraInformation.Update( clientUpdateRequest.headerInfo,
                                                                   clientUpdateRequest.eventClient.
                                                                       clientExtraInformation,
                                                                   connection );

                        // var cei = clientUpdateRequest.eventClient.clientExtraInformation.Update();

                        if ( !cei.Successful )
                        {
                            clientUpdateResponse.response = new ResponseStatus();
                            clientUpdateResponse.response = cei;
                            return clientUpdateResponse;
                        }
                    }

                    // Return Code = 1, Reason Code = 2 means "Record not found"
                    //
                    if ( ceiResponse.ReturnCode == 1 && ceiResponse.ReasonCode == 2 )
                    {
                        // Create new record

                        // -------------------------------------------
                        // Call method to add client extra information
                        // -------------------------------------------
                        clientUpdateRequest.eventClient.clientExtraInformation.FKClientUID = clientUpdateRequest.eventClient.UID;
                        var cei = RepClientExtraInformation.Insert(
                                        HeaderInfo.Instance,
                                        clientUpdateRequest.eventClient.clientExtraInformation,
                                        connection );

                        if ( cei.ReturnCode != 1 )
                        {
                            // Rollback transaction
                            //
                            tr.Dispose();

                            clientUpdateResponse.response = new ResponseStatus();
                            clientUpdateResponse.response = cei;
                            return clientUpdateResponse;

                        }

                    }

                    tr.Complete();
                }
            }

            return clientUpdateResponse;
        }

        /// <summary>
        /// Client Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="eventClient"> </param>
        public ClientDeleteResponse ClientDelete( ClientDeleteRequest clientDeleteRequest )
        {
            // Using model
            Model.ModelClient.Client clientToBeDeleted = new Model.ModelClient.Client( clientDeleteRequest.headerInfo );
            clientToBeDeleted.UID = clientDeleteRequest.clientUID;

            // Using Repository
            ClientDeleteResponse response = new ClientDeleteResponse();
            response.responseStatus = RepClient.Delete( clientToBeDeleted );

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readFieldRequest"></param>
        /// <returns></returns>
        public ReadFieldResponse ReadFieldClient( ReadFieldRequest readFieldRequest )
        {
            var response = RepClient.ReadFieldClient( readFieldRequest );

            return response;
        }

        /// <summary>
        /// Client Read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="eventClient"> </param>
        public static ClientReadResponse ClientRead( ClientReadRequest clientReadRequest )
        {

            var clientReadResponse = RepClient.Read( clientReadRequest.clientUID );

            clientReadResponse.client.clientExtraInformation = new ClientExtraInformation();
            clientReadResponse.client.clientExtraInformation.FKClientUID = clientReadResponse.client.UID;

            // clientReadResponse.client.clientExtraInformation.Read();

            RepClientExtraInformation.Read( clientReadResponse.client.clientExtraInformation );


            return clientReadResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readFieldRequest"></param>
        /// <returns></returns>
        public static string GetClientName( int clientUID )
        {
            var response = RepClient.GetClientName( clientUID );

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readFieldRequest"></param>
        /// <returns></returns>
        public static int GetLinkedClient( string userID )
        {
            var clientUID = RepClient.ReadLinkedClient( userID );

            return clientUID;
        }



        /// <summary>
        /// Add client
        /// </summary>
        /// <param name="headerInfo"> </param>
        /// <param name="eventClient"></param>
        /// <param name="linkInitialSet"> </param>
        /// <returns></returns>
        public ClientAddResponse ClientAddFull( ClientAddRequest clientAddRequest )
        {
            var response = new ClientAddResponse();

            // This is a new client.
            //
            if ( string.IsNullOrEmpty( clientAddRequest.eventClient.Name ) )
            {
                response.responseStatus = new ResponseStatus()
                {
                    ReturnCode = -0010,
                    ReasonCode = 0001,
                    Message = "Client Name is mandatory."
                };
                return response;
            }
            // --------------------------------------------------------------
            // Check if user ID is already connected to a client
            // --------------------------------------------------------------
            #region Check if user is already connected to a client
            if ( !string.IsNullOrEmpty( clientAddRequest.eventClient.FKUserID ) )
            {
                var checkLinkedUser = new Client( clientAddRequest.headerInfo ) { FKUserID = clientAddRequest.eventClient.FKUserID };
                //var responseLinked = checkLinkedUser.ReadLinkedUser();

                var responseLinked = RepClient.ReadLinkedUser( checkLinkedUser );

                if ( !responseLinked.Successful )
                {
                    response.responseStatus = new ResponseStatus();
                    response.responseStatus = responseLinked;
                    return response;
                }

                if ( responseLinked.ReturnCode == 0001 && responseLinked.ReasonCode == 0001 )
                {
                    response.responseStatus = new ResponseStatus()
                    {
                        ReturnCode = -0010,
                        ReasonCode = 0002,
                        Message = "User ID is already linked to another client."
                    };
                    return response;
                }
            }
            #endregion

            var newClientUid = 0;

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {

                using ( var tr = new TransactionScope( TransactionScopeOption.Required ) )
                {
                    connection.Open();

                    // -------------------------------
                    // Call method to add new client
                    // -------------------------------
                    //var newClient = clientAddRequest.eventClient.Insert(clientAddRequest.headerInfo, connection);

                    var newClient = RepClient.Insert( clientAddRequest.headerInfo, clientAddRequest.eventClient, connection );

                    //   var newClientX = eventClient.MySQLInsert(headerInfo);

                    newClientUid = Convert.ToInt32( newClient.Contents );

                    // -------------------------------------------
                    // Call method to add client extra information
                    // -------------------------------------------
                    clientAddRequest.eventClient.clientExtraInformation.FKClientUID = clientAddRequest.eventClient.UID;
                    var cei = RepClientExtraInformation.Insert(
                                    HeaderInfo.Instance,
                                    clientAddRequest.eventClient.clientExtraInformation,
                                    connection );

                    if ( cei.ReturnCode != 1 )
                    {
                        // Rollback transaction
                        //
                        tr.Dispose();

                        response.responseStatus = new ResponseStatus();
                        response.responseStatus = cei;
                        return response;

                    }

                    // Add user role
                    //
                    SecurityUserRole securityUserRole = new SecurityUserRole();
                    securityUserRole.FK_Role = FCMConstant.UserRoleType.CLIENT;
                    securityUserRole.FK_UserID = clientAddRequest.headerInfo.UserID;
                    securityUserRole.IsActive = "Y";
                    securityUserRole.IsVoid = "N";
                    securityUserRole.StartDate = System.DateTime.Today;
                    securityUserRole.EndDate = Convert.ToDateTime("9999-12-31");
                    securityUserRole.Add();

                    // --------------------------------------------
                    // Add List of Employees
                    // --------------------------------------------
                    SaveEmployees( clientAddRequest.eventClient.UID, clientAddRequest.eventClient.clientEmployee, clientAddRequest.headerInfo.UserID );

                    // 14/04/2013
                    // Not adding sets when client is created because the client is created just after the user ID is registered!
                    //

                    // 17/04/2013
                    // If the ADMINistrator creates the client the document set has to be created and documents added.
                    //
                    if ( clientAddRequest.linkInitialSet == "Y" )
                    {
                        // --------------------------------------------
                        // Add first document set
                        // --------------------------------------------
                        var cds = new ClientDocumentSet();
                        cds.FKClientUID = newClientUid;

                        // cds.FolderOnly = "CLIENT" + newClientUID.ToString().Trim().PadLeft(4, '0');
                        cds.FolderOnly = "CLIENT" + newClientUid.ToString().Trim().PadLeft(4, '0');

                        // cds.Folder = FCMConstant.SYSFOLDER.CLIENTFOLDER + "\\CLIENT" + newClientUID.ToString().Trim().PadLeft(4, '0');
                        cds.Folder = FCMConstant.SYSFOLDER.CLIENTFOLDER + @"\" + cds.FolderOnly;

                        cds.SourceFolder = FCMConstant.SYSFOLDER.TEMPLATEFOLDER;
                        cds.Add(clientAddRequest.headerInfo, connection);

                        // --------------------------------------------
                        // Apply initial document set
                        // --------------------------------------------
                        BUSClientDocument.AssociateDocumentsToClient(
                                clientDocumentSet: cds,
                                documentSetUID: clientAddRequest.eventClient.FKDocumentSetUID,
                                headerInfo: clientAddRequest.headerInfo );

                        // Fix Destination Folder Location 
                        //
                        BUSClientDocumentGeneration.UpdateLocation( cds.FKClientUID, cds.ClientSetID );
                    }

                     // Commit transaction
                    
                    tr.Complete();
                }
            }

            ClientList( clientAddRequest.headerInfo );

            // List();

            // Return new client id
            response.clientUID = newClientUid;
            response.responseStatus = new ResponseStatus();

            return response;
        }

        /// <summary>
        /// Client Read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="eventClient"> </param>
        public static ClientReadResponse ClientReadFull( ClientReadRequest clientReadRequest )
        {
            // Check if the user can access the client record
            //
            bool isadmin = false;

            string userid = clientReadRequest.headerInfo.UserID;
            var sur = new SecurityUserRole();

            var clientReadResponse = RepClient.Read( clientReadRequest.clientUID );

            if ( sur.UserHasAccessToRole( userid, FCMConstant.UserRoleType.ADMIN ) )
            {
                // ok
            }
            else
            {
                if ( sur.UserHasAccessToRole( userid, FCMConstant.UserRoleType.CLIENT ) )
                {
                    if ( clientReadResponse.client.FKUserID.ToUpper() == clientReadRequest.headerInfo.UserID.ToUpper() )
                    {
                        //ok
                    }
                    else
                        return new ClientReadResponse();
                }
                else
                    return new ClientReadResponse();
            }



            clientReadResponse.client.clientExtraInformation = new ClientExtraInformation();
            clientReadResponse.client.clientExtraInformation.FKClientUID = clientReadResponse.client.UID;

            RepClientExtraInformation.Read( clientReadResponse.client.clientExtraInformation );

            clientReadResponse.client.clientEmployee = RepEmployee.ReadEmployees( clientReadRequest.clientUID );

            return clientReadResponse;
        }

        /// <summary>
        /// Update client details
        /// </summary>
        /// <param name="headerInfo"> </param>
        /// <param name="eventClient"> </param>
        public ClientUpdateResponse ClientUpdateFull( ClientUpdateRequest clientUpdateRequest )
        {
            var clientUpdateResponse = new ClientUpdateResponse();

            bool contractorSizeFirstTime = false;

            // Check if contractor size has been set before
            //
            var clientRead = RepClient.Read(clientUpdateRequest.eventClient.UID);
            if ( clientRead.client.FKDocumentSetUID == 0)
                contractorSizeFirstTime = true;

            clientUpdateResponse.response = new ResponseStatus();

            // --------------------------------------------------------------
            // Check if user ID is already connected to a client
            // --------------------------------------------------------------

            //var checkLinkedUser = new Client(clientUpdateRequest.headerInfo) 
            //{ FKUserID = clientUpdateRequest.eventClient.FKUserID };

            var checkLinkedUser = new Model.ModelClient.Client( clientUpdateRequest.headerInfo )
            {
                FKUserID = clientUpdateRequest.eventClient.FKUserID,
                UID = clientUpdateRequest.eventClient.UID
            };

            if ( !string.IsNullOrEmpty( checkLinkedUser.FKUserID ) )
            {
                var responseLinked = RepClient.ReadLinkedUser( checkLinkedUser );
                // var responseLinked = checkLinkedUser.ReadLinkedUser();

                if ( responseLinked.ReturnCode == 0001 && responseLinked.ReasonCode == 0001 )
                {
                    clientUpdateResponse.response =
                        new ResponseStatus() { ReturnCode = -0010, ReasonCode = 0001, Message = "User ID is already linked to another client." };
                    return clientUpdateResponse;
                }

                if ( responseLinked.ReturnCode == 0001 && responseLinked.ReasonCode == 0003 )
                {
                    // All good. User ID is connected to Client Supplied.
                    //
                }
            }


            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {
                using ( var tr = new TransactionScope( TransactionScopeOption.Required ) )
                {

                    connection.Open();
                    var newClient = RepClient.Update( clientUpdateRequest.headerInfo, clientUpdateRequest.eventClient, connection );

                    //var responseClientUpdate = clientUpdateRequest.eventClient.Update();
                    var responseClientUpdate = newClient;

                    if ( !responseClientUpdate.Successful )
                    {
                        // Rollback
                        tr.Dispose();

                        clientUpdateResponse.response = new ResponseStatus( MessageType.Error );

                        clientUpdateResponse.response.Message = responseClientUpdate.Message;
                        clientUpdateResponse.response.ReturnCode = responseClientUpdate.ReturnCode;
                        clientUpdateResponse.response.ReasonCode = responseClientUpdate.ReasonCode;

                        return clientUpdateResponse;
                    }
                    // -------------------------------------------
                    // Call method to add client extra information
                    // -------------------------------------------

                    var ceiRead = new RepClientExtraInformation( clientUpdateRequest.headerInfo );
                    ceiRead.FKClientUID = clientUpdateRequest.eventClient.UID;

                    // var ceiResponse = ceiRead.Read();

                    var ceiResponse = RepClientExtraInformation.Read( ceiRead );

                    if ( ceiResponse.ReturnCode != 1 )
                    {
                        // Rollback
                        tr.Dispose();

                        clientUpdateResponse.response = new ResponseStatus( MessageType.Error );
                        return clientUpdateResponse;
                    }

                    // Return Code = 1, Reason Code = 2 means "Record not found"
                    //
                    if ( ceiResponse.ReturnCode == 1 && ceiResponse.ReasonCode == 1 )
                    {

                        clientUpdateRequest.eventClient.clientExtraInformation.RecordVersion = ceiRead.RecordVersion;

                        var cei = RepClientExtraInformation.Update( clientUpdateRequest.headerInfo,
                                                                   clientUpdateRequest.eventClient.
                                                                       clientExtraInformation,
                                                                   connection );

                        // var cei = clientUpdateRequest.eventClient.clientExtraInformation.Update();

                        if ( !cei.Successful )
                        {
                            clientUpdateResponse.response = new ResponseStatus();
                            clientUpdateResponse.response = cei;
                            return clientUpdateResponse;
                        }
                    }

                    // Return Code = 1, Reason Code = 2 means "Record not found"
                    //
                    if ( ceiResponse.ReturnCode == 1 && ceiResponse.ReasonCode == 2 )
                    {
                        // Create new record

                        // -------------------------------------------
                        // Call method to add client extra information
                        // -------------------------------------------
                        clientUpdateRequest.eventClient.clientExtraInformation.FKClientUID = clientUpdateRequest.eventClient.UID;
                        var cei = RepClientExtraInformation.Insert(
                                        HeaderInfo.Instance,
                                        clientUpdateRequest.eventClient.clientExtraInformation,
                                        connection );

                        if ( cei.ReturnCode != 1 )
                        {
                            // Rollback transaction
                            //
                            tr.Dispose();

                            clientUpdateResponse.response = new ResponseStatus();
                            clientUpdateResponse.response = cei;
                            return clientUpdateResponse;

                        }

                    }

                    //tr.Complete();

                    // If this is the first time the users sets the contractor size, add documents.
                    //
                    if ( contractorSizeFirstTime )
                    {
                        // --------------------------------------------
                        // Add first document set
                        // --------------------------------------------
                        var cds = new ClientDocumentSet();
                        cds.FKClientUID = clientUpdateRequest.eventClient.UID;

                        // cds.FolderOnly = "CLIENT" + newClientUID.ToString().Trim().PadLeft(4, '0');
                        cds.FolderOnly = "CLIENT" + clientUpdateRequest.eventClient.UID.ToString().Trim().PadLeft( 4, '0' );

                        // cds.Folder = FCMConstant.SYSFOLDER.CLIENTFOLDER + "\\CLIENT" + newClientUID.ToString().Trim().PadLeft(4, '0');
                        cds.Folder = FCMConstant.SYSFOLDER.CLIENTFOLDER + @"\" + cds.FolderOnly;

                        cds.SourceFolder = FCMConstant.SYSFOLDER.TEMPLATEFOLDER;
                        // cds.Add( clientUpdateRequest.headerInfo, connection );
                        cds.Add( clientUpdateRequest.headerInfo );

                        // --------------------------------------------
                        // Apply initial document set
                        // --------------------------------------------
                        BUSClientDocument.AssociateDocumentsToClient(
                                clientDocumentSet: cds,
                                documentSetUID: clientUpdateRequest.eventClient.FKDocumentSetUID,
                                headerInfo: clientUpdateRequest.headerInfo );

                        // Fix Destination Folder Location 
                        //
                        BUSClientDocumentGeneration.UpdateLocation( cds.FKClientUID, cds.ClientSetID );

                    }

                    SaveEmployees( clientUpdateRequest.eventClient.UID, clientUpdateRequest.eventClient.clientEmployee, clientUpdateRequest.headerInfo.UserID );

                }
            }

            return clientUpdateResponse;
        }

    }
}

