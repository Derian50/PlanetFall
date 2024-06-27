using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    private Locales _currentLocale;

    public static Locales CurrentLocale { get; private set; }
    public static LanguageManager LMSingleton;

    private void Awake()
    {

        if (LMSingleton != null)
        {
            Destroy(this);
        }
        else
        {
            LMSingleton = this;
            DontDestroyOnLoad(this);
        }
        

        DataManager.LocalizationData.Init();

        _currentLocale = System.Enum.Parse<Locales>(YaSDK.GetLanguage());
        CurrentLocale = _currentLocale;
        
        
    }
}
