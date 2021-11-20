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
		
        public enum EasingType
        {
            Linear,
            Curve,
            Spring,
            InQuad,
            OutQuad,
            InOutQuad,
            InCubic,
            OutCubic,
            InOutCubic,
            InQuart,
            OutQuart,
            InOutQuart,
            InQuint,
            OutQuint,
            InOutQuint,
            InSine,
            OutSine,
            InOutSine,
            InExpo,
            OutExpo,
            InOutExpo,
            InCirc,
            OutCirc,
            InOutCirc,
            InBounce,
            OutBounce,
            InOutBounce,
            InBack,
            OutBack,
            InOutBack,
            InElastic,
            OutElastic,
            InOutElastic
        }
        
		public static float Ease(EasingType easingType, float value, AnimationCurve curve = null)
		{
			switch (easingType)
			{
				case EasingType.Linear:
					return value;
                case EasingType.Curve:
                    return curve?.Evaluate(value) ?? value;
				case EasingType.InSine:
					return EaseInSine(value);
				case EasingType.OutSine:
					return EaseOutSine(value);
				case EasingType.InOutCubic:
					return EaseInOutCubic(value);
                case EasingType.Spring:
                    return Spring(value);
                case EasingType.InQuad:
                    return EaseInQuad(value);
                case EasingType.OutQuad:
                    return EaseOutQuad(value);
                case EasingType.InOutQuad:
                    return EaseInOutQuad(value);
                case EasingType.InCubic:
                    return EaseInCubic(value);
                case EasingType.OutCubic:
                    return EaseOutCubic(value);
                case EasingType.InQuart:
                    return EaseInQuart(value);
                case EasingType.OutQuart:
                    return EaseOutQuart(value);
                case EasingType.InOutQuart:
                    return EaseInOutQuart(value);
                case EasingType.InQuint:
                    return EaseInQuint(value);
                case EasingType.OutQuint:
                    return EaseOutQuint(value);
                case EasingType.InOutQuint:
                    return EaseInOutQuint(value);
                case EasingType.InOutSine:
                    return EaseInOutSine(value);
                case EasingType.InExpo:
                    return EaseInExpo(value);
                case EasingType.OutExpo:
                    return EaseOutExpo(value);
                case EasingType.InOutExpo:
                    return EaseInOutExpo(value);
                case EasingType.InCirc:
                    return EaseInCirc(value);
                case EasingType.OutCirc:
                    return EaseOutCirc(value);
                case EasingType.InOutCirc:
                    return EaseInOutCirc(value);
                case EasingType.InBounce:
                    return EaseInBounce(value);
                case EasingType.OutBounce:
                    return EaseOutBounce(value);
                case EasingType.InOutBounce:
                    return EaseInOutBounce(value);
                case EasingType.InBack:
                    return EaseInBack(value);
                case EasingType.OutBack:
                    return EaseOutBack(value);
                case EasingType.InOutBack:
                    return EaseInOutBack(value);
                case EasingType.InElastic:
                    return EaseInElastic(value);
                case EasingType.OutElastic:
                    return EaseOutElastic(value);
                case EasingType.InOutElastic:
                    return EaseInOutElastic(value);
                default:
					throw new ArgumentOutOfRangeException(nameof(easingType), easingType, null);
			}
		}
		
		
		public static bool IsPowerOfTwo(ulong x)
		{
			return (x != 0) && ((x & (x - 1)) == 0);
		}
		
		public static float Spring(float val)
        {
            val = Mathf.Clamp01(val);
            val = (Mathf.Sin(val * Mathf.PI * (0.2f + 2.5f * val * val * val)) * Mathf.Pow(1f - val, 2.2f) + val) * (1f + (1.2f * (1f - val)));
            return 1 + val;
        }

        public static float EaseInQuad(float val)
        {
            return val * val;
        }

        public static float EaseOutQuad(float val)
        {
            return -1f * val * (val - 2);
        }

        public static float EaseInOutQuad(float val)
        {
            val /= .5f;
            if (val < 1) return 0.5f * val * val;
            val--;
            return -0.5f * (val * (val - 2) - 1);
        }

        public static float EaseInCubic(float val)
        {
            return val * val * val;
        }

        public static float EaseOutCubic(float val)
        {
            val--;
            return (val * val * val + 1);
        }

        public static float EaseInOutCubic(float value)
        {
            return value < 0.5 ? 4 * value * value * value : 1 - Mathf.Pow(-2 * value + 2, 3) / 2;
        }

        public static float EaseInQuart(float val)
        {
            return val * val * val * val;
        }

        public static float EaseOutQuart(float val)
        {
            val--;
            return -(val * val * val * val - 1);
        }

        public static float EaseInOutQuart(float val)
        {
            val /= .5f;
            if (val < 1) return 0.5f * val * val * val * val;
            val -= 2;
            return -0.5f * (val * val * val * val - 2);
        }

        public static float EaseInQuint(float val)
        {
            return val * val * val * val * val;
        }

        public static float EaseOutQuint(float val)
        {
            val--;
            return (val * val * val * val * val + 1);
        }

        public static float EaseInOutQuint(float val)
        {
            val /= .5f;
            if (val < 1) return 0.5f * val * val * val * val * val;
            val -= 2;
            return 0.5f * (val * val * val * val * val + 2);
        }
        
        public static float EaseInSine(float value)
        {
            return 1 - Mathf.Cos((value * Mathf.PI) / 2);
        }

        public static float EaseOutSine(float value)
        {
            return Mathf.Sin((value *  Mathf.PI) / 2);
        }
        
        public static float EaseInOutSine(float val)
        {
            return -0.5f * (Mathf.Cos(Mathf.PI * val / 1) - 1);
        }

        public static float EaseInExpo(float val)
        {
            return Mathf.Pow(2, 10 * (val / 1 - 1));
        }

        public static float EaseOutExpo(float val)
        {
            return (-Mathf.Pow(2, -10 * val / 1) + 1);
        }

        public static float EaseInOutExpo(float val)
        {
            val /= .5f;
            if (val < 1) return 0.5f * Mathf.Pow(2, 10 * (val - 1));
            val--;
            return 0.5f * (-Mathf.Pow(2, -10 * val) + 2);
        }

        public static float EaseInCirc(float val)
        {
            return -1f * (Mathf.Sqrt(1 - val * val) - 1);
        }

        public static float EaseOutCirc(float val)
        {
            val--;
            return Mathf.Sqrt(1 - val * val);
        }

        public static float EaseInOutCirc(float val)
        {
            val /= .5f;
            if (val < 1) return -0.5f * (Mathf.Sqrt(1 - val * val) - 1);
            val -= 2;
            return 0.5f * (Mathf.Sqrt(1 - val * val) + 1);
        }

        public static float EaseInBounce(float val)
        {
            return 1f - EaseOutBounce(1f - val);
        }

        public static float EaseOutBounce(float val)
        {
            val /= 1f;
            if (val < (1 / 2.75f))
            {
                return (7.5625f * val * val);
            }
            else if (val < (2 / 2.75f))
            {
                val -= (1.5f / 2.75f);
                return (7.5625f * (val) * val + .75f);
            }
            else if (val < (2.5 / 2.75))
            {
                val -= (2.25f / 2.75f);
                return (7.5625f * (val) * val + .9375f);
            }
            else
            {
                val -= (2.625f / 2.75f);
                return (7.5625f * (val) * val + .984375f);
            }
        }

        public static float EaseInOutBounce(float val)
        {
            float d = 1f;
            if (val < d / 2) return EaseInBounce(val * 2) * 0.5f;
            else return EaseOutBounce(val * 2 - d) * 0.5f + 0.5f;
        }

        public static float EaseInBack(float val)
        {
            val /= 1;
            float s = 1.70158f;
            return (val) * val * ((s + 1) * val - s);
        }

        public static float EaseOutBack(float val)
        {
            float s = 1.70158f;
            val = (val / 1) - 1;
            return ((val) * val * ((s + 1) * val + s) + 1);
        }

        public static float EaseInOutBack(float val)
        {
            float s = 1.70158f;
            val /= .5f;
            if ((val) < 1)
            {
                s *= (1.525f);
                return 0.5f * (val * val * (((s) + 1) * val - s));
            }
            val -= 2;
            s *= (1.525f);
            return 0.5f * ((val) * val * (((s) + 1) * val + s) + 2);
        }

        public static float EaseInElastic(float val)
        {
            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (val == 0) return 0f;
            val = val / d;
            if (val == 1) return 1f;

            if (a == 0f || a < 1f)
            {
                a = 1f;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(1f / a);
            }
            val = val - 1;
            return -(a * Mathf.Pow(2, 10 * val) * Mathf.Sin((val * d - s) * (2 * Mathf.PI) / p));
        }

        public static float EaseOutElastic(float val)
        {
            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (val == 0) return 0f;

            val = val / d;
            if (val == 1) return 1f;

            if (a == 0f || a < 1f)
            {
                a = 1f;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(1f / a);
            }

            return (a * Mathf.Pow(2, -10 * val) * Mathf.Sin((val * d - s) * (2 * Mathf.PI) / p) + 1f);
        }

        public static float EaseInOutElastic(float val)
        {
            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (val == 0) return 0f;

            val = val / (d / 2);
            if (val == 2) return 1f;

            if (a == 0f || a < 1f)
            {
                a = 1f;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(1f / a);
            }

            if (val < 1)
            {
                val = val - 1;
                return -0.5f * (a * Mathf.Pow(2, 10 * val) * Mathf.Sin((val * d - s) * (2 * Mathf.PI) / p));
            }
            val = val - 1;
            return a * Mathf.Pow(2, -10 * val) * Mathf.Sin((val * d - s) * (2 * Mathf.PI) / p) * 0.5f + 1f;
        }
	}
}