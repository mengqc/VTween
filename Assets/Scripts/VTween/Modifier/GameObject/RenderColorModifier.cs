using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VTween {

	public class RenderColorModifier : BaseIterModifier {

		private Renderer _img;
		private Color _start;
		private Color _end;
		private bool _isLocal = false;
		private uint _mask = ColorChannel.R | ColorChannel.G | ColorChannel.B | ColorChannel.A;

		public RenderColorModifier(Renderer img, Color end) {
			_img = img;
			_end = end;
		}

		public RenderColorModifier(Renderer img, Color end, uint mask) : this(img, end) {
			_mask = mask;
		}

		override public void OnSaveStartValue() {
			_start = _img.material.color;
		}

		override public void Lerp(float t) {
			Color result;
			result = _img.material.color;
			if ((_mask & ColorChannel.R) > 0) {
				result.r = Mathf.Lerp(_start.r, _end.r, t);
			}
			if ((_mask & ColorChannel.G) > 0) {
				result.g = Mathf.Lerp(_start.g, _end.g, t);
			}
			if ((_mask & ColorChannel.B) > 0) {
				result.b = Mathf.Lerp(_start.b, _end.b, t);
			}
			if ((_mask & ColorChannel.A) > 0) {
				result.a = Mathf.Lerp(_start.a, _end.a, t);
			}
			_img.material.color = result;
		}

	}
}
