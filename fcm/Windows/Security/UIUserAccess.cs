using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Security;
using MackkadoITFramework.Utils;
using fcm.Windows.Cache;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;

namespace fcm.Windows
{
    public partial class UIUserAccess : Form
    {
        private TreeNode tndocSelected;
        private List<UserAccess> _ListOfUsers;
        ImageList imageList;
        ImageList imageList32;
        public string ScreenCode;
        float tvClientDocumentListFontSize;
        int tvClientDocumentListIconSize;

        /// <summary>
        /// Constructor
        /// </summary>
        public UIUserAccess()
        {
            InitializeComponent();

            ScreenCode = FCMConstant.ScreenCode.UserAccess;

        }

        /// <summary>
        /// Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIUserAccess_Load(object sender, EventArgs e)
        {
            // Image list
            //

            // 32 x 32
            imageList32 = ControllerUtils.GetImageList();
            imageList32.ImageSize = new Size(32, 32);

            // 16 x 16
            imageList = ControllerUtils.GetImageList();
            tvUserList.ImageList = imageList;
            tvAvailableRoles.ImageList = imageList;

            // Clear nodes
            tvUserList.Nodes.Clear();
            tvAvailableRoles.Nodes.Clear();

            RefreshList();

        }

        /// <summary>
        /// Event Drag and Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvUserList_DragDrop(object sender, DragEventArgs e)
        {
            AddRoleToUser(sender, e);
        }

        /// <summary>
        /// Add role to user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRoleToUser(object sender, DragEventArgs e)
        {
            // Get selected item in available tree
            //
            TreeNode tnRoleAvailableSelected = tvAvailableRoles.SelectedNode;
            if (tnRoleAvailableSelected == null)
                return;

            // Get destination node
            //
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt;
                TreeNode destinationNode;
                pt = tvUserList.PointToClient(new Point(e.X, e.Y));
                destinationNode = tvUserList.GetNodeAt(pt);
                if (destinationNode == null)
                    return;

                var user = new UserAccess();
                user = (UserAccess)destinationNode.Tag;

                if (tnRoleAvailableSelected != null)
                {
                    tnRoleAvailableSelected.Remove();

                    destinationNode.Nodes.Add(tnRoleAvailableSelected);

                    // Get role
                    //
                    SecurityRole roleNew = new SecurityRole();
                    roleNew = (SecurityRole)tnRoleAvailableSelected.Tag;


                    // Update database
                    //
                    SecurityUserRole newUserRole = new SecurityUserRole(HeaderInfo.Instance);
                    newUserRole.FK_Role = roleNew.Role;
                    newUserRole.FK_UserID = user.UserID;
                    newUserRole.IsActive = "Y";
                    newUserRole.IsVoid = "N";
                    newUserRole.StartDate = System.DateTime.Today;

                    var response = newUserRole.Add();

                    // Show message
                    ControllerUtils.ShowFCMMessage(response.UniqueCode, Utils.UserID);

                    RefreshList();
                }
            }
        }

