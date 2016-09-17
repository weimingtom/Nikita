﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Nikita.Base.Define;
using Nikita.DataAccess.Expression2Sql.Mapper;
using Nikita.DataAccess4DBHelper;

namespace Nikita.DataAccess.Expression2Sql
{
    public class ExpressionToSql<T>
    {
        private string _mainTableName = typeof(T).Name;
        private SqlBuilder _sqlBuilder;

        public ExpressionToSql(IDbSqlParser dbSqlParser)
        {
            this._sqlBuilder = new SqlBuilder(dbSqlParser);
        }

        //public ExpressionToSql(DbContext dbContext)
        //{
        //    IDbSqlParser dbSqlParser = null;
        //    switch (dbContext.SqlType)
        //    {
        //        case SqlType.SqlServer:
        //            dbSqlParser = new SQLServerSqlParser();
        //            break;
        //        case SqlType.Oracle:
        //            dbSqlParser = new OracleSqlParser();
        //            break;
        //        case SqlType.MySql:
        //            dbSqlParser = new MySQLSqlParser();
        //            break;
        //        case SqlType.SQLite:
        //            dbSqlParser = new SQLiteSqlParser();
        //            break;
        //    }
        //    this._sqlBuilder = new SqlBuilder(dbSqlParser);
        //    dbHelper = DbHelper.GetDbHelper(dbContext.SqlType, dbContext.ConnectionString);
        //}

        public Dictionary<string, object> DbParams
        {
            get
            {
                return this._sqlBuilder.DbParams;
            }
        }

        public string Sql
        {
            get
            {
                return this._sqlBuilder.Sql + ";";
            }
        }

        public ExpressionToSql<T> Avg(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            this.Clear();
            Expression2SqlProvider.Avg(expression.Body, this._sqlBuilder);
            return this;
        }

        public void Clear()
        {
            this._sqlBuilder.Clear();
        }

        public ExpressionToSql<T> Count(Expression<Func<T, object>> expression = null)
        {
            this.Clear();
            if (expression == null)
            {
                string tableName = typeof(T).Name;

                this._sqlBuilder.SetTableAlias(tableName);
                string tableAlias = this._sqlBuilder.GetTableAlias(tableName);

                if (!string.IsNullOrWhiteSpace(tableAlias))
                {
                    tableName += " " + tableAlias;
                }
                this._sqlBuilder.AppendFormat("select count(*) from {0}", tableName);
            }
            else
            {
                Expression2SqlProvider.Count(expression.Body, this._sqlBuilder);
            }

            return this;
        }

        public ExpressionToSql<T> Delete()
        {
            this.Clear();
            this._sqlBuilder.IsSingleTable = true;
            this._sqlBuilder.SetTableAlias(this._mainTableName);
            this._sqlBuilder.AppendFormat("delete {0}", this._mainTableName);
            return this;
        }

