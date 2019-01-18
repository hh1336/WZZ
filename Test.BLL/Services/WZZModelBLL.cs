﻿using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    /// <summary>
    /// 模块服务实现
    /// </summary>
    public class WZZModelBLL : IWZZModelBLL
    {
        private readonly MyDbContext _db;

        public WZZModelBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<WZZModel> GetAll()
        {
            return _db.WZZModels.Where(w => w.id >= 0);
        }

        /// <summary>
        /// 获取所有数据并返回list类型的集合
        /// </summary>
        /// <returns></returns>
        public List<WZZModel> GetAllList()
        {
            var result = GetAll();
            return result.ToList();
        }

        /// <summary>
        /// 根据id获取模块信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WZZModel GetById(int id)
        {
            var result = _db.WZZModels.SingleOrDefault(w => w.id == id);
            return result;
        }
    }
}