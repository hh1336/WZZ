using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Article> Articles { set; get; }
        public virtual DbSet<WZZModel> WZZModels { set; get; }
        public virtual DbSet<RotationChart> RotationCharts { set; get; }
        public virtual DbSet<TeaType> TeaTypes { set; get; }
        public virtual DbSet<ArticleConTent> ArticleConTents { set; get; }
        public virtual DbSet<ArticleImage> ArticleImages { set; get; }
        public virtual DbSet<Subheading> Subheadings { set; get; }
        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<WebStationSetting> WebStationSettings { set; get; }
    }
}
