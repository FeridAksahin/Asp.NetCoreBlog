﻿using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<HomePageArticleDTO>> GetArticleInformationForHomePage()
        {
            return await _articleDal.GetArticleForHomePage();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ArticlePostDTO> GetArticlePost(int id)
        {
            return await _articleDal.GetArticlePost(id);
        }

        [HttpGet("{email}")]
        public async Task<List<ArticleDTO>> AllAddedArticle(string email)
        {
            return await _articleDal.GetAllAdminArticle(email);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteArticleById(int id)
        {
            return await _articleDal.DeleteArticle(id);
        }
    }
}
