using System;
using System.Windows.Forms;
using MackkadoITFramework.ErrorHandling;

namespace FCMMySQLBusinessLibrary.Model.ModelDocument
{
    public class MasterSystemDocument
    {

        /// <summary>
        /// Generate master of system documents
        /// </summary>
        /// <param name="tv"></param>
        private ResponseStatus GenerateMasterOfSystemDocuments(TreeView tv)
        {
            ResponseStatus ret = new ResponseStatus();
            object destinationFileName = "temp01.doc";
            object saveFile = destinationFileName;

            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object vkTrue = true;
            object vkDynamic = 2;

            object vkMissing = System.Reflection.Missing.Value;
            Word.Application vkWordApp = new Word.Application();

            Word.Document vkMyDoc;
            try
            {
                vkMyDoc = vkWordApp.Documents.Open(
                    ref destinationFileName, ref vkMissing, ref vkReadOnly,
                    ref vkMissing, ref vkMissing, ref vkMissing,
                    ref vkMissing, ref vkMissing, ref vkMissing,
                    ref vkMissing, ref vkMissing, ref vkVisible);

            }
            catch (Exception ex)
            {

                ret.ReturnCode = -1;
                ret.ReasonCode = 1000;
                ret.Message = "Error creating file.";
                ret.Contents = ex;
                return ret;
            }





            return ret;
        }

    }
}
