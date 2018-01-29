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
        /// <param name="whereLambda">Lambda表达式</param>
        /// <param name="isCache">是否读取缓存     默认：false</param>
        /// <param name="isFresh">是否刷新缓存内容 默认：false</param>
        /// <param name="isCacheAllModel">是否缓存所有数据 默认：false</param>
        /// <param name="CacheKey">缓存Key值       默认：空</param>
        /// <returns></returns>
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda,bool isCache = false, bool isFresh = false, bool isCacheAllModel = false, string CacheKey="");

        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);
    }
}