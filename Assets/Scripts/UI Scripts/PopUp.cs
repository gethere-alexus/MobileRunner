using UnityEngine;

// assign on the pop up canvas
public class PopUp : MonoBehaviour
{
    public void Close()
    {
        Destroy(this.gameObject);
    }
}
