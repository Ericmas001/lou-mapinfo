using System;
using System.Collections.Generic;
using System.Text;
using LouMapInfo.Entities;

namespace LouMapInfo.Entities.Filter
{
    public class Filters
    {
        private List<FilterType> m_Filters = new List<FilterType>();

        public List<FilterType> AllFilters
        {
            get { return m_Filters; }
            set { m_Filters = value; }
        }
        public Filters(params FilterType[] features)
        {
            m_Filters.AddRange(features);
        }
        public static FilterType Filter(CityType type)
        {
            if (type == CityType.City)
                return FilterType.TypeCity;
            else if (type == CityType.Castle)
                return FilterType.TypeCastle;
            else
                return FilterType.TypePalace;
        }
    }
}
