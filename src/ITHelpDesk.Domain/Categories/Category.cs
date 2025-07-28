using System;
using Volo.Abp.Domain.Entities;

namespace ITHelpDesk.Categories
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }

        public Category(Guid id, string name) : base(id)
        {
            Name = name;
        }

       
     //   public Category() { }
    }
}
