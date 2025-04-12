using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MINIPROJECT.ServiceReference1;
using MINIPROJECT.ServiceReference2;
namespace MINIPROJECT
{
    public class Manager

    {
        private ImemberClient memberClient = new ImemberClient();
        
        private static Manager instance;

     

        public static Manager Instance { get { return instance; } }
        static Manager() { instance = new Manager(); }

        private Manager() { }

        public string PlayerInfo(string id)
        {

           return memberClient.GetUserInformation(id);
            

        }
        public bool Insert(string id, string name, string password)
        {
           
            if(memberClient.InsertMember(id,name,password) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Login(string id, string password)
        {
            if (memberClient.Login(id, password) == true)
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        public bool IdOk(string id)
        {
            if (memberClient.IsIdOkay(id) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool NameOk(string name)
        {
            if (memberClient.IsNameOkay(name) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

      
    }
}
