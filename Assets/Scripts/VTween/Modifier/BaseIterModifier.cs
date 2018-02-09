using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VTween {

	public class BaseIterModifier : BaseModifier {

		protected List<IPropModifier> _subModifierList = new List<IPropModifier>();

		override public void OnInit(VTween tween, TweenProp prop) {
			base.OnInit(tween, prop);
			_subModifierList.Clear();
			var root = _tween.Target<GameObject>();
			IterTransform(root.transform, FindModifiable);
		}

		private void FindModifiable(Transform trans) {
			TryAddNewModifier(trans);
		}

		virtual protected void AddSubModifier(IPropModifier sub) {
			_subModifierList.Add(sub);
		}

		virtual protected void TryAddNewModifier(Transform trans) {
		}

		private void IterTransform(Transform trans, Action<Transform> action) {
			action(trans);
			foreach (Transform subTrans in trans) {
				IterTransform(subTrans, action);
			}
		}

		override public void OnSaveStartValue() {
			foreach (IPropModifier sub in _subModifierList) {
				sub.OnSaveStartValue();
			}
		}

		override public void Lerp(float t) {
			foreach(IPropModifier sub in _subModifierList) {
				sub.Lerp(t);
			}
		}
	}

}
