namespace C868
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }

        public City(int cityId, string cityName, int countryId)
        {
            CityID = cityId;
            CityName = cityName;
            CountryID = countryId;
        }
    }
}