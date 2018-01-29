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
        private DbContext _dbContext = new LocalDBContext();

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

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda,bool isCache,bool isFresh, bool isCacheAllModel, string CacheKey) {
            //isCache 读取缓存内容 true-读取 false-不读取
            if (isCache) { 
                //isFresh 刷新缓存内容 true-刷新 false-不刷新
                if (isFresh)
                {
                    RedisHelper.CommonRemove(CacheKey);
                }

                string CacheValue = RedisHelper.ItemGet<string>(CacheKey);
                if (CacheValue != null)
                {
                    return JsonHelper.DeserializeJsonToList<T>(CacheValue).AsQueryable();
                }
                else
                {
                    IQueryable<T> _TList = null;
                    //isCacheAllModel 缓存所有数据 true-缓存所有数据 false-按照条件缓存
                    if (isCacheAllModel)
                    {
                        _TList = _dbContext.Set<T>().Where(x => true);
                    }
                    else
                    {
                        _TList = _dbContext.Set<T>().Where(whereLambda);
                    }
                    if (_TList.Count() > 0)
                    {
                        CacheValue = JsonHelper.SerializeObject(_TList);
                        RedisHelper.ItemSet<string>(CacheKey, CacheValue);
                        RedisHelper.CommonSetExpire(CacheKey, ToolMethod.GetNow().AddDays(1));
                    }
                    return _TList;
                }
            }else { 
                return _dbContext.Set<T>().Where(whereLambda);
            }
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda) {
            //是否升序
            if (isAsc)
            {
                return _dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
    }
}