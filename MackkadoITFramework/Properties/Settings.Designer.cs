﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MackkadoITFramework.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=localhost;Port=3306;Database=management;Uid=fcmuser;Pwd=oculos;;AutoEnlist" +
            "=false")]
        public string FrameworkConnection {
            get {
                return ((string)(this["FrameworkConnection"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=TOSHIBA2011\\SQLSERVERTOSH,1433;Initial Catalog=management;Integrated " +
            "Security=SSPI;User ID=service_fcm;Password=service_fcm;MultipleActiveResultSets=" +
            "True;")]
        public string SQLConnectionString {
            get {
                return ((string)(this["SQLConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\TEMP")]
        public string AuditLogPath {
            get {
                return ((string)(this["AuditLogPath"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Local")]
        public string DefaultDB {
            get {
                return ((string)(this["DefaultDB"]));
            }
            set {
                this["DefaultDB"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=localhost;Port=3306;Database=management;Uid=fcmuser;Pwd=oculos;AutoEnlist=" +
            "false")]
        public string ApplicationConnectionString {
            get {
                return ((string)(this["ApplicationConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=TOSHIBA2011\\SQLSERVERTOSH,1433;Initial Catalog=management;Integrated " +
            "Security=SSPI;User ID=service_fcm;Password=service_fcm;MultipleActiveResultSets=" +
            "True;")]
        public string FCMApplicationConnectionString {
            get {
                return ((string)(this["FCMApplicationConnectionString"]));
            }
            set {
                this["FCMApplicationConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=localhost;Port=3306;Database=childcare;Uid=childcare;Pwd=oculos;AutoEnlist" +
            "=false;")]
        public string ChildCareConnectionString {
            get {
                return ((string)(this["ChildCareConnectionString"]));
            }
            set {
                this["ChildCareConnectionString"] = value;
            }
        }
    }
}
