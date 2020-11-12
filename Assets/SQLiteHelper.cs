using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;

public class SQLiteHelper : MonoBehaviour
{
    protected string dbName = "test2.db";
    private string filePath
    {
        get { return Application.streamingAssetsPath + "/" + dbName; }

    }
    protected DbAccess db;
    protected SqliteDataReader dataReader;

    protected void OpenDB()
    {
        db = new DbAccess("URI=file:" + filePath);
    }


    protected void CloseDB()
    {
        if (dataReader!=null)
        {
            dataReader.Close();
            dataReader = null;
        }
        
        db.CloseSqlConnection();
    }

    protected string GetStr(object o)
    {

        return "'" + o + "'";

    }


}
