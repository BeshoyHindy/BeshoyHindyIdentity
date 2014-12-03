

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "BeshoyHindyIdentity.WebGUI\Web.config"
//     Connection String Name: "DBDataContext"
//     Connection String:      "Data Source=.;Initial Catalog=DBIdentity;Persist Security Info=True;User ID=sa;Password=sql2012"

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace DAL.DataModels
{
    // ************************************************************************
    // Unit of work
    public interface IDBDataContext : IDisposable
    {
        IDbSet<AboutMe> AboutMes { get; set; } // AboutMes
        IDbSet<Admin> Admins { get; set; } // Admins
        IDbSet<Client> Clients { get; set; } // Clients
        IDbSet<Contact> Contacts { get; set; } // Contacts
        IDbSet<Education> Educations { get; set; } // Educations
        IDbSet<GeneralSkill> GeneralSkills { get; set; } // GeneralSkills
        IDbSet<Process> Processes { get; set; } // Processes
        IDbSet<Resume> Resumes { get; set; } // Resumes
        IDbSet<Service> Services { get; set; } // Services
        IDbSet<SocialLink> SocialLinks { get; set; } // SocialLinks
        IDbSet<SoftwareSkill> SoftwareSkills { get; set; } // SoftwareSkills
        IDbSet<Work> Works { get; set; } // Works
        IDbSet<WorkImage> WorkImages { get; set; } // WorkImages
        IDbSet<WorkType> WorkTypes { get; set; } // WorkTypes

        int SaveChanges();
    }

    // ************************************************************************
    // Database context
    public class DBDataContext : DbContext, IDBDataContext
    {
        public IDbSet<AboutMe> AboutMes { get; set; } // AboutMes
        public IDbSet<Admin> Admins { get; set; } // Admins
        public IDbSet<Client> Clients { get; set; } // Clients
        public IDbSet<Contact> Contacts { get; set; } // Contacts
        public IDbSet<Education> Educations { get; set; } // Educations
        public IDbSet<GeneralSkill> GeneralSkills { get; set; } // GeneralSkills
        public IDbSet<Process> Processes { get; set; } // Processes
        public IDbSet<Resume> Resumes { get; set; } // Resumes
        public IDbSet<Service> Services { get; set; } // Services
        public IDbSet<SocialLink> SocialLinks { get; set; } // SocialLinks
        public IDbSet<SoftwareSkill> SoftwareSkills { get; set; } // SoftwareSkills
        public IDbSet<Work> Works { get; set; } // Works
        public IDbSet<WorkImage> WorkImages { get; set; } // WorkImages
        public IDbSet<WorkType> WorkTypes { get; set; } // WorkTypes

        static DBDataContext()
        {
            Database.SetInitializer<DBDataContext>(null);
        }

        public DBDataContext()
            : base("Name=DBDataContext")
        {
        }

        public DBDataContext(string connectionString) : base(connectionString)
        {
        }

        public DBDataContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AboutMeConfiguration());
            modelBuilder.Configurations.Add(new AdminConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new EducationConfiguration());
            modelBuilder.Configurations.Add(new GeneralSkillConfiguration());
            modelBuilder.Configurations.Add(new ProcessConfiguration());
            modelBuilder.Configurations.Add(new ResumeConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new SocialLinkConfiguration());
            modelBuilder.Configurations.Add(new SoftwareSkillConfiguration());
            modelBuilder.Configurations.Add(new WorkConfiguration());
            modelBuilder.Configurations.Add(new WorkImageConfiguration());
            modelBuilder.Configurations.Add(new WorkTypeConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AboutMeConfiguration(schema));
            modelBuilder.Configurations.Add(new AdminConfiguration(schema));
            modelBuilder.Configurations.Add(new ClientConfiguration(schema));
            modelBuilder.Configurations.Add(new ContactConfiguration(schema));
            modelBuilder.Configurations.Add(new EducationConfiguration(schema));
            modelBuilder.Configurations.Add(new GeneralSkillConfiguration(schema));
            modelBuilder.Configurations.Add(new ProcessConfiguration(schema));
            modelBuilder.Configurations.Add(new ResumeConfiguration(schema));
            modelBuilder.Configurations.Add(new ServiceConfiguration(schema));
            modelBuilder.Configurations.Add(new SocialLinkConfiguration(schema));
            modelBuilder.Configurations.Add(new SoftwareSkillConfiguration(schema));
            modelBuilder.Configurations.Add(new WorkConfiguration(schema));
            modelBuilder.Configurations.Add(new WorkImageConfiguration(schema));
            modelBuilder.Configurations.Add(new WorkTypeConfiguration(schema));
            return modelBuilder;
        }
    }

    // ************************************************************************
    // Fake Database context
    public class FakeDBDataContext : IDBDataContext
    {
        public IDbSet<AboutMe> AboutMes { get; set; }
        public IDbSet<Admin> Admins { get; set; }
        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Contact> Contacts { get; set; }
        public IDbSet<Education> Educations { get; set; }
        public IDbSet<GeneralSkill> GeneralSkills { get; set; }
        public IDbSet<Process> Processes { get; set; }
        public IDbSet<Resume> Resumes { get; set; }
        public IDbSet<Service> Services { get; set; }
        public IDbSet<SocialLink> SocialLinks { get; set; }
        public IDbSet<SoftwareSkill> SoftwareSkills { get; set; }
        public IDbSet<Work> Works { get; set; }
        public IDbSet<WorkImage> WorkImages { get; set; }
        public IDbSet<WorkType> WorkTypes { get; set; }

        public FakeDBDataContext()
        {
            AboutMes = new FakeDbSet<AboutMe>();
            Admins = new FakeDbSet<Admin>();
            Clients = new FakeDbSet<Client>();
            Contacts = new FakeDbSet<Contact>();
            Educations = new FakeDbSet<Education>();
            GeneralSkills = new FakeDbSet<GeneralSkill>();
            Processes = new FakeDbSet<Process>();
            Resumes = new FakeDbSet<Resume>();
            Services = new FakeDbSet<Service>();
            SocialLinks = new FakeDbSet<SocialLink>();
            SoftwareSkills = new FakeDbSet<SoftwareSkill>();
            Works = new FakeDbSet<Work>();
            WorkImages = new FakeDbSet<WorkImage>();
            WorkTypes = new FakeDbSet<WorkType>();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException(); 
        }
    }

    // ************************************************************************
    // Fake DbSet
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private readonly HashSet<T> _data;

        public FakeDbSet()
        {
            _data = new HashSet<T>();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public void Detach(T item)
        {
            _data.Remove(item);
        }

        Type IQueryable.ElementType
        {
            get { return _data.AsQueryable().ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _data.AsQueryable().Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _data.AsQueryable().Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public ObservableCollection<T> Local
        {
            get
            {
                return new ObservableCollection<T>(_data);
            }
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }
    }

    // ************************************************************************
    // POCO classes

    // AboutMes
    public class AboutMe
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string JobTitle { get; set; } // JobTitle
        public DateTime? Birthdate { get; set; } // Birthdate
        public string Phone { get; set; } // Phone
        public string Email { get; set; } // Email
        public string WebSiteUrl { get; set; } // WebSiteURL
        public string ReusmeUrl { get; set; } // ReusmeURL
        public string Image { get; set; } // Image
        public string Address { get; set; } // Address
        public string Quote { get; set; } // Quote
        public string IdentityDescription { get; set; } // IdentityDescription
        public int? ExperienceYears { get; set; } // ExperienceYears
        public int? Clints { get; set; } // Clints
        public int? Projects { get; set; } // Projects
        public int? Certifications { get; set; } // Certifications
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // Admins
    public class Admin
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string UserName { get; set; } // UserName
        public string LoginName { get; set; } // LoginName
        public string Password { get; set; } // Password
        public string Photo { get; set; } // Photo
        public int? RecOrder { get; set; } // RecOrder
        public DateTime CreatedOn { get; set; } // CreatedOn
        public Guid CreatedBy { get; set; } // CreatedBy
        public DateTime ModifiedOn { get; set; } // ModifiedOn
        public Guid ModifiedBy { get; set; } // ModifiedBy
        public bool Active { get; set; } // Active
    }

    // Clients
    public class Client
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string ClientName { get; set; } // ClientName
        public string ClientPosition { get; set; } // ClientPosition
        public string Logo { get; set; } // Logo
        public string ClientMessage { get; set; } // ClientMessage
        public string ClientUrl { get; set; } // ClientURL
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // Contacts
    public class Contact
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Address { get; set; } // Address
        public string Email { get; set; } // Email
        public string Phone { get; set; } // Phone
        public string GoogleMap { get; set; } // GoogleMap
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // Educations
    public class Education
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Institute { get; set; } // Institute
        public string Description { get; set; } // Description
        public string DateFrom { get; set; } // DateFrom
        public string DateTo { get; set; } // DateTo
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // GeneralSkills
    public class GeneralSkill
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public int? Percentage { get; set; } // Percentage
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // Processes
    public class Process
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public string Logo { get; set; } // Logo
        public int? Oreder { get; set; } // Oreder
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // Resumes
    public class Resume
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string JobTitle { get; set; } // JobTitle
        public string JobDescription { get; set; } // JobDescription
        public string JobPosition { get; set; } // JobPosition
        public string CompanyName { get; set; } // CompanyName
        public string DateFrom { get; set; } // DateFrom
        public string DateTo { get; set; } // DateTo
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // Services
    public class Service
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public string Image { get; set; } // Image
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // SocialLinks
    public class SocialLink
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Logo { get; set; } // Logo
        public string URl { get; set; } // URl
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // SoftwareSkills
    public class SoftwareSkill
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public int? Percentage { get; set; } // Percentage
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // Works
    public class Work
    {
        public Guid Id { get; set; } // Id (Primary key)
        public Guid WorkTypeId { get; set; } // WorkTypeId
        public string Title { get; set; } // Title
        public string ProjectDate { get; set; } // ProjectDate
        public string Description { get; set; } // Description
        public string IamgeThumb { get; set; } // IamgeThumb
        public string IamgeFile { get; set; } // IamgeFile
        public string Url { get; set; } // URL
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }

    // WorkImages
    public class WorkImage
    {
        public Guid Id { get; set; } // Id (Primary key)
        public Guid? WorkId { get; set; } // WorkId
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public string IamgeFile { get; set; } // IamgeFile
        public string Url { get; set; } // URL
        public int? RecOrder { get; set; } // RecOrder
        public DateTime CreatedOn { get; set; } // CreatedOn
        public Guid CreatedBy { get; set; } // CreatedBy
        public DateTime ModifiedOn { get; set; } // ModifiedOn
        public Guid ModifiedBy { get; set; } // ModifiedBy
        public bool Active { get; set; } // Active
    }

    // WorkTypes
    public class WorkType
    {
        public Guid Id { get; set; } // Id (Primary key)
        public string TypeName { get; set; } // TypeName
        public string ClassName { get; set; } // ClassName
        public string Image { get; set; } // Image
        public int? RecOrder { get; set; } // RecOrder
        public DateTime? CreatedOn { get; set; } // CreatedOn
        public Guid? CreatedBy { get; set; } // CreatedBy
        public DateTime? ModifiedOn { get; set; } // ModifiedOn
        public Guid? ModifiedBy { get; set; } // ModifiedBy
        public bool? Active { get; set; } // Active
    }


    // ************************************************************************
    // POCO Configuration

    // AboutMes
    internal class AboutMeConfiguration : EntityTypeConfiguration<AboutMe>
    {
        public AboutMeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".AboutMes");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(150);
            Property(x => x.JobTitle).HasColumnName("JobTitle").IsOptional().HasMaxLength(100);
            Property(x => x.Birthdate).HasColumnName("Birthdate").IsOptional();
            Property(x => x.Phone).HasColumnName("Phone").IsOptional().HasMaxLength(25);
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasMaxLength(100);
            Property(x => x.WebSiteUrl).HasColumnName("WebSiteURL").IsOptional().HasMaxLength(150);
            Property(x => x.ReusmeUrl).HasColumnName("ReusmeURL").IsOptional();
            Property(x => x.Image).HasColumnName("Image").IsOptional().HasMaxLength(250);
            Property(x => x.Address).HasColumnName("Address").IsOptional();
            Property(x => x.Quote).HasColumnName("Quote").IsOptional();
            Property(x => x.IdentityDescription).HasColumnName("IdentityDescription").IsOptional();
            Property(x => x.ExperienceYears).HasColumnName("ExperienceYears").IsOptional();
            Property(x => x.Clints).HasColumnName("Clints").IsOptional();
            Property(x => x.Projects).HasColumnName("Projects").IsOptional();
            Property(x => x.Certifications).HasColumnName("Certifications").IsOptional();
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // Admins
    internal class AdminConfiguration : EntityTypeConfiguration<Admin>
    {
        public AdminConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Admins");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.UserName).HasColumnName("UserName").IsOptional().HasMaxLength(150);
            Property(x => x.LoginName).HasColumnName("LoginName").IsOptional().HasMaxLength(150);
            Property(x => x.Password).HasColumnName("Password").IsOptional().HasMaxLength(150);
            Property(x => x.Photo).HasColumnName("Photo").IsOptional();
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsRequired();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsRequired();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsRequired();
            Property(x => x.Active).HasColumnName("Active").IsRequired();
        }
    }

    // Clients
    internal class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Clients");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.ClientName).HasColumnName("ClientName").IsOptional().HasMaxLength(150);
            Property(x => x.ClientPosition).HasColumnName("ClientPosition").IsOptional().HasMaxLength(150);
            Property(x => x.Logo).HasColumnName("Logo").IsOptional();
            Property(x => x.ClientMessage).HasColumnName("ClientMessage").IsOptional();
            Property(x => x.ClientUrl).HasColumnName("ClientURL").IsOptional().HasMaxLength(150);
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // Contacts
    internal class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Contacts");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(20);
            Property(x => x.Address).HasColumnName("Address").IsOptional();
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasMaxLength(150);
            Property(x => x.Phone).HasColumnName("Phone").IsOptional().HasMaxLength(25);
            Property(x => x.GoogleMap).HasColumnName("GoogleMap").IsOptional();
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // Educations
    internal class EducationConfiguration : EntityTypeConfiguration<Education>
    {
        public EducationConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Educations");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Institute).HasColumnName("Institute").IsOptional().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.DateFrom).HasColumnName("DateFrom").IsOptional().HasMaxLength(25);
            Property(x => x.DateTo).HasColumnName("DateTo").IsOptional().HasMaxLength(25);
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // GeneralSkills
    internal class GeneralSkillConfiguration : EntityTypeConfiguration<GeneralSkill>
    {
        public GeneralSkillConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".GeneralSkills");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.Percentage).HasColumnName("Percentage").IsOptional();
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // Processes
    internal class ProcessConfiguration : EntityTypeConfiguration<Process>
    {
        public ProcessConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Processes");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(100);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.Logo).HasColumnName("Logo").IsOptional();
            Property(x => x.Oreder).HasColumnName("Oreder").IsOptional();
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // Resumes
    internal class ResumeConfiguration : EntityTypeConfiguration<Resume>
    {
        public ResumeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Resumes");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.JobTitle).HasColumnName("JobTitle").IsOptional().HasMaxLength(50);
            Property(x => x.JobDescription).HasColumnName("JobDescription").IsOptional();
            Property(x => x.JobPosition).HasColumnName("JobPosition").IsOptional();
            Property(x => x.CompanyName).HasColumnName("CompanyName").IsOptional().HasMaxLength(100);
            Property(x => x.DateFrom).HasColumnName("DateFrom").IsOptional().HasMaxLength(25);
            Property(x => x.DateTo).HasColumnName("DateTo").IsOptional().HasMaxLength(25);
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // Services
    internal class ServiceConfiguration : EntityTypeConfiguration<Service>
    {
        public ServiceConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Services");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.Image).HasColumnName("Image").IsOptional();
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // SocialLinks
    internal class SocialLinkConfiguration : EntityTypeConfiguration<SocialLink>
    {
        public SocialLinkConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".SocialLinks");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Logo).HasColumnName("Logo").IsOptional();
            Property(x => x.URl).HasColumnName("URl").IsOptional().HasMaxLength(250);
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // SoftwareSkills
    internal class SoftwareSkillConfiguration : EntityTypeConfiguration<SoftwareSkill>
    {
        public SoftwareSkillConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".SoftwareSkills");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.Percentage).HasColumnName("Percentage").IsOptional();
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // Works
    internal class WorkConfiguration : EntityTypeConfiguration<Work>
    {
        public WorkConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Works");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.WorkTypeId).HasColumnName("WorkTypeId").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.ProjectDate).HasColumnName("ProjectDate").IsOptional().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.IamgeThumb).HasColumnName("IamgeThumb").IsOptional();
            Property(x => x.IamgeFile).HasColumnName("IamgeFile").IsOptional();
            Property(x => x.Url).HasColumnName("URL").IsOptional().HasMaxLength(250);
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

    // WorkImages
    internal class WorkImageConfiguration : EntityTypeConfiguration<WorkImage>
    {
        public WorkImageConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".WorkImages");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.WorkId).HasColumnName("WorkId").IsOptional();
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.IamgeFile).HasColumnName("IamgeFile").IsOptional();
            Property(x => x.Url).HasColumnName("URL").IsOptional().HasMaxLength(250);
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsRequired();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsRequired();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsRequired();
            Property(x => x.Active).HasColumnName("Active").IsRequired();
        }
    }

    // WorkTypes
    internal class WorkTypeConfiguration : EntityTypeConfiguration<WorkType>
    {
        public WorkTypeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".WorkTypes");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.TypeName).HasColumnName("TypeName").IsOptional().HasMaxLength(50);
            Property(x => x.ClassName).HasColumnName("ClassName").IsOptional().HasMaxLength(50);
            Property(x => x.Image).HasColumnName("Image").IsOptional();
            Property(x => x.RecOrder).HasColumnName("RecOrder").IsOptional();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsOptional();
        }
    }

}

