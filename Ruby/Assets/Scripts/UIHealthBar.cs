using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
	public static UIHealthBar instance { get; private set; }
	
	public Image pMask;
	float gOriginalSize;
	
	void Awake()
	{
		instance = this;
	}
	
    void Start()
    {
        gOriginalSize = pMask.rectTransform.rect.width;
    }

	public void SetValue( float iValue )
	{
		pMask.rectTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, gOriginalSize * iValue );
	}

}
