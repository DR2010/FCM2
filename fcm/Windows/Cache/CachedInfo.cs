using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClient;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace fcm.Windows.Cache
{
    public static class CachedInfo
    {
        public static List<RelatedCode> ListOfRelatedCodes;
        public static List<RelatedCodeValue> ListOfRelatedCodeValues;
        public static List<CodeType> ListOfCodeTypes;
        public static List<CodeValue> ListOfCodeValues;
        public static List<CodeValue> ErrorList;
        public static List<CodeValue> ListOfScreensAllowedToUser;

        /// <summary>
        /// Refresh cache
        /// </summary>
        /// <returns></returns>
        public static void LoadReferenceDataInCache(HeaderInfo headerInfo)
        {
            if (CachedInfo.ListOfCodeTypes == null)
                CachedInfo.ListOfCodeTypes = new List<CodeType>();

            var codeType = new CodeType();
            codeType.List(headerInfo);

            ListOfCodeTypes.Clear();
            ListOfCodeTypes = codeType.codeTypeList;

            if (ListOfCodeValues != null)
                ListOfCodeValues.Clear();

            var codeValue = new CodeValue();
            ListOfCodeValues = codeValue.ListS();


            if (ListOfScreensAllowedToUser != null)
                ListOfScreensAllowedToUser.Clear();

            CachedInfo.ListOfScreensAllowedToUser = 
                BUSReferenceData.GetListScreensForUser(Utils.UserID);


            return;
        }

        /// <summary>
        /// Retrieve description from cache.
        /// </summary>
        /// <param name="codeType"></param>
        /// <param name="codeValue"></param>
        /// <returns></returns>
        public static string GetDescription(string codeType, string codeValue)
        {
            string response = "";

            foreach (var value in ListOfCodeValues)
            {
                if (value.FKCodeType == codeType && value.ID == codeValue)
                    response = value.Description;
            }

            return response;
        }

        /// <summary>
        /// List value for a give code type
        /// </summary>
        /// <param name="codeType"></param>
        /// <returns></returns>
        public static List<CodeValue> GetListOfCodeValue(string codeType)
        {
            List<CodeValue> list = new List<CodeValue>();

            foreach (var value in ListOfCodeValues)
            {
                if (value.FKCodeType == codeType)
                {
                    list.Add(value);
                }
            }
            return list;
        }


        /// <summary>
        /// Refresh cache
        /// </summary>
        /// <returns></returns>
        public static void LoadRelatedCodeInCache()
        {
            if (CachedInfo.ListOfRelatedCodes == null)
                CachedInfo.ListOfRelatedCodes = new List<RelatedCode>();

            if (CachedInfo.ListOfRelatedCodes != null)
                CachedInfo.ListOfRelatedCodes.Clear();

            CachedInfo.ListOfRelatedCodes = BUSReferenceData.ListRelatedCode();
            CachedInfo.ListOfRelatedCodeValues = BUSReferenceData.ListRelatedCodeValue();

            return;
        }

        /// <summary>
        /// Retrieve related code from cache
        /// </summary>
        /// <param name="relatedCodeID"></param>
        /// <returns></returns>
        public static RelatedCode GetRelatedCode( string relatedCodeID )
        {
            RelatedCode response = new RelatedCode();

            foreach (var value in ListOfRelatedCodes)
            {
                if (value.RelatedCodeID == relatedCodeID)
                    response = value;
            }

            return response;
        }

        /// <summary>
        /// List value for a give code type
        /// </summary>
        /// <param name="codeType"></param>
        /// <returns></returns>
        public static List<RelatedCodeValue> GetListOfRelatedCodeValue(
            string relatedCodeID, 
            string codeTypeFrom, 
            string codeValueFrom)
        {
            List<RelatedCodeValue> list = new List<RelatedCodeValue>();

            foreach (var value in ListOfRelatedCodeValues)
            {
                if (   value.FKRelatedCodeID == relatedCodeID
                    && value.FKCodeTypeFrom == codeTypeFrom
                    && value.FKCodeValueFrom == codeValueFrom )
                {
                    list.Add(value);
                }
            }
            return list;
        }

    
        public static bool IsUserAllowedToScreen(string userID, string screen)
        {
            bool userIsAllowed = false;

            foreach (var sc in CachedInfo.ListOfScreensAllowedToUser)
            {
                if (sc.ID == screen)
                {
                    userIsAllowed = true;
                    break;
                }
            }

            return userIsAllowed;
        }

    
    }
}

