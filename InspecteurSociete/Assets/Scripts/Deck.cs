using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [JsonConverter(typeof(List<CarteCrime>))]
    static public List<CarteCrime> carteSuspects = null;

    public TextAsset jsonFile;

    //Debug.Log (JsonConvert.SerializeObject(carteSuspects, Formatting.None));
    private void Awake()
    {
        carteSuspects = JsonConvert.DeserializeObject<List<CarteCrime>>(jsonFile.text);
    }

    public static List<CarteCrime> GetDeck()
    {
        return carteSuspects;
    }
}
