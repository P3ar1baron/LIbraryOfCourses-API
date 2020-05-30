using AutoMapper;
using CourseLibrary.API.Services;
using LibraryOfCourses.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LibraryOfCourses.API.Controllers
{
    [ApiController]
    [Route("api/authorcollections")]
    public class AuthorCollectionsController
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorCollectionsController(ICourseLibraryRepository courseLibraryRepository,
            IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //array key: 1,2,3
        //composite key: key1=value1, key2=value2

        [HttpGet("({ids})")]
        public IActionResult GetAuthorCollection(
            [FromRoute] IEnumerable<Guid> ids)
        {

        }



        [HttpPost]
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthorCollection(
           IEnumerable<AuthorForCreationDto> authorCollection)
        {
            var authorEntities = _mapper.Map<IEnumerable<CourseLibrary.API.Entities.Author>>(authorCollection);

            foreach (var author in authorEntities)
            {
                _courseLibraryRepository.AddAuthor(author);
            }

            _courseLibraryRepository.Save();

            return Ok();
        }
    }
}
