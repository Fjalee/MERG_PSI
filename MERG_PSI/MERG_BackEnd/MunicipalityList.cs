using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MERG_BackEnd
{
    public class MunicipalityList
    {
        
        public string Municipality { get; }
        public MunicipalityList( )
        {
        }
        public MunicipalityList(string municipality)
        {
            Municipality = municipality;
        }
        public async Task<ObservableCollection<MunicipalityList>> ListOfStore() //List of Countries  
        {
                var municipalityList =  new ObservableCollection<MunicipalityList>();
                municipalityList.Add(new MunicipalityList("Akmenės r. sav."));
                municipalityList.Add(new MunicipalityList("Alytaus m. sav."));
                municipalityList.Add(new MunicipalityList("Alytaus r. sav."));
                municipalityList.Add(new MunicipalityList("Anykščių r. sav."));
                municipalityList.Add(new MunicipalityList("Birštono sav."));
                municipalityList.Add(new MunicipalityList("Biržų r. sav."));
                municipalityList.Add(new MunicipalityList("Druskininkų sav."));
                municipalityList.Add(new MunicipalityList("Elektrėnų sav."));
                municipalityList.Add(new MunicipalityList("Ignalinos r. sav."));
                municipalityList.Add(new MunicipalityList("Jonavos r. sav."));
                municipalityList.Add(new MunicipalityList("Joniškio r. sav."));
                municipalityList.Add(new MunicipalityList("Jurbarko r. sav."));
                municipalityList.Add(new MunicipalityList("Kaišiadorių r. sav."));
                municipalityList.Add(new MunicipalityList("Kalvarijos sav."));
                municipalityList.Add(new MunicipalityList("Kauno m. sav."));
                municipalityList.Add(new MunicipalityList("Kauno r. sav."));
                municipalityList.Add(new MunicipalityList("Kazlų Rūdos sav."));
                municipalityList.Add(new MunicipalityList("Kėdainių r. sav."));
                municipalityList.Add(new MunicipalityList("Kelmės r. sav."));
                municipalityList.Add(new MunicipalityList("Klaipėdos m. sav."));
                municipalityList.Add(new MunicipalityList("Klaipėdos r. sav."));
                municipalityList.Add(new MunicipalityList("Kretingos r. sav."));
                municipalityList.Add(new MunicipalityList("Kupiškio r. sav."));
                municipalityList.Add(new MunicipalityList("Lazdijų r. sav."));
                municipalityList.Add(new MunicipalityList("Marijampolės sav."));
                municipalityList.Add(new MunicipalityList("Mažeikių r. sav."));
                municipalityList.Add(new MunicipalityList("Molėtų r. sav."));
                municipalityList.Add(new MunicipalityList("Neringos sav."));
                municipalityList.Add(new MunicipalityList("Pagėgių sav."));
                municipalityList.Add(new MunicipalityList("Pakruojo r. sav."));
                municipalityList.Add(new MunicipalityList("Palangos m. sav."));
                municipalityList.Add(new MunicipalityList("Panevėžio m. sav."));
                municipalityList.Add(new MunicipalityList("Panevėžio r. sav."));
                municipalityList.Add(new MunicipalityList("Pasvalio r. sav."));
                municipalityList.Add(new MunicipalityList("Plungės r. sav."));
                municipalityList.Add(new MunicipalityList("Prienų r. sav."));
                municipalityList.Add(new MunicipalityList("Radviliškio r. sav."));
                municipalityList.Add(new MunicipalityList("Raseinių r. sav."));
                municipalityList.Add(new MunicipalityList("Rietavo sav."));
                municipalityList.Add(new MunicipalityList("Rokiškio r. sav."));
                municipalityList.Add(new MunicipalityList("Skuodo r. sav."));
                municipalityList.Add(new MunicipalityList("Šakių r. sav."));
                municipalityList.Add(new MunicipalityList("Šalčininkų r. sav."));
                municipalityList.Add(new MunicipalityList("Šiaulių miesto sav."));
                municipalityList.Add(new MunicipalityList("Šiaulių r. sav."));
                municipalityList.Add(new MunicipalityList("Šilalės r. sav."));
                municipalityList.Add(new MunicipalityList("Šilutės r. sav."));
                municipalityList.Add(new MunicipalityList("Širvintų r. sav."));
                municipalityList.Add(new MunicipalityList("Švenčionių r. sav."));
                municipalityList.Add(new MunicipalityList("Tauragės r. sav."));
                municipalityList.Add(new MunicipalityList("Telšių r. sav."));
                municipalityList.Add(new MunicipalityList("Trakų r. sav."));
                municipalityList.Add(new MunicipalityList("Ukmergės r. sav."));
                municipalityList.Add(new MunicipalityList("Utenos r. sav."));
                municipalityList.Add(new MunicipalityList("Varėnos r. sav."));
                municipalityList.Add(new MunicipalityList("Vilkaviškio r. sav."));
                municipalityList.Add(new MunicipalityList("Vilniaus m. sav."));
                municipalityList.Add(new MunicipalityList("Vilniaus r. sav."));
                municipalityList.Add(new MunicipalityList("Visagino sav."));
                municipalityList.Add(new MunicipalityList("Zarasų r. sav."));

            return municipalityList;
        }
    }
}
