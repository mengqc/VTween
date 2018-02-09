using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace VTween {
	public class GraphicColorModifier : BaseModifier {

		private Graphic _img;
		private Color _start;
		private Color _end;
		private uint _mask = ColorChannel.R | ColorChannel.G | ColorChannel.B | ColorChannel.A;

		public GraphicColorModifier(Graphic img, Color end) {
			_img = img;
			_end = end;
		}

		public GraphicColorModifier(Graphic img, Color end, uint mask) : this(img, end) {
			_mask = mask;
		}

		override public void OnSaveStartValue() {
			_start = _img.color;
		}

		override public void Lerp(float t) {
			Color result;
			result = _img.color;
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
			_img.color = result;
		}
	}
}
