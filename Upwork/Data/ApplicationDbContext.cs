﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Upwork.Models;
using Upwork.Models.DbModels;
using Upwork.Models.MessageModels;

namespace Upwork.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreaOfStudy> AreasOfStudy { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Freelancer> Freelancers { get; set; }

        public virtual DbSet<Freelancer_Education> Freelancer_Education { get; set; }

        public virtual DbSet<Freelancer_Experience> Freelancer_Experience { get; set; }

        public virtual DbSet<Freelancer_Language> Freelancer_Language { get; set; }

        public virtual DbSet<Freelancer_Skill> Freelancer_Skill { get; set; }

        public virtual DbSet<JobTitle> JobTitle { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<Language_Proficiency> Language_Proficiency { get; set; }

        public virtual DbSet<School> Schools { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<SubCategory> SubCategories { get; set; }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<ProjectTags> ProjectTags { get; set; }
        public virtual DbSet<ProjectSkills> ProjectSkills { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<JobsSkills> JobsSkills { get; set; }
        public virtual DbSet<Freelancer_Job> Freelancer_Jobs{ get; set; }
        public virtual DbSet<Client_Projects> Client_Projects { get; set; }

        public virtual DbSet<ReviewJobQuestion> ReviewJobQuestions { get; set; }
        public virtual DbSet<JobQuestions> JobQuestions { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Freelancer_Education>().HasKey(o => new { o.SchoolId, o.DegreeId, o.AreaId, o.FreelancerId });
            builder.Entity<Freelancer_Experience>().HasKey(o => new { o.JobTitleId, o.CountryId, o.CompanyId, o.FreelancerId });
            builder.Entity<Freelancer_Language>().HasKey(o => new { o.LanguageId, o.FreelancerId });
            builder.Entity<Freelancer_Skill>().HasKey(o => new { o.SkillId, o.FreelancerId });
            builder.Entity<ProjectTags>().HasKey(o => new { o.ProjectId, o.TagsId });
            builder.Entity<ProjectSkills>().HasKey(o => new { o.ProjectId, o.SkillId });
            builder.Entity<JobsSkills>().HasKey(o => new { o.JobsId, o.skillId });
            builder.Entity<JobQuestions>().HasKey(o => new { o.JobsId, o.ReviewJobQuestionId });
            builder.Entity<Freelancer_Job>().HasKey(o => new { o.JobsId, o.FreelancerId });
            builder.Entity<Client_Projects>().HasKey(o => new { o.ProjectId, o.ClientId });
           
            builder.Entity<JobsSkills>()
                .HasOne(bc => bc.Jobs)
                .WithMany(b => b.jobsSkills)
                .HasForeignKey(bc => bc.JobsId);
            builder.Entity<JobsSkills>()
                .HasOne(bc => bc.skill)
                .WithMany(c => c.jobsSkills)
                .HasForeignKey(bc => bc.skillId);
            base.OnModelCreating(builder);
            builder.Entity<Message>().
                HasOne<ApplicationUser>(a => a.Sender).
                WithMany(d => d.Messages).
                HasForeignKey(d => d.UserId);


        }


    }
}
