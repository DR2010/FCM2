using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Interfaces;
using MackkadoITFramework.Utils;
//using Microsoft.Office.Core;

namespace MackkadoITFramework.APIDocument
{
    public class WordDocumentTasks
    {
        private int row;

        // ---------------------------------------------
        //             Open Document
        // ---------------------------------------------
        public static ResponseStatus OpenDocument(object fromFileName, object vkReadOnly, bool isFromWeb=false)
        {

            if ( !isFromWeb )
                if ( !File.Exists( (string) fromFileName ) )
                {
                    ResponseStatus rserror = new ResponseStatus( MessageType.Error );
                    rserror.Message = "File not found. " + fromFileName;
                    MessageBox.Show( rserror.Message );
                    return rserror;
                }

            Word.Application vkWordApp =
                                 new Word.Application();

            // object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object vkTrue = true;
            object vkDynamic = 2;


            object vkMissing = System.Reflection.Missing.Value;

            // Let's make the word application visible
            vkWordApp.Visible = true;
            vkWordApp.Activate();

            // Let's open the document
            Word.Document vkMyDoc = vkWordApp.Documents.Open(
                ref fromFileName, ref vkMissing, ref vkReadOnly,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkVisible);

            return new ResponseStatus();
        }

        // ---------------------------------------------
        //             Copy Documents
        // ---------------------------------------------
        public static object CopyDocumentReplaceContents(
                                           object fromFileName,
                                           object destinationFileName,
                                           List<WordDocumentTasks.TagStructure> tag
                                  )
        {

            Word.Application vkWordApp = 
                                 new Word.Application();

            object saveFile = destinationFileName;

            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object vkTrue = true;
            object vkDynamic = 2;


            object vkMissing = System.Reflection.Missing.Value;

            // Let's make the word application visible
            vkWordApp.Visible = true;
            vkWordApp.Activate();

            // Let's open the document
            Word.Document vkMyDoc = vkWordApp.Documents.Open(
                ref fromFileName, ref vkMissing, ref vkReadOnly,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkVisible);

            // Let's create a new document
            Word.Document vkNewDoc = vkWordApp.Documents.Add(
                ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkVisible);

            // Select and Copy from the original document
            vkMyDoc.Select();
            vkWordApp.Selection.Copy();

            // Paste into new document as unformatted text
            vkNewDoc.Select();
            vkWordApp.Selection.PasteSpecial(ref vkMissing, ref vkFalse,
                                               ref vkMissing, ref vkFalse, ref vkDynamic, 
                                               ref vkMissing, ref vkMissing);

            // Save the new document
            vkNewDoc.SaveAs(ref saveFile, ref vkMissing,
                               ref vkMissing, ref vkMissing, ref vkMissing,
                               ref vkMissing, ref vkMissing, ref vkMissing,
                               ref vkMissing, ref vkMissing, ref vkMissing);


            // Copy elements
            // FromString => toString
            // 
            // underdevelopment
            //
            vkNewDoc.Select();

            foreach (var t in tag)
            {
                FindAndReplace(t.Tag, t.TagValue, 1, vkWordApp, vkMyDoc);
            }

            vkNewDoc.Save();

            // close the new document
            vkNewDoc.Close(ref vkFalse, ref vkMissing, ref vkMissing);

            // close the original document
            vkMyDoc.Close(ref vkFalse, ref vkMissing, ref vkMissing);

            // close word application
            vkWordApp.Quit(ref vkFalse, ref vkMissing, ref vkMissing);

            return saveFile;
        }

        
        // ---------------------------------------------
        //    
        // ---------------------------------------------
        /// <summary>
        /// Create client document and replace document tags
        /// </summary>
        /// <param name="fromFileName"></param>
        /// <param name="destinationFileName"></param>
        /// <param name="tag"></param>
        /// <param name="vkWordApp"></param>
        /// <returns></returns>
        public static ResponseStatus CopyDocument(
                                           object fromFileName,
                                           object destinationFileName,
                                           List<WordDocumentTasks.TagStructure> tag,
                                            Word.Application vkWordApp,
                                            IOutputMessage uioutput,
                                            string processName, string userID
                                  )
        {

            ResponseStatus ret = new ResponseStatus();

            object saveFile = destinationFileName;

            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object vkTrue = true;
            object vkDynamic = 2;

            object vkMissing = System.Reflection.Missing.Value;

            // Let's make the word application not visible
            // vkWordApp.Visible = false;
            // vkWordApp.Activate();

            // Let's copy the document

            if ( uioutput != null ) uioutput.AddOutputMessage( "Copying file from: " + fromFileName + " to: " + destinationFileName, processName, userID );

            File.Copy(fromFileName.ToString(), destinationFileName.ToString(), true);

            // Let's open the DESTINATION document

            Word.Document vkMyDoc;
            try
            {

                //vkMyDoc = vkWordApp.Documents.Open(
                //    ref destinationFileName, ref vkMissing, ref vkReadOnly,
                //    ref vkMissing, ref vkMissing, ref vkMissing,
                //    ref vkMissing, ref vkMissing, ref vkMissing,
                //    ref vkMissing, ref vkMissing, ref vkVisible );

                //vkMyDoc = vkWordApp.Documents.Open(
                //    ref destinationFileName, ref vkMissing, ref vkReadOnly,
                //    ref vkMissing, ref vkMissing, ref vkMissing,
                //    ref vkMissing, ref vkMissing, ref vkMissing,
                //    ref vkMissing, ref vkMissing, ref vkVisible );

                if ( uioutput != null ) uioutput.AddOutputMessage( "Opening file: " + destinationFileName, processName, userID );

                vkMyDoc = vkWordApp.Documents.Open(
                    FileName: destinationFileName,
                    ConfirmConversions: vkFalse,
                    ReadOnly: vkFalse,
                    AddToRecentFiles: vkMissing,
                    PasswordDocument: vkMissing,
                    PasswordTemplate: vkMissing,
                    Revert: vkMissing,
                    WritePasswordDocument: vkMissing,
                    WritePasswordTemplate: vkMissing, 
                    Format: vkMissing, 
                    Encoding: vkMissing,
                    Visible: vkFalse );

            }
            catch (Exception ex)
            {

                ret.ReturnCode = -1;
                ret.ReasonCode = 1000;
                ret.Message = "Error opening file." + destinationFileName;
                ret.Contents = ex;
                return ret;
            }

            //
            // In case the file is still read-only...
            //
            if ( uioutput != null ) uioutput.AddOutputMessage( "Checking if file is read-only: " + destinationFileName, processName, userID );
            if ( vkMyDoc.ReadOnly )
            {
                uioutput.AddOutputMessage( "(Word) File is Read-only contact support:  " + fromFileName, processName, userID );
                vkMyDoc.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject( vkMyDoc );
                return ret;
            }

            if ( uioutput != null ) uioutput.AddOutputMessage( "File is NOT read-only!!  " + destinationFileName, processName, userID );

            if ( uioutput != null ) uioutput.AddOutputMessage( "Starting find and replace loop", processName, userID );


            // 18/04/2013
            // 
            vkMyDoc.Activate();

            foreach (var t in tag)
            {
                if ( t.TagType == Helper.Utils.InformationType.FIELD || t.TagType == Helper.Utils.InformationType.VARIABLE )
                {
                    FindAndReplace(t.Tag, t.TagValue, 1, vkWordApp, vkMyDoc);
                    // ReplaceProperty(t.Tag, t.TagValue, 1, vkWordApp, vkMyDoc);
                }
                else
                {
                    insertPicture( vkMyDoc, t.TagValue, t.Tag );
                }
            }

            // 15/03/2013
            // Force field update
            if ( uioutput != null ) uioutput.AddOutputMessage( "Force field updates.", processName, userID );
            foreach (Word.Range myStoryRange in vkMyDoc.StoryRanges)
            {
                myStoryRange.Fields.Update();
            }

            // 24/10/2010 - Modificado quando troquei a referencia do Word
            //
            //vkMyDoc.Sections.Item( 1 ).Headers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterPrimary ).Range.Fields.Update();
            //vkMyDoc.Sections.Item( 1 ).Footers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterPrimary ).Range.Fields.Update();

            try
            {
                if ( vkMyDoc.ReadOnly )
                {
                    if (uioutput != null)
                        uioutput.AddOutputMessage( "(Word) File is Read-only contact support:  " + fromFileName, processName, userID );
                }
                else
                {
                    if ( uioutput != null ) uioutput.AddOutputMessage( "Saving file, it is no read-only.", processName, userID );

                    vkMyDoc.Save();
                }
            }
            catch (Exception ex)
            {
                if (uioutput != null)
                    uioutput.AddOutputMessage( "(Word) ERROR Saving in file:  " + fromFileName + " --- Message: " + ex.ToString(), processName, userID );
            }

            // close the new document
            try
            {
                if ( uioutput != null ) uioutput.AddOutputMessage( "Closing file", processName, userID );
                vkMyDoc.Close(SaveChanges:vkTrue);

            }
            catch ( Exception ex )
            {
                if (uioutput != null)
                    uioutput.AddOutputMessage( "(Word) ERROR Closing file:  " + fromFileName + " --- Message: " + ex.ToString(), processName, userID );
            }


            
            // Trying to release COM object
            if ( uioutput != null ) uioutput.AddOutputMessage( "Releasing COM object", processName, userID );
            System.Runtime.InteropServices.Marshal.ReleaseComObject( vkMyDoc );

            return ret;
        }




