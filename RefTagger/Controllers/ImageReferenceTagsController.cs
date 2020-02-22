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
    public class ImageReferenceTagsController : ControllerBase
    {
        private readonly DbContextOptions<RefTaggerContext> dbContextOptions;

        public ImageReferenceTagsController(DbContextOptions<RefTaggerContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImageReferenceTag>> Get(int pageSize = 100, int pageIndex = 1)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            return context.ImageReferenceTags
                          .Skip((pageIndex - 1) * pageSize)
                          .Take(pageSize)
                          .ToList();
        }

        [HttpGet]
        [Route("{fileName}")]
        public ActionResult<IEnumerable<ImageReferenceTag>> Get(string fileName, int pageSize = 100, int pageIndex = 1)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            return context.ImageReferenceTags
                          .Where(x => x.ImageReference.FileName == fileName)
                          .Skip((pageIndex - 1) * pageSize)
                          .Take(pageSize)
                          .ToList();
        }

        [HttpPost]
        public ActionResult<ImageReferenceTag> Post(ImageReferenceTag imageReferenceTag)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            context.ImageReferenceTags.Add(imageReferenceTag);

            return imageReferenceTag;
        }

        [Route("id")]
        [HttpPut]
        public ActionResult<ImageReferenceTag> Put(int id, ImageReferenceTag imageReferenceTag)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            context.ImageReferenceTags.Update(imageReferenceTag);

            return imageReferenceTag;
        }

        [Route("id")]
        [HttpDelete]
        public ActionResult<bool> Delete(ImageReferenceTag imageReferenceTag)
        {
            using var context = new RefTaggerContext(dbContextOptions);

            context.ImageReferenceTags.Remove(imageReferenceTag);

            return true;
        }
    }
}