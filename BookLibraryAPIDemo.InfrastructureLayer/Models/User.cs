using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryAPIDemo.InfrastructureLayer.Models
{
    internal class User : BaseModel
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
