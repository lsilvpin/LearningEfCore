using LearningEfCore.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningEfCore.Entities
{
    [Table("Countries")]
    public class Country : Identifiable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Job> Jobs { get; set; }
        public virtual IList<Person> Persons { get; set; }

        public Country() { }
        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