        // ---------------------------------------------
        //             Copy Documents
        // ---------------------------------------------
        public static object CopyDocument(
                                           object fromFileName,
                                           object destinationFileName,
                                           List<WordDocumentTasks.TagStructure> tag
                                  )
        {

            Word.Application vkWordApp =
                                 new Word.Application();

            object saveFile = destinationFileName;

            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object vkTrue = true;
            object vkDynamic = 2;

            object vkMissing = System.Reflection.Missing.Value;

            // Let's make the word application visible
            vkWordApp.Visible = true;
            vkWordApp.Activate();

            // Let's copy the document
            File.Copy(fromFileName.ToString(), destinationFileName.ToString(), true);

            // Let's open the DESTINATION document
            Word.Document vkMyDoc = vkWordApp.Documents.Open(
                ref destinationFileName, ref vkMissing, ref vkReadOnly,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkVisible);

            foreach (var t in tag)
            {
                FindAndReplace(t.Tag, t.TagValue, 1, vkWordApp, vkMyDoc);
            }

            vkMyDoc.Save();

            // close the new document
            vkMyDoc.Close(ref vkFalse, ref vkMissing, ref vkMissing);

            // close word application
            vkWordApp.Quit(ref vkFalse, ref vkMissing, ref vkMissing);

            return saveFile;
        }

