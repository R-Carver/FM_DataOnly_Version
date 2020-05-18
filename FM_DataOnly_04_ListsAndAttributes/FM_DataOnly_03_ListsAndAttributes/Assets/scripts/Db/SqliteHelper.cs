using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;

public class SqliteHelper
{
    private const string database_name = "PlayerListTest.db";

    public string db_connection_string;
    public IDbConnection db_connection;

    public SqliteHelper(string dataPath)
    {
        db_connection_string = "URI=file:" + dataPath + "/Db/" + database_name;
        db_connection = new SqliteConnection(db_connection_string);
        db_connection.Open();

        Debug.Log("Db Connection");
    }

    //Helper functions
    public IDbCommand GetDbCommand()
    {
        return db_connection.CreateCommand();
    }

    public IDataReader getNumOfRows(string table_name)
    {
        IDbCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText =
            "SELECT COALESCE(MAX(id)+1, 0) FROM " + table_name;
        IDataReader reader = dbcmd.ExecuteReader();
        return reader;
    }

    public void close()
    {
        db_connection.Close();
    }

    public string GetInsertStringForObject(object obj, string tableName)
    {
        string outString = "";

        List<FieldInfo> fields = getObjectDbFields(obj);

        string insertString = "INSERT INTO " + tableName + "(";
        string valueString = ") VALUES (";

        foreach(FieldInfo field in fields)
        {
            insertString += field.Name + ",";

            if(field.FieldType == typeof(string))
            {
                valueString += "\"" + field.GetValue(obj) + "\",";
            }else
            {
                valueString += field.GetValue(obj) + ",";
            }
        }

        //remove last ,
        insertString = insertString.Substring(0, insertString.Length-1);
        valueString = valueString.Substring(0, valueString.Length-1);
        outString = insertString + valueString;

        outString += ")";

        return outString;
    }

    private List<FieldInfo> getObjectDbFields(object obj)
    {   
        FieldInfo[] fields = obj.GetType().GetFields();

        List<FieldInfo> outList = new List<FieldInfo>();

        foreach(FieldInfo field in fields)
        {
            FmDbField dbAnnotation = Attribute.GetCustomAttribute(field, typeof(FmDbField)) as FmDbField;

            if(dbAnnotation != null)
            {
                outList.Add(field);
            }
        }
        return outList;
    }
}