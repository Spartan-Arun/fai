using System.ComponentModel.DataAnnotations;
namespace AuthserverAPi.data{

    public class Employee
    {
        [Key]
        public long ProfileId{get;set;}
        public string FirstName{get;set;}
        public string LasteName{get;set;}
        public string Note{get;set;}
        public string ProfilePic{get;set;}
        public string Email{get;set;}
        public string Phone{get;set;}
    }
}