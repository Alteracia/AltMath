using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Alteracia.Logic
{
	public static class ComponentExtension
	{
		public static IEnumerable<MethodInfo> GetDeclaredMethodList( this Component component)
		{
			return component.GetType().GetMethods();
		}
	
		public static MethodInfo GetDeclaredMethod( this Component component, string method)
		{
			return component.GetType().GetMethod(method);
		}
		
		public static PropertyInfo GetProperty( this Component component, string property)
		{
			PropertyInfo prop = component.GetType().GetProperty(property);
			return prop;
		}
	}
}