        //// ----------------------------------------------------
        ////         Find and replace words in MS Word
        //// ----------------------------------------------------
        //public static void FindAndReplaceFIRST(
        //                           object vkFind, 
        //                           object vkReplace, 
        //                           object vkNum, 
        //            Word.Application vkWordApp,
        //                    Word.Document vkMyDoc
        //    )
        //{
        //    object vkReadOnly = false;
        //    object vkVisible = true;
        //    object vkFalse = false;
        //    object missing = false;
        //    object vkTrue = true;
        //    object vkDynamic = 2;
        //    object replaceAll = Word.WdReplace.wdReplaceAll;

        //    if (vkMyDoc == null)
        //    {
        //        return;
        //    }
        //    if (vkWordApp == null)
        //    {
        //        return;
        //    }
        //    if (vkReplace.ToString().Trim().Length == 0)
        //    {
        //        return;
        //    }
        //    if (vkFind.ToString().Trim().Length == 0)
        //    {
        //        return;
        //    }


        //    // Replace Word Document body
        //    //
            
        //    // 05/09/2010 - Testando a passagem de paramentros com nome do parametro... nao remover codigo abaixo.

        //    // Working... Forward = false;

        //    //vkWordApp.Selection.Find.Execute(
        //    //    ref vkFind, ref vkFalse, ref vkFalse,
        //    //    ref vkFalse, ref vkFalse, ref vkFalse,
        //    //    ref vkTrue, ref vkNum, ref vkFalse,
        //    //    ref vkReplace, ref vkDynamic, ref vkFalse,
        //    //    ref vkFalse, ref vkFalse, ref vkFalse );

        //    //vkWordApp.Selection.Find.Execute(
        //    //          FindText: vkFind,
        //    //          ReplaceWith: vkReplace,
        //    //          MatchCase: vkFalse,
        //    //          MatchWholeWord: vkTrue,
        //    //          MatchAllWordForms: vkTrue,
        //    //          Replace: vkDynamic);

