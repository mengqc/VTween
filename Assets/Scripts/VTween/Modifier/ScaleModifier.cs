using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VTween {
	public class ScaleModifier : BaseModifier {

		private Vector3 _start;
		private Vector3 _end;
		private Vector3 _mask = Vector3.one;

		public ScaleModifier(Vector3 end) {
			_end = end;
		}

		public ScaleModifier(Vector3 end, Vector3 mask) : this(end) {
			_mask = mask;
		}

		override public void OnSaveStartValue() {
			_start = scale;
		}

		override public void Lerp(float t) {
			Vector3 result = scale;
			if (_mask.x > 0) {
				result.x = Mathf.Lerp(_start.x, _end.x, t);
			}
			if (_mask.y > 0) {
				result.y = Mathf.Lerp(_start.y, _end.y, t);
			}
			if (_mask.z > 0) {
				result.z = Mathf.Lerp(_start.z, _end.z, t);
			}
			scale = result;
		}

		public Vector3 scale {
			get {
				return _tween.Target<GameObject>().transform.localScale;
			}
			set {
				_tween.Target<GameObject>().transform.localScale = value;
			}
		}

	}
}
