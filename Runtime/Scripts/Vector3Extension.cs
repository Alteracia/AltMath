using UnityEngine;

namespace Plugins.FRANTS.Workspace.Logic
{
	public static class Vector3Extension
	{
		public static Vector3 EulerClamp(this Vector3 eulerAngles)
		{
			for (int i = 0; i < 3; i++)
			{
				if (eulerAngles[i] > 180f) eulerAngles[i] = -(360 - eulerAngles[i]);
				else if (eulerAngles[i] < -180f) eulerAngles[i] = 360 + eulerAngles[i];
			}
			return eulerAngles;
		}


		public static Vector3 Multiply(this Vector3 a, Vector3 b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public static Vector3 Clamp(this Vector3 vector, Vector3 limits)
		{
			for (int i = 0; i < 3; i++)
			{
				if (vector[i] > limits[i]) vector[i] = limits[i];
				else if (vector[i] < -limits[i]) vector[i] = -limits[i];
			}
			return vector;
		}

		public static Vector3 Euler(Vector3 forward, Vector3 up)
		{
			float x = Mathf.Atan2(forward.y, forward.z) * Mathf.Rad2Deg;
			float y = Mathf.Atan2(forward.x, forward.z) * Mathf.Rad2Deg;
			float z = Mathf.Atan2(up.x, up.y) * Mathf.Rad2Deg;
			return new Vector3(x, y, z);
		}
	}
}
