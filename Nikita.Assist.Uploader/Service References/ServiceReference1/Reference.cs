﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.0
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nikita.Assist.Uploader.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MethodRequest", Namespace="http://schemas.datacontract.org/2004/07/H.M.WcfDataLayer")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial struct MethodRequest : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ParamIndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ParamKeysField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ParamValsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProceDbField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProceNameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ParamIndex {
            get {
                return this.ParamIndexField;
            }
            set {
                if ((this.ParamIndexField.Equals(value) != true)) {
                    this.ParamIndexField = value;
                    this.RaisePropertyChanged("ParamIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] ParamKeys {
            get {
                return this.ParamKeysField;
            }
            set {
                if ((object.ReferenceEquals(this.ParamKeysField, value) != true)) {
                    this.ParamKeysField = value;
                    this.RaisePropertyChanged("ParamKeys");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] ParamVals {
            get {
                return this.ParamValsField;
            }
            set {
                if ((object.ReferenceEquals(this.ParamValsField, value) != true)) {
                    this.ParamValsField = value;
                    this.RaisePropertyChanged("ParamVals");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProceDb {
            get {
                return this.ProceDbField;
            }
            set {
                if ((object.ReferenceEquals(this.ProceDbField, value) != true)) {
                    this.ProceDbField = value;
                    this.RaisePropertyChanged("ProceDb");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProceName {
            get {
                return this.ProceNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProceNameField, value) != true)) {
                    this.ProceNameField = value;
                    this.RaisePropertyChanged("ProceName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DataRequest_By_DataTable", ReplyAction="http://tempuri.org/IService1/DataRequest_By_DataTableResponse")]
        System.Data.DataTable DataRequest_By_DataTable(Nikita.Assist.Uploader.ServiceReference1.MethodRequest mthReq);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DataRequest_By_DataSet", ReplyAction="http://tempuri.org/IService1/DataRequest_By_DataSetResponse")]
        System.Data.DataSet DataRequest_By_DataSet(Nikita.Assist.Uploader.ServiceReference1.MethodRequest mthReq);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DataRequest_By_DataSet_New", ReplyAction="http://tempuri.org/IService1/DataRequest_By_DataSet_NewResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Nikita.Assist.Uploader.ServiceReference1.MethodRequest))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(byte[]))]
        System.Data.DataSet DataRequest_By_DataSet_New(string strSpName, string[] strKey, object[] strVal, string proceDb);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DataRequest_By_DataTable_New", ReplyAction="http://tempuri.org/IService1/DataRequest_By_DataTable_NewResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Nikita.Assist.Uploader.ServiceReference1.MethodRequest))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(byte[]))]
        System.Data.DataTable DataRequest_By_DataTable_New(string strSpName, string[] strKey, object[] strVal, string proceDb);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DataRequest_By_DataSet_More", ReplyAction="http://tempuri.org/IService1/DataRequest_By_DataSet_MoreResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Nikita.Assist.Uploader.ServiceReference1.MethodRequest))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(byte[]))]
        System.Data.DataSet DataRequest_By_DataSet_More(string strSpName, string[] strKey, object[] strVal, string proceDb, int dbIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DataRequest_By_DataTable_More", ReplyAction="http://tempuri.org/IService1/DataRequest_By_DataTable_MoreResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Nikita.Assist.Uploader.ServiceReference1.MethodRequest))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(byte[]))]
        System.Data.DataTable DataRequest_By_DataTable_More(string strSpName, string[] strKey, object[] strVal, string proceDb, int dbIndex);
        
        // CODEGEN: 消息 FileUploadMessage 的包装名称(FileUploadMessage)以后生成的消息协定与默认值(UploadFile)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="UploadFile", ReplyAction="http://tempuri.org/IService1/UploadFileResponse")]
        global::Nikita.Assist.Uploader.ServiceReference1.UploadFileResponse UploadFile(global::Nikita.Assist.Uploader.ServiceReference1.FileUploadMessage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="DownloadFile", ReplyAction="http://tempuri.org/IService1/DownloadFileResponse")]
        byte[] DownloadFile(string fileName, long offset, int blocksize, string folder);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FileUploadMessage", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class FileUploadMessage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string SavePath;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileData;
        
        public FileUploadMessage() {
        }
        
        public FileUploadMessage(string FileName, string SavePath, System.IO.Stream FileData) {
            this.FileName = FileName;
            this.SavePath = SavePath;
            this.FileData = FileData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadFileResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UploadFileResponse {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public bool Flag;
        
        public UploadFileResponse() {
        }
        
        public UploadFileResponse(bool Flag) {
            this.Flag = Flag;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : global::Nikita.Assist.Uploader.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<global::Nikita.Assist.Uploader.ServiceReference1.IService1>, global::Nikita.Assist.Uploader.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable DataRequest_By_DataTable(Nikita.Assist.Uploader.ServiceReference1.MethodRequest mthReq) {
            return base.Channel.DataRequest_By_DataTable(mthReq);
        }
        
        public System.Data.DataSet DataRequest_By_DataSet(Nikita.Assist.Uploader.ServiceReference1.MethodRequest mthReq) {
            return base.Channel.DataRequest_By_DataSet(mthReq);
        }
        
        public System.Data.DataSet DataRequest_By_DataSet_New(string strSpName, string[] strKey, object[] strVal, string proceDb) {
            return base.Channel.DataRequest_By_DataSet_New(strSpName, strKey, strVal, proceDb);
        }
        
        public System.Data.DataTable DataRequest_By_DataTable_New(string strSpName, string[] strKey, object[] strVal, string proceDb) {
            return base.Channel.DataRequest_By_DataTable_New(strSpName, strKey, strVal, proceDb);
        }
        
        public System.Data.DataSet DataRequest_By_DataSet_More(string strSpName, string[] strKey, object[] strVal, string proceDb, int dbIndex) {
            return base.Channel.DataRequest_By_DataSet_More(strSpName, strKey, strVal, proceDb, dbIndex);
        }
        
        public System.Data.DataTable DataRequest_By_DataTable_More(string strSpName, string[] strKey, object[] strVal, string proceDb, int dbIndex) {
            return base.Channel.DataRequest_By_DataTable_More(strSpName, strKey, strVal, proceDb, dbIndex);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        global::Nikita.Assist.Uploader.ServiceReference1.UploadFileResponse global::Nikita.Assist.Uploader.ServiceReference1.IService1.UploadFile(global::Nikita.Assist.Uploader.ServiceReference1.FileUploadMessage request) {
            return base.Channel.UploadFile(request);
        }
        
        public bool UploadFile(string FileName, string SavePath, System.IO.Stream FileData) {
            global::Nikita.Assist.Uploader.ServiceReference1.FileUploadMessage inValue = new global::Nikita.Assist.Uploader.ServiceReference1.FileUploadMessage();
            inValue.FileName = FileName;
            inValue.SavePath = SavePath;
            inValue.FileData = FileData;
            global::Nikita.Assist.Uploader.ServiceReference1.UploadFileResponse retVal = ((global::Nikita.Assist.Uploader.ServiceReference1.IService1)(this)).UploadFile(inValue);
            return retVal.Flag;
        }
        
        public byte[] DownloadFile(string fileName, long offset, int blocksize, string folder) {
            return base.Channel.DownloadFile(fileName, offset, blocksize, folder);
        }
    }
}