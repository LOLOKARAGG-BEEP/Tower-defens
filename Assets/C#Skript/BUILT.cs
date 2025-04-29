using UnityEngine;

public class BuildPoint : MonoBehaviour
{
    private bool hasTurret = false;

    public bool HasTurret()
    {
        return hasTurret;
    }

    public void SetHasTurret()
    {
        hasTurret = true;
    }

    void OnMouseDown()
    {
        if (hasTurret) return;

        BuildPointUI ui = FindObjectOfType<BuildPointUI>();
        if (ui != null)
        {
            ui.ShowUI(this);
        }
    }
}
