using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTween {
	public class BaseModifier : IPropModifier {

		protected VTween _tween;
		protected TweenProp _prop;

		virtual public void OnSaveStartValue() {
			throw new NotImplementedException();
		}

		virtual public void OnInit(VTween tween, TweenProp prop) {
			_tween = tween;
			_prop = prop;
		}

		virtual public void Lerp(float t) {
			throw new NotImplementedException();
		}
	}
}
