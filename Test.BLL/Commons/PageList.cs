using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Commons
{
    /// <summary>
    /// 分页的公共类
    /// </summary>
    public static class PageList
    {
        /// <summary>
        /// IQueryable的扩展方法，用于分页
        /// </summary>
        /// <typeparam name="TSource">实体类型</typeparam>
        /// <param name="source">需要进行分页的数据</param>
        /// <param name="limit">每页显示条数</param>
        /// <param name="page">从第几页开始</param>
        /// <param name="field">排序的字段</param>
        /// <param name="order">排序规则</param>
        /// <returns></returns>
        public static async Task<IPageList<TSource>> ToPageList<TSource>(this IQueryable<TSource> source, int limit, int page) where TSource : class, new()
        {
            //计算取第几页的值
            int skip = (page - 1) * limit;
            //计算取几条
            int take = source.Count() < limit ? source.Count() : limit;
            //取出对应页数的数据
            var query = source.Skip(skip).Take(take);

            //返回数据
            return new IPageList<TSource>()
            {
                data = await query.ToListAsync(),
                total = source.Count() / limit < 1 ? 1 : source.Count() / limit,
                code = 200,
                count = source.Count(),
                message = query.Count() > 0 ? "加载成功" : "没有数据"
            };
        }

        /// <summary>
        /// 对数据进行排序，用于IQueryable<>类型
        /// </summary>
        /// <typeparam name="TSource">实体</typeparam>
        /// <param name="source">数据</param>
        /// <param name="field">排序字段</param>
        /// <param name="order">排序规则</param>
        /// <returns></returns>
        public static IQueryable<TSource> Sort<TSource>(this IQueryable<TSource> source, string field, string order) where TSource : class, new()
        {
            IQueryable<TSource> query;
            //判断需要进行的是升序还是降序
            if (order.Equals("desc"))
            {
                query = from item in source
                        orderby field descending
                        select item;
            }
            else
            {
                query = from item in source
                        orderby field ascending
                        select item;
            }
            return query;
        }

        ///// <summary>
        ///// 对内容进行升序
        ///// </summary>
        ///// <typeparam name="TSource"></typeparam>
        ///// <param name="source"></param>
        ///// <param name="func"></param>
        ///// <returns></returns>
        //public static IQueryable<TSource> SortASC<TSource>(this IQueryable<TSource> source, Func<TSource, T> func) where TSource : class, new()
        //{
        //    string sort = "";
        //    foreach (var item in source)
        //    {
        //        sort = func(item);
        //    }
        //    var query = from item in source
        //                orderby sort ascending
        //                select item;
        //    return query;
        //}

        ///// <summary>
        ///// 对内容进行降序
        ///// </summary>
        ///// <typeparam name="TSource"></typeparam>
        ///// <param name="source"></param>
        ///// <param name="func"></param>
        ///// <returns></returns>
        //public static IQueryable<TSource> SortDESC<TSource>(this IQueryable<TSource> source, Func<TSource, string> func) where TSource : class, new()
        //{
        //    string sort = "";
        //    foreach (var item in source)
        //    {
        //        sort = func(item);
        //    }
        //    var query = from item in source
        //                orderby sort descending
        //                select item;
        //    return query;
        //}

    }

    /// <summary>
    /// 分页的泛型类，用于定义返回的类型
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    public class IPageList<T>
    {
        /// <summary>
        /// 共多少页
        /// </summary>
        public int total { set; get; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> data { set; get; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { set; get; }

        /// <summary>
        /// 加载状态码
        /// </summary>
        public int code { set; get; }

        /// <summary>
        /// 一共多少条数据
        /// </summary>
        public int count { set; get; }
    }


}
