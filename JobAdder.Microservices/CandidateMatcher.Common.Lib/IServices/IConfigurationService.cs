using CandidateMatcher.Common.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateMatcher.Common.IServices
{
    public interface IConfigurationService
    {
        JobAdderApiConfiguration GetJobAdderApiConfiguration();
        ApplicationConfiguration GetApplicationConfiguration();
    }
}
