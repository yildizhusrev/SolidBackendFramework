using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TmTFramework.Core.DataAccess.Dapper
{
    public static class ExpressionExtensions
    {
        public static string ToMSSqlString(this Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Add:
                    var add = expression as BinaryExpression;
                    return add.Left.ToMSSqlString() + " + " + add.Right.ToMSSqlString();
                case ExpressionType.Constant:
                    var constant = expression as ConstantExpression;
                    if (constant.Type == typeof(string))
                        return "N'" + constant.Value.ToString().Replace("'", "''") + "'";
                    return constant.Value.ToString();
                case ExpressionType.Equal:
                    var equal = expression as BinaryExpression;
                    return equal.Left.ToMSSqlString() + " = " +
                           equal.Right.ToMSSqlString();
                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    var and = expression as BinaryExpression;
                    return $"( {and.Left.ToMSSqlString()}  AND  {and.Right.ToMSSqlString()} )" ;
                case ExpressionType.OrElse:
                case ExpressionType.Or:
                    var strOr = expression as BinaryExpression;
                    return $"( {strOr.Left.ToMSSqlString()}   OR   {strOr.Right.ToMSSqlString()} )";
                case ExpressionType.Lambda:
                    var l = expression as LambdaExpression;
                    return l.Body.ToMSSqlString();
                case ExpressionType.MemberAccess:
                    var memberaccess = expression as MemberExpression;
                    // todo: if column aliases are used, look up ColumnAttribute.Name
                    return "[" + memberaccess.Member.Name + "]";
            }

            throw new NotImplementedException(
              expression.GetType().ToString() + " " +
              expression.NodeType.ToString());
        }
    }
}
