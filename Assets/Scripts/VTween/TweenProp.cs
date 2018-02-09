using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace VTween {

	[Serializable]
	public class TweenProp {

		public Func<float, float> EaseFunc;

		private IPropModifier _modifier;
		private VTween _tween;

		private bool _isInited = false;

		public TweenProp(VTween tween, IPropModifier modifier) {
			_tween = tween;
			_modifier = modifier;
			EaseFunc = t => t;
		}

		public TweenProp(VTween tween, IPropModifier modifier, Func<float, float> easeFunc) : this(tween, modifier) {
			EaseFunc = easeFunc;
		}

		public void Init(VTween tween) {
			if (!_isInited) {
				_modifier.OnInit(tween, this);
				_isInited = true;
			}
			_modifier.OnSaveStartValue();
		}

		virtual public void UpdateTime(float time) {
			_modifier.Lerp(EaseFunc(time));
		}

		public VTween Tween() {
			return _tween;
		}

	}
}
