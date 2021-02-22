using Cinematron.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematron.DAL.Contracts
{
    public interface ISearchService
    {
        List<IWatchable> Search(string query);
    }
}
