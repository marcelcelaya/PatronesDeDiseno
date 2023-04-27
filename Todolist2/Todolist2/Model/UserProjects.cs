using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist2.Model
{
    public class UserProjects
    {
        [Key]
        public int Id { get; set; }
        public Project  Project { get; set; }
        public User User { get; set; }
    }
}
