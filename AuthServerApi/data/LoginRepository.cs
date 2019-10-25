using System.Linq;
using System.Collections.Generic;
namespace AuthserverAPi.data{

    public class LoginRepository : ILoginRepository
    {

        private readonly AppDBContext _context;
        public LoginRepository(AppDBContext context){
            this._context = context;
        }
        public bool UserLogin(string Username, string Password , out string role){
            List<Login> user = _context.Users.Where(x=>x.UserName == Username && x.Password == Password).ToList();
            role = user[0].Role;
            if(user.Count()>0){
                return true;
            }
            else
                return false;
        }
        
    }

}