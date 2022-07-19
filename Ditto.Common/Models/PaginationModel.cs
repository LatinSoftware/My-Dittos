namespace Ditto.Common.Models;

public class PaginationModel<TModel>
{
    public PaginationModel(IEnumerable<TModel> Data, int totalCount)
    {
        this.TotalCount = totalCount;
        this.Results = Data;
    }
    public int TotalCount { get; set; }
    public IEnumerable<TModel> Results { get; set; }

}
