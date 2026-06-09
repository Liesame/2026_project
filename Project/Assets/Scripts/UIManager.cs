using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Toggle bgmToggle;
    public Toggle fxToggle;

    public Slider bgmSlider;
    public Slider fxSlider;

    public Button openButton;
    public Button exitButton;

    public GameObject optionPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmToggle.onValueChanged.AddListener(Soundmanager.instance.OnOffBGM);
        fxToggle.onValueChanged.AddListener(Soundmanager.instance.OnOffFx);

        bgmSlider.onValueChanged.AddListener(Soundmanager.instance.ChangeBGMVolume);
        fxSlider.onValueChanged.AddListener(Soundmanager.instance.ChangeFxVolume);

        openButton.onClick.AddListener(OpenPanel);
        exitButton.onClick.AddListener(ClosePanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OpenPanel()
    {
        optionPanel.SetActive(true);
    }

    private void ClosePanel()
    {
        optionPanel.SetActive(false);
    }
}
