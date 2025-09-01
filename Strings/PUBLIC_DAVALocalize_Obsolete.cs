using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PUBLIC_DAVALocalize_Obsolete : MonoBehaviour
{
    [SerializeField] private string localizationKey;
    private Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        UpdateText();
        PUBLIC_DAVAGlobalStrings.OnLanguageChanged += UpdateText;
    }

    private void OnDestroy()
    {
        PUBLIC_DAVAGlobalStrings.OnLanguageChanged -= UpdateText;
    }

    public void UpdateText()
    {
        if (textComponent != null && !string.IsNullOrEmpty(localizationKey))
        {
            textComponent.text = PUBLIC_DAVAGlobalStrings.Instance.Get(localizationKey);
        }
    }

    public void SetKey(string newKey)
    {
        localizationKey = newKey;
        UpdateText();
    }
}
