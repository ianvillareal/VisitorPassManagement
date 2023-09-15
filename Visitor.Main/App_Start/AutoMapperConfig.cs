using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visitor.Main
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.AddProfiles(new[]
                {
                    "Visitor.Service",
                    "Visitor.Main"
                });
                });

                //Mapper.AssertConfigurationIsValid();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw e;
            }
        }
    }
}