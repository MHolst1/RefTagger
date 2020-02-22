using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefTagger.Core.Models;
using RefTagger.Infrastructure.EF;

namespace RefTagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageTagsController : ControllerBase
    {
        private readonly DbContextOptions<RefTaggerContext> dbContextOptions;

        public ImageTagsController(DbContextOptions<RefTaggerContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImageTag>> Get(int pageSize = 100, int pageIndex = 1)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            return context.ImageTags
                          .Skip((pageIndex - 1) * pageSize)
                          .Take(pageSize)
                          .ToList();
        }

        [HttpGet]
        [Route("{fileName}")]
        public ActionResult<IEnumerable<ImageTag>> Get(string fileName, int pageSize = 100, int pageIndex = 1)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            return context.ImageTags
                          .Where(x => x.ImageFileName == fileName)
                          .Skip((pageIndex - 1) * pageSize)
                          .Take(pageSize)
                          .ToList();
        }

        [HttpPost]
        public ActionResult<ImageTag> Post(ImageTag imageReferenceTag)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            context.ImageTags.Add(imageReferenceTag);

            return imageReferenceTag;
        }

        [Route("id")]
        [HttpPut]
        public ActionResult<ImageTag> Put(int id, ImageTag imageReferenceTag)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            context.ImageTags.Update(imageReferenceTag);

            return imageReferenceTag;
        }

        [Route("id")]
        [HttpDelete]
        public ActionResult<bool> Delete(ImageTag imageReferenceTag)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            context.ImageTags.Remove(imageReferenceTag);

            return true;
        }
    }
}