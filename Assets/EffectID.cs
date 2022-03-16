using UnityEngine;
using UnityEngine.UI;
public class EffectID : MonoBehaviour
{
    private int number;
    private int unlocked;

    public GameObject cost, ids;

    public GameObject unl, loc;

    private void Start()
    {
        number = GetComponent<ApplicationManager>().number;
        unlocked = PlayerPrefs.GetInt("" + number, 0);
        if (unlocked == 1)
        {
            unl.SetActive(true);
            loc.SetActive(false);
        }
        else
        {
            unl.SetActive(false);
            loc.SetActive(true);
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("" + number, 0) == 1)
        {
            unl.SetActive(true);
            loc.SetActive(false);
        }
        else
        {
            unl.SetActive(false);
            loc.SetActive(true);
        }
    }

    public int GetUnlock()
    {
        return unlocked;
    }

    public void prch()
    {
        cost.GetComponent<Text>().text = "cost: " + ((number + 1) * 150);
        cost.transform.parent.parent.parent.parent.gameObject.SetActive(true);

        ids.GetComponent<purchFinal>().cost = ((number + 1) * 150);
        ids.GetComponent<purchFinal>().id = number;
    }
}
