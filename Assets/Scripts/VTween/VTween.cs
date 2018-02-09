using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VTween {

	public class VTween {
		public bool isCompleted = false;

		private object _target;
		private VTimeLine _timeline;
		private Action _OnComplete;

		private float _duration = 0;
		public float duration {
			get {
				return _duration;
			}
		}

		private float _delay = 0;
		public float delay {
			get {
				return _delay;
			}
		}

		private bool _isFrom = false;

		private List<TweenProp> _propList = new List<TweenProp>();

		public VTween(VTimeLine timeline, object target, float duration) {
			_timeline = timeline;
			_target = target;
			_duration = duration;
		}

		public VTween(VTimeLine timeline, object target, float duration, float delay) : this(timeline, target, duration) {
			_delay = delay;
		}

		public T Target<T>() {
			return (T)_target;
		}

		public VTimeLine TimeLine() {
			return _timeline;
		}

		public void Init() {
			isCompleted = false;
			foreach (TweenProp prop in _propList) {
				prop.Init(this);
			}
			UpdateTime(0);
		}

		public VTween To() {
			_isFrom = false;
			return this;
		}

		public VTween From() {
			_isFrom = true;
			return this;
		}

		public void UpdateTime(float time) {
			float execTime = Mathf.Max(time - _delay, 0);
			if (time >= _delay && execTime >= _duration) {
				isCompleted = true;
				execTime = _duration;
			}
			float normalizedTime;
			if(_duration == 0) {
				normalizedTime = 0;
			} else {
				normalizedTime = execTime / _duration;
			}
			if (_isFrom) {
				normalizedTime = 1 - normalizedTime;
			}

			//执行属性变化
			foreach (TweenProp prop in _propList) {
				prop.UpdateTime(normalizedTime);
			}

			if (isCompleted) {
				VTweenUtil.TryCallAction(_OnComplete);
			}
		}

		public VTween AddProp(IPropModifier modifier) {
			var prop = new TweenProp(this, modifier);
			_propList.Add(prop);
			return this;
		}

		public VTween AddProp(IPropModifier modifier, Func<float, float> easeFunc) {
			var prop = new TweenProp(this, modifier, easeFunc);
			_propList.Add(prop);
			return this;
		}

		public VTween ListenComplete(Action onComplete) {
			_OnComplete += onComplete;
			return this;
		}

	}

}
