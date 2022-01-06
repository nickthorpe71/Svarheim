using UnityEngine;

public class AnchorUI : MonoBehaviour
{
    public GameObject uiObj;

    [SerializeField] private bool x;
    [SerializeField] private bool y;
    [SerializeField] private bool z;

    private void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        uiObj.transform.position = new Vector3(
            x ? pos.x : 0,
            y ? pos.y : 0,
            z ? pos.z : 0
            );
    }
}
