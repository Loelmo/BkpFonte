﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36366
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.36366.
// 
#pragma warning disable 1591

namespace Sistema_de_Gestao.SiacWebCadastroHistoricoWS.ws {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SiacWEB_HistoricoWSSoap", Namespace="Historico")]
    public partial class SiacWEB_HistoricoWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback Trans_Ins_HistoricoRealizacaoClienteOperationCompleted;
        
        private System.Threading.SendOrPostCallback Trans_Exc_HistoricoRealizacaoClienteOperationCompleted;
        
        private System.Threading.SendOrPostCallback Util_Rec_HistoricoRealizacaoClienteOperationCompleted;
        
        private System.Threading.SendOrPostCallback Util_Rec_ProjetosPorEstadoOperationCompleted;
        
        private System.Threading.SendOrPostCallback Util_Rec_AcoesPorProjetoOperationCompleted;
        
        private System.Threading.SendOrPostCallback Util_Rec_SebraePorEstadoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SiacWEB_HistoricoWS() {
            this.Url = global::Sistema_de_Gestao.Properties.Settings.Default.Sistema_de_Gestao_SiacWebCadastroHistoricoWS_ws_SiacWEB_HistoricoWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event Trans_Ins_HistoricoRealizacaoClienteCompletedEventHandler Trans_Ins_HistoricoRealizacaoClienteCompleted;
        
        /// <remarks/>
        public event Trans_Exc_HistoricoRealizacaoClienteCompletedEventHandler Trans_Exc_HistoricoRealizacaoClienteCompleted;
        
        /// <remarks/>
        public event Util_Rec_HistoricoRealizacaoClienteCompletedEventHandler Util_Rec_HistoricoRealizacaoClienteCompleted;
        
        /// <remarks/>
        public event Util_Rec_ProjetosPorEstadoCompletedEventHandler Util_Rec_ProjetosPorEstadoCompleted;
        
        /// <remarks/>
        public event Util_Rec_AcoesPorProjetoCompletedEventHandler Util_Rec_AcoesPorProjetoCompleted;
        
        /// <remarks/>
        public event Util_Rec_SebraePorEstadoCompletedEventHandler Util_Rec_SebraePorEstadoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("Historico/Trans_Ins_HistoricoRealizacaoCliente", RequestNamespace="Historico", ResponseNamespace="Historico")]
        public string Trans_Ins_HistoricoRealizacaoCliente(
                    int CodCliente, 
                    int CodEmpreendimento, 
                    string DataHoraInicioRealizacao, 
                    string DataHoraFimRealizacao, 
                    string NomeRealizacao, 
                    int CodRealizacao, 
                    int CodRealizacaoComp, 
                    string TipoRealizacao, 
                    string Instrumento, 
                    string Abordagem, 
                    string DescRealizacao, 
                    string CodProjeto, 
                    int CodAcao, 
                    string MesAnoCompetencia, 
                    double CargaHoraria, 
                    int CodSebrae) {
            object[] results = this.Invoke("Trans_Ins_HistoricoRealizacaoCliente", new object[] {
                        CodCliente,
                        CodEmpreendimento,
                        DataHoraInicioRealizacao,
                        DataHoraFimRealizacao,
                        NomeRealizacao,
                        CodRealizacao,
                        CodRealizacaoComp,
                        TipoRealizacao,
                        Instrumento,
                        Abordagem,
                        DescRealizacao,
                        CodProjeto,
                        CodAcao,
                        MesAnoCompetencia,
                        CargaHoraria,
                        CodSebrae});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Trans_Ins_HistoricoRealizacaoClienteAsync(
                    int CodCliente, 
                    int CodEmpreendimento, 
                    string DataHoraInicioRealizacao, 
                    string DataHoraFimRealizacao, 
                    string NomeRealizacao, 
                    int CodRealizacao, 
                    int CodRealizacaoComp, 
                    string TipoRealizacao, 
                    string Instrumento, 
                    string Abordagem, 
                    string DescRealizacao, 
                    string CodProjeto, 
                    int CodAcao, 
                    string MesAnoCompetencia, 
                    double CargaHoraria, 
                    int CodSebrae) {
            this.Trans_Ins_HistoricoRealizacaoClienteAsync(CodCliente, CodEmpreendimento, DataHoraInicioRealizacao, DataHoraFimRealizacao, NomeRealizacao, CodRealizacao, CodRealizacaoComp, TipoRealizacao, Instrumento, Abordagem, DescRealizacao, CodProjeto, CodAcao, MesAnoCompetencia, CargaHoraria, CodSebrae, null);
        }
        
        /// <remarks/>
        public void Trans_Ins_HistoricoRealizacaoClienteAsync(
                    int CodCliente, 
                    int CodEmpreendimento, 
                    string DataHoraInicioRealizacao, 
                    string DataHoraFimRealizacao, 
                    string NomeRealizacao, 
                    int CodRealizacao, 
                    int CodRealizacaoComp, 
                    string TipoRealizacao, 
                    string Instrumento, 
                    string Abordagem, 
                    string DescRealizacao, 
                    string CodProjeto, 
                    int CodAcao, 
                    string MesAnoCompetencia, 
                    double CargaHoraria, 
                    int CodSebrae, 
                    object userState) {
            if ((this.Trans_Ins_HistoricoRealizacaoClienteOperationCompleted == null)) {
                this.Trans_Ins_HistoricoRealizacaoClienteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTrans_Ins_HistoricoRealizacaoClienteOperationCompleted);
            }
            this.InvokeAsync("Trans_Ins_HistoricoRealizacaoCliente", new object[] {
                        CodCliente,
                        CodEmpreendimento,
                        DataHoraInicioRealizacao,
                        DataHoraFimRealizacao,
                        NomeRealizacao,
                        CodRealizacao,
                        CodRealizacaoComp,
                        TipoRealizacao,
                        Instrumento,
                        Abordagem,
                        DescRealizacao,
                        CodProjeto,
                        CodAcao,
                        MesAnoCompetencia,
                        CargaHoraria,
                        CodSebrae}, this.Trans_Ins_HistoricoRealizacaoClienteOperationCompleted, userState);
        }
        