        public ExpressionToSql<T> FullJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "full ");
        }

        public ExpressionToSql<T> FullJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "full ");
        }

        public ExpressionToSql<T> GroupBy(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            this._sqlBuilder += "\ngroup by ";
            Expression2SqlProvider.GroupBy(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> InnerJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "inner ");
        }

        public ExpressionToSql<T> InnerJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "inner ");
        }

        public ExpressionToSql<T> Insert(Expression<Func<object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            this.Clear();
            this._sqlBuilder.IsSingleTable = true;
            this._sqlBuilder.AppendFormat("insert into {0}", this._mainTableName);
            Expression2SqlProvider.Insert(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Join<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression);
        }

        public ExpressionToSql<T> Join<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression);
        }

        public ExpressionToSql<T> LeftJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "left ");
        }

        public ExpressionToSql<T> LeftJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "left ");
        }

        public ExpressionToSql<T> Max(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            this.Clear();
            Expression2SqlProvider.Max(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Min(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            this.Clear();
            Expression2SqlProvider.Min(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> OrderBy(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            this._sqlBuilder += "\norder by ";
            Expression2SqlProvider.OrderBy(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> RightJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "right ");
        }

        public ExpressionToSql<T> RightJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "right ");
        }

        public ExpressionToSql<T> Select(Expression<Func<T, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2>(Expression<Func<T, T2, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2, T3>(Expression<Func<T, T2, T3, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Select<T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null)
        {
            return SelectParser(expression, expression == null ? null : expression.Body, typeof(T));
        }

        public ExpressionToSql<T> Sum(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            this.Clear();
            Expression2SqlProvider.Sum(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Update(Expression<Func<object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            this.Clear();
            this._sqlBuilder.IsSingleTable = true;
            this._sqlBuilder.AppendFormat("update {0} set ", this._mainTableName);
            Expression2SqlProvider.Update(expression.Body, this._sqlBuilder);
            return this;
        }

        public ExpressionToSql<T> Where(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            if (expression.Body != null && expression.Body.NodeType == ExpressionType.Constant)
            {
                throw new ArgumentException("Cannot be parse expression", "expression");
            }

            this._sqlBuilder += "\nwhere";
            Expression2SqlProvider.Where(expression.Body, this._sqlBuilder);
            return this;
        }

        private ExpressionToSql<T> JoinParser<T2>(Expression<Func<T, T2, bool>> expression, string leftOrRightJoin = "")
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            string joinTableName = typeof(T2).Name;
            this._sqlBuilder.SetTableAlias(joinTableName);
            string strAlias = this._sqlBuilder.QueueEnglishWords.Dequeue();
            this._sqlBuilder.JoinTables.Add(strAlias, joinTableName);
            if (_sqlBuilder.JoinTables.Count(t => t.Value.Equals(joinTableName)) > 1)
            {
                this._sqlBuilder.AppendFormat("\n{0}join {1} on", leftOrRightJoin, joinTableName + " " + strAlias);
            }
            else
            {
                this._sqlBuilder.AppendFormat("\n{0}join {1} on", leftOrRightJoin, joinTableName + " " + this._sqlBuilder.GetTableAlias(joinTableName));
            }
            Expression2SqlProvider.Join(expression.Body, this._sqlBuilder);
            return this;
        }

        private ExpressionToSql<T> JoinParser2<T2, T3>(Expression<Func<T2, T3, bool>> expression, string leftOrRightJoin = "")
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Value cannot be null");
            }

            string joinTableName = typeof(T3).Name;
            this._sqlBuilder.SetTableAlias(joinTableName);
            string strAlias = this._sqlBuilder.QueueEnglishWords.Dequeue();
            this._sqlBuilder.JoinTables.Add(strAlias, joinTableName);
            if (_sqlBuilder.JoinTables.Count(t => t.Value.Equals(joinTableName)) > 1)
            {
                this._sqlBuilder.AppendFormat("\n{0}join {1} on", leftOrRightJoin, joinTableName + " " + strAlias);
            }
            else
            {
                this._sqlBuilder.AppendFormat("\n{0}join {1} on", leftOrRightJoin,
                    joinTableName + " " + this._sqlBuilder.GetTableAlias(joinTableName));
            }
            Expression2SqlProvider.Join(expression.Body, this._sqlBuilder);
            return this;
        }

        private ExpressionToSql<T> SelectParser(Expression expression, Expression expressionBody, params Type[] ary)
        {
            this.Clear();
            this._sqlBuilder.IsSingleTable = false;

            if (expressionBody != null && expressionBody.Type == typeof(T))
            {
                throw new ArgumentException("cannot be parse expression", "expression");
            }

            foreach (var item in ary)
            {
                string tableName = item.Name;
                this._sqlBuilder.SetTableAlias(tableName);
            }

            string sql = "select {0}\nfrom " + this._mainTableName + " " + this._sqlBuilder.GetTableAlias(this._mainTableName);

            if (expression == null)
            {
                this._sqlBuilder.AppendFormat(sql, "*");
            }
            else
            {
                Expression2SqlProvider.Select(expressionBody, this._sqlBuilder);
                this._sqlBuilder.AppendFormat(sql, this._sqlBuilder.SelectFieldsStr);
            }

            return this;
        } 
    }
}