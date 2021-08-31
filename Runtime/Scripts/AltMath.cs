using System;
using UnityEngine;

namespace Alteracia.Logic
{
	public static class AltMath
	{
		public static float Remap(float value, float oldMin, float oldMax, float newMin, float newMax)
		{
			var normal = Mathf.InverseLerp(oldMin, oldMax, value);
			return Mathf.Lerp(newMin, newMax, normal);
		}

		public static float Remap01(float value, float oldMin, float oldMax)
		{
			float diff = oldMax - oldMin;
			return Mathf.Abs(diff) <= Single.Epsilon ? value : (value - oldMin) / diff;
		}
		
		public enum EasingType { Linear, InSine, OutSine, InOutCubic, Curve }

		public static float Ease(EasingType easingType, float value, AnimationCurve curve = null)
		{
			switch (easingType)
			{
				case EasingType.Linear:
					return value;
				case EasingType.InSine:
					return EaseInSine(value);
				case EasingType.OutSine:
					return EaseOutSine(value);
				case EasingType.InOutCubic:
					return EaseInOutCubic(value);
				case EasingType.Curve:
					return curve?.Evaluate(value) ?? value;
				default:
					throw new ArgumentOutOfRangeException(nameof(easingType), easingType, null);
			}
		}
		
		public static float EaseInSine(float value)
		{
			return 1 - Mathf.Cos((value * Mathf.PI) / 2);
		}

		public static float EaseOutSine(float value)
		{
			return Mathf.Sin((value *  Mathf.PI) / 2);
		}

		public static float EaseInOutCubic(float value)
		{
			return value < 0.5 ? 4 * value * value * value : 1 - Mathf.Pow(-2 * value + 2, 3) / 2;
		}
		
		public static bool IsPowerOfTwo(ulong x)
		{
			return (x != 0) && ((x & (x - 1)) == 0);
		}
	}
}