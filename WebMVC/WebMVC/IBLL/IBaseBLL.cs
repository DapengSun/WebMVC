using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebMVC.IBLL
{
    public interface IBaseBLL<T> where T : class , new()
    {
        bool Add(T t);
        bool Delete(T t);
        bool Update(T t);

        /// <summary>
        /// 根据条件 获取T类泛型数据
        /// </summary>
        /// <param name="whereLambda">查询Lambda表达式</param>
        /// <param name="isReadCache">是否读取缓存     默认：false</param>
        /// <param name="cacheLambda">缓存Lambda表达式 默认：空</param>
        /// <param name="cacheKey">缓存Key值           默认：空</param>
        /// <returns></returns>
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda, bool isReadCache = false,  Expression<Func<T, bool>> cacheLambda = null, string cacheKey = "");

        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);
    }
}