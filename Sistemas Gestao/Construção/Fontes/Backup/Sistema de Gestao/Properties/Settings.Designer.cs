﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_de_Gestao.Properties {
    
    
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
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Programa {
            get {
                return ((string)(this["Programa"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ws.sebrae.com.br/siacwebportal/WebServices/siacweb_cadastroatenderws.asmx")]
        public string Sistema_de_Gestao_SiacWebCadastroAtendimentoWS_ws_SiacWEB_CadastroAtenderWS {
            get {
                return ((string)(this["Sistema_de_Gestao_SiacWebCadastroAtendimentoWS_ws_SiacWEB_CadastroAtenderWS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ws.sebrae.com.br/siacwebportal/WebServices/siacweb_historicows.asmx")]
        public string Sistema_de_Gestao_SiacWebCadastroHistoricoWS_ws_SiacWEB_HistoricoWS {
            get {
                return ((string)(this["Sistema_de_Gestao_SiacWebCadastroHistoricoWS_ws_SiacWEB_HistoricoWS"]));
            }
        }
    }
}
