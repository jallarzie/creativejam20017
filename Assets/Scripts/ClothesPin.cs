using UnityEngine;
using System.Collections;

public enum ClothesPinColor{
	Blue,
	Green,
	Yellow,
	Red
}

public class ClothesPin : MonoBehaviour {

    [SerializeField]
    private Sprite[] topSprites;
    [SerializeField]
    private Sprite[] bottomSprites;

    [SerializeField]
    private SpriteRenderer top;
    [SerializeField]
    private SpriteRenderer bottom;

    private ClothesPinColor _clothesColor;

	public ClothesPinColor clothesColor
    {
        get
        {
            return _clothesColor;
        }
        set
        {
            _clothesColor = value;
            top.sprite = topSprites[(int)_clothesColor];
            bottom.sprite = bottomSprites[(int)_clothesColor];
            top.enabled = true;
            bottom.enabled = true;
        }
    }

    public bool placed { get; set; }

    public void Hide()
    {
        top.enabled = false;
        bottom.enabled = false;
    }

}
