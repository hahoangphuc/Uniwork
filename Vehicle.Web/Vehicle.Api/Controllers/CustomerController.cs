using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vehicle.Bussiness.Models;
using Vehicle.Bussiness.Reposistory;
using Vehicle.Data;

namespace Vehicle.Api.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("")]
        public IHttpActionResult GetAllList(int Page = 1, int PageSize = 20)
        {
            var Total = 0;
            var ls = _unitOfWork.customerReposistory.GetAllList(Page, PageSize,ref Total);
            return Ok(new { data = ls, totalRecord = Total });
        }

        [Route("createupdate")]
        [HttpPost]
        public IHttpActionResult CreateUpdate(CustomerViewModel md)
        {
            var mdCustomer = Mapper.Map<CustomerViewModel, Customer>(md);
            var res = _unitOfWork.customerReposistory.CreateUpdate(mdCustomer);                   
            return Ok(res);
        }
    }
}
