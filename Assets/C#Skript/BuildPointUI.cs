using UnityEngine;
using UnityEngine.UI;

public class BuildPointUI : MonoBehaviour
{
    public GameObject[] turretPrefabs;         
    public int[] turretCosts = { 8, 10, 12 };  
    public GameObject uiPanel;                 

    private BuildPoint currentPoint;           
    public void ShowUI(BuildPoint point)
    {
        currentPoint = point;
        uiPanel.SetActive(true);
    }

    public void HideUI()
    {
        uiPanel.SetActive(false);
        currentPoint = null;
    }

    public void BuildTurret(int index)
    {
        if (currentPoint == null || currentPoint.HasTurret()) return;

        int cost = turretCosts[index];

        if (CoinManager.instance != null && CoinManager.instance.HasCoins(cost))
        {
            Instantiate(turretPrefabs[index], currentPoint.transform.position, Quaternion.identity);
            CoinManager.instance.SpendCoins(cost);
            currentPoint.SetHasTurret();
        }

        HideUI();
    }
}
