namespace SailClubLibrary.Helpers.Filter
{
    public static class FilterFunctions<T>
    {
        public static List<T> FilterList(List<T> toFilter, params Predicate<T>[] predicates)
        {
            for (int i = toFilter.Count - 1; i >= 0; i--)
            {
                foreach (Predicate<T> p in predicates)
                {
                    if (!p(toFilter[i]))
                    {
                        toFilter.RemoveAt(i);
                        break;
                    }
                }
            }
            return toFilter;
        }
    }
}