        //    vkWordApp.Selection.Find.Execute(
        //        MatchCase: vkFalse,
        //        MatchWholeWord: vkTrue,
        //        MatchWildcards: vkFalse,
        //        MatchSoundsLike: vkFalse,
        //        MatchAllWordForms: vkFalse,
        //        Forward: vkFalse,
        //        Wrap: vkNum,
        //        Format: vkFalse,
        //        FindText: vkFind,
        //        ReplaceWith: vkReplace,
        //        Replace: vkDynamic,
        //        MatchKashida: vkFalse,
        //        MatchDiacritics: vkFalse,
        //        MatchAlefHamza: vkFalse,
        //        MatchControl: vkFalse );

        //    // Replace in the primary header/ footer
        //    //
        //    //vkMyDoc.Sections.Item(1).Headers.Item(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Find.Execute(
        //    //    ref vkFind, ref vkFalse, ref vkFalse,
        //    //    ref vkFalse, ref vkFalse, ref vkFalse,
        //    //    ref vkTrue, ref vkNum, ref vkFalse,
        //    //    ref vkReplace, ref vkDynamic, ref vkFalse,
        //    //    ref vkFalse, ref vkFalse, ref vkFalse);

        //    vkMyDoc.Sections.Item( 1 ).Headers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterPrimary ).Range.Find.Execute(
        //        FindText: vkFind,
        //        MatchCase: vkFalse,
        //        MatchWholeWord: vkFalse,
        //        MatchWildcards: vkFalse,
        //        MatchSoundsLike: vkFalse,
        //        MatchAllWordForms: vkFalse,
        //        Forward: vkFalse,
        //        Wrap: vkNum,
        //        Format: vkFalse,
        //        ReplaceWith: vkReplace,
        //        Replace: vkDynamic,
        //        MatchKashida: vkFalse,
        //        MatchDiacritics: vkFalse,
        //        MatchAlefHamza: vkFalse,
        //        MatchControl: vkFalse );

        //    vkMyDoc.Sections.Item( 1 ).Headers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage).Range.Find.Execute(
        //        FindText: vkFind,
        //        MatchCase: vkFalse,
        //        MatchWholeWord: vkFalse,
        //        MatchWildcards: vkFalse,
        //        MatchSoundsLike: vkFalse,
        //        MatchAllWordForms: vkFalse,
        //        Forward: vkFalse,
        //        Wrap: vkNum,
        //        Format: vkFalse,
        //        ReplaceWith: vkReplace,
        //        Replace: vkDynamic,
        //        MatchKashida: vkFalse,
        //        MatchDiacritics: vkFalse,
        //        MatchAlefHamza: vkFalse,
        //        MatchControl: vkFalse );

        //    vkMyDoc.Sections.Item( 1 ).Headers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages).Range.Find.Execute(
        //        FindText: vkFind,
        //        MatchCase: vkFalse,
        //        MatchWholeWord: vkFalse,
        //        MatchWildcards: vkFalse,
        //        MatchSoundsLike: vkFalse,
        //        MatchAllWordForms: vkFalse,
        //        Forward: vkFalse,
        //        Wrap: vkNum,
        //        Format: vkFalse,
        //        ReplaceWith: vkReplace,
        //        Replace: vkDynamic,
        //        MatchKashida: vkFalse,
        //        MatchDiacritics: vkFalse,
        //        MatchAlefHamza: vkFalse,
        //        MatchControl: vkFalse );
    

        //    // Replace in the first page footer
        //    //
        //    //vkMyDoc.Sections.Item( 1 ).Footers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Find.Execute(
        //    //    ref vkFind, ref vkFalse, ref vkFalse,
        //    //    ref vkFalse, ref vkFalse, ref vkFalse,
        //    //    ref vkTrue, ref vkNum, ref vkFalse,
        //    //    ref vkReplace, ref vkDynamic, ref vkFalse,
        //    //    ref vkFalse, ref vkFalse, ref vkFalse );


        //    vkMyDoc.Sections.Item( 1 ).Footers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Find.Execute(
        //        FindText: vkFind,
        //        MatchCase: vkFalse,
        //        MatchWholeWord: vkFalse,
        //        MatchWildcards: vkFalse,
        //        MatchSoundsLike: vkFalse,
        //        MatchAllWordForms: vkFalse,
        //        Forward: vkFalse,
        //        Wrap: vkNum,
        //        Format: vkFalse,
        //        ReplaceWith: vkReplace,
        //        Replace: vkDynamic,
        //        MatchKashida: vkFalse,
        //        MatchDiacritics: vkFalse,
        //        MatchAlefHamza: vkFalse,
        //        MatchControl: vkFalse );


