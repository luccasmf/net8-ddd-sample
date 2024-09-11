namespace net8_ddd_sample.domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual Product[] Products { get; set; }
    }
}
