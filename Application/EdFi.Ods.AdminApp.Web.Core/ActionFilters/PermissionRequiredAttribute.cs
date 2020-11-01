// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.AdminApp.Management.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.AdminApp.Web.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionRequiredAttribute : TypeFilterAttribute
    {
        public PermissionRequiredAttribute(Permission permission)
            : base(typeof(PermissionRequiredFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}
