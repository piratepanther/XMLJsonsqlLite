using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;


public class SQLiteDemo : SQLiteHelper
{
    //创建
    private void CreatTable()
    {
        OpenDB();
        db.CreateTable("Role", 
            new string[] { "id", "name", "age", "lv", "exp" },             
            new string[] { "int", "test", "int", "int", "float" });
        CloseDB();
    }

    //增
    private void InsertData()
    {
        OpenDB();
        db.InsertInto("Role",
            new string[] { "1", GetStr("zhangsan"), "18", "12", "200" });
        db.InsertInto("Role",
            new string[] { "2", GetStr("lisi"), "22", "14", "600" });
        db.InsertInto("Role",
            new string[] { "3", GetStr("wangwu"), "43", "40", "800" });
        CloseDB();

    }


    //删
    private void DelData()
    {
        OpenDB();
        db.Delete("Role",
            new string[]{"id","lv"},
            new string[]{"1","40"});//或的关系
        //db.DeleteContents("Role");

        CloseDB();
    }


    //改
    private void UpdateData()
    {
        OpenDB();
        db.UpdateInto("Role",
            new string[] { "exp", "lv" },
            new string[] { "350", "16" },
            "id","1");//
        CloseDB();

    }

    //查

    private void SearchData()
    {
        OpenDB();
        //id=3 lv=40,find name

        dataReader = db.SelectWhere("Role",
            new string[] { "name","age" },
            new string[] { "id" ,"lv"},
            new string[] { "=", "=" },
            new string[] { "2", "14" }
            );//与的关系
        if (dataReader.HasRows)
        {
            dataReader.Read();
            print(dataReader.GetString(dataReader.GetOrdinal("name")));
            print(dataReader.GetInt32(dataReader.GetOrdinal("age")));
            //Console.WriteLine(dataReader.GetString(dataReader.GetOrdinal("name")));
            //Console.WriteLine(dataReader.GetInt32(dataReader.GetOrdinal("age")));

        }
        else
        {
            //Console.WriteLine("no data");
            print("no data");
        }

        CloseDB();
    }
    private void SelectData()
    {
        OpenDB();
        //dataReader = db.Select("Role","id","2");
        //dataReader = db.Select("Role", "id", ">","2");
        //dataReader = db.ReadFullTable("Role");
        //dataReader = db.SelectOrderASC("Role", "age");
        dataReader = db.SelectOrderDESC("Role", "lv");

        if(dataReader.HasRows)
        {
            while (dataReader.Read())
            {
                string s = "";
                s += dataReader.GetInt32(dataReader.GetOrdinal("id"));
                s += dataReader.GetString(dataReader.GetOrdinal("name"));
                s += dataReader.GetInt32(dataReader.GetOrdinal("age"));
                s += dataReader.GetInt32(dataReader.GetOrdinal("lv"));
                s += dataReader.GetFloat(dataReader.GetOrdinal("exp"));
                print(s);
            }
        }
        CloseDB();



    }


    private void OnGUI()
    {
        if (GUILayout.Button("CreatTable"))
        {
            CreatTable();
        }
        if (GUILayout.Button("InsertData"))
        {
            InsertData();
        }
        if (GUILayout.Button("DelData"))
        {
            DelData();
        }
        if (GUILayout.Button("UpdateData"))
        {
            UpdateData();
        }
        if (GUILayout.Button("SearchData"))
        {
            SearchData();
        }
        if (GUILayout.Button("SelectData"))
        {
            SelectData();
        }

    }




}
