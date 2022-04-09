namespace FitnessTracker.Models.SupplementationPlans
{
    public class SupplPlanSupplementViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public bool IsChecked { get; set; }

    }
}
