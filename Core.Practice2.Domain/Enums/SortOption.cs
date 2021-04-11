using System.ComponentModel;

namespace Core.Practice2.Domain.Enums
{
    public enum SortOption
    {
        [Description("Low to High Price")]
        Low,

        [Description("High to Low Price")]
        High,

        [Description("A - Z sort on the Name")]
        Ascending,

        [Description("Z - A sort on the Name")]
        Decending,

        [Description("Recommended")]
        Recommended
    }
}
