using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateMatcher.Common.IServices
{
    public interface IExternalApiService
    {
        T GetEntity<T>(string httpClientName, string query);
    }
}
