using TMPro;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public float gatehp;
    public float gatemaxhp;
    public float repairTime;
    public float repairing;
    public TextMeshPro gateText;
    public GameObject healthFill;
    public GameObject hitbox;
    void Start()
    {
        gatehp = gatemaxhp;
        repairing = repairTime;
    }
    // Update is called once per frame
    void Update()
    {
        gateText.text = Mathf.Floor(gatehp) + "/" + Mathf.Floor(gatemaxhp);
        healthFill.transform.localPosition = new Vector3(-30f * ((gatemaxhp - gatehp) / gatemaxhp), 45f, 0f);
        healthFill.transform.localScale = new Vector3(60 * (gatehp / gatemaxhp), 12f, 1f);
        if (gatehp <= 0f)
        {
            hitbox.SetActive(false);
            gatehp = 0;
        }
        else
        {
            hitbox.SetActive(true);
        }
    }
}
