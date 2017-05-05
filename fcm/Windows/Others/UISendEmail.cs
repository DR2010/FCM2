using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.Repository.RepositoryClient;
using MackkadoITFramework.Utils;

namespace fcm.Windows.Others
{
    public partial class UISendEmail : Form
    {
        private int emailCount;
        private string groupType;
        public UISendEmail()
        {
            InitializeComponent();

            txtHTMLPath.Text = "c:/temp/LetterClient.html";
            txtAttachmentLocation.Text = "c:/FCM_FINAL SafetySeminars 4page eFlyer.pdf";
            txtDestination.Text = "DanielLGMachado@gmail.com";
            txtinlineAttachment.Text = "c:/temp/FCMSignature.jpg";
            txtEmailCount.Text = "2";
            emailCount = 2;
            groupType = "Client";

            webBrowser1.Navigate(txtHTMLPath.Text);

            rbtClient.Checked = true;
        }

        private void btnShowEmail_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate(txtHTMLPath.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string emailTO = txtDestination.Text;

            string emailSubject = "Free Safety Management Plan - October 2014";

           switch (groupType)
            {
                case "Client":
                    emailSubject = "Free Safety Management Plan - October 2014";
                    break;
                case "Contractor":
                    emailSubject = "Construction Safety Workshop - October 2014 - Not to be missed";
                    break;
            }

            string emailBody = webBrowser1.DocumentText;
            string firstname = "Graham";

            string finalemailBody = "";

            switch (groupType)
            {
                case "Client":
                    finalemailBody = "<html><body>" +
                                " Hello " + firstname + " " + emailBody;
                    break;
                case "Sponsor":
                    finalemailBody = "<html><body>" +
                                " Dear " + firstname + " " + emailBody;
                    break;
                case "Presenter":
                    finalemailBody = "<html><body>" +
                                " Dear " + firstname + " " + emailBody;
                    break;
                case "Contractor":
                    finalemailBody = "<html><body>" +
                                " Dear " + firstname + " " + emailBody;
                    break;

            }

            string emailinlineAttachment = txtinlineAttachment.Text;

            var resp1 = FCMEmail.SendEmailSimple(
                iRecipient: emailTO,
                iSubject: emailSubject,
                iBody: finalemailBody,
                // iAttachmentLocation:txtAttachmentLocation.Text,
                inlineAttachment: emailinlineAttachment);

            Cursor.Current = Cursors.Arrow;
            MessageBox.Show("Done."); 
        }

        private void btnToGraham_Click(object sender, EventArgs e)
        {
            txtDestination.Text = "graham.coyle@federalcm.com.au";
        }

        private void btnToDaniel_Click(object sender, EventArgs e)
        {
            txtDestination.Text = "DanielLGMachado@gmail.com";
        }

        private void btnSendGroupEmail_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SendEmailToGroup(groupType);
            Cursor.Current = Cursors.Arrow;
            // MessageBox.Show("Function has been commented out."); 
        }


        private void SendEmailToGroup(string tgroupType)
        {
            emailCount = Convert.ToInt32(txtEmailCount.Text);
            int numberOfEmailsSent = 0;

            // Client
            string emailSubject = "Free Safety Management Plan";
            
            
            // string emailSubject = "Construction Safety Workshop ";
            
            string emailBody = webBrowser1.DocumentText;

            var listOfClientEmail = RepClientEmail.List(tgroupType);

            foreach (var clientEmail in listOfClientEmail)
            {
                if (numberOfEmailsSent >= emailCount)
                    break;

                if (string.IsNullOrEmpty(clientEmail.EmailAddress))
                {
                    LogFile.WriteToTodaysLogFile("Email NOT sent to : " + clientEmail.FirstName + " Empty email address ", "DM0001");
                    continue;
                }
                string finalemailBody = "";

                switch (tgroupType)
                {
                    case "Client":
                        emailSubject = "Free Safety Management Plan - October 2014 ";
                        finalemailBody = "<html><body>" +
                                    " Hello " + clientEmail.FirstName + " " + emailBody;
                        break;
                    case "Sponsor":
                        finalemailBody = "<html><body>" +
                                    " Dear " + clientEmail.FirstName + " " + emailBody;
                        break;
                    case "Presenter":
                        finalemailBody = "<html><body>" +
                                    " Dear " + clientEmail.FirstName + " " + emailBody;
                        break;
                    case "Contractor":
                        emailSubject = "Construction Safety Workshop - October 2014 - Not to be missed";
                        finalemailBody = "<html><body>" +
                                    " Dear " + clientEmail.FirstName + " " + emailBody;
                        break;

                }

                string emailinlineAttachment = txtinlineAttachment.Text;

                var resp1 = FCMEmail.SendEmailSimple(
                    iRecipient: clientEmail.EmailAddress,
                    iSubject: emailSubject,
                    iBody: finalemailBody,
                    // iAttachmentLocation: txtAttachmentLocation.Text,
                    inlineAttachment: emailinlineAttachment);

                LogFile.WriteToTodaysLogFile("Email sent to : " + clientEmail.EmailAddress + " " + clientEmail.FirstName, "DM0001");

                RepClientEmail.UpdateToEmailSent(clientEmail.UID);

                numberOfEmailsSent++;
            }

        }