        //    vkMyDoc.Sections.Item( 1 ).Footers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage ).Range.Find.Execute(
        //        FindText: vkFind,
        //        MatchCase: vkFalse,
        //        MatchWholeWord: vkFalse,
        //        MatchWildcards: vkFalse,
        //        MatchSoundsLike: vkFalse,
        //        MatchAllWordForms: vkFalse,
        //        Forward: vkFalse,
        //        Wrap: vkNum,
        //        Format: vkFalse,
        //        ReplaceWith: vkReplace,
        //        Replace: vkDynamic,
        //        MatchKashida: vkFalse,
        //        MatchDiacritics: vkFalse,
        //        MatchAlefHamza: vkFalse,
        //        MatchControl: vkFalse );

        //    vkMyDoc.Sections.Item( 1 ).Footers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages ).Range.Find.Execute(
        //        FindText: vkFind,
        //        MatchCase: vkFalse,
        //        MatchWholeWord: vkFalse,
        //        MatchWildcards: vkFalse,
        //        MatchSoundsLike: vkFalse,
        //        MatchAllWordForms: vkFalse,
        //        Forward: vkFalse,
        //        Wrap: vkNum,
        //        Format: vkFalse,
        //        ReplaceWith: vkReplace,
        //        Replace: vkDynamic,
        //        MatchKashida: vkFalse,
        //        MatchDiacritics: vkFalse,
        //        MatchAlefHamza: vkFalse,
        //        MatchControl: vkFalse );

        //}



        /// <summary>
        /// Replace inside the range
        /// </summary>
        /// <param name="range"></param>
        /// <param name="wordDocument"></param>
        /// <param name="wordApp"></param>
        /// <param name="findText"></param>
        /// <param name="replaceText"></param>
        private static void ReplaceRange(Word.Range range, Word.Document wordDocument, Word.Application wordApp, object findText, object replaceText)
        {
            object missing = System.Reflection.Missing.Value;
            wordDocument.Activate();

            //object item = Word.WdGoToItem.wdGoToPage;
            //object whichItem = Word.WdGoToDirection.wdGoToFirst;
            //wordDocument.GoTo(ref item, ref whichItem, ref missing, ref missing);

            //object forward = true;
            //object replaceAll = Word.WdReplace.wdReplaceAll;
            //object matchAllWord = true;

            //range.Find.Execute(ref findText, ref missing, ref matchAllWord,
            //    ref missing, ref missing, ref missing, ref forward,
            //    ref missing, ref missing, ref replaceText, ref replaceAll,
            //    ref missing, ref missing, ref missing, ref missing);

            range.Find.ClearFormatting();
            range.Find.Replacement.ClearFormatting();
            
            object vkTrue = true;
            object vkFalse = false;

            range.Find.Execute(
                FindText: findText,
                MatchCase: vkFalse,
                MatchWholeWord: vkTrue,
                MatchWildcards: vkFalse,
                MatchSoundsLike: vkFalse,
                MatchAllWordForms: vkFalse,
                Forward: vkFalse,
                Wrap: 1,
                Format: vkFalse,
                ReplaceWith: replaceText,
                Replace: 2,
                MatchKashida: vkFalse,
                MatchDiacritics: vkFalse,
                MatchAlefHamza: vkFalse,
                MatchControl: vkFalse);

        }



