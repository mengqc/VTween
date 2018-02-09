using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace VTween {
	public class ColorChannel {
		public static uint R = 1;
		public static uint G = 1 << 1;
		public static uint B = 1 << 2;
		public static uint A = 1 << 3;
	}

	public class ColorModifier : BaseIterModifier {

		private Color _end;
		private bool _isLocal = false;
		private uint _mask = ColorChannel.R | ColorChannel.G | ColorChannel.B | ColorChannel.A;

		public ColorModifier(Color end) {
			_end = end;
		}

		public ColorModifier(Color end, uint mask) : this(end) {
			_mask = mask;
		}

		protected override void TryAddNewModifier(Transform trans) {
			Graphic graph = trans.GetComponent<Graphic>();
			if(graph != null) {
				AddSubModifier(new GraphicColorModifier(graph, _end, _mask));
			}

			Renderer renderer = trans.GetComponent<Renderer>();
			if(renderer != null) {
				AddSubModifier(new RenderColorModifier(renderer, _end, _mask));
			}
		}

	}

}
