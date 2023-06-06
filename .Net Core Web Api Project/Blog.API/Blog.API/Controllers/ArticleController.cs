﻿using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleDal _articleDal;
        public ArticleController(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddArticle(ArticleDTO article)
        {
            return await _articleDal.AddArticle(article) ? StatusCode(StatusCodes.Status201Created)
                : StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
    }
}
