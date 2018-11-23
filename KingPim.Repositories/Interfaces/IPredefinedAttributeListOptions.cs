using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface IPredefinedAttributeListOptions
    {
        IEnumerable<PredefinedAttrListOptions> GetAllOptions();
    }
}
