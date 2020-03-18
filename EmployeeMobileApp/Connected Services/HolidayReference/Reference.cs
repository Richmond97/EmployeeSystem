﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeMobileApp.HolidayReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HolidayReference.BookinFunctionalitySoap")]
    public interface BookinFunctionalitySoap {
        
        // CODEGEN: Generating message contract since element name Password from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerificationLogin", ReplyAction="*")]
        EmployeeMobileApp.HolidayReference.VerificationLoginResponse VerificationLogin(EmployeeMobileApp.HolidayReference.VerificationLoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerificationLogin", ReplyAction="*")]
        System.Threading.Tasks.Task<EmployeeMobileApp.HolidayReference.VerificationLoginResponse> VerificationLoginAsync(EmployeeMobileApp.HolidayReference.VerificationLoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetID", ReplyAction="*")]
        long GetID(long StaffID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetID", ReplyAction="*")]
        System.Threading.Tasks.Task<long> GetIDAsync(long StaffID);
        
        // CODEGEN: Generating message contract since element name ViewHolidayReqStatusResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ViewHolidayReqStatus", ReplyAction="*")]
        EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusResponse ViewHolidayReqStatus(EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ViewHolidayReqStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusResponse> ViewHolidayReqStatusAsync(EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SubmitHolidayReq", ReplyAction="*")]
        bool SubmitHolidayReq(System.DateTime startH, System.DateTime endH, long StaffID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SubmitHolidayReq", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> SubmitHolidayReqAsync(System.DateTime startH, System.DateTime endH, long StaffID);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class VerificationLoginRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="VerificationLogin", Namespace="http://tempuri.org/", Order=0)]
        public EmployeeMobileApp.HolidayReference.VerificationLoginRequestBody Body;
        
        public VerificationLoginRequest() {
        }
        
        public VerificationLoginRequest(EmployeeMobileApp.HolidayReference.VerificationLoginRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class VerificationLoginRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int StaffID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Password;
        
        public VerificationLoginRequestBody() {
        }
        
        public VerificationLoginRequestBody(int StaffID, string Password) {
            this.StaffID = StaffID;
            this.Password = Password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class VerificationLoginResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="VerificationLoginResponse", Namespace="http://tempuri.org/", Order=0)]
        public EmployeeMobileApp.HolidayReference.VerificationLoginResponseBody Body;
        
        public VerificationLoginResponse() {
        }
        
        public VerificationLoginResponse(EmployeeMobileApp.HolidayReference.VerificationLoginResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class VerificationLoginResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool VerificationLoginResult;
        
        public VerificationLoginResponseBody() {
        }
        
        public VerificationLoginResponseBody(bool VerificationLoginResult) {
            this.VerificationLoginResult = VerificationLoginResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ViewHolidayReqStatusRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ViewHolidayReqStatus", Namespace="http://tempuri.org/", Order=0)]
        public EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequestBody Body;
        
        public ViewHolidayReqStatusRequest() {
        }
        
        public ViewHolidayReqStatusRequest(EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ViewHolidayReqStatusRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long staffID;
        
        public ViewHolidayReqStatusRequestBody() {
        }
        
        public ViewHolidayReqStatusRequestBody(long staffID) {
            this.staffID = staffID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ViewHolidayReqStatusResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ViewHolidayReqStatusResponse", Namespace="http://tempuri.org/", Order=0)]
        public EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusResponseBody Body;
        
        public ViewHolidayReqStatusResponse() {
        }
        
        public ViewHolidayReqStatusResponse(EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ViewHolidayReqStatusResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public EmployeeMobileApp.HolidayReference.ArrayOfString ViewHolidayReqStatusResult;
        
        public ViewHolidayReqStatusResponseBody() {
        }
        
        public ViewHolidayReqStatusResponseBody(EmployeeMobileApp.HolidayReference.ArrayOfString ViewHolidayReqStatusResult) {
            this.ViewHolidayReqStatusResult = ViewHolidayReqStatusResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BookinFunctionalitySoapChannel : EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookinFunctionalitySoapClient : System.ServiceModel.ClientBase<EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap>, EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap {
        
        public BookinFunctionalitySoapClient() {
        }
        
        public BookinFunctionalitySoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookinFunctionalitySoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookinFunctionalitySoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookinFunctionalitySoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EmployeeMobileApp.HolidayReference.VerificationLoginResponse EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap.VerificationLogin(EmployeeMobileApp.HolidayReference.VerificationLoginRequest request) {
            return base.Channel.VerificationLogin(request);
        }
        
        public bool VerificationLogin(int StaffID, string Password) {
            EmployeeMobileApp.HolidayReference.VerificationLoginRequest inValue = new EmployeeMobileApp.HolidayReference.VerificationLoginRequest();
            inValue.Body = new EmployeeMobileApp.HolidayReference.VerificationLoginRequestBody();
            inValue.Body.StaffID = StaffID;
            inValue.Body.Password = Password;
            EmployeeMobileApp.HolidayReference.VerificationLoginResponse retVal = ((EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap)(this)).VerificationLogin(inValue);
            return retVal.Body.VerificationLoginResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EmployeeMobileApp.HolidayReference.VerificationLoginResponse> EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap.VerificationLoginAsync(EmployeeMobileApp.HolidayReference.VerificationLoginRequest request) {
            return base.Channel.VerificationLoginAsync(request);
        }
        
        public System.Threading.Tasks.Task<EmployeeMobileApp.HolidayReference.VerificationLoginResponse> VerificationLoginAsync(int StaffID, string Password) {
            EmployeeMobileApp.HolidayReference.VerificationLoginRequest inValue = new EmployeeMobileApp.HolidayReference.VerificationLoginRequest();
            inValue.Body = new EmployeeMobileApp.HolidayReference.VerificationLoginRequestBody();
            inValue.Body.StaffID = StaffID;
            inValue.Body.Password = Password;
            return ((EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap)(this)).VerificationLoginAsync(inValue);
        }
        
        public long GetID(long StaffID) {
            return base.Channel.GetID(StaffID);
        }
        
        public System.Threading.Tasks.Task<long> GetIDAsync(long StaffID) {
            return base.Channel.GetIDAsync(StaffID);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusResponse EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap.ViewHolidayReqStatus(EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequest request) {
            return base.Channel.ViewHolidayReqStatus(request);
        }
        
        public EmployeeMobileApp.HolidayReference.ArrayOfString ViewHolidayReqStatus(long staffID) {
            EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequest inValue = new EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequest();
            inValue.Body = new EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequestBody();
            inValue.Body.staffID = staffID;
            EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusResponse retVal = ((EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap)(this)).ViewHolidayReqStatus(inValue);
            return retVal.Body.ViewHolidayReqStatusResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusResponse> EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap.ViewHolidayReqStatusAsync(EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequest request) {
            return base.Channel.ViewHolidayReqStatusAsync(request);
        }
        
        public System.Threading.Tasks.Task<EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusResponse> ViewHolidayReqStatusAsync(long staffID) {
            EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequest inValue = new EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequest();
            inValue.Body = new EmployeeMobileApp.HolidayReference.ViewHolidayReqStatusRequestBody();
            inValue.Body.staffID = staffID;
            return ((EmployeeMobileApp.HolidayReference.BookinFunctionalitySoap)(this)).ViewHolidayReqStatusAsync(inValue);
        }
        
        public bool SubmitHolidayReq(System.DateTime startH, System.DateTime endH, long StaffID) {
            return base.Channel.SubmitHolidayReq(startH, endH, StaffID);
        }
        
        public System.Threading.Tasks.Task<bool> SubmitHolidayReqAsync(System.DateTime startH, System.DateTime endH, long StaffID) {
            return base.Channel.SubmitHolidayReqAsync(startH, endH, StaffID);
        }
    }
}