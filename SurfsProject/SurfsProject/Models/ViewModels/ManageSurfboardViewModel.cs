namespace SurfsProject.Models.ViewModels
{
    public class ManageSurfboardViewModel
    {
        public PaginatedList<SurfboardViewModel> Surfboards { get; set; }

        public string SearchString { get; set; }
        public string TypeSearch { get; set; }
        public string EquipmentSearch { get; set; }

        public string SortOrder { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }

    }
}
