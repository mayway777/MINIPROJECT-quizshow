﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MINIPROJECT.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.Imember")]
    public interface Imember {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/InsertMember", ReplyAction="http://tempuri.org/Imember/InsertMemberResponse")]
        bool InsertMember(string id, string name, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/InsertMember", ReplyAction="http://tempuri.org/Imember/InsertMemberResponse")]
        System.Threading.Tasks.Task<bool> InsertMemberAsync(string id, string name, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/Login", ReplyAction="http://tempuri.org/Imember/LoginResponse")]
        bool Login(string userid, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/Login", ReplyAction="http://tempuri.org/Imember/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string userid, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/IsIdOkay", ReplyAction="http://tempuri.org/Imember/IsIdOkayResponse")]
        bool IsIdOkay(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/IsIdOkay", ReplyAction="http://tempuri.org/Imember/IsIdOkayResponse")]
        System.Threading.Tasks.Task<bool> IsIdOkayAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/IsNameOkay", ReplyAction="http://tempuri.org/Imember/IsNameOkayResponse")]
        bool IsNameOkay(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/IsNameOkay", ReplyAction="http://tempuri.org/Imember/IsNameOkayResponse")]
        System.Threading.Tasks.Task<bool> IsNameOkayAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/GetUserInformation", ReplyAction="http://tempuri.org/Imember/GetUserInformationResponse")]
        string GetUserInformation(string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/GetUserInformation", ReplyAction="http://tempuri.org/Imember/GetUserInformationResponse")]
        System.Threading.Tasks.Task<string> GetUserInformationAsync(string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/User1rd", ReplyAction="http://tempuri.org/Imember/User1rdResponse")]
        bool User1rd(string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/User1rd", ReplyAction="http://tempuri.org/Imember/User1rdResponse")]
        System.Threading.Tasks.Task<bool> User1rdAsync(string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/User2rd", ReplyAction="http://tempuri.org/Imember/User2rdResponse")]
        bool User2rd(string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/User2rd", ReplyAction="http://tempuri.org/Imember/User2rdResponse")]
        System.Threading.Tasks.Task<bool> User2rdAsync(string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/User3rd", ReplyAction="http://tempuri.org/Imember/User3rdResponse")]
        bool User3rd(string userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Imember/User3rd", ReplyAction="http://tempuri.org/Imember/User3rdResponse")]
        System.Threading.Tasks.Task<bool> User3rdAsync(string userid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ImemberChannel : MINIPROJECT.ServiceReference1.Imember, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ImemberClient : System.ServiceModel.ClientBase<MINIPROJECT.ServiceReference1.Imember>, MINIPROJECT.ServiceReference1.Imember {
        
        public ImemberClient() {
        }
        
        public ImemberClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ImemberClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImemberClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImemberClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool InsertMember(string id, string name, string password) {
            return base.Channel.InsertMember(id, name, password);
        }
        
        public System.Threading.Tasks.Task<bool> InsertMemberAsync(string id, string name, string password) {
            return base.Channel.InsertMemberAsync(id, name, password);
        }
        
        public bool Login(string userid, string password) {
            return base.Channel.Login(userid, password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string userid, string password) {
            return base.Channel.LoginAsync(userid, password);
        }
        
        public bool IsIdOkay(string id) {
            return base.Channel.IsIdOkay(id);
        }
        
        public System.Threading.Tasks.Task<bool> IsIdOkayAsync(string id) {
            return base.Channel.IsIdOkayAsync(id);
        }
        
        public bool IsNameOkay(string name) {
            return base.Channel.IsNameOkay(name);
        }
        
        public System.Threading.Tasks.Task<bool> IsNameOkayAsync(string name) {
            return base.Channel.IsNameOkayAsync(name);
        }
        
        public string GetUserInformation(string userid) {
            return base.Channel.GetUserInformation(userid);
        }
        
        public System.Threading.Tasks.Task<string> GetUserInformationAsync(string userid) {
            return base.Channel.GetUserInformationAsync(userid);
        }
        
        public bool User1rd(string userid) {
            return base.Channel.User1rd(userid);
        }
        
        public System.Threading.Tasks.Task<bool> User1rdAsync(string userid) {
            return base.Channel.User1rdAsync(userid);
        }
        
        public bool User2rd(string userid) {
            return base.Channel.User2rd(userid);
        }
        
        public System.Threading.Tasks.Task<bool> User2rdAsync(string userid) {
            return base.Channel.User2rdAsync(userid);
        }
        
        public bool User3rd(string userid) {
            return base.Channel.User3rd(userid);
        }
        
        public System.Threading.Tasks.Task<bool> User3rdAsync(string userid) {
            return base.Channel.User3rdAsync(userid);
        }
    }
}
