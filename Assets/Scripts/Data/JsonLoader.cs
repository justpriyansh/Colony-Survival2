using UnityEngine;

public static class JsonLoader
{
    public static T Load<T>(string fileName)
    {
        TextAsset json = Resources.Load<TextAsset>(fileName);

        if (json == null)
        {
            Debug.LogError($"Could not load {fileName}");
            return default;
        }

        return JsonUtility.FromJson<T>(json.text);
    }
}