using HRTrainingTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities
{
    public class HRTrainingContext : DbContext
    {

        public HRTrainingContext()
        {

        }

        public HRTrainingContext(DbContextOptions<HRTrainingContext> options) 
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<TrainingTypes> TrainingTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source= (localdb)\\ProjectsV13; Initial Catalog=TrainingDB",
                //    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                //);
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:TrainingDB",
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                );
            }
        }
    }
}
