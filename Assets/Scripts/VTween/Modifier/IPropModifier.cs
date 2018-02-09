using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTween {
	public interface IPropModifier {
		void OnInit(VTween tween, TweenProp prop);
		void OnSaveStartValue();
		void Lerp(float t);
	}
}
