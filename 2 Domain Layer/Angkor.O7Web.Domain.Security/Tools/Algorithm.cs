// O7ERP Web created by felix_dev
using System.Collections.Generic;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Domain.Security.Tools
{
    public class Algorithm
    {
        public static List<O7Menu> SortMenus(List<Menu> menus, string menuId)
        {
            var result = new List<O7Menu>();
            foreach (var item in menus)
            {
                if (item.FatherId != menuId) continue;
                var node = new O7Menu(item.Id, item.Title, item.Observacion, item.Url, item.Icon, item.Folder);
                node.Menus = SortMenus(menus, node.Id);
                result.Add(node);
            }
            return result;
        }
    }    
}