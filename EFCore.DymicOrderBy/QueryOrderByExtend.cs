using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;

namespace EFCore.DynamicOrderBy
{
    public static class QueryOrderByExtend
    {

        public static IQueryable<T> DynamicOrderBy<T>(this IQueryable<T> query, List<DynamicOrderByPredicate> dymicOrderByPredicates)
        {
            if (dymicOrderByPredicates.Count == 0)
            {
                throw new ArgumentException($"DynamicOrderBy：必须有一个排序条件");
            }
            var i = 0;

            foreach (var d in dymicOrderByPredicates)
            {
                ParameterExpression p = Expression.Parameter(typeof(T));
                Expression key = Expression.Property(p, d.FieldName);
                var propInfo = GetPropertyInfo(typeof(T), d.FieldName);
                var expr = GetOrderExpression(typeof(T), propInfo);


                if (!string.IsNullOrWhiteSpace(d.FieldName))
                {
                    if (i == 0)
                    {
                        if (d.IsDesc)
                        {
                            var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);
                            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
                            query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
                        }
                        else
                        {
                            var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
                            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
                            query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
                        }

                    }
                    else
                    {
                        if (d.IsDesc)
                        {
                            var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == "ThenByDescending" && m.GetParameters().Length == 2);
                            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
                            query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
                        }
                        else
                        {
                            var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == "ThenBy" && m.GetParameters().Length == 2);
                            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
                            query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
                        }

                    }
                }

                i++;

            }

            return query;
        }
        /// <summary>
        /// 获取model属性
        /// </summary>
        /// <param name="objType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static PropertyInfo GetPropertyInfo(Type objType, string name)
        {
            var properties = objType.GetProperties();
            var matchedProperty = properties.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (matchedProperty == null)
                throw new ArgumentException($"DynamicOrderBy：没找到{name}字段");

            return matchedProperty;
        }
        /// <summary>
        /// 生成表达式
        /// </summary>
        /// <param name="objType"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        private static LambdaExpression GetOrderExpression(Type objType, PropertyInfo pi)
        {
            var paramExpr = Expression.Parameter(objType);
            var propAccess = Expression.PropertyOrField(paramExpr, pi.Name);
            var expr = Expression.Lambda(propAccess, paramExpr);
            return expr;
        }
    }

    public class DynamicOrderByPredicate
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 是否倒序
        /// </summary>
        public bool IsDesc { get; set; }
    }
}