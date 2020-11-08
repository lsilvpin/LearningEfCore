using LearningEfCore.Entities;
using System;
using System.Collections.Generic;

namespace LearningEfCore.Data
{
    class Seed
    {
        private readonly Repository<Country> countryRepository;
        private readonly Repository<Job> jobRepository;
        private readonly Repository<Person> personRepository;

        internal Seed(Repository<Country> countryRepository,
            Repository<Job> jobRepository,
            Repository<Person> personRepository)
        {
            this.countryRepository = countryRepository;
            this.jobRepository = jobRepository;
            this.personRepository = personRepository;
        }

        internal void Execute()
        {
            CreatePersons();
            CreateJobs();
            CreateCountries();
        }

        private void CreatePersons()
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Name = "João",
                    Birthdate = DateTimeOffset.Now
                },

                new Person
                {
                    Name = "José",
                    Birthdate = DateTimeOffset.Now
                },

                new Person
                {
                    Name = "Luís",
                    Birthdate = DateTimeOffset.Now
                },

                new Person
                {
                    Name = "Laura",
                    Birthdate = DateTimeOffset.Now
                },

                new Person
                {
                    Name = "Rosane",
                    Birthdate = DateTimeOffset.Now
                },

                new Person
                {
                    Name = "Raul",
                    Birthdate = DateTimeOffset.Now
                },

                new Person
                {
                    Name = "Dídio",
                    Birthdate = DateTimeOffset.Now
                },

                new Person
                {
                    Name = "Ioni",
                    Birthdate = DateTimeOffset.Now
                },

                new Person
                {
                    Name = "Ninil",
                    Birthdate = DateTimeOffset.Now
                },
            };

            personRepository.Create(persons);
            personRepository.Commit();
        }

        private void CreateJobs()
        {
            var jobs = new List<Job>
            {
                new Job
                {
                    Name = "Programador",
                    Salary = 2.500,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                },

                new Job
                {
                    Name = "Dentista",
                    Salary = 10.000,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                },

                new Job
                {
                    Name = "Coletor",
                    Salary = 1.800,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                },

                new Job
                {
                    Name = "Comerciante",
                    Salary = 4.500,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                },

                new Job
                {
                    Name = "Professor",
                    Salary = 1.000,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                },

                new Job
                {
                    Name = "Lixeiro",
                    Salary = 1.500,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                },

                new Job
                {
                    Name = "Carpinteiro",
                    Salary = 2.200,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                },

                new Job
                {
                    Name = "Alfaiate",
                    Salary = 3.000,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                },

                new Job
                {
                    Name = "Ferreiro",
                    Salary = 1.400,
                    HiringDate = DateTimeOffset.Now,

                    Persons = new List<Person>()
                }
            };

            jobRepository.Create(jobs);
            jobRepository.Commit();
        }

        private void CreateCountries()
        {
            var countries = new List<Country>
            {
                new Country
                {
                    Name = "Brasil",

                    Jobs = new List<Job>(),
                    Persons = new List<Person>()
                },

                new Country
                {
                    Name = "EUA",

                    Jobs = new List<Job>(),
                    Persons = new List<Person>()
                },

                new Country
                {
                    Name = "Canadá",

                    Jobs = new List<Job>(),
                    Persons = new List<Person>()
                }
            };

            countryRepository.Create(countries);
            countryRepository.Commit();
        }
    }
}
