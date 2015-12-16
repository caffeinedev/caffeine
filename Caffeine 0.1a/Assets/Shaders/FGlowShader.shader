public class FGlowShader : FShader
{
	private float _glowAmount;
	private Color _glowColor;
	
	public FGlowShader(float glowAmount,Color glowColor) : base("GlowShader", Shader.Find("Futile/Glow"))
	{
		_glowAmount = glowAmount;
		_glowColor = glowColor;
		needsApply = true;
	}
	
	override public void Apply(Material mat)
	{
		mat.SetFloat("_GlowAmount",_glowAmount);
		mat.SetColor("_GlowColor",_glowColor);
	}
	
	public float glowAmount
	{
		get {return _glowAmount;}
		set {if(_glowAmount != value) {_glowAmount = value; needsApply = true;}}
	}
	
	public Color glowColor
	{
		get {return _glowColor;}
		set {if(_glowColor != value) {_glowColor = value; needsApply = true;}}
	}
}