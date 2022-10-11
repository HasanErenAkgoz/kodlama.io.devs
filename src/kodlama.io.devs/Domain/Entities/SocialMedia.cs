using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMedia : Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public SocialMedia()
        {

        }
        public SocialMedia(int id,string name, string url,bool isActive) :this()
        {
            Id = id;
            Name = name;
            Url = url;
            IsActive = isActive;
        }

    }
}
