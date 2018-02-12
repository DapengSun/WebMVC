using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebMVC.Common;
using WebMVC.DBContext;
using WebMVC.IDAL;

namespace WebMVC.DAL
{
    public class BaseDAL<T> : IBaseDAL<T> where T : class,new()
    {
        //private DbContext _dbContext = new LocalDBContext();
        private DbContext _dbContext = DbContextFactory.Create();

        public bool Add(T t) {
            _dbContext.Set<T>().Add(t);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(T t) {
            _dbContext.Set<T>().AddOrUpdate(t);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(T t) {
            _dbContext.Set<T>().Remove(t);
            _dbContext.SaveChanges();
            return true;
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda, bool isReadCache = true, Expression<Func<T, bool>> cacheLambda = null, string cacheKey = "") {
            //isReadCache 读取缓存内容 true-读取 false-不读取
            if (isReadCache) { 

                List<T> CacheValue = RedisHelper.HashGetAll<T>(cacheKey);

                if (CacheValue != null && CacheValue.Count > 0)
                {
                    return CacheValue.AsQueryable().Where(whereLambda);
                }
                else
                {
                    //缓存数据
                    IQueryable<T> _TList = null;
                    //返回数据
                    IQueryable<T> _ReturnTList = null;

                    //缓存cacheLambda条件为空 则按照原条件缓存
                    if (cacheLambda != null)
                    {
                        _TList = _dbContext.Set<T>().Where(cacheLambda);
                        _ReturnTList = _dbContext.Set<T>().Where(whereLambda);
                    }
                    else
                    {
                        _ReturnTList = _dbContext.Set<T>().Where(whereLambda);
                    }

                    if (_TList != null && _TList.Count() > 0)
                    {
                        foreach (T item in _TList)
                        {
                            var c = item.GetType();
                            //通过反射获取Item Id 作为单项的Key 便于修改内容
                            RedisHelper.HashSet<T>(cacheKey, item.GetType().GetProperty("Id").GetValue(item).ToString(), item);
                        }
                    }

                    return _ReturnTList;
                }
            }else { 
                return _dbContext.Set<T>().Where(whereLambda);
            }
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda , bool isReadCache = true, Expression<Func<T, bool>> cacheLambda = null, string cacheKey = "") {
            //isReadCache 读取缓存内容 true-读取 false-不读取
            if (isReadCache)
            {
                List<T> CacheValue = RedisHelper.HashGetAll<T>(cacheKey);

                if (CacheValue != null && CacheValue.Count > 0)
                {
                    //是否升序
                    if (isAsc)
                    {
                        return CacheValue.AsQueryable().Where(whereLambda).OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    }
                    else
                    {
                        return CacheValue.AsQueryable().Where(whereLambda).OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    }
                }
                else
                {
                    //缓存数据
                    IQueryable<T> _TList = null;
                    //返回数据
                    IQueryable<T> _ReturnTList = null;

                    //缓存cacheLambda条件为空 则按照原条件缓存
                    if (cacheLambda != null)
                    {
                        _TList = _dbContext.Set<T>().Where(cacheLambda);
                    }

                    //是否升序
                    if (isAsc)
                    {
                        _ReturnTList = CacheValue.AsQueryable().Where(whereLambda).OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    }
                    else
                    {
                        _ReturnTList = CacheValue.AsQueryable().Where(whereLambda).OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    }

                    if (_TList != null && _TList.Count() > 0)
                    {
                        foreach (T item in _TList)
                        {
                            var c = item.GetType();
                            //通过反射获取Item Id 作为单项的Key 便于修改内容
                            RedisHelper.HashSet<T>(cacheKey, item.GetType().GetProperty("Id").GetValue(item).ToString(), item);
                        }
                    }

                    return _ReturnTList;
                }
            }
            else {
                //是否升序
                if (isAsc)
                {
                    return _dbContext.Set<T>().Where(whereLambda).OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }
                else
                {
                    return _dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }
            }
        }
    }
}