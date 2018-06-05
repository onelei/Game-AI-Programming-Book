using UnityEngine;
using System.Collections.Generic;

namespace FootBallGame
{
	public class Res
	{
		public string file;
		public Object obj;

		public Res(string file,Object obj)
		{
			this.file = file;
			this.obj = obj;
		}
	}

	public class ResourceManager
	{
		public static List<Res> CacheList = new List<Res>();
		public static T Load<T> (string file) where T : Component
		{
			if (string.IsNullOrEmpty (file)) {
				Debug.LogError ("no file.");
				return null;
			}

			Object obj = GetCache (file);
			if(obj==null)
			{
				obj = Resources.Load (file);
				if (obj == null) {
					Debug.LogError ("Resources load file failure. file: " + file);
					return null;
				}
				CacheList.Add (new Res (file, obj));
			}

			GameObject go = GameObject.Instantiate (obj) as GameObject;
			if (go == null) {
				Debug.LogError ("Instantiate file failure. file: " + file);
				return null;
			}
			T compoment = go.GetComponent<T> ();
			if (compoment == null) {
				Debug.LogError ("GetComponent failure. file: " + file); 
				return null;
			}
			return compoment;
		}


		public static Object GetCache(string file)
		{ 
			for (int i = 0; i < CacheList.Count; i++) {
				if(CacheList[i].file == file)
				{
					return CacheList [i].obj;
				}
			}
			return null;
		}
	}

}

