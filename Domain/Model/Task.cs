using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Task
    {
        int Id { get; set; }
        String Nombre { get; set; }
        String Descripcion { get; set; }
        String Status { get; set; }
    }
}
