﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace BDAuscultation.SQLite
{
   public  class SqliteHelper
    {
       public string ConnString { get; set; }
       public SqliteHelper(string ConnString="")
       {
           this.ConnString=  ConnString;
       }
       public DataTable ExecuteDatatable(string sqlText, params object[] dictParams)
       {
           DataTable dt = new DataTable();
           using (SQLiteConnection conn = new SQLiteConnection(ConnString))
           {
               conn.Open();
               SQLiteCommand command = new SQLiteCommand(conn);
               var listPar = new List<string>();
               for (int i = 0; i < dictParams.Length; i++)
               {
                   object value = dictParams[i];
                   if (null==dictParams[i])
                       value = DBNull.Value;
                   string strPar = "@SqlParameter" + i;
                   listPar.Add(strPar);
                   var param = new SQLiteParameter(strPar, value);
                   command.Parameters.Add(param);
               }
               command.CommandText = string.Format(sqlText, listPar.ToArray());
               SQLiteDataAdapter sqliteAda = new SQLiteDataAdapter(command);
               sqliteAda.Fill(dt);
               conn.Close();
           }
           return dt;
       }

       /// <summary>
       /// 执行非查询sql
       /// </summary>
       /// <param name="sqlText"></param>
       /// <param name="dictParams"></param>
       /// <returns></returns>
       public int ExecuteNonQuery(string sqlText, params object[] dictParams)
       {
               using (SQLiteConnection conn = new SQLiteConnection(ConnString))
               {
                   conn.Open();
                   var command = new SQLiteCommand( conn);
                   var listPar=new List<string>();
                   for (int i = 0; i < dictParams.Length; i++)
                   {
                       object value=dictParams[i];
                       if (null==dictParams[i])
                           value = DBNull.Value;
                       string strPar = "@SqlParameter" + i;
                       listPar.Add(strPar);
                       var param = new SQLiteParameter(strPar, value );
                       command.Parameters.Add(param);
                   }
                   command.CommandText = string.Format(sqlText, listPar.ToArray());
                   var count = command.ExecuteNonQuery();
                   conn.Close();
                   return count;
               }
               return 0;
       }
       public object ExecuteScalar(string sqlText, params object[] dictParams)
       {
           using (SQLiteConnection conn = new SQLiteConnection(ConnString))
           {
               conn.Open();
               var command = new SQLiteCommand(conn);
               var listPar = new List<string>();
               for (int i = 0; i < dictParams.Length; i++)
               {
                   object value = dictParams[i];
                   if (null==dictParams[i])
                       value = DBNull.Value;
                   string strPar = "@SqlParameter" + i;
                   listPar.Add(strPar);
                   var param = new SQLiteParameter(strPar, value);
                   command.Parameters.Add(param);
               }
               command.CommandText = string.Format(sqlText, listPar.ToArray());
                   var r = command.ExecuteScalar();
               conn.Close();
               return r;
           }
           return 0;
       }
   }
}
