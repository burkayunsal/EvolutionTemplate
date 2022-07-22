
public class UpgradeManager : Singleton<UpgradeManager>
{
    public int[] UpgradeRequirements;

    public int downgradeLimit;
    public int upgradeLimit;

    public int upgradeIndex;

    private void Start()
    {
        downgradeLimit = 0;
        upgradeLimit = UpgradeRequirements[0];
        upgradeIndex = 0;
    }

    public void CheckForUpgradeDowngrade(int totalValue, bool up)
    {
        if (up)
        {
            Upgrade(totalValue);
        } else
        {
            Downgrade(totalValue);
        }
       
    }

    void Upgrade(int totVal)
    {
        if (upgradeIndex < UpgradeRequirements.Length)
        {
            while(totVal >= upgradeLimit)
            {
                upgradeIndex++;

                if (upgradeIndex == UpgradeRequirements.Length)
                    break;

                upgradeLimit = UpgradeRequirements[upgradeIndex];
                downgradeLimit = UpgradeRequirements[upgradeIndex - 1];

                

            }

        }
    }


    void Downgrade(int totVal)
    {



        if (0 < upgradeIndex)
        {
            while(totVal < downgradeLimit)
            {
                if (upgradeIndex == 0)
                    break;
                
                upgradeIndex--;
                upgradeLimit = UpgradeRequirements[upgradeIndex];
                downgradeLimit = (upgradeIndex == 0) ? 0 : UpgradeRequirements[upgradeIndex];
            }
        }
    }


}
