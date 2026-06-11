using UnityEngine;

public interface ICasinoGlobal 
{

    public  void TempName();
   


}

public class LowclassCasino : MonoBehaviour, ICasinoGlobal
{
    void ICasinoGlobal.TempName()
    {
        throw new System.NotImplementedException();
    }

    
}

