﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ImageStore.Services.Properties {
    
    
    [CompilerGenerated()]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [SpecialSetting(SpecialSetting.ConnectionString)]
        [DefaultSettingValue("Data Source=192.168.1.29;Initial Catalog=imageserver;Persist Security Info=True;U" +
            "ser ID=sa;Password=cry.cap.fox-999")]
        public string imageserverConnectionString {
            get {
                return ((string)(this["imageserverConnectionString"]));
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [SpecialSetting(SpecialSetting.ConnectionString)]
        [DefaultSettingValue("Data Source=192.168.1.29;Initial Catalog=imagestore;User ID=sa;Password=cry.cap.f" +
            "ox-999")]
        public string imagestoreConnectionString {
            get {
                return ((string)(this["imagestoreConnectionString"]));
            }
        }
    }
}