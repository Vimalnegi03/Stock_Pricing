using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces
{
    public interface ITokenService
    { 
        string CreateToken(AppUser user);
        
    }
}