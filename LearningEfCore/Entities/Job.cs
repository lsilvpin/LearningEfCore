using LearningEfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningEfCore.Entities
{
    [Table("Jobs")]
    public class Job : Identifiable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTimeOffset HiringDate { get; set; }

        public virtual IList<Person> Persons { get; set; }

        public Job() { }
        public Job(int id, string name, double salary, DateTimeOffset hiringDate)
        {
            Id = id;
            Name = name;
            Salary = salary;
            HiringDate = hiringDate;
        }
    }
}
