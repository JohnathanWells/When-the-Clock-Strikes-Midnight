using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;

public class CommunicationDecision : MonoBehaviour
{
	public string preface;
	public Button button;
	public TextMeshProUGUI textMesh;
	public Choice choice;
	public Color OnColor;
	public Color OffColor;

    private void Start()
    {
		OffColor = textMesh.color;
    }

    public void Set(Choice choice)
    {
		textMesh.text = preface + choice.text;
		this.choice = choice;
    }

	public void SetColorOn()
    {
		textMesh.color = OnColor;
	}
	public void SetColorOff()
	{
		textMesh.color = OffColor;
	}
}
