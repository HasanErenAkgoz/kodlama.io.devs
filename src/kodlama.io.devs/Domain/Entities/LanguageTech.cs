using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LanguageTech:Entity
    {
      
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguages? ProgrammingLanguage { get; set; }
        public LanguageTech()
        {

        }
        public LanguageTech(int id,int programmingLanguageId, string name):this()
        {
            Id= id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
          
        }
    }
}