        private void OnTrans_Ins_HistoricoRealizacaoClienteOperationCompleted(object arg) {
            if ((this.Trans_Ins_HistoricoRealizacaoClienteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Trans_Ins_HistoricoRealizacaoClienteCompleted(this, new Trans_Ins_HistoricoRealizacaoClienteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("Historico/Trans_Exc_HistoricoRealizacaoCliente", RequestNamespace="Historico", ResponseNamespace="Historico")]
        public string Trans_Exc_HistoricoRealizacaoCliente(int CodCliente, int CodEmpreendimento, int CodRealizacao, int CodRealizacaoComp, string TipoRealizacao, int CodSebrae) {
            object[] results = this.Invoke("Trans_Exc_HistoricoRealizacaoCliente", new object[] {
                        CodCliente,
                        CodEmpreendimento,
                        CodRealizacao,
                        CodRealizacaoComp,
                        TipoRealizacao,
                        CodSebrae});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Trans_Exc_HistoricoRealizacaoClienteAsync(int CodCliente, int CodEmpreendimento, int CodRealizacao, int CodRealizacaoComp, string TipoRealizacao, int CodSebrae) {
            this.Trans_Exc_HistoricoRealizacaoClienteAsync(CodCliente, CodEmpreendimento, CodRealizacao, CodRealizacaoComp, TipoRealizacao, CodSebrae, null);
        }
        
        /// <remarks/>
        public void Trans_Exc_HistoricoRealizacaoClienteAsync(int CodCliente, int CodEmpreendimento, int CodRealizacao, int CodRealizacaoComp, string TipoRealizacao, int CodSebrae, object userState) {
            if ((this.Trans_Exc_HistoricoRealizacaoClienteOperationCompleted == null)) {
                this.Trans_Exc_HistoricoRealizacaoClienteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTrans_Exc_HistoricoRealizacaoClienteOperationCompleted);
            }
            this.InvokeAsync("Trans_Exc_HistoricoRealizacaoCliente", new object[] {
                        CodCliente,
                        CodEmpreendimento,
                        CodRealizacao,
                        CodRealizacaoComp,
                        TipoRealizacao,
                        CodSebrae}, this.Trans_Exc_HistoricoRealizacaoClienteOperationCompleted, userState);
        }
        
        private void OnTrans_Exc_HistoricoRealizacaoClienteOperationCompleted(object arg) {
            if ((this.Trans_Exc_HistoricoRealizacaoClienteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Trans_Exc_HistoricoRealizacaoClienteCompleted(this, new Trans_Exc_HistoricoRealizacaoClienteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("Historico/Util_Rec_HistoricoRealizacaoCliente", RequestNamespace="Historico", ResponseNamespace="Historico")]
        public string Util_Rec_HistoricoRealizacaoCliente(int CodCliente, int CodEmpreendimento, string DataHoraInicioRealizacao, string DataHoraFimRealizacao, int CodRealizacao, int CodRealizacaoComp, string TipoRealizacao, string Instrumento, string Abordagem, string CodProjeto, int CodAcao, string MesAnoCompetenciaInicio, string MesAnoCompetenciaFim, int CodSebrae) {
            object[] results = this.Invoke("Util_Rec_HistoricoRealizacaoCliente", new object[] {
                        CodCliente,
                        CodEmpreendimento,
                        DataHoraInicioRealizacao,
                        DataHoraFimRealizacao,
                        CodRealizacao,
                        CodRealizacaoComp,
                        TipoRealizacao,
                        Instrumento,
                        Abordagem,
                        CodProjeto,
                        CodAcao,
                        MesAnoCompetenciaInicio,
                        MesAnoCompetenciaFim,
                        CodSebrae});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Util_Rec_HistoricoRealizacaoClienteAsync(int CodCliente, int CodEmpreendimento, string DataHoraInicioRealizacao, string DataHoraFimRealizacao, int CodRealizacao, int CodRealizacaoComp, string TipoRealizacao, string Instrumento, string Abordagem, string CodProjeto, int CodAcao, string MesAnoCompetenciaInicio, string MesAnoCompetenciaFim, int CodSebrae) {
            this.Util_Rec_HistoricoRealizacaoClienteAsync(CodCliente, CodEmpreendimento, DataHoraInicioRealizacao, DataHoraFimRealizacao, CodRealizacao, CodRealizacaoComp, TipoRealizacao, Instrumento, Abordagem, CodProjeto, CodAcao, MesAnoCompetenciaInicio, MesAnoCompetenciaFim, CodSebrae, null);
        }
        
        /// <remarks/>
        public void Util_Rec_HistoricoRealizacaoClienteAsync(int CodCliente, int CodEmpreendimento, string DataHoraInicioRealizacao, string DataHoraFimRealizacao, int CodRealizacao, int CodRealizacaoComp, string TipoRealizacao, string Instrumento, string Abordagem, string CodProjeto, int CodAcao, string MesAnoCompetenciaInicio, string MesAnoCompetenciaFim, int CodSebrae, object userState) {
            if ((this.Util_Rec_HistoricoRealizacaoClienteOperationCompleted == null)) {
                this.Util_Rec_HistoricoRealizacaoClienteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUtil_Rec_HistoricoRealizacaoClienteOperationCompleted);
            }
            this.InvokeAsync("Util_Rec_HistoricoRealizacaoCliente", new object[] {
                        CodCliente,
                        CodEmpreendimento,
                        DataHoraInicioRealizacao,
                        DataHoraFimRealizacao,
                        CodRealizacao,
                        CodRealizacaoComp,
                        TipoRealizacao,
                        Instrumento,
                        Abordagem,
                        CodProjeto,
                        CodAcao,
                        MesAnoCompetenciaInicio,
                        MesAnoCompetenciaFim,
                        CodSebrae}, this.Util_Rec_HistoricoRealizacaoClienteOperationCompleted, userState);
        }
        
        private void OnUtil_Rec_HistoricoRealizacaoClienteOperationCompleted(object arg) {
            if ((this.Util_Rec_HistoricoRealizacaoClienteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Util_Rec_HistoricoRealizacaoClienteCompleted(this, new Util_Rec_HistoricoRealizacaoClienteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("Historico/Util_Rec_ProjetosPorEstado", RequestNamespace="Historico", ResponseNamespace="Historico")]
        public string Util_Rec_ProjetosPorEstado(int CodSebrae) {
            object[] results = this.Invoke("Util_Rec_ProjetosPorEstado", new object[] {
                        CodSebrae});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Util_Rec_ProjetosPorEstadoAsync(int CodSebrae) {
            this.Util_Rec_ProjetosPorEstadoAsync(CodSebrae, null);
        }
        
        /// <remarks/>
        public void Util_Rec_ProjetosPorEstadoAsync(int CodSebrae, object userState) {
            if ((this.Util_Rec_ProjetosPorEstadoOperationCompleted == null)) {
                this.Util_Rec_ProjetosPorEstadoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUtil_Rec_ProjetosPorEstadoOperationCompleted);
            }
            this.InvokeAsync("Util_Rec_ProjetosPorEstado", new object[] {
                        CodSebrae}, this.Util_Rec_ProjetosPorEstadoOperationCompleted, userState);
        }
        
        private void OnUtil_Rec_ProjetosPorEstadoOperationCompleted(object arg) {
            if ((this.Util_Rec_ProjetosPorEstadoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Util_Rec_ProjetosPorEstadoCompleted(this, new Util_Rec_ProjetosPorEstadoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("Historico/Util_Rec_AcoesPorProjeto", RequestNamespace="Historico", ResponseNamespace="Historico")]
        public string Util_Rec_AcoesPorProjeto(string CodProjeto) {
            object[] results = this.Invoke("Util_Rec_AcoesPorProjeto", new object[] {
                        CodProjeto});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Util_Rec_AcoesPorProjetoAsync(string CodProjeto) {
            this.Util_Rec_AcoesPorProjetoAsync(CodProjeto, null);
        }
        
        /// <remarks/>
        public void Util_Rec_AcoesPorProjetoAsync(string CodProjeto, object userState) {
            if ((this.Util_Rec_AcoesPorProjetoOperationCompleted == null)) {
                this.Util_Rec_AcoesPorProjetoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUtil_Rec_AcoesPorProjetoOperationCompleted);
            }
            this.InvokeAsync("Util_Rec_AcoesPorProjeto", new object[] {
                        CodProjeto}, this.Util_Rec_AcoesPorProjetoOperationCompleted, userState);
        }
        
        private void OnUtil_Rec_AcoesPorProjetoOperationCompleted(object arg) {
            if ((this.Util_Rec_AcoesPorProjetoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Util_Rec_AcoesPorProjetoCompleted(this, new Util_Rec_AcoesPorProjetoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("Historico/Util_Rec_SebraePorEstado", RequestNamespace="Historico", ResponseNamespace="Historico")]
        public string Util_Rec_SebraePorEstado(int CodEstado, string SiglaEstado) {
            object[] results = this.Invoke("Util_Rec_SebraePorEstado", new object[] {
                        CodEstado,
                        SiglaEstado});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Util_Rec_SebraePorEstadoAsync(int CodEstado, string SiglaEstado) {
            this.Util_Rec_SebraePorEstadoAsync(CodEstado, SiglaEstado, null);
        }
        
        /// <remarks/>
        public void Util_Rec_SebraePorEstadoAsync(int CodEstado, string SiglaEstado, object userState) {
            if ((this.Util_Rec_SebraePorEstadoOperationCompleted == null)) {
                this.Util_Rec_SebraePorEstadoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUtil_Rec_SebraePorEstadoOperationCompleted);
            }
            this.InvokeAsync("Util_Rec_SebraePorEstado", new object[] {
                        CodEstado,
                        SiglaEstado}, this.Util_Rec_SebraePorEstadoOperationCompleted, userState);
        }
        
        private void OnUtil_Rec_SebraePorEstadoOperationCompleted(object arg) {
            if ((this.Util_Rec_SebraePorEstadoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Util_Rec_SebraePorEstadoCompleted(this, new Util_Rec_SebraePorEstadoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    public delegate void Trans_Ins_HistoricoRealizacaoClienteCompletedEventHandler(object sender, Trans_Ins_HistoricoRealizacaoClienteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Trans_Ins_HistoricoRealizacaoClienteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Trans_Ins_HistoricoRealizacaoClienteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    public delegate void Trans_Exc_HistoricoRealizacaoClienteCompletedEventHandler(object sender, Trans_Exc_HistoricoRealizacaoClienteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Trans_Exc_HistoricoRealizacaoClienteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Trans_Exc_HistoricoRealizacaoClienteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    public delegate void Util_Rec_HistoricoRealizacaoClienteCompletedEventHandler(object sender, Util_Rec_HistoricoRealizacaoClienteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Util_Rec_HistoricoRealizacaoClienteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Util_Rec_HistoricoRealizacaoClienteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    public delegate void Util_Rec_ProjetosPorEstadoCompletedEventHandler(object sender, Util_Rec_ProjetosPorEstadoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Util_Rec_ProjetosPorEstadoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Util_Rec_ProjetosPorEstadoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    public delegate void Util_Rec_AcoesPorProjetoCompletedEventHandler(object sender, Util_Rec_AcoesPorProjetoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Util_Rec_AcoesPorProjetoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Util_Rec_AcoesPorProjetoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    public delegate void Util_Rec_SebraePorEstadoCompletedEventHandler(object sender, Util_Rec_SebraePorEstadoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.36366")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Util_Rec_SebraePorEstadoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Util_Rec_SebraePorEstadoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591