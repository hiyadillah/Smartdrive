using System.Runtime.InteropServices;

namespace Smartdrive.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        T FindById(dynamic id);
    }
}
