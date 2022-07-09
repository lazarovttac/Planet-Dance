using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetSettings : MonoBehaviour
{
    public string planetName = "New Planet";
    public float a, b, w, sC, eC, sW, eW, tT;
    public Color startTrailColor;
    public Color endTrailColor;
    
    [SerializeField]
    private Slider aSlider, bSlider, wSlider, startColorSlider, endColorSlider, trailTimeSlider, trailStartWidthSlider, trailEndWidthSlider;
    
    [SerializeField]
    private Image startColorSliderBackground, endColorSliderBackground;

    [SerializeField]
    private TextMeshProUGUI nameText, aText, bText, wText, sCText, eCText, tText, sWText, eWText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = planetName;
        aSlider.value = a;
        bSlider.value = b;
        wSlider.value = w;

        startColorSlider.value = sC;
        endColorSlider.value = eC;

        trailStartWidthSlider.value = sW;
        trailEndWidthSlider.value = eW;
        trailTimeSlider.value = tT;
    }

    // Update is called once per frame
    void Update()
    {
        a = aSlider.value;
        b = bSlider.value;
        w = wSlider.value;
        sC = startColorSlider.value;
        eC = endColorSlider.value;
        
        sW = trailStartWidthSlider.value;
        eW = trailEndWidthSlider.value;
        tT = trailTimeSlider.value;

        aText.text = a.ToString();
        bText.text = b.ToString();
        wText.text = w.ToString();
        sCText.text = sC.ToString();
        eCText.text = eC.ToString();
        
        tText.text = tT.ToString();
        sWText.text = sW.ToString();
        eWText.text = eW.ToString();

        startTrailColor = Color.HSVToRGB(sC / 360, 0.5f, 1);
        endTrailColor = Color.HSVToRGB(eC / 360, 0.5f, 1);

        startColorSliderBackground.color = startTrailColor;
        endColorSliderBackground.color = endTrailColor;
    }
}
