using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vehicle.Bussiness.Models;
using Vehicle.Bussiness.Reposistory;
using Vehicle.Data;
using Vehicle.Data.Infastractor;

namespace Vehicle.Api.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Route("")]
        public IHttpActionResult GetAllList(int Page = 1, int PageSize = 20)
        {
            var Total = 0;
            var ls = _unitOfWork.CategoryReposistory.GetAllList(Page, PageSize, ref Total);           
            return Ok(new { data = ls , totalRecord = Total});
        }

        [Route("createupdate")]
        [HttpPost]
        public IHttpActionResult CreateUpdate([FromBody]CategoryViewModel md)
        {
            var mdCate = Mapper.Map<CategoryViewModel, Category>(md);
            var res = _unitOfWork.CategoryReposistory.CreateUpdate(mdCate);
            return Ok(res);
        }

        [Route("delete")]
        [HttpDelete]
        public IHttpActionResult Delete(string lsItem)
        {
            var lsDelete = lsItem.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var res = _unitOfWork.CategoryReposistory.Delete(lsDelete);
            return Ok(res);
        }
    }
}