        /// <summary>
        /// Find and replace words in document
        /// </summary>
        /// <param name="vkFind"></param>
        /// <param name="vkReplace"></param>
        /// <param name="vkNum"></param>
        /// <param name="vkWordApp"></param>
        /// <param name="vkMyDoc"></param>
        public static void FindAndReplace(
                                   object vkFind,
                                   object vkReplace,
                                   object vkNum,
                    Word.Application vkWordApp,
                            Word.Document vkMyDoc
            )
        {
            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object missing = false;
            object vkTrue = true;
            object vkDynamic = 2;
            object replaceAll = Word.WdReplace.wdReplaceAll;

            if (vkMyDoc == null)
            {
                return;
            }
            if (vkWordApp == null)
            {
                return;
            }

            // 12.01.2013
            // Allow spaces in replace variable - it will cause the system to clean-up unwanted variables.
            //
            //if (vkReplace.ToString().Trim().Length == 0)
            //{
            //    return;
            //}

            if (vkFind.ToString().Trim().Length == 0)
            {
                return;
            }

            string findText = vkFind.ToString().Trim();
            string replaceText = vkReplace.ToString().Trim();

            // In theory not needed...
            //

            //foreach (Word.Comment comment in vkMyDoc.Comments)
            //{
            //    ReplaceRange(comment.Range, vkMyDoc, vkWordApp, findText, replaceText);
            //}

            //foreach (Word.HeaderFooter header in vkMyDoc.Sections.Last.Headers)
            //{
            //    ReplaceRange(header.Range, vkMyDoc, vkWordApp, findText, replaceText);
            //}

            //foreach (Word.HeaderFooter footer in vkMyDoc.Sections.Last.Footers)
            //{
            //    ReplaceRange(footer.Range, vkMyDoc, vkWordApp, findText, replaceText);
            //}
            // End of changes on 07/01/2013
            // I have enabled the code above to see if it work for the IMS document
            //
            
            foreach (Word.Shape shp in vkMyDoc.Shapes)
            {
                if (shp.TextFrame.HasText < 0)
                {
                    ReplaceRange(shp.TextFrame.TextRange, vkMyDoc, vkWordApp, findText, replaceText);
                }
            }

            foreach (Word.Range myStoryRange in vkMyDoc.StoryRanges)
            {
                ReplaceRange(myStoryRange, vkMyDoc, vkWordApp, findText, replaceText);

                foreach (Word.InlineShape shp in myStoryRange.InlineShapes)
                {
                    ReplaceRange(shp.Range, vkMyDoc, vkWordApp, findText, replaceText);
                }

                // 23.02.2013
                // This is to try to address header in different sections
                // It works!
                // 
                foreach ( Word.HeaderFooter header in myStoryRange.Sections.Last.Headers )
                {
                    ReplaceRange( header.Range, vkMyDoc, vkWordApp, findText, replaceText );
                }
                foreach ( Word.HeaderFooter footer in myStoryRange.Sections.Last.Footers )
                {
                    ReplaceRange( footer.Range, vkMyDoc, vkWordApp, findText, replaceText );
                }
            
            }

        }


        /// <summary>
        /// Replace the property name
        /// </summary>
        /// <param name="vkFind"></param>
        /// <param name="vkReplace"></param>
        /// <param name="vkNum"></param>
        /// <param name="vkWordApp"></param>
        /// <param name="vkMyDoc"></param>
        public static void ReplaceProperty(
                                   object vkFind,
                                   object vkReplace,
                                   object vkNum,
                    Word.Application vkWordApp,
                            Word.Document vkMyDoc
            )
        {

            if ( vkMyDoc == null )
            {
                return;
            }
            if ( vkWordApp == null )
            {
                return;
            }
 
            if ( vkFind.ToString().Trim().Length == 0 )
            {
                return;
            }

            object oDocCustomProps;
            string propertyName = vkFind.ToString().Trim();
            string propertyValue = vkReplace.ToString().Trim();

            // -- change code from here -- //
            // It works however the propertyName must be defined in the document first otherwise it won't work.
            //

            var properties = vkMyDoc.CustomDocumentProperties;

            properties [propertyName].Value = propertyValue;

        }


        /// <summary>
        /// Not in use - Find Replace
        /// </summary>
        /// <param name="vkFind"></param>
        /// <param name="vkReplace"></param>
        /// <param name="vkNum"></param>
        /// <param name="vkWordApp"></param>
        /// <param name="vkMyDoc"></param>
        [Obsolete("There is another version of FindReplace", true)]
        public static void FindAndReplaceY(
                                   object vkFind,
                                   object vkReplace,
                                   object vkNum,
                    Word.Application vkWordApp,
                            Word.Document vkMyDoc
            )
        {
            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object missing = false;
            object vkTrue = true;
            object vkDynamic = 2;
            object replaceAll = Word.WdReplace.wdReplaceAll;

            // Replace Word Document body
            //

            foreach (Word.Range myStoryRange in vkMyDoc.StoryRanges)
            {
                ReplaceRange(myStoryRange, vkMyDoc, vkWordApp, vkFind, vkReplace);
            }

        }

