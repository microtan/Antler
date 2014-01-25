﻿using SmartElk.Antler.Core.Abstractions.Configuration;
using SmartElk.Antler.Core.Domain;
using SmartElk.Antler.Core.Domain.Configuration;
using SmartElk.Antler.EntityFramework;

namespace SmartElk.Antler.Specs.Shared.EntityFramework.Configuration
{
    public static class ConfigurationEx
    {
        public static void ClearDatabase(this IAntlerConfigurator configurator, string storageName=null)
        {            
            ((ISessionScopeFactoryEx)configurator.Configuration.Container.GetWithNameOrDefault<ISessionScopeFactory>(storageName)).CreateDataContext().Clear();
        }        
    }
}
