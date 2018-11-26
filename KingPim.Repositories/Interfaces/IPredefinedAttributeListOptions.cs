using KingPim.Models.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories.Interfaces
{
    public interface IPredefinedAttributeListOptions
    {
        IEnumerable<PredefinedAttrListOptions> GetAllOptions();

        void CreateOptionToPredefinedList(ProductViewModel vm);
        void AddOptionIfNotExists(ProductViewModel vm);
        void UpdateProductAttributeValue(ProductViewModel vm);
    }
}
