using AutoMapper;
using Bookly.APIs.DTOs;
using Bookly.APIs.Entities;
using Bookly.APIs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.APIs.Controllers
{

    public class AuthorsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AuthorDto>>> GetAuthors()
        {
            var authors = await _unitOfWork.Repository<Author>().GetAllAsync();
            var mappedAuthors = _mapper.Map<IReadOnlyList<Author>, IReadOnlyList<AuthorDto>>(authors);
            return Ok(mappedAuthors);
        }


    }
}
