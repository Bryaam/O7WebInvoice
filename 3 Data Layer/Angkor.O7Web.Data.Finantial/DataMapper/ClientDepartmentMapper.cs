﻿// O7ERP Web created by felix_dev
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class ClientDepartmentMapper : O7DbMapper<ClientDepartment>
    {
        public static Type Class => typeof(ClientDepartmentMapper);
        public override ClientDepartment MapTarget()
            => new ClientDepartment
            {
                Id = Source.GetValue<string>(0),
                Description = Source.GetValue<string>(1)
            };
    }
}