using AngularAndAdapter.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAdapter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IDataServices _DataServices;

        public HomeController(IDataServices DataServices)
        {
            _DataServices = DataServices;
        }

        //string to anything
        [HttpPost]
        [Route("StringToBase64")]
        public ActionResult StringToBase64(string str)
        {
            var result = _DataServices.StringToBase64(str);
            return Ok(result);
        }
        [HttpPost]
        [Route("StringToByte")]
        public ActionResult StringToByte(string str)
        {
            var result = _DataServices.StringToByte(str);
            return Ok(result);
        }
        [HttpPost]
        [Route("StringToHex")]
        public ActionResult StringToHex(string str)
        {
            var result = _DataServices.StringToHex(str);
            return Ok(result);
        }
        //convert to string
        [HttpPost]
        [Route("HexToString")]
        public ActionResult HexToString(string str)
        {
            var result = _DataServices.HexToString(str);
            return Ok(result);
        }
        [HttpPost]
        [Route("Base64ToString")]
        public ActionResult Base64ToString(string str)
        {
            var result = _DataServices.Base64ToString(str);
            return Ok(result);
        }
        [HttpPost]
        [Route("ByteToString")]
        public ActionResult ByteToString(string str)
        {
            var result = _DataServices.ByteToString(str);
            return Ok(result);
        }
        //Hex convert
        [HttpPost]
        [Route("HexToBase64")]
        public ActionResult HexToBase64(string str)
        {
            var result = _DataServices.HexToBase64(str);
            return Ok(result);
        }
        [HttpPost]
        [Route("HexToByte")]
        public ActionResult HexToByte(string str)
        {
            var result = _DataServices.HexToByte(str);
            return Ok(result);
        }
        //Base64 convert
        [HttpPost]
        [Route("Base64ToHex")]
        public ActionResult Base64ToHex(string str)
        {
            var result = _DataServices.Base64ToHex(str);
            return Ok(result);
        }
        [HttpPost]
        [Route("Base64ToByte")]
        public ActionResult Base64ToByte(string str)
        {
            var result = _DataServices.Base64ToByte(str);
            return Ok(result);
        }
        //Byte convert
        [HttpPost]
        [Route("ByteToHex")]
        public ActionResult ByteToHex(string str)
        {
            var result = _DataServices.ByteToHex(str);
            return Ok(result);
        }
        [HttpPost]
        [Route("ByteToBase64")]
        public ActionResult ByteToBase64(string str)
        {
            var result = _DataServices.ByteToBase64(str);
            return Ok(result);
        }
    }
}
