// Create by Felix A. Bueno
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Data.Security.DataMapper
{
    public class MenuDataMapper : O7DbMapper<Menu>
    {
        public static Type Class => typeof(MenuDataMapper);

        public override Menu MapTarget()
            => new Menu
            {
                FatherId = Source.GetValue<string>(0),
                Id = Source.GetValue<string>(1),
                Title = Source.GetValue<string>(2),
                Observacion = Source.GetValue<string>(3),
                Folder = Source.GetValue<string>(4),
                Url = Source.GetValue<string>(5),
                Icon = Source.GetValue<string>(6)
            };
    }
}