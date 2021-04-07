using Newtonsoft.Json;
using OnTrial.Logger;
using System;
using System.Net.Http;

namespace OnTrial.Api.Test
{
    public class TestItem
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public string ToJson() => JsonConvert.SerializeObject(this);
    }

    public class TestService
    {
        public ApiClient client;

        #region Constructor(s)

        public TestService(string pUrl)
        {
            this.client = new ApiClient(pUrl);
        }

        #endregion

        #region Operation(s)

        public HttpResponseMessage Get(int? pId)
        {
            try
            {
                if (pId is null)
                    throw new ArgumentNullException(nameof(pId));

                return client.SendRequestAsync(ApiMethod.Get, $"api/Todo/{pId}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        public HttpResponseMessage Create(TestItem pItem)
        {
            try
            {
                if (pItem is null)
                    throw new ArgumentNullException(nameof(pItem));

                return client.SendRequestAsync(ApiMethod.Post, $"api/Todo", pItem.ToJson());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        public HttpResponseMessage Update(int? pId, TestItem pItem)
        {
            try
            {
                if (pId is null)
                    throw new ArgumentNullException(nameof(pId));
                
                if (pItem is null)
                    throw new ArgumentNullException(nameof(pItem));

                return client.SendRequestAsync(ApiMethod.Put, $"api/Todo/{pId}", pItem.ToJson());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        public HttpResponseMessage Delete(int? pId)
        {
            try
            {
                if (pId is null)
                    throw new ArgumentNullException(nameof(pId));

                return client.SendRequestAsync(ApiMethod.Delete, $"api/Todo/{pId}");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        #endregion
    }
}
