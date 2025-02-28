using AutoMapper;
using Bookly.APIs.DTOs;
using Bookly.APIs.Entities;
using Bookly.APIs.Interfaces;
using Bookly.APIs.Specifications;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var spec = new AuthorSpecifications(id);
            var author = await _unitOfWork.Repository<Author>().GetEntityWithSpecAsync(spec);

            return Ok(_mapper.Map<Author,AuthorDto>(author));
        }



        [HttpPost]
        public async Task<ActionResult<AuthorDto>> AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<AuthorDto, Author>(authorDto);
            await _unitOfWork.Repository<Author>().AddAsync(author);
            await _unitOfWork.Complete();
            return Ok(_mapper.Map<Author,AuthorDto>(author));
        }


        [HttpPut]
        public async Task<ActionResult<AuthorDto>> UpdateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<AuthorDto, Author>(authorDto);
            _unitOfWork.Repository<Author>().Update(author);
            await _unitOfWork.Complete();
            return Ok(author);
        }

        [HttpDelete]
        public async Task<ActionResult<DeletedMessageDto>> DeleteAuthor(int id)
        {
            var spec = new AuthorSpecifications(id);
            var author = await _unitOfWork.Repository<Author>().GetEntityWithSpecAsync(spec);
            _unitOfWork.Repository<Author>().Delete(author);
            await _unitOfWork.Complete();
            return Ok(new DeletedMessageDto("Author Deleted Successfully"));
        }



    }
}
