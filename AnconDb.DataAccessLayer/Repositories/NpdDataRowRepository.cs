using AnconDb.DataAccessLayer.Entities;

namespace AnconDb.DataAccessLayer.Repositories
{
    public class NpdDataRowRepository : RepositoryBase<NpdDataRow>
    {
        public NpdDataRowRepository(NoisePowerDistanceDbContext context)
            : base(context)
        {
             
        }
    }
}
