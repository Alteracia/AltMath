using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Plugins.FRANTS.Workspace.Logic
{
	public static class TransformExtension
	{
		public static int CountChildren( this Transform t, bool activeOnly )
		{
			return activeOnly ? t.Cast<Transform>().Count(c => c.gameObject.activeSelf) : t.childCount;
		}

		public static int GetSiblingIndex(this Transform t, bool activeOnly) // TODO cant add inactive in runtime
		{
			var parent = t.parent;
			if (!parent) return 0;
			//Debug.Log(parent.Cast<Transform>().ToList().Count);
			return activeOnly ? t.GetSiblingIndex() : parent.Cast<Transform>().ToList().IndexOf(t);
		}

		public static IEnumerable<Transform> GetChildren( this Transform t, bool activeOnly )
		{
			return activeOnly ? (from Transform c in t where c.gameObject.activeSelf select c) : t.Cast<Transform>();
		}

		public static IEnumerable<GameObject> GetChildrenAsGameObjects( this Transform t, bool activeOnly )
		{
			return from Transform c in t where !activeOnly || c.gameObject.activeSelf select c.gameObject;
		}
	
		public static IEnumerable<T> GetComponentsInChildrenOnly<T>( this Transform t, bool activeOnly )
		{
			return from Transform c in t where (!activeOnly || c.gameObject.activeSelf) 
			                                   && c.TryGetComponent<T>(out var temp) select c.GetComponent<T>();
		}
	}
}

