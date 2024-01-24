

 
using PagedList;

namespace Clinic.Abstract;

 
    public interface IPaginationHelper<T>
    {
    IPagedList<T> Pagination<T>(IEnumerable<T> data, int pageNumber);
}
 
