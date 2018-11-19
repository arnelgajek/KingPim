using KingPim.Data;

namespace KingPim.Repositories.Repositories
{
    public class SubcategoryAttributeGroupRepository
    {
        private ApplicationDbContext _ctx;
        public SubcategoryAttributeGroupRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
    }
}
