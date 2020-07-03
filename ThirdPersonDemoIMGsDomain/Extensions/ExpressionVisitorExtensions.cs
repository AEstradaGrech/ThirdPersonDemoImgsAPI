using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGsDomain.Extensions
{
    public static class ExpressionVisitorExtensions
    {
       public static Expression<Func<T, bool>> CombinePredicates<T>(this Expression<Func<T,bool>> expression,
           List<Expression<Func<T,bool>>> predicates, Func<Expression, Expression, BinaryExpression> logicalExpression)
           where T : Entity
       {
            if(predicates.Count > 0)
            {
                var firstPredicate = predicates[0];

                Expression body = firstPredicate.Body;

                for(int i = 0; i<predicates.Count; i++)
                {
                    body = logicalExpression(body, Expression.Invoke(predicates[i], firstPredicate.Parameters));
                }

                expression = Expression.Lambda<Func<T, bool>>(body, firstPredicate.Parameters);
            }

            return expression;
       }
    }
}
