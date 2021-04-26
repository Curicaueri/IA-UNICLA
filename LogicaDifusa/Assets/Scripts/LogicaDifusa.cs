using UnityEditor;
using UnityEngine;

public class LogicaDifusa : MonoBehaviour {
	
	//Estados
	private const string labeltext = "{0} true";
	public AnimationCurve motivated;
	public AnimationCurve normal;
	public AnimationCurve tired;
	
	public inputField statusInput;
	
	public Text motivatedLabel;
	public Text normalLabel;
	public Text tiredLabel;
	
	private float motivatedValue = 0f;
	private float normalValue = 0f;
	private float tiredValue = 0f;
	
	private void Start ()
	{
		SetLabels;
	}
	
	
	//Evaluar curvas y regresar valores
	public void EvaluateStatements()
	{
		if (string.IsNullOrEmpty(statusInput.text))
		{
			return;
		}
		float inputValue = float.Parse(statusInput.text);
		
		motivatedValue = motivated.Evaluate(inputValue);
		normalValue = normal.Evaluate(inputValue);
		tiredValue =tired.Evaluate(inputValue);
		
		SetLabels();
	}
	
	//Actualiza el GUI con los valores evaluados
	
	private void SetLabels ()
	{
		motivatedLabel.text = string.Format(labeltext, motivatedValue);
		normalLabel.text = string.Format(labeltext, normalValue);
		tiredLabel.text = string.Format(labeltext, tiredValue);
		
	}
	
	
	public float evaluarStatus(float speed)
	{
		//Cambio de velocidad en estado
		
		if (tiredValue > 10)
		{
			Debug.Log("Reducir velocidad a la mitad");
			return speed / 2f;
		}
		
		
		//Terminan las reglas
	}
    
}
