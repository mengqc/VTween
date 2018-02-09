using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace VTween {

	public class PositionModifier : BaseModifier {

		private Vector3 _start;
		private Vector3 _end;
		private bool _isLocal = false;
		private Vector3 _mask = Vector3.one;

		public PositionModifier(Vector3 end) {
			_end = end;
		}

		public PositionModifier(Vector3 end, bool isLocal) : this(end) {
			_isLocal = isLocal;
		}

		public PositionModifier(Vector3 end, bool isLocal, Vector3 mask) : this(end, isLocal) {
			_mask = mask;
		}

		override public void OnSaveStartValue() {
			_start = position;
		}

		override public void Lerp(float t) {
			Vector3 result = position;
			if (_mask.x > 0) {
				result.x = Mathf.Lerp(_start.x, _end.x, t);
			}
			if (_mask.y > 0) {
				result.y = Mathf.Lerp(_start.y, _end.y, t);
			}
			if(_mask.z > 0) {
				result.z = Mathf.Lerp(_start.z, _end.z, t);
			}
			position = result;
		}

		public Vector3 position {
			get {
				if (_isLocal) {
					return _tween.Target<GameObject>().transform.localPosition;
				} else {
					return _tween.Target<GameObject>().transform.position;
				}
			}
			set {
				if (_isLocal) {
					_tween.Target<GameObject>().transform.localPosition = value;
				} else {
					_tween.Target<GameObject>().transform.position = value;
				}
			}
		}

	}
}
