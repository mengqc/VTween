using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VTween {
	public class VTweenMono : MonoBehaviour {

		public VTimeLine timeline;
		public bool isAutoDestroy = false;

		private void Update() {
			if(timeline != null) {
				timeline.UpdateTween();
				if (timeline.isCompleted) {
					if (isAutoDestroy) {
						Destroy(gameObject);
					} else {
						Destroy(this);
					}
				}
			}
		}

		private void OnDestroy() {
			timeline.Dispose();
		}

	}
}
