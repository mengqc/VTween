### VTween
## Tween for unity3d

# Extendable
# Customize ease function visible
# Method chaning

new VTimeLine().AddTween(gameObject, 2)
			.AddProp(new PositionModifier(Vector3.one * 100, true, Vector3.up), Ease.Curve(yCurve))
			.AddProp(new PositionModifier(Vector3.one * 300, true, Vector3.right), EaseBounce.EaseIn)
			.AddProp(new ColorModifier(new Color(0, 0, 0, 0), ColorChannel.A), EaseCirc.EaseInOut)
			.AddProp(new ScaleModifier(Vector3.one * 2, Vector3.up))
			.TimeLine()
			.Start(gameObject);
