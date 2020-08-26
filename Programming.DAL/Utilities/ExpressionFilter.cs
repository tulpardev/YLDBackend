using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Programming.DAL.Utilities
{
    [JsonObject]
    public class FilteredQuery
    {
        public string Category { get; set; }
        public string Value { get; set; }
    }
    public class ExpressionFilter
    {

        public  Func<T, bool> GetDynamicQueryWithExpresionTrees<T>(string query)
        {
            if (string.IsNullOrEmpty(query))
                return null;
            Expression<Func<T, bool>> predicate = (t) => true;

            List<FilteredQuery> filterList = JsonConvert.DeserializeObject<List<FilteredQuery>>(query);
            foreach (var item in filterList)
            {
                Expression left = null;
                Expression right = null;
                var param = Expression.Parameter(typeof(T));
                var type = typeof(T);
                var property = type.GetProperties().FirstOrDefault(q => q.Name == item.Category);
                if (property == null)
                {
                    throw new Exception();
                }
                left = Expression.Property(param, item.Category);
                right = Expression.Convert(ToExprConstant(property, item.Value), property.PropertyType);

                var returnExp = Expression.Lambda<Func<T, bool>>(Expression.Equal(left, right), param);

                // var final = Expression.Lambda<Func<T, bool>>(body: body, parameters: param);
                // predicate = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(predicate, final));

                predicate = And<T>(returnExp, predicate);
            }
            return predicate.Compile();
        }
        public static Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        private static UnaryExpression GetValueExpression(string propertyName, string val, ParameterExpression param)
        {
            var member = Expression.Property(param, propertyName);
            var propertyType = ((PropertyInfo)member.Member).PropertyType;
            var converter = TypeDescriptor.GetConverter(propertyType);

            if (!converter.CanConvertFrom(typeof(string)))
                throw new NotSupportedException();

            var propertyValue = converter.ConvertFromInvariantString(val);
            var constant = Expression.Constant(propertyValue);
            return Expression.Convert(constant, propertyType);
        }

        public static Expression ToExprConstant(PropertyInfo prop, string value)
        {
            object val = null;
            if (string.IsNullOrEmpty(value))
                return Expression.Constant(null);
            else
            {
                var fullName = prop.PropertyType.FullName;
                if (prop.PropertyType.FullName.Contains("System.DateTime") && prop.PropertyType.FullName.Contains("System.Nullable"))
                    fullName = "System.DateTime";
                else if (prop.PropertyType.FullName.Contains("System.Guid") && prop.PropertyType.FullName.Contains("System.Nullable"))
                    fullName = "System.Guid";
                else if (
                    (!prop.PropertyType.IsGenericType && prop.PropertyType.IsEnum)
                    || (prop.PropertyType.IsGenericType && Nullable.GetUnderlyingType(prop.PropertyType).BaseType == typeof(Enum))
                    )
                    fullName = "System.Enum";


                switch (fullName)
                {
                    case "System.Guid":
                        val = Guid.Parse(value);
                        break;
                    case "System.DateTime":
                        if (DateTime.TryParseExact(value, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                            val = result;
                        else
                            val = DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        break;
                    case "System.Enum":
                        val = Int32.Parse(value);
                        break;
                    default:
                        Type t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        val = Convert.ChangeType(value, Type.GetType(t.FullName));
                        break;
                }
                return Expression.Constant(val);
            }

        }
    }
}
