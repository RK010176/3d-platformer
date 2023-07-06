using UnityEngine;
using UnityEngine.UI;
using Common;


public class UpdateKey : MonoBehaviour
{
	public Image Img;
	[SerializeField] private BoolVal _Key;
    
    
    
	public void DisplayKey()
	{
		Img.enabled = true;		
	}
}
