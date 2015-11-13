using UnityEngine;
using System.Collections;
 
public class FPSDebuggerScript : MonoBehaviour
{
	float deltaTime = 0.0f;
    public Color textColor = new Color (255, 219, 0, 1);
	
	private int screenWidth;
	private int screenHeight;
	private GUIStyle guiStyle;
	
	private string fpsString;
	private float  fpsCount;
	private float  msecCount;
	private Rect   rectangleRender;
	
	void Start() {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		
		guiStyle = new GUIStyle();
	//	guiStyle.textColor = textColor;
		guiStyle.alignment = TextAnchor.UpperLeft;
		guiStyle.fontSize = screenHeight * 2 / 100;
		Debug.Log("CAMERAFPS: FONTSIZE " + guiStyle.fontSize);
		guiStyle.normal.textColor = textColor;
		
		
	}

    void Update() {
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		
		fpsCount = 1.0f / deltaTime;
		msecCount = deltaTime * 1000.0f;
		
		fpsString = string.Format("{0:0.0} ms ({1:0.} fps)", msecCount, fpsCount);
		rectangleRender = new Rect(0, 0, screenWidth, screenHeight * 2 / 100);
		
		
	}
 
	void OnGUI() {
		GUI.Label(rectangleRender, fpsString, guiStyle);
	}
}