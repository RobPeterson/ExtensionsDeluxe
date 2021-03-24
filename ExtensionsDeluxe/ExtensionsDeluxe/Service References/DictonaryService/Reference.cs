﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExtensionsDeluxe.DictonaryService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://services.aonaware.com/webservices/", ConfigurationName="DictonaryService.DictServiceSoap")]
    public interface DictServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/ServerInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ServerInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/ServerInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> ServerInfoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/DictionaryList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ExtensionsDeluxe.DictonaryService.Dictionary[] DictionaryList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/DictionaryList", ReplyAction="*")]
        System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.Dictionary[]> DictionaryListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/DictionaryListExtended", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ExtensionsDeluxe.DictonaryService.Dictionary[] DictionaryListExtended();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/DictionaryListExtended", ReplyAction="*")]
        System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.Dictionary[]> DictionaryListExtendedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/DictionaryInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string DictionaryInfo(string dictId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/DictionaryInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> DictionaryInfoAsync(string dictId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/Define", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ExtensionsDeluxe.DictonaryService.WordDefinition Define(string word);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/Define", ReplyAction="*")]
        System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.WordDefinition> DefineAsync(string word);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/DefineInDict", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ExtensionsDeluxe.DictonaryService.WordDefinition DefineInDict(string dictId, string word);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/DefineInDict", ReplyAction="*")]
        System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.WordDefinition> DefineInDictAsync(string dictId, string word);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/StrategyList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ExtensionsDeluxe.DictonaryService.Strategy[] StrategyList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/StrategyList", ReplyAction="*")]
        System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.Strategy[]> StrategyListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/Match", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ExtensionsDeluxe.DictonaryService.DictionaryWord[] Match(string word, string strategy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/Match", ReplyAction="*")]
        System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.DictionaryWord[]> MatchAsync(string word, string strategy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/MatchInDict", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ExtensionsDeluxe.DictonaryService.DictionaryWord[] MatchInDict(string dictId, string word, string strategy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.aonaware.com/webservices/MatchInDict", ReplyAction="*")]
        System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.DictionaryWord[]> MatchInDictAsync(string dictId, string word, string strategy);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class Dictionary : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string idField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class DictionaryWord : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dictionaryIdField;
        
        private string wordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string DictionaryId {
            get {
                return this.dictionaryIdField;
            }
            set {
                this.dictionaryIdField = value;
                this.RaisePropertyChanged("DictionaryId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Word {
            get {
                return this.wordField;
            }
            set {
                this.wordField = value;
                this.RaisePropertyChanged("Word");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class Strategy : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string idField;
        
        private string descriptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class Definition : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string wordField;
        
        private Dictionary dictionaryField;
        
        private string wordDefinitionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Word {
            get {
                return this.wordField;
            }
            set {
                this.wordField = value;
                this.RaisePropertyChanged("Word");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Dictionary Dictionary {
            get {
                return this.dictionaryField;
            }
            set {
                this.dictionaryField = value;
                this.RaisePropertyChanged("Dictionary");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string WordDefinition {
            get {
                return this.wordDefinitionField;
            }
            set {
                this.wordDefinitionField = value;
                this.RaisePropertyChanged("WordDefinition");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class WordDefinition : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string wordField;
        
        private Definition[] definitionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Word {
            get {
                return this.wordField;
            }
            set {
                this.wordField = value;
                this.RaisePropertyChanged("Word");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public Definition[] Definitions {
            get {
                return this.definitionsField;
            }
            set {
                this.definitionsField = value;
                this.RaisePropertyChanged("Definitions");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DictServiceSoapChannel : ExtensionsDeluxe.DictonaryService.DictServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DictServiceSoapClient : System.ServiceModel.ClientBase<ExtensionsDeluxe.DictonaryService.DictServiceSoap>, ExtensionsDeluxe.DictonaryService.DictServiceSoap {
        
        public DictServiceSoapClient() {
        }
        
        public DictServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DictServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DictServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DictServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ServerInfo() {
            return base.Channel.ServerInfo();
        }
        
        public System.Threading.Tasks.Task<string> ServerInfoAsync() {
            return base.Channel.ServerInfoAsync();
        }
        
        public ExtensionsDeluxe.DictonaryService.Dictionary[] DictionaryList() {
            return base.Channel.DictionaryList();
        }
        
        public System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.Dictionary[]> DictionaryListAsync() {
            return base.Channel.DictionaryListAsync();
        }
        
        public ExtensionsDeluxe.DictonaryService.Dictionary[] DictionaryListExtended() {
            return base.Channel.DictionaryListExtended();
        }
        
        public System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.Dictionary[]> DictionaryListExtendedAsync() {
            return base.Channel.DictionaryListExtendedAsync();
        }
        
        public string DictionaryInfo(string dictId) {
            return base.Channel.DictionaryInfo(dictId);
        }
        
        public System.Threading.Tasks.Task<string> DictionaryInfoAsync(string dictId) {
            return base.Channel.DictionaryInfoAsync(dictId);
        }
        
        public ExtensionsDeluxe.DictonaryService.WordDefinition Define(string word) {
            return base.Channel.Define(word);
        }
        
        public System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.WordDefinition> DefineAsync(string word) {
            return base.Channel.DefineAsync(word);
        }
        
        public ExtensionsDeluxe.DictonaryService.WordDefinition DefineInDict(string dictId, string word) {
            return base.Channel.DefineInDict(dictId, word);
        }
        
        public System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.WordDefinition> DefineInDictAsync(string dictId, string word) {
            return base.Channel.DefineInDictAsync(dictId, word);
        }
        
        public ExtensionsDeluxe.DictonaryService.Strategy[] StrategyList() {
            return base.Channel.StrategyList();
        }
        
        public System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.Strategy[]> StrategyListAsync() {
            return base.Channel.StrategyListAsync();
        }
        
        public ExtensionsDeluxe.DictonaryService.DictionaryWord[] Match(string word, string strategy) {
            return base.Channel.Match(word, strategy);
        }
        
        public System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.DictionaryWord[]> MatchAsync(string word, string strategy) {
            return base.Channel.MatchAsync(word, strategy);
        }
        
        public ExtensionsDeluxe.DictonaryService.DictionaryWord[] MatchInDict(string dictId, string word, string strategy) {
            return base.Channel.MatchInDict(dictId, word, strategy);
        }
        
        public System.Threading.Tasks.Task<ExtensionsDeluxe.DictonaryService.DictionaryWord[]> MatchInDictAsync(string dictId, string word, string strategy) {
            return base.Channel.MatchInDictAsync(dictId, word, strategy);
        }
    }
}
