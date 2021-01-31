using UnityEngine;
using TMPro;

public class GhostRemainingText : MonoBehaviour
{
    private TextMeshProUGUI textVariable;
    
    // Start is called before the first frame update
    void Awake()
    {
        textVariable = GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        textVariable.text = "Ghost Remaining: " + PlaceOnPlane.ghostRemaining.ToString();   
    }
}