        private void rbtClient_CheckedChanged(object sender, EventArgs e)
        {
            groupType = "Client";
            ShowEmail(groupType);
            ListDestination(groupType);
        }

        private void rbtSponsor_CheckedChanged(object sender, EventArgs e)
        {
            groupType = "Sponsor";
            ShowEmail(groupType);
            ListDestination(groupType);

        }

        private void rbtPresenter_CheckedChanged(object sender, EventArgs e)
        {
            groupType = "Presenter";
            ShowEmail(groupType);
            ListDestination(groupType);
        }

        private void rbtChampion_CheckedChanged(object sender, EventArgs e)
        {
            groupType = "Contractor";
            ShowEmail(groupType);
            ListDestination(groupType);
        }

        private void ShowEmail(string emailType)
        {
            switch (emailType)
            {
                case "Client":

                    txtHTMLPath.Text = @"C:/I_Daniel/Dropbox/I_Projects/FCM_Projects/Workshops/Dec2014/Letters/LetterParticipant.html";
                    webBrowser1.Navigate(txtHTMLPath.Text);
                    break;

                case "Sponsor":

                    txtHTMLPath.Text = "c:/temp/LetterSponsor.html";
                    webBrowser1.Navigate(txtHTMLPath.Text);
                    break;

                case "Contractor":

                    txtHTMLPath.Text = "c:/temp/LetterContractor.html";
                    webBrowser1.Navigate(txtHTMLPath.Text);
                    break;

                case "Presenter":

                    txtHTMLPath.Text = "c:/temp/LetterPresenter.html";
                    webBrowser1.Navigate(txtHTMLPath.Text);
                    break;

                case "ISS":

                    txtHTMLPath.Text = "c:/temp/CertificateISS.html";
                    webBrowser1.Navigate(txtHTMLPath.Text);
                    break;


                case "WSP":

                    txtHTMLPath.Text = "c:/temp/CertificateWSP.html";
                    webBrowser1.Navigate(txtHTMLPath.Text);
                    break;
            }
        }

        private void ListDestination(string tgroupType)
        {
            List<ClientEmail> listOfClientEmail;
            if (groupType == "ISS" || groupType == "WSP")
                listOfClientEmail = RepClientEmail.ListCertificates(tgroupType);
            else
                listOfClientEmail = RepClientEmail.List(tgroupType);
                
            txtTotalEmail.Text = listOfClientEmail.Count.ToString();

            listBox1.Items.Clear();
            
            foreach (var clientEmail in listOfClientEmail)
            {
                listBox1.Items.Add(clientEmail.FirstName +" "+ clientEmail.EmailAddress + " == " + clientEmail.Type);
            }
        }


        private void rbtCert2_CheckedChanged(object sender, EventArgs e)
        {
            groupType = "ISS";
            ShowEmail("ISS");
            ListDestination(groupType);
        }

        private void rbtCert1_CheckedChanged(object sender, EventArgs e)
        {
            groupType = "WSP";
            ShowEmail("WSP");
            ListDestination(groupType);
        }

        private void btnEmailCertificates_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            emailCount = Convert.ToInt32(txtEmailCount.Text);
            int numberOfEmailsSent = 0;

            string emailSubject = "";
            string emailBody = webBrowser1.DocumentText;

            var listOfClientEmail = RepClientEmail.ListCertificates(groupType); // "Cert"

            foreach (var clientEmail in listOfClientEmail)
            {
                if (numberOfEmailsSent >= emailCount)
                    break;

                if (string.IsNullOrEmpty(clientEmail.EmailAddress))
                {
                    LogFile.WriteToTodaysLogFile("Email NOT sent to : " + clientEmail.FirstName + " Empty email address ", "DM0001");
                    continue;
                }
                string finalemailBody = "";



                if (clientEmail.CertificateType == "WSP")
                    emailSubject = "Working Safely With Plant 2013 Certificate and Question and Answers";
                else
                    emailSubject = "FCM 2014 Final Construction Safety Workshop Presentations";


                finalemailBody = "<html><body>" +
                                " Dear " + clientEmail.FirstName + " " + emailBody;

                string emailinlineAttachment = txtinlineAttachment.Text;

                // iAttachmentLocation: @"C:\I_Daniel\Dropbox\I_Projects\FCM_Projects\Workshops\Dec2014\FullPresentation.pdf",

                var resp1 = FCMEmail.SendEmailSimple(
                    iRecipient: clientEmail.EmailAddress,
                    iSubject: emailSubject,
                    iBody: finalemailBody,
                    iAttachmentLocation: "",
                    iAttachmentLocation2: "",
                    inlineAttachment: emailinlineAttachment);

                LogFile.WriteToTodaysLogFile("Email sent to : " + clientEmail.EmailAddress + " " + clientEmail.FirstName, "DM0001");

                RepClientEmail.UpdateToEmailSent(clientEmail.UID);

                numberOfEmailsSent++;
            }
            Cursor.Current = Cursors.Arrow;


        }

        private void UISendEmail_Load(object sender, EventArgs e)
        {

        }

    }
}
