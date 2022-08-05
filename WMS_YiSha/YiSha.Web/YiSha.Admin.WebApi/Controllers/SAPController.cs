using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YiSha.Admin.WebApi.Filter;
using YiSha.Business.SystemManage;
using YiSha.Model.Param.SystemManage;
using YiSha.Model.Result.SystemManage;
using YiSha.Util.Model;

namespace YiSha.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class SAPController : ControllerBase
    { 

        #region 获取数据
        /// <summary>
        /// SAP数据接口测试
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public string PMCNA_API_GET_PART_DESC([FromQuery] string Meterial)
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            string s = string.Empty;
            try
            {
                dic = SAPFunction.PMCNA_API_GET_PART_DESC(Meterial);
            }
            catch (Exception ex)
            {
                dic.Add("Error", ex.Message);
            }
            finally
            { 
                foreach (string key in dic.Keys)
                {
                    s += key + "=" + dic[key] + ";";
                }
                 
            }

            return "Result:    " + s;
        }
        #endregion
    }
}