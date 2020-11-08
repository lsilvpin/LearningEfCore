using LearningEfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningEfCore.Entities
{
    [Table("Persons")]
    public class Person : Identifiable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Birthdate { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public virtual Person Parent { get; set; }

        [ForeignKey("Job")]
        public int? JobId { get; set; }
        public virtual Job Job { get; set; }

        public virtual IList<Person> Friends { get; set; }

        public Person() { }
        public Person(int id, string name, DateTimeOffset birthdate, int? parentId, Person parent)
        {
            Id = id;
            Name = name;
            Birthdate = birthdate;
            ParentId = parentId;
            Parent = parent;
        }
    }
}
