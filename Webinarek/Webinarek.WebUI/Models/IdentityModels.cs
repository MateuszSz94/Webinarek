﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Webinarek.Models.Entity;

namespace Webinarek.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Webinar> Webinars { get; set; }

		public DbSet<Lista_webinarow_w_kursie> Lista_webinarow_w_kursies { get; set; }

		public DbSet<Kurs> Kurs { get; set; }

		public DbSet<Student_Lists>Student_Lists { get; set; }

		public DbSet<Skin> Skins { get; set; }

		public DbSet<Student> Students { get; set; }


		public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class MainDBContext : DbContext
    {
        public MainDBContext() : base(@"DefaultConnection")
        { }
       
    }
}