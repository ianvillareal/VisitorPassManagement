using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visitor.Presentation
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
                    "Visitor.Presentation"
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