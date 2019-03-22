using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using BLL.Interfaces;
using BLL.Services;

namespace BLL
{
    public class BLLDIRegister
    {
        public void DIRegister_DAL(IServiceCollection services)
        {
            //配置依赖注入映射关系
            services.AddTransient(typeof(IWZZModelBLL), typeof(WZZModelBLL));
            services.AddTransient(typeof(ITeaTypeBLL), typeof(TeaTypeBLL));
            services.AddTransient(typeof(IArticleBLL), typeof(ArticleBLL));
            services.AddTransient(typeof(IRotationChartBLL), typeof(RotationChartBLL));
            services.AddTransient(typeof(ILoginBLL), typeof(LoginBLL));
            services.AddTransient(typeof(IUserBLL), typeof(UserBLL));
            services.AddTransient(typeof(IArticleConTentBLL), typeof(ArticleConTentBLL));
            services.AddTransient(typeof(IArticleImageBLL), typeof(ArticleImageBLL));
            services.AddTransient(typeof(ISubheadingBLL), typeof(SubheadingBLL));
            services.AddTransient(typeof(IRecoveryServiceBLL), typeof(RecoveryServiceBLL));
            services.AddTransient(typeof(IRotationChartSettingBLL), typeof(RotationChartSettingBLL));
            services.AddTransient(typeof(IVarietiesBLL), typeof(VarietiesBLL));
            services.AddTransient(typeof(IWebStationSettingBLL), typeof(WebStationSettingBLL));
            services.AddTransient(typeof(IVisitAmountBLL), typeof(VisitAmountBLL));

        }
    }
}
