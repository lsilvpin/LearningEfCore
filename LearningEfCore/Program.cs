using LearningEfCore.Data;
using LearningEfCore.Entities;
using LearningEfCore.Models;
using LearningEfCore.Tools;
using System;

namespace LearningEfCore
{
    static class Program
    {
        static void Main()
        {
            var pathHandler = new PathHandler();
            var jsonHandler = new JsonHandler<AppConfig>();

            var db = new EfContext(pathHandler, jsonHandler);

            var countryRepository = new Repository<Country>(db);
            var jobRepository = new Repository<Job>(db);
            var personRepository = new Repository<Person>(db);

            Start(countryRepository, jobRepository, personRepository);
        }

        private static void Start(Repository<Country> countryRepository, 
            Repository<Job> jobRepository, 
            Repository<Person> personRepository)
        {
            countryRepository.Select(c => c.Name).ForEach(name =>
            {
                Console.WriteLine(name);
            });
            Console.WriteLine();
            jobRepository.Select(j => j.Name).ForEach(name =>
            {
                Console.WriteLine(name);
            });
            Console.WriteLine();
            personRepository.Select(p => p.Name).ForEach(name =>
            {
                Console.WriteLine(name);
            });
        }
    }
}
