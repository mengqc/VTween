﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VTween {

	public class Ease {

		public static float Linear(float value) {
			return value;
		}

		public static Func<float, float> Curve(AnimationCurve curve) {
			return t => curve.Evaluate(t);
		}

		public static float Spring(float value) {
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
			return value;
		}

		public static float Punch(float value) {
			float s = 9;
			if (value == 0) {
				return 0;
			} else if (value == 1) {
				return 0;
			}
			float period = 1 * 0.3f;
			s = period / (2 * Mathf.PI) * Mathf.Asin(0);
			return Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period);
		}

	}

	public class EaseQuad {

		public static float EaseIn(float value) {
			return value * value;
		}

		public static float EaseOut(float value) {
			return -value * (value - 2);
		}

		public static float EaseInOut(float value) {
			value /= .5f;
			if (value < 1) return 1 * 0.5f * value * value;
			value--;
			return -0.5f * (value * (value - 2) - 1);
		}
	}

	public class EaseCubic {

		public static float EaseIn(float value) {
			return value * value * value;
		}

		public static float EaseOut(float value) {
			value--;
			return value * value * value + 1;
		}

		public static float EaseInOut(float value) {
			value /= .5f;
			if (value < 1) return 1 * 0.5f * value * value * value;
			value -= 2;
			return 0.5f * (value * value * value + 2);
		}

	}

	public class EaseQuart {

		public static float EaseIn(float value) {
			return value * value * value * value;
		}

		public static float EaseOut(float value) {
			value--;
			return -(value * value * value * value - 1);
		}

		public static float EaseInOut(float value) {
			value /= .5f;
			if (value < 1) return 0.5f * value * value * value * value;
			value -= 2;
			return -0.5f * (value * value * value * value - 2);
		}

	}

	public class EaseQuint {

		public static float EaseIn(float value) {
			return value * value * value * value * value;
		}

		public static float EaseOut(float value) {
			value--;
			return value * value * value * value * value + 1;
		}

		public static float EaseInOut(float value) {
			value /= .5f;
			if (value < 1) return 1 * 0.5f * value * value * value * value * value;
			value -= 2;
			return 0.5f * (value * value * value * value * value + 2);
		}
	}

	public class EaseSine {

		public static float EaseIn(float value) {
			return -Mathf.Cos(value * (Mathf.PI * 0.5f)) + 1;
		}

		public static float EaseOut(float value) {
			return Mathf.Sin(value * (Mathf.PI * 0.5f));
		}

		public static float EaseInOut(float value) {
			return -0.5f * (Mathf.Cos(Mathf.PI * value) - 1);
		}
	}

	public class EaseExpo {

		public static float EaseIn(float value) {
			return Mathf.Pow(2, 10 * (value - 1));
		}

		public static float EaseOut(float value) {
			return -Mathf.Pow(2, -10 * value) + 1;
		}

		public static float EaseInOut(float value) {
			value /= .5f;
			if (value < 1) return 1 * 0.5f * Mathf.Pow(2, 10 * (value - 1));
			value--;
			return 0.5f * (-Mathf.Pow(2, -10 * value) + 2);
		}

	}

	public class EaseCirc {

		public static float EaseIn(float value) {
			return -(Mathf.Sqrt(1 - value * value) - 1);
		}

		public static float EaseOut(float value) {
			value--;
			return Mathf.Sqrt(1 - value * value);
		}

		public static float EaseInOut(float value) {
			value /= .5f;
			if (value < 1) return -0.5f * (Mathf.Sqrt(1 - value * value) - 1);
			value -= 2;
			return 0.5f * (Mathf.Sqrt(1 - value * value) + 1);
		}

	}

	/* GFX47 MOD START */
	public class EaseBounce {

		public static float EaseIn(float value) {
			float d = 1f;
			return 1 - EaseOut(d - value);
		}

		public static float EaseOut(float value) {
			value /= 1f;
			if (value < (1 / 2.75f)) {
				return 7.5625f * value * value;
			} else if (value < (2 / 2.75f)) {
				value -= (1.5f / 2.75f);
				return 7.5625f * (value) * value + .75f;
			} else if (value < (2.5 / 2.75)) {
				value -= (2.25f / 2.75f);
				return 7.5625f * (value) * value + .9375f;
			} else {
				value -= (2.625f / 2.75f);
				return 7.5625f * (value) * value + .984375f;
			}
		}

		public static float EaseInOut(float value) {
			float d = 1f;
			if (value < d * 0.5f) return EaseIn(value * 2) * 0.5f;
			else return EaseOut(value * 2 - d) * 0.5f + 0.5f;
		}

	}

	public class EaseElastic {

		public static float EaseIn(float value) {

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0) return 0;

			if ((value /= d) == 1) return 1;

			if (a == 0f || a < Mathf.Abs(1)) {
				a = 1;
				s = p / 4;
			} else {
				s = p / (2 * Mathf.PI) * Mathf.Asin(1 / a);
			}

			return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p));
		}

		public static float EaseOut(float value) {

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0) return 0;

			if ((value /= d) == 1) return 1;

			if (a == 0f || a < Mathf.Abs(1)) {
				a = 1;
				s = p * 0.25f;
			} else {
				s = p / (2 * Mathf.PI) * Mathf.Asin(1 / a);
			}

			return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + 1);
		}

		public static float EaseInOut(float value) {

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0) return 0;

			if ((value /= d * 0.5f) == 2) return 1;

			if (a == 0f || a < Mathf.Abs(1)) {
				a = 1;
				s = p / 4;
			} else {
				s = p / (2 * Mathf.PI) * Mathf.Asin(1 / a);
			}

			if (value < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p));
			return a * Mathf.Pow(2, -10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + 1;
		}

	}

	/* GFX47 MOD END */

	public class EaseBack {

		public static float EaseIn(float value) {
			value /= 1;
			float s = 1.70158f;
			return value * value * ((s + 1) * value - s);
		}

		public static float EaseOut(float value) {
			float s = 1.70158f;
			value = value - 1;
			return (value) * value * ((s + 1) * value + s) + 1;
		}

		public static float EaseInOut(float value) {
			float s = 1.70158f;
			value /= .5f;
			if ((value) < 1) {
				s *= (1.525f);
				return 0.5f * (value * value * (((s) + 1) * value - s));
			}
			value -= 2;
			s *= 1.525f;
			return 0.5f * ((value) * value * (((s) + 1) * value + s) + 2);
		}

	}

}
