using Her.Domain.Entities;
using Her.Domain.Entities.Dictionaries;
using Her.Domain.Entities.ManyToMany;
using Her.Domain.Entities.Wro;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Her.Context
{
	public class HerContext : IdentityDbContext<ApplicationUser>
	{
		public HerContext()
		{
		}
		public HerContext(DbContextOptions<HerContext> options)
			: base(options)
		{
		}
		public virtual DbSet<VersionModel> Version { get; set; }
		public virtual DbSet<TaskCategoryModel> TaskCategory { get; set; }
		public virtual DbSet<TaskModel> Task { get; set; }
		public virtual DbSet<IntrestModel> Intrest { get; set; }
		public virtual DbSet<NotificationModel> Notification { get; set; }
		public virtual DbSet<UserCustomSettingsModel> UserCustomSettings { get; set; }
		public virtual DbSet<WeatherModel> Weather { get; set; }
		public virtual DbSet<MPKInfoModel> MPKInfoModel { get; set; }

		///////////////////////////////////////////////Wroc///////////////////////////////////////////////////
		public virtual DbSet<WrocItemsModel> WrocItems { get; set; }
		public virtual DbSet<WrocMainImageModel> WrocMainImages { get; set; }
		public virtual DbSet<WrocOfferAdressModel> WrocOfferAdressModels { get; set; }
		public virtual DbSet<WrocOfferCategoriesModel> WroOffersCategories { get; set; }
		public virtual DbSet<WrocOfferModel> WrocOffers { get; set; }
		public virtual DbSet<WrocOfferTypeModel> WrocOfferTypeModels { get; set; }
		public virtual DbSet<WroCategoryModel> WroCategories { get; set; }
		///////////////////////////////////////////////Wroc///////////////////////////////////////////////////

		//////////////////////////////////////////////Many-To-Many////////////////////////////////////////////
		public virtual DbSet<UserInterestModel> UserInterests { get; set; }
		public virtual DbSet<UserDailyWroEventsModel> UserDailyWroEvents { get; set; }
		//////////////////////////////////////////////Many-To-Many////////////////////////////////////////////

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// User intrest
			modelBuilder.Entity<UserInterestModel>()
			.HasKey(t => new { t.IntrestID, t.UserID });

			modelBuilder.Entity<UserInterestModel>()
				.HasOne(pt => pt.User)
				.WithMany(p => p.Interests)
				.HasForeignKey(pt => pt.UserID);

			modelBuilder.Entity<UserInterestModel>()
				.HasOne(pt => pt.Intrest)
				.WithMany(t => t.UserInterests)
				.HasForeignKey(pt => pt.IntrestID);
			//UserDailyWroEventsModel
			modelBuilder.Entity<UserDailyWroEventsModel>()
			.HasKey(t => new { t.WrocItemsID, t.UserID });

			modelBuilder.Entity<UserDailyWroEventsModel>()
				.HasOne(pt => pt.User)
				.WithMany(p => p.DailyWroEvents)
				.HasForeignKey(pt => pt.UserID);

			modelBuilder.Entity<UserDailyWroEventsModel>()
				.HasOne(pt => pt.WrocItems)
				.WithMany(t => t.UserDailyWroEvents)
				.HasForeignKey(pt => pt.WrocItemsID);
		}

		//////////// https://www.captechconsulting.com/blogs/Customizing-the-ASPNET-Identity-Data-Model-with-the-Entity-Framework-Fluent-API--Part-1
	}

}