        /// <summary>
        /// Find Replace option
        /// </summary>
        /// <param name="vkFind"></param>
        /// <param name="vkReplace"></param>
        /// <param name="vkNum"></param>
        /// <param name="vkWordApp"></param>
        /// <param name="vkMyDoc"></param>
        [Obsolete("There is another version of FindReplace", true)]
        public static void FindAndReplaceYS(
                                   object vkFind,
                                   object vkReplace,
                                   object vkNum,
                    Word.Application vkWordApp,
                            Word.Document vkMyDoc
            )
        {
            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object missing = false;
            object vkTrue = true;
            object vkDynamic = 2;
            object replaceAll = Word.WdReplace.wdReplaceAll;

            // Replace Word Document body
            //

            vkWordApp.Selection.Find.ClearFormatting();
            vkWordApp.Selection.Find.Text = vkFind.ToString();

            vkWordApp.Selection.Find.Replacement.ClearFormatting();
            vkWordApp.Selection.Find.Replacement.Text = vkFind.ToString();

            vkWordApp.Selection.Find.Execute(
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref replaceAll, ref missing, ref missing, ref missing, ref missing);

        }


        // ----------------------------------------------------
        //         Insert picture 
        // ----------------------------------------------------
        public static void insertPicture(Word.Document oDoc, 
                                         string pictureFile,
                                         object bookMarkName
                                         )
        {

            // 02.03.2013
            // Inserting pictures is on hold
            // PICTUREHOLD

            LogFile.WriteToTodaysLogFile(
                "Error: Pictures and logos are not being replace at this time. Issues are being investigated.","","","WordDocumentTasks.cs");
            return;



            object oMissing = System.Reflection.Missing.Value;

            if ( pictureFile == "\\" || pictureFile == "\\\\" || string.IsNullOrEmpty( pictureFile ) )
                return;

            // oDoc.ActiveWindow.Selection.Range.InlineShapes.AddPicture(
            //     pictureFile, ref oMissing, ref oMissing, ref oMissing);

            // Object bookMarkName = "COMPANY_LOGO";

            if (oDoc.Bookmarks.Exists(bookMarkName.ToString()))
            {
                //oDoc.Bookmarks.Item(ref bookMarkName).Range.InlineShapes.AddPicture(
                //    pictureFile, ref oMissing, ref oMissing, ref oMissing);

                try
                {
                    //oDoc.Bookmarks.Item(ref bookMarkName).Range.InlineShapes.AddPicture(
                    //    FileName: pictureFile,
                    //    LinkToFile: oMissing,
                    //    SaveWithDocument: oMissing,
                    //    Range: oMissing);

                    oDoc.Bookmarks.Item( ref bookMarkName ).Range.InlineShapes.AddPicture(
                        FileName: pictureFile,
                        LinkToFile: oMissing,
                        SaveWithDocument: oMissing,
                        Range: oMissing );


                }
                catch( Exception ex)
                {
                    LogFile.WriteToTodaysLogFile( "insertPicture " + ex, "", "", "WordDocumentTasks.cs" );
                }
            }
            // Object oMissed = doc.Paragraphs[2].Range; //the position you want to insert
            // doc.InlineShapes.AddPicture(

        }


        // ----------------------------------------------------
        //            Copy folder structure including files
        // ----------------------------------------------------
        static public void CopyFolder( string sourceFolder, string destFolder )
        {
            if (!Directory.Exists( destFolder ))
                Directory.CreateDirectory( destFolder );

            string[] files = Directory.GetFiles( sourceFolder );
            foreach (string file in files)
            {
                string name = Path.GetFileName( file );

                string fileName = Path.GetFileNameWithoutExtension(file);
                string fileExtension = Path.GetExtension(file);

                string dest = Path.Combine( destFolder, 
                               fileName + "v01" + fileExtension );

                File.Copy( file, dest );
            }

            string[] folders = Directory.GetDirectories( sourceFolder );
            foreach (string folder in folders)
            {
                string name = Path.GetFileName( folder );
                string dest = Path.Combine( destFolder, name );
                CopyFolder( folder, dest );
            }
        }


        // ----------------------------------------------------
        //            Copy folder structure
        // ----------------------------------------------------
        static public void ReplicateFolderStructure(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                ReplicateFolderStructure(folder, dest);
            }
        }

