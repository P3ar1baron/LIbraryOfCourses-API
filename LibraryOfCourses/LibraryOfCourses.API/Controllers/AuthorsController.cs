﻿using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryOfCourses.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            return new JsonResult(authorsFromRepo);
        }

        [HttpGet("{authorId:guid}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            return new JsonResult(authorFromRepo);
        }
    }
}
