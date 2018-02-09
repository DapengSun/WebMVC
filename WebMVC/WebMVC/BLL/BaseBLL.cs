using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebMVC.IBLL;
using WebMVC.IDAL;

namespace WebMVC.BLL
{
    public abstract class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        public IBaseDAL<T> _Dal { get; set; }

        public BaseBLL() {
            SetDAL();
        }

        public abstract void SetDAL();

        public bool Add(T t)
        {
            return _Dal.Add(t);
        }

        public bool Delete(T t)
        {
            return _Dal.Delete(t);
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda, bool isReadCache = false, Expression<Func<T, bool>> cacheLambda = null, string cacheKey = "")
        {
            return _Dal.GetModels(whereLambda, isReadCache,cacheLambda,cacheKey);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            return _Dal.GetModelsByPage<type>(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }

        public bool Update(T t)
        {
            return _Dal.Update(t);
        }
    }
}