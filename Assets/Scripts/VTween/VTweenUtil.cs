using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTween {
	public class VTweenUtil {

		public static void TryCallAction(Action action) {
			if (action == null) return;
			action.Invoke();
		}

	}
}
