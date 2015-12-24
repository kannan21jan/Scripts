using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public static class Extensions
{
	public static T ToClass<T>(this string result)
	{
		return JsonConvert.DeserializeObject<T>(result);
	}

	public static Sprite ToSprite(this Texture2D texture)
	{
		Rect rect = new Rect (0,0,texture.width,texture.height);
		return Sprite.Create(texture,rect,new Vector2(0.34f,0.34f));
	}

	public static string ToJson(this object c)
	{
		return JsonConvert.SerializeObject(c);
	}

	public static int ToInt(this string str)
	{
		return System.Int32.Parse (str);
	}

	public static string TrimLooseEnds(this string c)
	{
		string result = c;
		result = result.Remove (result.Length-2,2);
		result = result.Remove (0,1);
		return result;
	}
}
