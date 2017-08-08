using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
namespace WebMVC.Common
{
    public class RedisHelper
    {
        #region 连接信息  
        //从配置文件中获取连接字符串  
        private static string RedisPath = ConfigurationManager.AppSettings["RedisPath"].ToString();
        public static PooledRedisClientManager Prcm = CreateManager(new string[] { RedisPath }, new string[] { RedisPath });
        private static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            // 支持读写分离，均衡负载   
            return new PooledRedisClientManager(readWriteHosts, readOnlyHosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 5, // “写”链接池链接数   
                MaxReadPoolSize = 5, // “读”链接池链接数   
                AutoStart = true,
            });
        }
        #endregion

        #region Item  
        /// <summary>  
        /// 设置单体  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">单体key</param>  
        /// <param name="t">对象</param>  
        /// <returns>操作是否成功</returns>  
        public static bool ItemSet<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.Set<T>(key, t, new TimeSpan(1, 0, 0));
            }
        }
        /// <summary>  
        /// 获取单体  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">单体key</param>  
        /// <returns>对象</returns>  
        public static T ItemGet<T>(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.Get<T>(key);
            }
        }
        #endregion

        #region Hash  
        /// <summary>  
        /// 存储数据到Hash表  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">Hash key</param>  
        /// <param name="dataKey">dataKey</param>  
        public static void HashSet<T>(string key, string dataKey, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                redis.SetEntryInHash(key, dataKey, value);
            }
        }
        /// <summary>  
        /// 移除Hash中的某值  
        /// </summary>  
        /// <param name="key">Hash key</param>  
        /// <param name="dataKey">dataKey</param>  
        /// <returns>操作是否成功</returns>  
        public static bool HashRemove(string key, string dataKey)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.RemoveEntryFromHash(key, dataKey);
            }
        }
        /// <summary>  
        /// 从Hash表获取数据  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">Hash key</param>  
        /// <param name="dataKey">dataKey</param>  
        /// <returns>对象</returns>  
        public static T HashGet<T>(string key, string dataKey)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                string value = redis.GetValueFromHash(key, dataKey);
                return ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(value);
            }
        }
        /// <summary>  
        /// 获取整个Hash的数据  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">Hash key</param>  
        /// <returns>List集合</returns>  
        public static List<T> HashGetAll<T>(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var list = redis.GetHashValues(key);
                if (list != null && list.Count > 0)
                {
                    List<T> result = new List<T>();
                    foreach (var item in list)
                    {
                        var value = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(item);
                        result.Add(value);
                    }
                    return result;
                }
                return null;
            }
        }
        /// <summary>  
        /// 判断某个数据是否已经被缓存  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">Hash key</param>  
        /// <param name="dataKey">dateKey</param>  
        /// <returns>是否被缓存</returns>  
        public static bool HashExist<T>(string key, string dataKey)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.HashContainsEntry(key, dataKey);
            }
        }
        /// <summary>  
        /// 统计Hash集合的项数  
        /// </summary>  
        /// <param name="key">Hash key</param>  
        /// <returns>项数</returns>  
        public static long HashCount(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.GetHashCount(key);
            }
        }
        #endregion

        #region List  
        /// <summary>  
        /// 添加对象到List集合头部  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">List key</param>  
        /// <param name="t">对象</param>  
        public static void ListAdd<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var redisTypedClient = redis.As<T>();
                redisTypedClient.AddItemToList(redisTypedClient.Lists[key], t);
            }
        }
        /// <summary>  
        /// 从List集合中移除指定的对象  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">List key</param>  
        /// <param name="t">对象</param>  
        /// <returns>操作是否成功</returns>  
        public static bool ListRemove<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var redisTypedClient = redis.As<T>();
                return redisTypedClient.RemoveItemFromList(redisTypedClient.Lists[key], t) > 0;
            }
        }
        /// <summary>  
        /// 获取指定key中List集合的所有对象  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">List key</param>  
        /// <returns>List集合</returns>  
        public static List<T> ListGetList<T>(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var c = redis.As<T>();
                return c.Lists[key].GetRange(0, c.Lists[key].Count);
            }
        }
        /// <summary>  
        /// 分页查询List集合（分页从尾部开始计算）  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">List key</param>  
        /// <param name="pageIndex">页码</param>  
        /// <param name="pageSize">页条数</param>  
        /// <returns>List集合</returns>  
        public static List<T> ListGetList<T>(string key, int pageIndex, int pageSize)
        {
            int start = pageSize * (pageIndex - 1);
            return ListGetRange<T>(key, start, pageSize);
        }
        /// <summary>  
        /// 获取List集合中指定下标的对象集合（下标从尾部开始计算）  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">List key</param>  
        /// <param name="start">开始下标</param>  
        /// <param name="count">结束下标</param>  
        /// <returns>List集合</returns>  
        public static List<T> ListGetRange<T>(string key, int start, int count)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var c = redis.As<T>();
                return c.Lists[key].GetRange(start, start + count - 1);
            }
        }
        /// <summary>  
        /// 统计List集合的项数  
        /// </summary>  
        /// <param name="key">List key</param>  
        /// <returns>项数</returns>  
        public static long ListCount(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.GetListCount(key);
            }
        }
        /// <summary>  
        /// 将对象入队到List集合的尾部  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">List key</param>  
        /// <param name="t">对象</param>  
        public static void ListEnqueue<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var redisTypedClient = redis.As<T>();
                redisTypedClient.EnqueueItemOnList(redisTypedClient.Lists[key], t);
            }
        }
        /// <summary>  
        /// 将List集合头部的对象出队  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">List key</param>  
        /// <returns>尾部对象</returns>  
        public static T ListDequeue<T>(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var redisTypedClient = redis.As<T>();
                return redisTypedClient.DequeueItemFromList(redisTypedClient.Lists[key]);
            }
        }
        #endregion

        #region Set  
        /// <summary>  
        /// 添加对象到Set中  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">Set key</param>  
        /// <param name="t">对象</param>  
        public static void SetAdd<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var redisTypedClient = redis.As<T>();
                redisTypedClient.Sets[key].Add(t);
            }
        }
        /// <summary>  
        /// 移除Set中的指定对象  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">Set key</param>  
        /// <param name="t">对象</param>  
        /// <returns>操作是否成功</returns>  
        public static bool SetRemove<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var redisTypedClient = redis.As<T>();
                return redisTypedClient.Sets[key].Remove(t);
            }
        }
        /// <summary>  
        /// 获取Set中所有对象  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">Set key</param>  
        /// <returns>List集合</returns>  
        public static List<T> SetGetAll<T>(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var redisTypedClient = redis.As<T>();
                var list = redisTypedClient.Sets[key].GetAll();
                if (list != null && list.Count > 0)
                {
                    List<T> result = new List<T>();
                    foreach (T item in list)
                    {
                        result.Add(item);
                    }
                    return result;
                }
            }
            return null;
        }
        /// <summary>  
        /// 判断Set中的指定对象是否存在  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">Set key</param>  
        /// <param name="t">对象</param>  
        /// <returns>是否存在</returns>  
        public static bool SetContains<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var redisTypedClient = redis.As<T>();
                return redisTypedClient.Sets[key].Contains(t);
            }
        }
        /// <summary>  
        /// 获取Set的个数  
        /// </summary>  
        /// <param name="key">Set key</param>  
        /// <returns>个数</returns>  
        public static long SetCount(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.GetSetCount(key);
            }
        }
        #endregion

        #region SortedSet  
        /// <summary>  
        ///  添加数据到SortedSet  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">SortedSet key</param>  
        /// <param name="t">对象</param>  
        /// <returns>操作是否成功</returns>  
        public static bool SortedSetAdd<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                return redis.AddItemToSortedSet(key, value);
            }
        }
        /// <summary>  
        ///  添加数据到SortedSet  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">SortedSet key</param>  
        /// <param name="t">对象</param>  
        /// <param name="score">score：排序值。优先按照score从小->大排序，否则按值小到大排序</param>  
        /// <returns>操作是否成功</returns>  
        public static bool SortedSetAdd<T>(string key, T t, double score)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                return redis.AddItemToSortedSet(key, value, score);
            }
        }
        /// <summary>  
        /// 移除数据从SortedSet  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">SortedSet key</param>  
        /// <param name="t">对象</param>  
        /// <returns>操作是否成功</returns>  
        public static bool SortedSetRemove<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                string value = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                return redis.RemoveItemFromSortedSet(key, value);
            }
        }
        /// <summary>  
        /// 移除SortedSet中指定下标的项  
        /// </summary>  
        /// <param name="key">SortedSet key</param>  
        /// <param name="minRank">开始下标</param>  
        /// <param name="maxRank">结束下标</param>  
        /// <returns>移除的条数</returns>  
        public static long SortedSetRemove(string key, int minRank, int maxRank)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.RemoveRangeFromSortedSet(key, minRank, maxRank);
            }
        }
        /// <summary>  
        /// 获取SortedSet的分页数据  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">SortedSet key</param>  
        /// <param name="pageIndex">页码</param>  
        /// <param name="pageSize">页条数</param>  
        /// <returns>List集合</returns>  
        public static List<T> SortedSetGetList<T>(string key, int pageIndex, int pageSize)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var list = redis.GetRangeFromSortedSet(key, (pageIndex - 1) * pageSize, pageIndex * pageSize - 1);
                if (list != null && list.Count > 0)
                {
                    List<T> result = new List<T>();
                    foreach (var item in list)
                    {
                        var data = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(item);
                        result.Add(data);
                    }
                    return result;
                }
            }
            return null;
        }
        /// <summary>  
        /// 获取SortedSet的全部数据  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">SortedSet key</param>  
        /// <returns>List集合</returns>  
        public static List<T> SortedSetGetListALL<T>(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var list = redis.GetRangeFromSortedSet(key, 0, 9999999);
                if (list != null && list.Count > 0)
                {
                    List<T> result = new List<T>();
                    foreach (var item in list)
                    {
                        var data = ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(item);
                        result.Add(data);
                    }
                    return result;
                }
            }
            return null;
        }
        /// <summary>  
        /// 获取SortedSet的个数  
        /// </summary>  
        /// <param name="key">SortedSet key</param>  
        /// <returns>个数</returns>  
        public static long SortedSetCount(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.GetSortedSetCount(key);
            }
        }
        /// <summary>  
        /// 获取指定对象的score值  
        /// </summary>  
        /// <typeparam name="T">类型</typeparam>  
        /// <param name="key">SortedSet key</param>  
        /// <param name="t">对象</param>  
        /// <returns>score值</returns>  
        public static double SortedSetGetItemScore<T>(string key, T t)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                var data = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                return redis.GetItemScoreInSortedSet(key, data);
            }
            return 0;
        }
        #endregion

        #region Common  
        /// <summary>  
        /// 设置缓存过期  
        /// </summary>  
        /// <param name="key">key</param>  
        /// <param name="datetime">过期时间</param>  
        /// <returns>操作是否成功</returns>  
        public static bool CommonSetExpire(string key, DateTime datetime)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.ExpireEntryAt(key, datetime);
            }
        }
        /// <summary>  
        /// 判断某个key是否已经被缓存  
        /// </summary>  
        /// <param name="key">key</param>  
        /// <returns>是否被缓存</returns>  
        public static bool CommonKeyExist(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.ContainsKey(key);
            }
        }
        /// <summary>  
        /// 移除指定key的数据  
        /// </summary>  
        /// <param name="key">key</param>  
        /// <returns>操作是否成功</returns>  
        public static bool CommonRemove(string key)
        {
            using (IRedisClient redis = Prcm.GetClient())
            {
                return redis.Remove(key);
            }
        }
        #endregion
    }
}
}