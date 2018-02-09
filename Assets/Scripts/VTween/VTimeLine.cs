using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VTween {

	public class VTimeLine : IDisposable {

		public bool isCompleted = false;

		private List<VTween> _tweenList = new List<VTween>();
		private float _passedTime;
		private float _duration;

		private Action _OnComplete;

		public IDisposable Start(GameObject gameObj = null) {
			AddTo(gameObj);
			isCompleted = false;
			_passedTime = 0;
			foreach (VTween tween in _tweenList) {
				tween.Init();
				_duration = Mathf.Max(_duration, tween.delay + tween.duration);
			}
			return this;
		}

		public void UpdateTween() {
			if (isCompleted) return;
			_passedTime += Time.deltaTime;
			if(_passedTime >= _duration) {
				_passedTime = _duration;
			}
			foreach (VTween tween in _tweenList) {
				if (tween.isCompleted) continue;
				if (_passedTime < tween.delay) continue;
				tween.UpdateTime(_passedTime);
			}
			bool isCanComplete = true;
			foreach (VTween tween in _tweenList) {
				if (!tween.isCompleted) {
					isCanComplete = false;
					break;
				}
			}
			if (isCanComplete) {
				isCompleted = true;
				VTweenUtil.TryCallAction(_OnComplete);
			}
		}

		public VTween AddTween(object target, float duration = 0, float delay = 0) {
			var tween = new VTween(this, target, duration, delay);
			_tweenList.Add(tween);
			return tween;
		}

		public VTween DelayCall(float time, Action func) {
			var tween = new VTween(this, null, 0, time);
			_tweenList.Add(tween);
			tween.ListenComplete(func);
			return tween;
		}

		public void Clear() {
			_tweenList.Clear();
		}

		private VTimeLine AddTo(GameObject gameObj = null) {
			bool isObjDestroy = false;
			if(gameObj == null) {
				gameObj = new GameObject();
				isObjDestroy = true;
			}
			VTweenMono mono = gameObj.AddComponent<VTweenMono>();
			mono.timeline = this;
			mono.isAutoDestroy = isObjDestroy;
			return this;
		}

		public VTimeLine ListenComplete(Action onComplete) {
			_OnComplete += onComplete;
			return this;
		}

		public void Dispose() {
			Clear();
		}

	}
}
