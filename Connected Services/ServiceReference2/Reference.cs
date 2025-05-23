﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MINIPROJECT.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IQuizService", CallbackContract=typeof(MINIPROJECT.ServiceReference2.IQuizServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IQuizService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuizService/JoinGame", ReplyAction="http://tempuri.org/IQuizService/JoinGameResponse")]
        bool JoinGame(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuizService/JoinGame", ReplyAction="http://tempuri.org/IQuizService/JoinGameResponse")]
        System.Threading.Tasks.Task<bool> JoinGameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IQuizService/Say")]
        void Say(string name, string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IQuizService/Say")]
        System.Threading.Tasks.Task SayAsync(string name, string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IQuizService/GameStart")]
        void GameStart();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IQuizService/GameStart")]
        System.Threading.Tasks.Task GameStartAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IQuizService/GetQuiz")]
        void GetQuiz();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IQuizService/GetQuiz")]
        System.Threading.Tasks.Task GetQuizAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IQuizService/IsAnswer")]
        void IsAnswer(string name, int num, string answer, int score);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IQuizService/IsAnswer")]
        System.Threading.Tasks.Task IsAnswerAsync(string name, int num, string answer, int score);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IQuizServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQuizService/DisplayPlayerInfo")]
        void DisplayPlayerInfo(string playerName, string msg, int score, int index);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQuizService/Say_Ack")]
        void Say_Ack(string playerName, string msg, int index);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQuizService/Start_Ack")]
        void Start_Ack(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQuizService/GetQuiz_Ack")]
        void GetQuiz_Ack(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQuizService/Quiz_Ack")]
        void Quiz_Ack(string msg, int score, int num);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQuizService/IsAnswer_Ack")]
        void IsAnswer_Ack(string ok, string msg, int index);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQuizService/Score_Ack")]
        void Score_Ack(string name, int score);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IQuizService/QuizImage_Ack")]
        void QuizImage_Ack(byte[] bytes, int score, int index);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IQuizServiceChannel : MINIPROJECT.ServiceReference2.IQuizService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QuizServiceClient : System.ServiceModel.DuplexClientBase<MINIPROJECT.ServiceReference2.IQuizService>, MINIPROJECT.ServiceReference2.IQuizService {
        
        public QuizServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public QuizServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public QuizServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public QuizServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public QuizServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool JoinGame(string name) {
            return base.Channel.JoinGame(name);
        }
        
        public System.Threading.Tasks.Task<bool> JoinGameAsync(string name) {
            return base.Channel.JoinGameAsync(name);
        }
        
        public void Say(string name, string msg) {
            base.Channel.Say(name, msg);
        }
        
        public System.Threading.Tasks.Task SayAsync(string name, string msg) {
            return base.Channel.SayAsync(name, msg);
        }
        
        public void GameStart() {
            base.Channel.GameStart();
        }
        
        public System.Threading.Tasks.Task GameStartAsync() {
            return base.Channel.GameStartAsync();
        }
        
        public void GetQuiz() {
            base.Channel.GetQuiz();
        }
        
        public System.Threading.Tasks.Task GetQuizAsync() {
            return base.Channel.GetQuizAsync();
        }
        
        public void IsAnswer(string name, int num, string answer, int score) {
            base.Channel.IsAnswer(name, num, answer, score);
        }
        
        public System.Threading.Tasks.Task IsAnswerAsync(string name, int num, string answer, int score) {
            return base.Channel.IsAnswerAsync(name, num, answer, score);
        }
    }
}
