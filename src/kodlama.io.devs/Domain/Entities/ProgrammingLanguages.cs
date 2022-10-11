using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingLanguages:Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<LanguageTech> languageTeches { get; set; }
        public ProgrammingLanguages()
        {

        }

        public ProgrammingLanguages(int id, string name,bool isActive) :this()
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
    }
}
