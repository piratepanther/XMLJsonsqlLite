using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.IO;

public class TestDB : MonoBehaviour {

	/// <summary>	/// 数据库	/// </summary>
	private DbAccess db;
	/// <summary>	/// 数据库路径	/// </summary>
	private string appDBPath;

	private string name;
	private int age;
	private float exp;

	/// <summary>	/// 创建/打开数据库	/// </summary>
	private void CreateDataBase()
	{
		#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		appDBPath = Application.streamingAssetsPath + "/Test.db";
		#elif UNITY_ANDROID || UNITY_IPHONE
		appDBPath = Application.persistentDataPath + "/Test.db";
		if(!File.Exists(appDBPath)){
			StartCoroutine(CopyDataBase());
		}
		#endif
		db = new DbAccess ("URI=file:" + appDBPath);
	}

	/// <summary>	/// 拷贝数据库	/// </summary>
	/// <returns>数据库.</returns>
	private IEnumerator CopyDataBase()
	{
		WWW loadDB = new WWW (Application.streamingAssetsPath + "/Test.db");
		yield return loadDB;
		File.WriteAllBytes (appDBPath,loadDB.bytes);
	}

	/// <summary>	/// 创建表	/// </summary>
	private void CreateTable()
	{
		CreateDataBase ();
		db.CreateTable ("Role",new string[] {"id","name","age","lv","exp"},
			new string[] {"int","text","int","int","float"});
		db.CloseSqlConnection ();
	}

	/// <summary>	/// 插入数据	/// </summary>
	private void InsertData()
	{
		CreateDataBase ();
		db.InsertInto ("Role",new string[] {"1","'张三'","18","10","100"});
		db.InsertInto ("Role",new string[] {"2","'李四'","20","2","2.2"});
		db.InsertInto ("Role",new string[] {"3","'老王'","19","3","3.3"});
		db.CloseSqlConnection ();
	}

	/// <summary>	/// 更新数据	/// </summary>
	private void UpdateData()
	{
		CreateDataBase ();
		db.UpdateInto ("Role",new string[] {"name","lv","exp"},
			new string[] {"'test'","1","1.1"},"id","1");
		db.CloseSqlConnection ();
	}

	/// <summary>	/// 删除数据	/// </summary>
	private void DeleteData()
	{
		CreateDataBase ();
		db.Delete ("Role",new string[] {"id","id"},new string[] {"1","3"});
		db.CloseSqlConnection ();
	}

	/// <summary>	/// 删除表中全部数据	/// </summary>
	private void DeleteAllData()
	{
		CreateDataBase ();
		db.DeleteContents ("Role");
		db.CloseSqlConnection ();
	}

	/// <summary>	/// 查询数据	/// </summary>
	private void FindData()
	{
		CreateDataBase ();
		SqliteDataReader sqReader = db.SelectWhere ("Role",new string[] {
			"name","age","exp"},new string[] {"id"},new string[] {"="},
			new string[] {"1"});
		sqReader.Read ();
		name = sqReader.GetString (sqReader.GetOrdinal("name"));
		age = sqReader.GetInt32 (sqReader.GetOrdinal("age"));
		exp = sqReader.GetFloat (sqReader.GetOrdinal("exp"));
		db.CloseSqlConnection ();
	}

	private void SelectData()
	{
		CreateDataBase ();
//		SqliteDataReader sqReader = db.ReadFullTable ("Role");
//		SqliteDataReader sqReader = db.SelectOrderASC ("Role","age");
		SqliteDataReader sqReader = db.SelectOrderDESC ("Role","age");
		while(sqReader.Read())
		{
			Debug.Log (sqReader.GetInt32(sqReader.GetOrdinal("id")) + " " +
				sqReader.GetString(sqReader.GetOrdinal("name")) + " " + 
				sqReader.GetInt32(sqReader.GetOrdinal("age")) + " " + 
				sqReader.GetInt32(sqReader.GetOrdinal("lv")) + " " + 
				sqReader.GetFloat(sqReader.GetOrdinal("exp")));
		}
		db.CloseSqlConnection ();
	}

	private void OnGUI()
	{
		if (GUILayout.Button ("创建表"))
			CreateTable ();
		if (GUILayout.Button ("插入数据"))
			InsertData ();
		if (GUILayout.Button ("更新数据"))
			UpdateData ();
		if (GUILayout.Button ("删除数据"))
			DeleteData ();
		if (GUILayout.Button ("删除表中全部数据"))
			DeleteAllData ();
		if (GUILayout.Button ("读取数据"))
			FindData ();
		if (GUILayout.Button ("多种读取数据"))
			SelectData ();
		#if HTC
		if (GUILayout.Button ("充值"))
			FindData ();
		#endif
		#if OC
		if (GUILayout.Button ("充值"))
			SelectData ();
		#endif
		GUILayout.Label ("name:" + name);
		GUILayout.Label ("age:" + age);
		GUILayout.Label ("exp:" + exp);
	
	}
}