        // ----------------------------------------------------
        //         Replace strings in structure
        // ----------------------------------------------------
        static public void ReplaceStringInAllFiles(
                   string originalFolder, 
                   List<TagStructure> tagList,
                   Word.Application vkWordApp)
        {
            object vkMissing = System.Reflection.Missing.Value;
            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;

            if (Directory.Exists(originalFolder))
            {
                string[] files = Directory.GetFiles(originalFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    object xFile = file;

                    // Let's open the document
                    Word.Document vkMyDoc = vkWordApp.Documents.Open(
                        ref xFile, ref vkMissing, ref vkReadOnly,
                        ref vkMissing, ref vkMissing, ref vkMissing,
                        ref vkMissing, ref vkMissing, ref vkMissing,
                        ref vkMissing, ref vkMissing, ref vkVisible);

                    vkMyDoc.Select();

                    if (tagList.Count > 0)
                    {
                        for (int i = 0; i < tagList.Count; i++)
                        {
                            FindAndReplace(
                                tagList[i].Tag,
                                tagList[i].TagValue,
                                1,
                                vkWordApp,
                                vkMyDoc);
                        }
                    }

                    WordDocumentTasks.insertPicture( vkMyDoc, "C:\\Research\\fcm\\Resources\\FCMLogo.jpg","");
                    vkMyDoc.Save();
                    vkMyDoc.Close(ref vkFalse, ref vkMissing, ref vkMissing);

                }

                //
                //  Replace in all folders
                //
                string[] folders = Directory.GetDirectories(originalFolder);
                foreach (string folder in folders)
                {
                    ReplaceStringInAllFiles(folder, 
                                            tagList,
                                            vkWordApp);
                }
            }
        }

        public struct TagStructure : IEnumerable
        {
            public string TagType;
            public string Tag;
            public string TagValue;
            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        // ---------------------------------------------
        //             Print Document
        // ---------------------------------------------
        public static void PrintDocument( object fromFileName )
        {

            if (!File.Exists( (string)fromFileName ))
            {
                MessageBox.Show( "File not found. " + fromFileName );
                return;
            }


            Word.Application vkWordApp =
                                 new Word.Application();

            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object vkTrue = true;
            object vkDynamic = 2;


            object vkMissing = System.Reflection.Missing.Value;

            // Let's make the word application visible
            vkWordApp.Visible = true;
            vkWordApp.Activate();

            // Let's open the document
            Word.Document vkMyDoc = vkWordApp.Documents.Open(
                ref fromFileName, ref vkMissing, ref vkReadOnly,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkVisible );

            vkMyDoc.PrintOut();

            vkMyDoc.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject( vkMyDoc );

            vkWordApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject( vkWordApp );

            return;
        }


        /*

 http://www.c-sharpcorner.com/UploadFile/amrish_deep/WordAutomation05102007223934PM/WordAutomation.aspx
         * 9.1 Embedding Pictures in Document Header:
 
//EMBEDDING LOGOS IN THE DOCUMENT
//SETTING FOCUES ON THE PAGE HEADER TO EMBED THE WATERMARK
oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;
 
//THE LOGO IS ASSIGNED TO A SHAPE OBJECT SO THAT WE CAN USE ALL THE
//SHAPE FORMATTING OPTIONS PRESENT FOR THE SHAPE OBJECT
Word.Shape logoCustom = null;
 
//THE PATH OF THE LOGO FILE TO BE EMBEDDED IN THE HEADER
String logoPath = "C:\\Document and Settings\\MyLogo.jpg";
logoCustom = oWord.Selection.HeaderFooter.Shapes.AddPicture(logoPath,
    ref oFalse, ref oTrue, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
 
logoCustom.Select(ref oMissing);
logoCustom.Name = "CustomLogo";
logoCustom.Left = (float)Word.WdShapePosition.wdShapeLeft;
 
//SETTING FOCUES BACK TO DOCUMENT
oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
        
        */


        public static void CompareDocuments(object fromFileName, string toFileName)
        {

            if (!File.Exists((string)fromFileName))
            {
                MessageBox.Show("File not found. " + fromFileName);
                return;
            }


            Word.Application vkWordApp =
                                 new Word.Application();

            object vkReadOnly = false;
            object vkVisible = true;
            object vkFalse = false;
            object vkTrue = true;
            object vkDynamic = 2;


            object vkMissing = System.Reflection.Missing.Value;

            // Let's make the word application visible
            vkWordApp.Visible = true;
            vkWordApp.Activate();

            // Let's open the document
            Word.Document vkMyDoc = vkWordApp.Documents.Open(
                ref fromFileName, ref vkMissing, ref vkReadOnly,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkMissing,
                ref vkMissing, ref vkMissing, ref vkVisible);

            vkMyDoc.Compare(toFileName);

            vkMyDoc.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(vkMyDoc);

            vkWordApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(vkWordApp);

            return;
        }

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
