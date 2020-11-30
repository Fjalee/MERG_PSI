
using System.Collections.ObjectModel;


namespace MERG_BackEnd
{
    public interface IList
    {
        ObservableCollection<IList> GetList();
        string Address
        {
            get;
            set;
        }
    }
}
