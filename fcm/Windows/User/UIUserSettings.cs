using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.Security;
using FCMMySQLBusinessLibrary;

namespace fcm.Windows
{
    public partial class UIUserSettings : Form
    {
        private TreeNode tndocSelected;
        private List<UserSettings> _ListOfSettings;
        ImageList imageList;
        ImageList imageList32;
        public string ScreenCode;
        float tvClientDocumentListFontSize;
        int tvClientDocumentListIconSize;

        /// <summary>
        /// Constructor
        /// </summary>
        public UIUserSettings()
        {
            InitializeComponent();
        }

        private void UIUserSettings_Load(object sender, EventArgs e)
        {
            // Image list
            //

            // 32 x 32
            imageList32 = ControllerUtils.GetImageList();
            imageList32.ImageSize = new Size(32, 32);

            // 16 x 16
            imageList = ControllerUtils.GetImageList();
            tvUserSettings.ImageList = imageList;

            // Clear nodes
            tvUserSettings.Nodes.Clear();

            ListUserSettings();

        }


        /// <summary>
        /// List user roles
        /// </summary>
        private void ListUserSettings()
        {
            tvUserSettings.Nodes.Clear();

            // List User/Roles
            _ListOfSettings = UserSettings.List(Utils.UserID);

            // Create root
            //
            UserAccess root = new UserAccess();
            root.UserID = Utils.UserID;
            root.UserName = Utils.UserID;

            var rootNode =
                new TreeNode(root.UserID, FCMConstant.Image.Folder, FCMConstant.Image.Folder);
            rootNode.Tag = root;

            tvUserSettings.Nodes.Add(rootNode);

            foreach (var userSetting in _ListOfSettings)
            {
                string show =  userSetting.FKScreenCode + " " +
                               userSetting.FKControlCode + " " +
                               userSetting.FKPropertyCode + " " +
                               userSetting.Value + " ";
 

                var usernode =
                    new TreeNode(
                        show,
                        FCMConstant.Image.Client,
                        FCMConstant.Image.Client);
                usernode.Tag = userSetting;

                rootNode.Nodes.Add(usernode);

            }
        }
    }
}