        /// <summary>
        /// Add screen to role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddScreenToRole(object sender, DragEventArgs e)
        {
            // Get selected item in available tree
            //
            TreeNode tnScreenAvailableSelected = tvScreenList.SelectedNode;
            if (tnScreenAvailableSelected == null)
                return;

            // Get destination node
            //
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt;
                TreeNode destinationNode;
                pt = tvAvailableRoles.PointToClient(new Point(e.X, e.Y));
                destinationNode = tvAvailableRoles.GetNodeAt(pt);
                if (destinationNode == null)
                    return;

                var role = new SecurityRole();
                role = (SecurityRole)destinationNode.Tag;

                if (tnScreenAvailableSelected != null)
                {
                    tnScreenAvailableSelected.Remove();

                    destinationNode.Nodes.Add(tnScreenAvailableSelected);

                    // Get scree
                    //
                    CodeValue roleNew = new CodeValue();
                    roleNew = (CodeValue)tnScreenAvailableSelected.Tag;

                    // Update database
                    //
                    SecurityRoleScreen newRoleScreen = new SecurityRoleScreen();
                    newRoleScreen.FKRoleCode = role.Role;
                    newRoleScreen.FKScreenCode = roleNew.ID;

                    var response = BUSUserAccess.AddScreenToRole(newRoleScreen);

                    // Show message
                    ControllerUtils.ShowFCMMessage(response.UniqueCode, Utils.UserID);

                    // RefreshList();
                }
            }
        }

        private void tvUserList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvUserList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvAvailableRoles_DragDrop(object sender, DragEventArgs e)
        {
            // Get selected item in available tree
            //
            //TreeNode tnRoleAvailableSelected = tvAvailableRoles.SelectedNode;
            //if (tnRoleAvailableSelected == null)
            //    return;

            AddScreenToRole(sender, e);

        }

        private void tvAvailableRoles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvAvailableRoles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void removeAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveRoleFromUser(sender, e);
        }

        /// <summary>
        /// Remove role from user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveRoleFromUser(object sender, EventArgs e)
        {
            // Get selected item in available tree
            //
            TreeNode tnUserRoleSelected = tvUserList.SelectedNode;
            if (tnUserRoleSelected == null)
                return;
            
            if (tnUserRoleSelected.Tag.GetType().ToString() != "FCMMySQLBusinessLibrary.SecurityUserRole")
                return;

            // Get role
            //
            SecurityUserRole roleOld = new SecurityUserRole(HeaderInfo.Instance);
            roleOld = (SecurityUserRole )tnUserRoleSelected.Tag;

            // Update database
            //
            SecurityUserRole newUserRole = new SecurityUserRole(HeaderInfo.Instance);
            newUserRole.UniqueID = roleOld.UniqueID;
            newUserRole.FK_Role = roleOld.FK_Role;
            newUserRole.FK_UserID = roleOld.FK_UserID;

            var response = newUserRole.Delete();

            Utils.RefreshCache();

            // Show message
            ControllerUtils.ShowFCMMessage(response.UniqueCode, Utils.UserID);

            RefreshList();

        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtNewPassword.Text = "";

            txtUserID.Focus();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var uacnew = new UserAccess();
            var readuser = uacnew.Read(txtUserID.Text);

            uacnew.UserID = txtUserID.Text;
            uacnew.UserName = txtName.Text;
            uacnew.Salt = System.DateTime.Now.Hour.ToString();
            uacnew.Password = txtPassword.Text;

            var response = BUSUserAccess.Save(uacnew);

            ControllerUtils.ShowFCMMessage(response.UniqueCode, Utils.UserID);

            RefreshList();

        }

        private void tvUserList_Click(object sender, EventArgs e)
        {
        }

        private void tvUserList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get selected item in available tree
            //
            TreeNode tnUserRoleSelected = tvUserList.SelectedNode;
            if (tnUserRoleSelected == null)
                return;

            // Get user
            //
            txtUserID.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtNewPassword.Text = "";

            if (tnUserRoleSelected.Tag.GetType().ToString() == "FCMMySQLBusinessLibrary.UserAccess")
            {
                UserAccess user = new UserAccess();
                user = (UserAccess)tnUserRoleSelected.Tag;

                txtUserID.Text = user.UserID;
                txtName.Text = user.UserName;
            }

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var uacnew = new UserAccess();
            var readuser = uacnew.Read(txtUserID.Text);

            uacnew.UserID = txtUserID.Text;
            uacnew.Salt = System.DateTime.Now.Hour.ToString();
            uacnew.Password = txtPassword.Text;

            if (txtPassword.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            var response = BUSUserAccess.SavePassword(uacnew);

            ControllerUtils.ShowFCMMessage(response.UniqueCode, Utils.UserID);

            // Refresh list
            //
            ListRoles();
            ListUserRoles();

        }

        private void btnSaveRole_Click(object sender, EventArgs e)
        {
            SecurityRole role = new SecurityRole();
            role.Role = txtRoleName.Text;
            role.Description = txtRoleDescription.Text;

            var response = BUSUserAccess.AddRole(role);

            ControllerUtils.ShowFCMMessage(response, HeaderInfo.Instance.UserID);
            RefreshList();


        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            txtRoleName.Focus();
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            // Refresh list
            //
            ListRoles();
            ListUserRoles();
            ListScreens();

            tvScreenList.Nodes[0].Expand();
            tvUserList.Nodes[0].Expand();
            tvAvailableRoles.Nodes[0].Expand();

        }

        /// <summary>
        /// List user roles
        /// </summary>
        private void ListUserRoles()
        {
            tvUserList.Nodes.Clear();

            // List User/Roles
            _ListOfUsers = UserAccess.List();

            // Create root
            //
            UserAccess root = new UserAccess();
            root.UserID = "ROOT";
            root.UserName = "ROOT FOLDER";

            var rootNode =
                new TreeNode(root.UserID, FCMConstant.Image.Folder, FCMConstant.Image.Folder);
            rootNode.Tag = root;

            tvUserList.Nodes.Add(rootNode);

            foreach (var user in _ListOfUsers)
            {
                var usernode =
                    new TreeNode(
                        user.UserID,
                        FCMConstant.Image.Client,
                        FCMConstant.Image.Client);
                usernode.Tag = user;

                rootNode.Nodes.Add(usernode);

                // List Roles
                //
                SecurityUserRole userRole = new SecurityUserRole(HeaderInfo.Instance);
                var userRoleList = userRole.UserRoleList(user.UserID);

                foreach (var userrole in userRoleList)
                {
                    var userrolenode =
                        new TreeNode(
                            userrole.FK_Role,
                            FCMConstant.Image.Checked,
                            FCMConstant.Image.Checked);
                    userrolenode.Tag = userrole;

                    usernode.Nodes.Add(userrolenode);
                }
            }
        }

        /// <summary>
        /// List roles
        /// </summary>
        private void ListRoles()
        {
            tvAvailableRoles.Nodes.Clear();

            // List roles
            //
            SecurityRole rootRole = new SecurityRole();
            rootRole.Role = "ROOT";
            rootRole.Description = "ROOT FOLDER";

            var rootRoleNode =
                new TreeNode(
                    rootRole.Role,
                    FCMConstant.Image.Folder,
                    FCMConstant.Image.Folder);
            rootRoleNode.Tag = rootRole;

            tvAvailableRoles.Nodes.Add(rootRoleNode);

            var roleList = SecurityRole.List();

            foreach (var role in roleList)
            {
                var roleNode =
                    new TreeNode(
                        role.Role,
                        FCMConstant.Image.Checked,
                        FCMConstant.Image.Checked);
                roleNode.Tag = role;

                rootRoleNode.Nodes.Add(roleNode);

                // Add screens connected to role
                //
                var respList = BUSUserAccess.ListByRole(role.Role);
                var listOfScreens = (List<SecurityRoleScreen>) respList.Contents;

                // Get Screen Description from cache.
                //
                foreach (var screen in listOfScreens)
                {
                    var screenDescription =
                        CachedInfo.GetDescription(FCMConstant.CodeTypeString.SCREENCODE, screen.FKScreenCode); 

                    var screenNode =
                        new TreeNode(
                            screenDescription,
                            FCMConstant.Image.Folder,
                            FCMConstant.Image.Folder);
                    screenNode.Tag = screen;

                    roleNode.Nodes.Add(screenNode);
                }

            }
        }

        /// <summary>
        /// List screens
        /// </summary>
        private void ListScreens()
        {
            tvScreenList.Nodes.Clear();

            var codeValue = new CodeValue();
            var listOfScreens = new List<CodeValue>();
            
            codeValue.ListS(FCMConstant.CodeTypeString.SCREENCODE, listOfScreens);

            // List roles
            //
            CodeValue rootScreen = new CodeValue();
            rootScreen.ID = "ROOT";
            rootScreen.Description = "ROOT Screen";

            var rootScreenNode =
                new TreeNode(
                    rootScreen.ID,
                    FCMConstant.Image.Folder,
                    FCMConstant.Image.Folder);
            rootScreenNode.Tag = rootScreen;

            tvScreenList.Nodes.Add(rootScreenNode);

            foreach (var screen in listOfScreens)
            {
                var roleNode =
                    new TreeNode(
                        screen.Description,
                        FCMConstant.Image.Checked,
                        FCMConstant.Image.Checked);
                roleNode.Tag = screen;

                rootScreenNode.Nodes.Add(roleNode);
            }

        }

        private void tvScreenList_DragDrop(object sender, DragEventArgs e)
        {
            // Get selected item in available tree
            //
            TreeNode tnRoleAvailableSelected = tvScreenList.SelectedNode;
            if (tnRoleAvailableSelected == null)
                return;


        }

        private void tvScreenList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvScreenList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    
    }
}
